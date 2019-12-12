using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day12 : BaseDay
    {
        public Day12() : base(2018, 12)
        {
        }

        public Day12(IEnumerable<string> inputLines) : base(2018, 12, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var generations = 20;
            return CalculatePlantTotal(generations);
        }

        protected override IConvertible PartTwo()
        {
            var generations = 50000000000;

            // after gen 88 it adds 62 every generation. To be sure, we'll add a buffer.
            // Verified this by manually checking the output to check if there was a pattern.
            var gens = 2000;
            var total = CalculatePlantTotal(gens);
            var restOfIterations = (generations - 2000) * 62;
            var totalWithoutIterating = total + restOfIterations;
            return totalWithoutIterating;
        }

        private long CalculatePlantTotal(long generations)
        {
            var inputList = inputLines.ToList();
            var (pots, notes) = Initialize(inputList);
            var finalGen = CycleGenerations(generations, pots, notes);

            return finalGen.Where(p => p.Plant).Sum(p => p.Index);
        }


        private List<Pot> CycleGenerations(long generations, List<Pot> current, List<Note> notes)
        {
            var nextGen = new List<Pot>();

            foreach (var currentPot in current)
            {
                nextGen.Add(currentPot.Clone());
            }

            for (long i = 0; i < generations; i++)
            {
                nextGen = NextGeneration(nextGen, notes);
            }

            return nextGen;
        }

        private List<Pot> NextGeneration(List<Pot> current, List<Note> notes)
        {
            var nextGen = new List<Pot>();

            long min = current.Min(p => p.Index);
            long max = current.Max(p => p.Index);
            current.Add(new Pot(min - 2, false));
            current.Add(new Pot(min - 1, false));
            current.Add(new Pot(max + 1, false));
            current.Add(new Pot(max + 2, false));

            for (long i = min - 2; i <= max + 2; i++)
            {
                var sample = new bool[5];
                var currentPot = current.Single(p => p.Index == i);

                sample[0] = current.SingleOrDefault(p => p.Index == i - 2)?.Plant ?? false;
                sample[1] = current.SingleOrDefault(p => p.Index == i - 1)?.Plant ?? false;
                sample[2] = current.SingleOrDefault(p => p.Index == i).Plant;
                sample[3] = current.SingleOrDefault(p => p.Index == i + 1)?.Plant ?? false;
                sample[4] = current.SingleOrDefault(p => p.Index == i + 2)?.Plant ?? false;

                var note = notes.SingleOrDefault(n => n.Condition.SequenceEqual(sample));

                if (note != null)
                {
                    nextGen.Add(new Pot(currentPot.Index, note.InputProducesPlant(sample)));
                }
                else
                {
                    nextGen.Add(new Pot(currentPot.Index, false));
                }
            }

            // cleanup
            while (nextGen.OrderBy(p => p.Index).First().Plant == false && nextGen.OrderBy(p => p.Index).Skip(1).First().Plant == false)
            {
                nextGen.Remove(nextGen.OrderBy(p => p.Index).First());
            }

            while (nextGen.OrderByDescending(p => p.Index).First().Plant == false && nextGen.OrderByDescending(p => p.Index).Skip(1).First().Plant == false)
            {
                nextGen.Remove(nextGen.OrderByDescending(p => p.Index).First());
            }

            return nextGen.OrderBy(p => p.Index).ToList();
        }

        private (List<Pot>, List<Note>) Initialize(IEnumerable<string> inputLines)
        {
            var pots = CreatePots(inputLines.First().Substring(15));
            var notes = CreateNotes(inputLines.Skip(2));
            return (pots, notes);
        }

        private List<Pot> CreatePots(string input)
        {
            var pots = new List<Pot>();

            var inputChars = input.ToCharArray();
            var currentPotIndex = 0;

            foreach (var inputChar in inputChars)
            {
                pots.Add(new Pot(currentPotIndex, inputChar == '#'));
                currentPotIndex++;
            }

            return pots;
        }

        private List<Note> CreateNotes(IEnumerable<string> input)
        {
            var notes = new List<Note>();

            foreach (var inputline in input)
            {
                notes.Add(new Note(inputline));
            }

            return notes;
        }
    }
}