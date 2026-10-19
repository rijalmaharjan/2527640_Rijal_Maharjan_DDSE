namespace ElevatorApp
{
    partial class MainForm
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
            grpControlPanel = new GroupBox();
            lblDisplay = new Label();
            lblDoorStatus = new Label();
            btnPanel1 = new Button();
            btnPanel0 = new Button();
            pnlShaft = new Panel();
            lblLine1 = new Label();
            lblLine0 = new Label();
            pnlCar = new Panel();
            pnlDoorLeft = new Panel();
            pnlDoorRight = new Panel();
            btnRequest1 = new Button();
            btnRequest0 = new Button();
            lblFloor1 = new Label();
            lblFloor0 = new Label();
            btnLog = new Button();
            grpControlPanel.SuspendLayout();
            pnlShaft.SuspendLayout();
            pnlCar.SuspendLayout();
            SuspendLayout();
            // 
            // grpControlPanel
            // 
            grpControlPanel.Controls.Add(lblDisplay);
            grpControlPanel.Controls.Add(lblDoorStatus);
            grpControlPanel.Controls.Add(btnPanel1);
            grpControlPanel.Controls.Add(btnPanel0);
            grpControlPanel.Location = new Point(20, 40);
            grpControlPanel.Name = "grpControlPanel";
            grpControlPanel.Size = new Size(130, 190);
            grpControlPanel.TabIndex = 0;
            grpControlPanel.TabStop = false;
            grpControlPanel.Text = "Control panel";
            // 
            // lblDisplay
            // 
            lblDisplay.BorderStyle = BorderStyle.Fixed3D;
            lblDisplay.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblDisplay.Location = new Point(10, 23);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(108, 50);
            lblDisplay.TabIndex = 0;
            lblDisplay.Text = "0";
            lblDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDoorStatus
            // 
            lblDoorStatus.Location = new Point(10, 82);
            lblDoorStatus.Name = "lblDoorStatus";
            lblDoorStatus.Size = new Size(110, 18);
            lblDoorStatus.TabIndex = 1;
            lblDoorStatus.Text = "Doors closed";
            lblDoorStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPanel1
            // 
            btnPanel1.Location = new Point(20, 110);
            btnPanel1.Name = "btnPanel1";
            btnPanel1.Size = new Size(90, 30);
            btnPanel1.TabIndex = 2;
            btnPanel1.Text = "Floor 1";
            btnPanel1.UseVisualStyleBackColor = true;
            btnPanel1.Click += btnPanel1_Click;
            // 
            // btnPanel0
            // 
            btnPanel0.Location = new Point(20, 150);
            btnPanel0.Name = "btnPanel0";
            btnPanel0.Size = new Size(90, 30);
            btnPanel0.TabIndex = 3;
            btnPanel0.Text = "Floor 0";
            btnPanel0.UseVisualStyleBackColor = true;
            btnPanel0.Click += btnPanel0_Click;
            // 
            // pnlShaft
            // 
            pnlShaft.BorderStyle = BorderStyle.FixedSingle;
            pnlShaft.Controls.Add(lblLine1);
            pnlShaft.Controls.Add(lblLine0);
            pnlShaft.Controls.Add(pnlCar);
            pnlShaft.Location = new Point(300, 40);
            pnlShaft.Name = "pnlShaft";
            pnlShaft.Size = new Size(200, 400);
            pnlShaft.TabIndex = 1;
            // 
            // lblLine1
            // 
            lblLine1.BorderStyle = BorderStyle.Fixed3D;
            lblLine1.Location = new Point(0, 170);
            lblLine1.Name = "lblLine1";
            lblLine1.Size = new Size(198, 2);
            lblLine1.TabIndex = 0;
            // 
            // lblLine0
            // 
            lblLine0.BorderStyle = BorderStyle.Fixed3D;
            lblLine0.Location = new Point(0, 380);
            lblLine0.Name = "lblLine0";
            lblLine0.Size = new Size(198, 2);
            lblLine0.TabIndex = 1;
            // 
            // pnlCar
            // 
            pnlCar.BorderStyle = BorderStyle.FixedSingle;
            pnlCar.Controls.Add(pnlDoorLeft);
            pnlCar.Controls.Add(pnlDoorRight);
            pnlCar.Location = new Point(40, 230);
            pnlCar.Name = "pnlCar";
            pnlCar.Size = new Size(120, 150);
            pnlCar.TabIndex = 2;
            // 
            // pnlDoorLeft
            // 
            pnlDoorLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlDoorLeft.Location = new Point(5, 5);
            pnlDoorLeft.Name = "pnlDoorLeft";
            pnlDoorLeft.Size = new Size(55, 138);
            pnlDoorLeft.TabIndex = 0;
            // 
            // pnlDoorRight
            // 
            pnlDoorRight.BorderStyle = BorderStyle.FixedSingle;
            pnlDoorRight.Location = new Point(60, 5);
            pnlDoorRight.Name = "pnlDoorRight";
            pnlDoorRight.Size = new Size(55, 138);
            pnlDoorRight.TabIndex = 1;
            // 
            // btnRequest1
            // 
            btnRequest1.Location = new Point(170, 115);
            btnRequest1.Name = "btnRequest1";
            btnRequest1.Size = new Size(110, 40);
            btnRequest1.TabIndex = 2;
            btnRequest1.Text = "Request Floor 1";
            btnRequest1.UseVisualStyleBackColor = true;
            btnRequest1.Click += btnRequest1_Click;
            // 
            // btnRequest0
            // 
            btnRequest0.Location = new Point(170, 325);
            btnRequest0.Name = "btnRequest0";
            btnRequest0.Size = new Size(110, 40);
            btnRequest0.TabIndex = 3;
            btnRequest0.Text = "Request Floor 0";
            btnRequest0.UseVisualStyleBackColor = true;
            btnRequest0.Click += btnRequest0_Click;
            // 
            // lblFloor1
            // 
            lblFloor1.BorderStyle = BorderStyle.FixedSingle;
            lblFloor1.Location = new Point(520, 115);
            lblFloor1.Name = "lblFloor1";
            lblFloor1.Size = new Size(220, 40);
            lblFloor1.TabIndex = 4;
            lblFloor1.Text = "Floor 1";
            lblFloor1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFloor0
            // 
            lblFloor0.BorderStyle = BorderStyle.FixedSingle;
            lblFloor0.Location = new Point(520, 325);
            lblFloor0.Name = "lblFloor0";
            lblFloor0.Size = new Size(220, 40);
            lblFloor0.TabIndex = 5;
            lblFloor0.Text = "Floor 0";
            lblFloor0.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLog
            // 
            btnLog.Location = new Point(20, 250);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(130, 35);
            btnLog.TabIndex = 6;
            btnLog.Text = "Log";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += btnLog_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(760, 470);
            Controls.Add(btnLog);
            Controls.Add(lblFloor0);
            Controls.Add(lblFloor1);
            Controls.Add(btnRequest0);
            Controls.Add(btnRequest1);
            Controls.Add(pnlShaft);
            Controls.Add(grpControlPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Elevator";
            grpControlPanel.ResumeLayout(false);
            pnlShaft.ResumeLayout(false);
            pnlCar.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpControlPanel;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblDoorStatus;
        private System.Windows.Forms.Button btnPanel1;
        private System.Windows.Forms.Button btnPanel0;
        private System.Windows.Forms.Panel pnlShaft;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label lblLine0;
        private System.Windows.Forms.Panel pnlCar;
        private System.Windows.Forms.Panel pnlDoorLeft;
        private System.Windows.Forms.Panel pnlDoorRight;
        private System.Windows.Forms.Button btnRequest1;
        private System.Windows.Forms.Button btnRequest0;
        private System.Windows.Forms.Label lblFloor1;
        private System.Windows.Forms.Label lblFloor0;
        private System.Windows.Forms.Button btnLog;
    }
}
