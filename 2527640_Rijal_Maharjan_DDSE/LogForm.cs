using System.Collections.Generic;
using System.Windows.Forms;

namespace ElevatorApp
{
    /// <summary>Displays the elevator's historical operation records.</summary>
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        public void LoadEntries(IList<LogEntry> entries)
        {
            logList.Items.Clear();
            foreach (LogEntry entry in entries)
            {
                ListViewItem item = new ListViewItem(entry.Time.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SubItems.Add(entry.Floor.ToString());
                item.SubItems.Add(entry.Description);
                logList.Items.Add(item);
            }
        }
    }
}
