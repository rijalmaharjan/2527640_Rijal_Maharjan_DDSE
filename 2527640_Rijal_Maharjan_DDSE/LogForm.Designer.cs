namespace ElevatorApp
{
    partial class LogForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.logList = new System.Windows.Forms.ListView();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.colFloor = new System.Windows.Forms.ColumnHeader();
            this.colEvent = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // logList
            // 
            this.logList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colFloor,
            this.colEvent});
            this.logList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logList.FullRowSelect = true;
            this.logList.GridLines = true;
            this.logList.Location = new System.Drawing.Point(0, 0);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(580, 360);
            this.logList.TabIndex = 0;
            this.logList.UseCompatibleStateImageBehavior = false;
            this.logList.View = System.Windows.Forms.View.Details;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 150;
            // 
            // colFloor
            // 
            this.colFloor.Text = "Floor";
            this.colFloor.Width = 60;
            // 
            // colEvent
            // 
            this.colEvent.Text = "Event";
            this.colEvent.Width = 340;
            // 
            // LogForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(580, 360);
            this.Controls.Add(this.logList);
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Elevator Log";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView logList;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colFloor;
        private System.Windows.Forms.ColumnHeader colEvent;
    }
}
