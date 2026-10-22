using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ElevatorApp
{
    /// <summary>
    /// Saves the elevator log in the Access database.
    /// The connection string is set in MainForm.cs (same style as Form1.cs).
    /// </summary>
    public class AccessElevatorLogger : IElevatorLogger
    {
        string connectionString;
        string databasePath;
        bool errorShown = false;

        public AccessElevatorLogger(string connectionString)
        {
            this.connectionString = connectionString;

            // full path of the database file (the connection string path is relative)
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder(connectionString);
            databasePath = Path.GetFullPath(builder.DataSource);

            try
            {
                if (!File.Exists(databasePath))
                    CreateDatabaseFile();   // file missing, make a new one

                CheckTable();
            }
            catch (Exception ex)
            {
                ShowError("Error opening the database", ex);
            }
        }

        // Makes an empty .accdb file (only used if ElevatorDB.accdb is missing)
        void CreateDatabaseFile()
        {
            Type? catalogType = Type.GetTypeFromProgID("ADOX.Catalog");
            if (catalogType == null)
                throw new Exception("ADOX is not installed, so the database file could not be created.");

            object? catalog = Activator.CreateInstance(catalogType);
            try
            {
                catalogType.InvokeMember("Create", BindingFlags.InvokeMethod, null, catalog,
                                         new object[] { connectionString });
            }
            finally
            {
                if (catalog != null)
                    Marshal.ReleaseComObject(catalog);
            }
        }

        // Makes the ElevatorLog table if the database file does not have it
        void CheckTable()
        {
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                try
                {
                    OleDbCommand check = new OleDbCommand("SELECT TOP 1 LogID FROM ElevatorLog", conn);
                    check.ExecuteScalar();
                }
                catch (OleDbException)
                {
                    string create = "CREATE TABLE ElevatorLog (LogID AUTOINCREMENT PRIMARY KEY, " +
                                    "LogTime DATETIME, FloorNumber INTEGER, EventDescription TEXT(255))";
                    OleDbCommand createCommand = new OleDbCommand(create, conn);
                    createCommand.ExecuteNonQuery();
                }
            }
        }

        public void Log(int floor, string description)
        {
            try
            {
                OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
                string query = "INSERT INTO ElevatorLog (LogTime, FloorNumber, EventDescription) VALUES (?, ?, ?)";

                OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);
                oleDbCommand.Parameters.Add("@LogTime", OleDbType.Date).Value = DateTime.Now;
                oleDbCommand.Parameters.Add("@FloorNumber", OleDbType.Integer).Value = floor;
                oleDbCommand.Parameters.Add("@EventDescription", OleDbType.VarWChar, 255).Value = description;

                oleDbConnection.Open();
                oleDbCommand.ExecuteNonQuery();
                oleDbConnection.Close();
            }
            catch (Exception ex)
            {
                ShowError("Error saving to the database", ex);
            }
        }

        public IList<LogEntry> GetAll()
        {
            List<LogEntry> entries = new List<LogEntry>();
            try
            {
                DataSet ds = new DataSet();
                string dbcommand = "SELECT LogTime, FloorNumber, EventDescription FROM ElevatorLog ORDER BY LogID";

                using (var conn = new OleDbConnection(connectionString))
                using (var comm = new OleDbCommand(dbcommand, conn))
                using (var adapter = new OleDbDataAdapter(comm))
                {
                    adapter.Fill(ds);
                }

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    LogEntry entry = new LogEntry();
                    entry.Time = Convert.ToDateTime(row["LogTime"]);
                    entry.Floor = Convert.ToInt32(row["FloorNumber"]);
                    entry.Description = Convert.ToString(row["EventDescription"]) ?? "";
                    entries.Add(entry);
                }
            }
            catch (Exception ex)
            {
                ShowError("Error reading the database", ex);
            }
            return entries;
        }

        // shows the real error text, but only once so the lift is not interrupted again and again
        void ShowError(string message, Exception ex)
        {
            if (!errorShown)
            {
                errorShown = true;
                MessageBox.Show(message + "\n\n" + ex.Message + "\n\nDatabase file:\n" + databasePath);
            }
        }
    }
}
