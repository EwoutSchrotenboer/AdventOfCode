using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Group
    {
        public Army Army { get; private set; }
        public AttackType AttackType { get; private set; }
        public int Initiative { get; private set; }
        public int HitPoints { get; private set; }
        public int UnitCount { get; private set; }
        public int AttackDamage { get; private set; }
        public List<AttackType> Weaknesses { get; } = new List<AttackType>();
        public List<AttackType> Immunities { get; } = new List<AttackType>();

        public Group(string input, Army army)
        {
            Army = army;
            ProcessInput(input);

        }

        private void ProcessInput(string input)
        {
            var inputItems = input.Split(' ').ToList();

            var numbersets = inputItems.Where(s => s.All(c => char.IsNumber(c))).ToList();
            var damageTypeIndex = inputItems.FindIndex(s => s == numbersets[2]) + 1;

            UnitCount = int.Parse(numbersets[0]);
            HitPoints = int.Parse(numbersets[1]);
            AttackDamage = int.Parse(numbersets[2]);
            Initiative = int.Parse(numbersets[3]);

            AttackType = Enum.Parse<AttackType>(inputItems[damageTypeIndex], true);


            var detailStart = input.IndexOf('(');
            var detailEnd = input.IndexOf(')');

            if (detailStart != -1 && detailEnd != -1)
            {
                HandleDetails(input.Substring(detailStart + 1, (detailEnd - detailStart) - 1));
            }
        }

        private void HandleDetails(string details)
        {
            var splitData = details.Split(';');

            foreach (var data in splitData)
            {
                if (data.Trim().StartsWith("weak to"))
                {
                    var parsedData = data.Replace("weak to", string.Empty).Split(',');
                    Weaknesses.AddRange(parsedData.Select(s => Enum.Parse<AttackType>(s.Trim(), true)));
                }
                else if (data.Trim().StartsWith("immune to"))
                {
                    var parsedData = data.Replace("immune to", string.Empty).Split(',');
                    Immunities.AddRange(parsedData.Select(s => Enum.Parse<AttackType>(s.Trim(), true)));
                }
            }
        }

        public int EffectiveDamage(Group target)
        {
            if (target.Immunities.Contains(AttackType)) { return 0; }
            var effectivePower = AttackDamage * UnitCount;
            return target.Weaknesses.Contains(AttackType) ? effectivePower * 2 : effectivePower;
        }

        public void DealDamage(Group target)
        {
            var damage = EffectiveDamage(target);
            target.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            var losses = damage / HitPoints;
            UnitCount -= losses;
        }

        public void BoostAttackDamage(int boost)
        {
            AttackDamage += boost;
        }
    }

    public enum AttackType
    {
        Bludgeoning,
        Cold,
        Fire,
        Radiation,
        Slashing,
    }

    public enum Army
    {
        ImmuneSystem,
        Infection
    }
}
