using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AoC.Y2019.Days
{
    public class Day18 : BaseDay
    {
        private readonly HashSet<VaultState> states = new HashSet<VaultState>();
        private readonly Dictionary<AoCPoint, List<VaultKey>> inReach = new Dictionary<AoCPoint, List<VaultKey>>();
        private readonly Dictionary<char, AoCPoint> keys = new Dictionary<char, AoCPoint>();
        private readonly Dictionary<char, AoCPoint> doors = new Dictionary<char, AoCPoint>();
        private readonly HashSet<AoCPoint> accessible = new HashSet<AoCPoint>();
        private readonly Dictionary<AoCPoint, char> replicantPositions = new Dictionary<AoCPoint, char>();

        public Day18() : base(2019, 18)
        {
        }

        public Day18(IEnumerable<string> inputLines) : base(2019, 18, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            ParseInput(inputLines.ToList(), false);

            inReach[replicantPositions.Single().Key] = FindKeysInReach(replicantPositions.Single().Key);

            foreach (var k in keys)
            {
                inReach[k.Value] = FindKeysInReach(k.Value);
            }

            return GetKeysInReach(inReach, keys, replicantPositions.Values.ToArray());
        }

        protected override IConvertible PartTwo()
        {
            ParseInput(inputLines.ToList(), true);

            for (var i = '1'; i <= '4'; i++)
            {
                inReach[replicantPositions.Single(r => r.Value == i).Key] = FindKeysInReach(replicantPositions.Single(r => r.Value == i).Key);
            }

            foreach (var k in keys)
            {
                inReach[k.Value] = FindKeysInReach(k.Value);
            }

            return GetKeysInReach(inReach, keys, replicantPositions.Values.ToArray());
        }

        private int GetKeysInReach(Dictionary<AoCPoint, List<VaultKey>> paths, Dictionary<char, AoCPoint> keys, char[] replicants)
        {
            var positions = replicantPositions.Where(r => replicants.Contains(r.Value)).Select(r => r.Key).ToArray();
            var currentMinimumSteps = int.MaxValue;

            var startingSquad = new ReplicantPositions();

            for (var i = 0; i < positions.Length; i++)
            {
                var replicant = positions[i];
                startingSquad[i + 1] = replicant;
            }

            var stateQueue = new Queue<VaultState>(new VaultState[] { new VaultState { Replicants = startingSquad, Keys = 0 } });
            var visited = new Dictionary<(ReplicantPositions, int), int>();
            var targetKeyAmount = 0;

            // Set key target
            for (var i = 0; i < keys.Count; ++i) { targetKeyAmount |= (int)Math.Pow(2, i); }

            while (stateQueue.Any())
            {
                var currentState = stateQueue.Dequeue();
                var value = (currentState.Replicants, currentState.Keys);

                if (visited.TryGetValue(value, out var steps))
                {
                    if (steps <= currentState.Steps) { continue; }

                    // update with lower stepcount, performance-wise this helps (Thanks internet!)
                    visited[value] = currentState.Steps;
                }
                else
                {
                    visited.Add(value, currentState.Steps);
                }

                if (currentState.Keys == targetKeyAmount)
                {
                    currentMinimumSteps = Math.Min(currentMinimumSteps, currentState.Steps);
                    continue;
                }

                for (int i = 1; i <= replicants.Length; i++)
                {
                    foreach (var keyEntry in paths[currentState.Replicants[i]])
                    {
                        // More internet-inspired optimalisation, comparing ints is faster than strings/objects, transforming the key name to an int
                        var keyInteger = (int)Math.Pow(2, keyEntry.Name - 'a');
                        if ((currentState.Keys & keyInteger) == keyInteger || (keyEntry.Obstacles & currentState.Keys) != keyEntry.Obstacles) { continue; }

                        // removing the key from the collection
                        var newKeyCollection = currentState.Keys | keyInteger;

                        var nextPosition = currentState.Replicants.Clone();
                        nextPosition[i] = keys[keyEntry.Name];

                        stateQueue.Enqueue(new VaultState { Replicants = nextPosition, Keys = newKeyCollection, Steps = currentState.Steps + keyEntry.Steps });
                    }
                }
            }

            return currentMinimumSteps;
        }

        private List<VaultKey> FindKeysInReach(AoCPoint source)
        {
            var keysInReach = new List<VaultKey>();
            var visitedPoints = new HashSet<AoCPoint>();

            var points = new Queue<AoCPoint>(); points.Enqueue(source);
            var stepsQueue = new Queue<int>(); stepsQueue.Enqueue(0);
            var obstacles = new Queue<int>(); obstacles.Enqueue(0);

            while (points.Any())
            {
                var point = points.Dequeue();
                var steps = stepsQueue.Dequeue();
                var obstacle = obstacles.Dequeue();

                if (visitedPoints.Contains(point)) { continue; }

                visitedPoints.Add(point);

                if (accessible.Contains(point))
                {
                    if (keys.ContainsValue(point))
                    {
                        var value = keys.Single(k => k.Value.Equals(point)).Key;
                        keysInReach.Add(new VaultKey(value, steps, obstacle));
                    }

                    // More internet-inspired optimalisation, bitwise magic!
                    if (doors.ContainsValue(point))
                    {
                        var value = doors.Single(k => k.Value.Equals(point)).Key;
                        obstacle |= (int)Math.Pow(2, char.ToLower(value) - 'a');
                    }

                    foreach (var adjacent in GetAdjacentPoints(point))
                    {
                        points.Enqueue(adjacent);
                        stepsQueue.Enqueue(steps + 1);
                        obstacles.Enqueue(obstacle);
                    }
                }
            }

            return keysInReach;
        }

        private List<AoCPoint> GetAdjacentPoints(AoCPoint src)
        {
            var possibleAdjacents = new AoCPoint[] { src.Up(), src.Down(), src.Left(), src.Right() };
            var adjacents = new List<AoCPoint>();

            foreach (var possible in possibleAdjacents)
            {
                if (accessible.Contains(possible)) { adjacents.Add(possible); }
            }

            return adjacents;
        }

        private void ParseInput(List<string> inputLines, bool partTwo)
        {
            var characterCount = partTwo ? 1 : 0;
            var verticalMiddle = inputLines.Count / 2;
            var horizontalMiddle = inputLines.First().Length / 2;

            for (int yPos = 0; yPos < inputLines.Count; yPos++)
            {
                for (int xPos = 0; xPos < inputLines.First().Count(); xPos++)
                {
                    var value = inputLines[yPos][xPos];

                    if (partTwo)
                    {
                        if (yPos == verticalMiddle || xPos == horizontalMiddle) { value = '#'; }
                        else if ((xPos == horizontalMiddle - 1 && yPos == verticalMiddle - 1)
                            || (xPos == horizontalMiddle - 1 && yPos == verticalMiddle + 1)
                            || (xPos == horizontalMiddle + 1 && yPos == verticalMiddle - 1)
                            || (xPos == horizontalMiddle + 1 && yPos == verticalMiddle + 1))
                        {
                            value = '@';
                        }
                    }

                    if (value != '#')
                    {
                        var point = new AoCPoint(xPos, yPos);
                        accessible.Add(point);
                        var characters = new char[] { '@', '1', '2', '3', '4' };

                        if (characters.Contains(value))
                        {
                            replicantPositions.Add(point, characters[characterCount]);
                            characterCount++;
                        }
                        if (char.IsLower(value)) { keys.Add(value, point); }
                        if (char.IsUpper(value)) { doors.Add(value, point); }
                    }
                }
            }
        }
    }
}