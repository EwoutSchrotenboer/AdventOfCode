using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Step
    {
        public char Name { get; set; }
        public List<Step> Prerequisites { get; set; } = new List<Step>();
        public Worker AssignedWorker { get; set; }
        public StepStatus Status {get; set;} = StepStatus.Ready;
        public int TimeLeft { get; set; }

        public Step(char name) : this(name, null) { }

        public Step(char name, Step prerequisite)
        {
            Name = name;
            TimeLeft = 60 + char.ToUpper(name) - 64;

            if (prerequisite != null)
            {
                Prerequisites.Add(prerequisite);
            }

        }
    }
}
