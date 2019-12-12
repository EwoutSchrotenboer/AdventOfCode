using AoC.Helpers.Utils;
using System;

namespace AoC.Y2018.Days
{
    public class Event
    {
        public DateTime ShiftDate { get; set; }
        public DateTime Date { get; set; }
        public EventType EventType { get; set; }
        public int GuardId { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        public Event(string eventLine)
        {
            var datePart = eventLine.Substring(1, 10);
            var timePart = eventLine.Substring(12, 5).Split(':');
            var hourPart = timePart[0];
            var minutePart = timePart[1];

            this.Date = DateTime.Parse(datePart);
            this.Hour = int.Parse(hourPart);
            this.Minute = int.Parse(minutePart);

            this.ShiftDate = this.Hour == 23 ? this.Date.AddDays(1) : this.Date;

            var eventPart = eventLine.Substring(19);

            if (eventPart.StartsWith("Guard"))
            {
                var splitEvent = eventPart.Split(' ');
                var guardIdString = splitEvent[1];
                var cleanedId = guardIdString.RemoveChar('#');

                this.GuardId = int.Parse(cleanedId);
                this.EventType = EventType.BeginsShift;

            }
            else if (eventPart.StartsWith("falls"))
            {
                this.EventType = EventType.FallsAsleep;
            }
            else
            {
                this.EventType = EventType.WakesUp;
            }
        }
    }
}