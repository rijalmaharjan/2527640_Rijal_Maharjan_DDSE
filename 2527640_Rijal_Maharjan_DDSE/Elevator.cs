using System;
using System.Collections.Generic;

namespace ElevatorApp
{
    public enum ElevatorState
    {
        Idle,           // stopped, doors closed
        Moving,
        DoorsOpening,
        DoorsOpen,
        DoorsClosing
    }

    // Delegates used to tell the form what is happening (Task 4)
    public delegate void PositionChangedHandler(double position);
    public delegate void DoorChangedHandler(double openness);
    public delegate void StatusChangedHandler(string message);

    /// <summary>
    /// The elevator logic. Position is 0.0 at floor 0 and 1.0 at floor 1.
    /// Steps: doors close -> move -> arrive -> doors open -> wait -> doors close.
    /// </summary>
    public class Elevator
    {
        public const int BottomFloor = 0;
        public const int TopFloor = 1;

        private System.Windows.Forms.Timer timer;
        private Queue<int> waiting = new Queue<int>();
        private int targetFloor;
        private int holdCount;

        public int CurrentFloor { get; private set; }
        public double Position { get; private set; }
        public double DoorOpenness { get; private set; }   // 0 = closed, 1 = open
        public int Direction { get; private set; }         // 1 = up, -1 = down, 0 = not moving
        public ElevatorState State { get; private set; }

        public event PositionChangedHandler PositionChanged;
        public event DoorChangedHandler DoorChanged;
        public event StatusChangedHandler StatusChanged;

        public Elevator()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            State = ElevatorState.Idle;
        }

        public bool IsMoving
        {
            get { return State == ElevatorState.Moving; }
        }

        // Called when any button is pressed
        public void GoTo(int floor)
        {
            if (floor < BottomFloor || floor > TopFloor)
                return;

            if (State == ElevatorState.Idle)
            {
                if (floor == CurrentFloor)
                    OpenDoors();
                else
                    StartMoving(floor);
            }
            else if (State == ElevatorState.DoorsOpen)
            {
                if (floor == CurrentFloor)
                    holdCount = 0;               // keep the doors open longer
                else
                    AddToWaiting(floor);
            }
            else if (State == ElevatorState.DoorsClosing && floor == CurrentFloor)
            {
                State = ElevatorState.DoorsOpening;   // open again
                Say("Doors opening again at floor " + CurrentFloor);
            }
            else if (floor != CurrentFloor || State == ElevatorState.Moving)
            {
                if (!(State == ElevatorState.Moving && floor == targetFloor))
                    AddToWaiting(floor);
            }
        }

        private void AddToWaiting(int floor)
        {
            if (!waiting.Contains(floor))
                waiting.Enqueue(floor);
        }

        private void StartMoving(int floor)
        {
            targetFloor = floor;
            Direction = floor > CurrentFloor ? 1 : -1;
            State = ElevatorState.Moving;
            Say("Elevator leaving floor " + CurrentFloor + " for floor " + floor);
            timer.Start();
        }

        private void OpenDoors()
        {
            State = ElevatorState.DoorsOpening;
            Say("Doors opening at floor " + CurrentFloor);
            timer.Start();
        }

        private void Say(string message)
        {
            if (StatusChanged != null)
                StatusChanged(message);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (State == ElevatorState.Moving)
                MoveStep();
            else if (State == ElevatorState.DoorsOpening)
                OpenStep();
            else if (State == ElevatorState.DoorsOpen)
                WaitStep();
            else if (State == ElevatorState.DoorsClosing)
                CloseStep();
        }

        private void MoveStep()
        {
            Position += Direction * 0.012;

            bool arrived = (Direction > 0 && Position >= targetFloor) ||
                           (Direction < 0 && Position <= targetFloor);
            if (arrived)
                Position = targetFloor;

            if (PositionChanged != null)
                PositionChanged(Position);

            if (arrived)
            {
                CurrentFloor = targetFloor;
                Direction = 0;
                State = ElevatorState.DoorsOpening;
                Say("Elevator arrived at floor " + CurrentFloor);
            }
        }

        private void OpenStep()
        {
            DoorOpenness = Math.Min(1.0, DoorOpenness + 0.04);
            if (DoorChanged != null)
                DoorChanged(DoorOpenness);

            if (DoorOpenness >= 1.0)
            {
                holdCount = 0;
                State = ElevatorState.DoorsOpen;
                Say("Doors opened at floor " + CurrentFloor);
            }
        }

        private void WaitStep()
        {
            holdCount++;
            if (holdCount >= 75)   // about 1.5 seconds
            {
                State = ElevatorState.DoorsClosing;
                Say("Doors closing at floor " + CurrentFloor);
            }
        }

        private void CloseStep()
        {
            DoorOpenness = Math.Max(0.0, DoorOpenness - 0.04);
            if (DoorChanged != null)
                DoorChanged(DoorOpenness);

            if (DoorOpenness <= 0.0)
            {
                State = ElevatorState.Idle;
                timer.Stop();
                Say("Doors closed at floor " + CurrentFloor);

                // go to the next waiting floor, if any
                if (waiting.Count > 0)
                {
                    int next = waiting.Dequeue();
                    if (next == CurrentFloor)
                        OpenDoors();
                    else
                        StartMoving(next);
                }
            }
        }
    }
}
