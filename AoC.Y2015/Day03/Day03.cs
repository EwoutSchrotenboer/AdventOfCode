using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day03 : BaseDay
    {
        public Day03() : base(2015, 3)
        {
        }

        public Day03(IEnumerable<string> inputLines) : base(2015, 3, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var input = inputLines.First();
            return FollowRoute(input, false).Count();
        }

        protected override IConvertible PartTwo()
        {
            var input = inputLines.First();
            return FollowRoute(input, true).Count();
        }

        private static HashSet<AoCPoint> FollowRoute(IEnumerable<char> directions, bool useRoboSanta)
        {
            var visitedHouses = new HashSet<AoCPoint>();
            var directionQueue = new Queue<char>(directions);

            var santaPosition = AoCPoint.Origin();
            var roboSantaPosition = AoCPoint.Origin();
            visitedHouses.Add(santaPosition);

            var roboSantaTurn = false;

            while (directionQueue.Any())
            {
                var d = directionQueue.Dequeue();

                if (useRoboSanta && roboSantaTurn) { roboSantaPosition = VisitHouse(visitedHouses, roboSantaPosition, d); }
                else { santaPosition = VisitHouse(visitedHouses, santaPosition, d); }
                roboSantaTurn = !roboSantaTurn;
            }

            return visitedHouses;
        }

        private static AoCPoint VisitHouse(HashSet<AoCPoint> visited, AoCPoint santaLocation, char d)
        {
            var currentLocation = santaLocation.MoveTo(d.GetDirection());
            if (!visited.Contains(currentLocation)) { visited.Add(currentLocation); }
            return currentLocation;
        }
    }
}
