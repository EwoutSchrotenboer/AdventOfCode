using AoC.Helpers.Utils;
using MoreLinq;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Guard
    {
        public int Id { get; set; }
        public int LikelyMinute { get; set; }
        public int LikelyMinuteSleepCount { get; set; }
        public List<Shift> Shifts { get; set; }
        public int TotalMinutesAsleep { get; set; }

        public Guard(int id)
        {
            this.Id = id;
            this.Shifts = new List<Shift>();
        }

        public void UpdateCalculations()
        {
            this.TotalMinutesAsleep = this.Shifts.Sum(s => s.MinutesAsleep);
            (int minute, int amount) = this.GetLikelyMinute();
            this.LikelyMinute = minute;
            this.LikelyMinuteSleepCount = amount;
        }

        private (int minute, int amount) GetLikelyMinute()
        {
            var minuteGroups = this.Shifts.SelectMany(s => s.ShiftDetails).GroupBy(sd => sd.Minute);

            var orderedGroups = minuteGroups.OrderByDescending(sd => sd.Where(s => s.Status == GuardStatus.Asleep).Count());

            return (orderedGroups.First().Key, orderedGroups.First().Count(s => s.Status == GuardStatus.Asleep));
        }
    }
}