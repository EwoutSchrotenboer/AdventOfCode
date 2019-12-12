using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Worker
    {
        public int Id { get; set; }
        public bool Available { get; set; } = true;

        public Worker(int id)
        {
            Id = id;
        }
    }
}
