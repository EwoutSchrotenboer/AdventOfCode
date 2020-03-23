using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day22 : BaseDay
    {
        public Day22() : base(2017, 22)
        {
        }

        public Day22(IEnumerable<string> inputLines) : base(2017, 22, inputLines)
        {
        }

        protected override IConvertible PartOne() => MoveVirusCarrier(ParseInput(inputLines), 10_000, false);

        protected override IConvertible PartTwo() => MoveVirusCarrier(ParseInput(inputLines), 10_000_000, true);

        private static ((int x, int y) start, Direction startDirection, Dictionary<(int x, int y), InfectionState> coordinates) ParseInput(IEnumerable<string> inputLines)
        {
            var lines = inputLines.ToList();
            var coordinates = new Dictionary<(int x, int y), InfectionState>();
            var size = lines.Count();

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (lines[y][x] == '#')
                    {
                        coordinates.Add((x, y), InfectionState.Infected);
                    }
                }
            }

            return ((size / 2, size / 2), Direction.Up, coordinates);
        }

        private Direction GetCarrierDirection(Direction current, InfectionState state) =>
            state switch
            {
                InfectionState.Clean => current.TurnTo(Turn.Left),
                InfectionState.Weakened => current,
                InfectionState.Infected => current.TurnTo(Turn.Right),
                InfectionState.Flagged => current.Reverse(),
                _ => throw new Exception($"Invalid infectionstate ({state})")
            };

        private InfectionState GetNextState(InfectionState current, bool partTwo) =>
            (partTwo, current) switch
            {
                (false, InfectionState.Clean) => InfectionState.Infected,
                (false, InfectionState.Infected) => InfectionState.Clean,
                (true, InfectionState.Clean) => InfectionState.Weakened,
                (true, InfectionState.Weakened) => InfectionState.Infected,
                (true, InfectionState.Infected) => InfectionState.Flagged,
                (true, InfectionState.Flagged) => InfectionState.Clean,
                (_, _) => throw new Exception($"Invalid state ({current}) or part ({partTwo})")
            };

        private int MoveVirusCarrier(((int x, int y) start, Direction startDirection, Dictionary<(int x, int y), InfectionState> coordinates) initial, int cycles, bool partTwo)
        {
            var (current, currentDirection, coordinates) = initial;
            var state = InfectionState.Clean;
            var infectionCount = 0;

            for (int i = 0; i < cycles; i++)
            {
                (current, currentDirection, state) = VirusCarrierBurst(coordinates, current, currentDirection, partTwo);
                infectionCount += state == InfectionState.Infected ? 1 : 0;
            }

            return infectionCount;
        }

        private (int, int) NextPos((int x, int y) current, Direction next) =>
            next switch
            {
                Direction.Up => (current.x, current.y - 1),
                Direction.Right => (current.x + 1, current.y),
                Direction.Down => (current.x, current.y + 1),
                Direction.Left => (current.x - 1, current.y),
                _ => throw new Exception($"Invalid direction ({next})")
            };

        private ((int, int) next, Direction nextDirection, InfectionState infected) VirusCarrierBurst(Dictionary<(int x, int y), InfectionState> coordinates, (int x, int y) current, Direction currentDirection, bool partTwo)
        {
            if (!coordinates.TryGetValue(current, out var state))
            {
                state = InfectionState.Clean;
            }

            var nextDirection = GetCarrierDirection(currentDirection, state);
            var nextState = GetNextState(state, partTwo);

            if (nextState == InfectionState.Clean)
            {
                coordinates.Remove(current);
            }
            else
            {
                coordinates[current] = nextState;
            }

            var next = NextPos(current, nextDirection);
            return (next, nextDirection, nextState);
        }
    }
}
