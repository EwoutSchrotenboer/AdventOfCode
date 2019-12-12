using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day04 : BaseDay
    {
        public Day04() : base(2018, 4) { }

        public Day04(IEnumerable<string> inputLines) : base(2018, 4, inputLines) { }

        public List<Event> GetEvents()
        {
            var events = new List<Event>();

            foreach (var inputLine in this.inputLines)
            {
                events.Add(new Event(inputLine));
            }

            return events.OrderBy(e => e.Date).ThenBy(e => e.Minute).ToList();
        }

        public List<Guard> GetGuards(List<Shift> shifts)
        {
            var guards = new List<Guard>();

            foreach (var shiftGroup in shifts.GroupBy(s => s.GuardId))
            {
                var guard = new Guard(shiftGroup.Key)
                {
                    Shifts = shiftGroup.Select(g => g).ToList()
                };

                guard.UpdateCalculations();
                guards.Add(guard);
            }

            return guards;
        }

        public List<Shift> GetShifts(List<Event> events)
        {
            var shifts = new List<Shift>();

            foreach (var ge in events.GroupBy(e => e.ShiftDate))
            {
                var shiftStartEvent = ge.First();
                var shift = new Shift(shiftStartEvent);

                foreach (var shiftEvent in ge.Where(e => e != shiftStartEvent))
                {
                    var shiftDetail = shift.ShiftDetails.SingleOrDefault(sd => sd.Minute == shiftEvent.Minute);

                    if (shiftDetail != null)
                    {
                        shiftDetail.UpdateStatus(shiftEvent.EventType);
                    }
                    else
                    {
                        shift.ShiftDetails.Add(new ShiftDetail(shiftEvent));
                    }
                }
                shift = this.UpdateShiftDetails(shift);
                shift.ShiftDetails = shift.ShiftDetails.OrderBy(s => s.Minute).ToList();
                shifts.Add(shift);
            }

            return shifts;
        }

        public Shift UpdateShiftDetails(Shift shift)
        {
            ShiftDetail previousDetail = shift.ShiftDetails.Single(sd => sd.Minute == 0);

            for (int i = 1; i < 60; i++)
            {
                var currentDetail = shift.ShiftDetails.SingleOrDefault(sd => sd.Minute == i);

                if (currentDetail == null)
                {
                    currentDetail = new ShiftDetail(i, previousDetail.Status);
                    shift.ShiftDetails.Add(currentDetail);
                }

                previousDetail = currentDetail;
            }

            shift.MinutesAsleep = shift.ShiftDetails.Count(sd => sd.Status == GuardStatus.Asleep);

            return shift;
        }

        protected override IConvertible PartOne()
        {
            var events = this.GetEvents();
            var shifts = this.GetShifts(events);
            var guards = this.GetGuards(shifts);
            var mostAsleepGuard = guards.OrderByDescending(g => g.TotalMinutesAsleep).First();
            var likelyMinute = mostAsleepGuard.LikelyMinute;

            return mostAsleepGuard.Id * likelyMinute;
        }

        protected override IConvertible PartTwo()
        {
            var events = this.GetEvents();
            var shifts = this.GetShifts(events);
            var guards = this.GetGuards(shifts);
            var mostAsleepGuard = guards.OrderByDescending(g => g.LikelyMinuteSleepCount).First();
            var likelyMinute = mostAsleepGuard.LikelyMinute;

            return mostAsleepGuard.Id * likelyMinute;
        }
    }
}