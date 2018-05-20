

using System;

namespace EmployeeScheduler.Models
{
    public enum EventType
    {
        Event
    }
    public class Event
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public int OrderId { get; set; }
        public EventType EventType { get; set; }
    }
}