using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Battle
    {
        private int elfCount;

        public Position[,] Grid { get; }
        public List<Unit> Units { get; } = new List<Unit>();

        public List<Unit> GetCreaturesInActingOrder() => Units
                .OrderBy(c => c.Position.Point.Y)
                .ThenBy(c => c.Position.Point.X)
                .ToList();

        public Battle(List<string> inputLines, int elfAttackPower = 3)
        {
            var data = inputLines;
            var width = data.First().Length;
            var height = data.Count;

            Grid = new Position[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (data[y][x] == '#') continue;

                    Unit unit = null;
                    if (data[y][x] == 'G') unit = Unit.CreateGoblin();
                    if (data[y][x] == 'E') unit = Unit.CreateElf(elfAttackPower);
                    if (unit != null) Units.Add(unit);

                    var value = (y * width) + x;

                    Grid[x, y] = new Position(x, y, value, unit);

                    if (y > 0 && Grid[x, y - 1] != null)
                    {
                        Grid[x, y].ConnectToPositionAbove(Grid[x, y - 1]);
                    }

                    if (x > 0 && Grid[x - 1, y] != null)
                    {
                        Grid[x, y].ConnectToPositionToTheLeft(Grid[x - 1, y]);
                    }
                }
            }

            elfCount = Units.Where(u => u.IsElf).Count();
        }

        public void Fight(Unit attacker, Unit target)
        {
            target.HitPoints -= attacker.AttackPower;

            if (target.HitPoints <= 0)
            {
                Units.Remove(target);
                target.Position.Unit = null;
                target.Position = null;
            }
        }

        public bool IsCleanElvenVictory() => elfCount == Units.Where(u => u.IsElf && !u.IsDead).Count();
        public bool IsOver() => Units.All(c => c.IsGoblin || c.IsDead) || Units.All(c => c.IsElf || c.IsDead);
        public int GetHitPointsLeft() => Units.Where(c => !c.IsDead).Sum(x => x.HitPoints);
        public int GetScoreFor(int completedRounds) => completedRounds * GetHitPointsLeft();
    }
}
