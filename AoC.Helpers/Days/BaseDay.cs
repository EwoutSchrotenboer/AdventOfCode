using AoC.Helpers.Input;
using AoC.Helpers.Output;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AoC.Helpers.Days
{
    /// <summary>
    /// Base implementation of a day
    /// </summary>
    public abstract class BaseDay
    {
        protected int day;
        protected int year;
        protected IEnumerable<string> inputLines;

        protected BaseDay(int year, int day) : this(year, day, InputParser.GetInputList(year, day))
        {
        }

        protected BaseDay(int year, int day, IEnumerable<string> inputLines)
        {
            this.inputLines = inputLines;
            this.year = year;
            this.day = day;
        }

        public IConvertible Debug(Part part)
        {
            return part == Part.One ? PartOne() : PartTwo();
        }

        public IConvertible Execute(Part part)
        {
            var sw = new Stopwatch();

            sw.Start();
            var result = part == Part.One ? PartOne() : PartTwo();
            sw.Stop();

            var resultString = $"Part {part} result: {result} (executed in {sw.ElapsedMilliseconds} ms)";

            return this.SaveAndReturnOutput(part, resultString);
        }

        protected abstract IConvertible PartOne();

        protected abstract IConvertible PartTwo();

        protected IConvertible SaveAndReturnOutput(Part part, IConvertible output)
        {
            OutputWriter.SaveOutput(this.year, this.day, part, output);

            return output;
        }

        protected IEnumerable<IConvertible> SaveAndReturnOutput(Part part, IEnumerable<IConvertible> output)
        {
            OutputWriter.SaveOutput(this.year, this.day, part, output);

            return output;
        }

        public override string ToString()
        {
            return $"Y{year} Day {day}";
        }
    }
}