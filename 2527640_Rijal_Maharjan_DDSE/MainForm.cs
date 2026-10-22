using System;
using System.Windows.Forms;

namespace ElevatorApp
{
    public partial class MainForm : Form
    {
        private Elevator elevator = new Elevator();
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ElevatorDB.accdb;";
        private IElevatorLogger logger;

        // Y positions of the elevator panel inside the shaft
        private const int Floor1Y = 20;
        private const int Floor0Y = 230;
        private const int DoorWidth = 55;

        public MainForm()
        {
            InitializeComponent();
            logger = new AccessElevatorLogger(connectionString);

            // delegates / events from the elevator
            elevator.PositionChanged += ElevatorPositionChanged;
            elevator.DoorChanged += ElevatorDoorChanged;
            elevator.StatusChanged += ElevatorStatusChanged;

            SetDoors(0);
            UpdateDisplays();
            logger.Log(elevator.CurrentFloor, "Elevator system started");
        }

        // ---------- Task 2: button events ----------
        private void btnRequest1_Click(object sender, EventArgs e)
        {
            PressButton(1, "Request button");
        }

        private void btnRequest0_Click(object sender, EventArgs e)
        {
            PressButton(0, "Request button");
        }

        private void btnPanel1_Click(object sender, EventArgs e)
        {
            PressButton(1, "Control panel button");
        }

        private void btnPanel0_Click(object sender, EventArgs e)
        {
            PressButton(0, "Control panel button");
        }

        private void PressButton(int floor, string buttonName)
        {
            logger.Log(floor, buttonName + " pressed for floor " + floor);
            elevator.GoTo(floor);
            UpdateDisplays();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            LogForm form = new LogForm();
            form.LoadEntries(logger.GetAll());
            form.ShowDialog();
        }

        // ---------- Task 4: animation using delegates and the timer ----------
        private void ElevatorPositionChanged(double position)
        {
            pnlCar.Top = Floor0Y - (int)(position * (Floor0Y - Floor1Y));
        }

        private void ElevatorDoorChanged(double openness)
        {
            SetDoors(openness);
        }

        private void ElevatorStatusChanged(string message)
        {
            logger.Log(elevator.CurrentFloor, message);
            UpdateDisplays();
        }

        // Doors slide towards the sides when they open
        private void SetDoors(double openness)
        {
            int width = (int)(DoorWidth * (1 - openness));
            pnlDoorLeft.Width = width;
            pnlDoorRight.Width = width;
            pnlDoorRight.Left = 115 - width;
        }

        // Updates the control panel display, the door label and both floor status displays
        private void UpdateDisplays()
        {
            if (elevator.IsMoving)
            {
                lblDisplay.Text = elevator.Direction > 0 ? "Up" : "Down";
                lblDoorStatus.Text = "Moving";
            }
            else
            {
                lblDisplay.Text = elevator.CurrentFloor.ToString();

                if (elevator.State == ElevatorState.Idle)
                    lblDoorStatus.Text = "Doors closed";
                else if (elevator.State == ElevatorState.DoorsOpening)
                    lblDoorStatus.Text = "Doors opening";
                else if (elevator.State == ElevatorState.DoorsOpen)
                    lblDoorStatus.Text = "Doors open";
                else
                    lblDoorStatus.Text = "Doors closing";
            }

            lblFloor1.Text = GetFloorText(1);
            lblFloor0.Text = GetFloorText(0);
        }

        private string GetFloorText(int floor)
        {
            if (elevator.IsMoving)
                return "Floor " + floor + ": elevator moving";
            if (elevator.CurrentFloor == floor)
                return "Floor " + floor + ": elevator is here";
            return "Floor " + floor + ": elevator at floor " + elevator.CurrentFloor;
        }
    }
}
