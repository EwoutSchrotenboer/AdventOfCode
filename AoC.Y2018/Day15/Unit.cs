using System;
using System.Linq;

namespace AoC.Y2018.Days
{
    internal class Unit
    {
        public bool IsGoblin { get; set; }
        public int HitPoints { get; set; } = 200;
        public int AttackPower { get; }
        public Position Position { get; set; }
        public bool IsDead => HitPoints <= 0;
        public bool IsElf => !IsGoblin;
        public bool IsEnemyFor(Unit other) => other.IsGoblin != this.IsGoblin;

        public Unit(int attackPower = 3)
        {
            this.AttackPower = attackPower;
        }

        public void MoveTo(Position other)
        {
            if (other.Unit != null || other == this.Position || (other != Position.Up && other != Position.Left && other != Position.Right && other != Position.Down))
            {
                return;
            }

            this.Position.Unit = null;
            this.Position = other;
            other.Unit = this;
        }

        public bool CanAttack() => FirstOrDefaultTarget() != null;

        public Unit FirstOrDefaultTarget()
        {
            return Position
                .EnumerateAdjacentUnits()
                .Where(c => c.IsEnemyFor(this))
                .OrderBy(c => c.HitPoints)
                .ThenBy(c => c.Position.Point.Y)
                .ThenBy(c => c.Position.Point.X)
                .FirstOrDefault();
        }

        private static int goblinId = 'Z';

        private static char GetNextId() => (char)(goblinId = goblinId > 89 ? 65 : goblinId + 1);

        private char myGoblinId = GetNextId();
        public char Rune => IsGoblin ? myGoblinId : '@';

        public static Unit CreateGoblin() => new Unit { IsGoblin = true };

        public static Unit CreateElf(int attackPower = 3) => new Unit(attackPower) { IsGoblin = false };
    }
}