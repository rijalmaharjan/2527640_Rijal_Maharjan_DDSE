using System;
using System.Collections.Generic;

namespace ElevatorApp
{
    public class LogEntry
    {
        public DateTime Time { get; set; }
        public int Floor { get; set; }
        public string Description { get; set; }
    }

    public interface IElevatorLogger
    {
        void Log(int floor, string description);
        IList<LogEntry> GetAll();
    }

    public class InMemoryElevatorLogger : IElevatorLogger
    {
        private readonly List<LogEntry> _entries = new List<LogEntry>();

        public void Log(int floor, string description)
        {
            _entries.Add(new LogEntry
            {
                Time = DateTime.Now,
                Floor = floor,
                Description = description
            });
        }

        public IList<LogEntry> GetAll()
        {
            return new List<LogEntry>(_entries);
        }
    }
}
