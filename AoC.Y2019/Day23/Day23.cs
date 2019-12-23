using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day23 : BaseDay
    {
        public Day23() : base(2019, 23)
        {
        }

        public Day23(IEnumerable<string> inputLines) : base(2019, 23, inputLines)
        {
        }

        protected override IConvertible PartOne() => RunSimulation(50, inputLines.First(), true);

        protected override IConvertible PartTwo() => RunSimulation(50, inputLines.First(), false);

        private static (Computer[] network, Dictionary<long, Queue<long>> cache, (long X, long Y, long PrevY) nat) InitializeNetwork(int nodes, string program)
        {
            var network = new Computer[nodes];
            var cache = new Dictionary<long, Queue<long>>();
            long natX = 0, natY = 0, prevY = long.MaxValue;

            for (long i = 0; i < nodes; i++)
            {
                network[i] = new Computer(program, i);
                network[i].Run();
                cache.Add(i, new Queue<long>());
            }

            return (network, cache, (natX, natY, prevY));
        }

        private static long RunSimulation(int nodes, string program, bool partOne)
        {
            var (network, cache, nat) = InitializeNetwork(nodes, program);

            while (true)
            {
                for (int networkIndex = 0; networkIndex < network.Length; networkIndex++)
                {
                    var node = network[networkIndex];

                    while (cache[networkIndex].Any())
                    {
                        node.AddInput(cache[networkIndex].Dequeue());
                    }
                    if (!node.AnyInputs()) { node.AddInput(-1); }

                    node.Run();

                    while (node.AnyOutputs())
                    {
                        var address = node.NextOutput();
                        var x = node.NextOutput();
                        var y = node.NextOutput();

                        if (address == 255 && partOne) { return y; }
                        else if (address == 255) { nat = (x, y, nat.PrevY); continue; }

                        cache[address].Enqueue(x);
                        cache[address].Enqueue(y);
                    }
                }

                // If the network is idle, send the NAT-value to address 0
                if (!partOne && cache.Sum(pq => pq.Value.Count) == 0)
                {
                    if (nat.Y == nat.PrevY) { return nat.Y; }

                    cache[0].Enqueue(nat.X);
                    cache[0].Enqueue(nat.Y);
                    nat.PrevY = nat.Y;
                }
            }
        }
    }
}
