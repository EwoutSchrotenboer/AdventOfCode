using System;
using System.Collections.Generic;

namespace AoC.Y2017.Days
{
    internal class TuringState
    {
        public string Name { get; set; }

        public (int Zero, int One) NextSlotOffset { get; set; }
        public (string Zero, string One) NextState { get; set; }
        public (int Zero, int One) WriteValue { get; set; }

        public TuringState(List<string> configuration)
        {
            Name = configuration[0].Replace(":", "").Split(' ')[2];
            WriteValue = GetNumberValues(configuration[2], configuration[6], 4);
            NextSlotOffset = GetSlotValues(configuration[3], configuration[7], 6);
            NextState = GetValues(configuration[4], configuration[8], 4);
        }

        public (int, int, string) GetValues(int current) => current == 0 ? (WriteValue.Zero, NextSlotOffset.Zero, NextState.Zero) : (WriteValue.One, NextSlotOffset.One, NextState.One);

        private (int, int) GetNumberValues(string zero, string one, int position)
        {
            var (zeroValue, oneValue) = GetValues(zero, one, position);
            return (int.Parse(zeroValue), int.Parse(oneValue));
        }

        private (int, int) GetSlotValues(string zero, string one, int position)
        {
            var (zeroValue, oneValue) = GetValues(zero, one, position);
            return (zeroValue == "left" ? -1 : 1, oneValue == "left" ? -1 : 1);
        }

        private (string, string) GetValues(string zero, string one, int position) =>
                            (zero.Replace(".", "").Split(' ', StringSplitOptions.RemoveEmptyEntries)[position],
            one.Replace(".", "").Split(' ', StringSplitOptions.RemoveEmptyEntries)[position]);
    }
}
