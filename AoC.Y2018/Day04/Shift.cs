using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;

namespace AoC.Y2018.Days
{
    public class Shift
    {
        public DateTime Date { get; set; }
        public int GuardId { get; set; }
        public int MinutesAsleep { get; set; }

        public List<ShiftDetail> ShiftDetails { get; set; }

        public Shift(Event e) : this(e.ShiftDate, e.Hour, e.Minute, e.GuardId)
        {
        }

        public Shift(DateTime date, int hour, int minute, int guardId)
        {
            this.ShiftDetails = new List<ShiftDetail>();
            this.GuardId = guardId;

            this.Date = date;
            var startMinute = hour == 23 ? 0 : minute;
            this.ShiftDetails.Add(new ShiftDetail(startMinute));

            if (minute != 0 && hour != 23)
            {
                this.ShiftDetails.Add(new ShiftDetail(0, GuardStatus.NotHere));
            }
        }
    }
}