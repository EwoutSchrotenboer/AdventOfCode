using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day15 : BaseDay
    {
        public Day15() : base(2018, 15)
        {
        }

        public Day15(IEnumerable<string> inputLines) : base(2018, 15, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var battle = new Battle(inputLines.ToList());
            return RunBattle(battle);
        }

        protected override IConvertible PartTwo()
        {
            for (int elfAttackPower = 0; elfAttackPower < 200; elfAttackPower++)
            {
                var battle = new Battle(inputLines.ToList(), elfAttackPower);
                var score = RunBattle(battle);
                if (battle.IsCleanElvenVictory()) return score;
            }

            return 0;
        }

        private int RunBattle(Battle battle)
        {
            var battleOngoing = true;
            var completedRounds = 0;

            while (battleOngoing)
            {
                var creaturesInActingOrder = battle.GetCreaturesInActingOrder();

                foreach (var creature in creaturesInActingOrder)
                {
                    if (creature.IsDead) continue;

                    if (battle.IsOver())
                    {
                        return battle.GetScoreFor(completedRounds);
                    }

                    if (!creature.CanAttack())
                    {
                        try
                        {
                            var optimalMove = GetOptimalMoveFor(creature, battle);
                            creature.MoveTo(optimalMove);
                        }
                        catch { }

                    }

                    var target = creature.FirstOrDefaultTarget();

                    if (target != null)
                    {
                       battle.Fight(creature, target);
                    }
                }

                completedRounds++;
            }

            return 0;
        }

        private static Position GetOptimalMoveFor(Unit creature, Battle battle)
        {
            var possibleMoves = new Dictionary<Position, int>();
            if (creature.Position.Up?.HasCreature == false) possibleMoves.Add(creature.Position.Up, 0);
            if (creature.Position.Left?.HasCreature == false) possibleMoves.Add(creature.Position.Left, 1);
            if (creature.Position.Right?.HasCreature == false) possibleMoves.Add(creature.Position.Right, 2);
            if (creature.Position.Down?.HasCreature == false) possibleMoves.Add(creature.Position.Down, 3);

            var targets = new Dictionary<int, ISet<Position>>();

            foreach (var pos in battle.Units.Where(c => c.IsEnemyFor(creature)).Select(c => c.Position))
            {
                if (pos.Up?.HasCreature == false) targets[pos.Up.ReadingOrderValue] = new HashSet<Position> { pos.Up };
                if (pos.Left?.HasCreature == false) targets[pos.Left.ReadingOrderValue] = new HashSet<Position> { pos.Left };
                if (pos.Right?.HasCreature == false) targets[pos.Right.ReadingOrderValue] = new HashSet<Position> { pos.Right };
                if (pos.Down?.HasCreature == false) targets[pos.Down.ReadingOrderValue] = new HashSet<Position> { pos.Down };
            }

            var visited = new HashSet<Position>();
            var exhausted = false;

            while (!exhausted)
            {
                exhausted = true;

                foreach (var key in targets.Keys.OrderBy(k => k))
                {
                    var newTargets = new HashSet<Position>();

                    Position bestMove = null;
                    int bestROrder = int.MaxValue;

                    foreach (var pos in targets[key])
                    {
                        if (visited.Contains(pos)) continue;

                        visited.Add(pos);
                        exhausted = false;

                        if (possibleMoves.ContainsKey(pos) && possibleMoves[pos] < bestROrder)
                        {
                            bestMove = pos;
                            bestROrder = possibleMoves[pos];
                        }

                        if (pos.Up?.HasCreature == false) newTargets.Add(pos.Up);
                        if (pos.Left?.HasCreature == false) newTargets.Add(pos.Left);
                        if (pos.Right?.HasCreature == false) newTargets.Add(pos.Right);
                        if (pos.Down?.HasCreature == false) newTargets.Add(pos.Down);
                    }

                    targets[key] = newTargets;

                    if (bestMove != null) return bestMove;
                }
            }

            return null;
        }
    }
}