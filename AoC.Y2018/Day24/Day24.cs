using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day24 : BaseDay
    {
        public Day24() : base(2018, 24)
        {
        }

        public Day24(IEnumerable<string> inputLines) : base(2018, 24, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var groups = GetGroups(inputLines);

            var (_, survivingUnitCount) = Battle(groups);

            return survivingUnitCount;
        }

        protected override IConvertible PartTwo()
        {
            var groups = new List<Group>();
            var survivingUnitCount = 0;
            var survivingArmy = Army.Infection;
            var boost = 0;


            do
            {
                groups = GetGroups(inputLines);
                boost++;
                (survivingArmy, survivingUnitCount) = Battle(groups, boost);
            }
            while (survivingArmy == Army.Infection);

            return survivingUnitCount;
        }

        private static (Army army, int survivingUnitCount) Battle(List<Group> groups, int boost = 0)
        {
            BoostImmuneSystem(groups.Where(g => g.Army == Army.ImmuneSystem), boost);

            do
            {
                Fight(groups);
                groups.RemoveAll(g => g.UnitCount < 1);

                if (groups.Any(g => g.Army == Army.ImmuneSystem) && groups.Any(g => g.Army == Army.Infection) && ArmiesDeadlocked(groups))
                {
                    return (Army.Infection, -1);
                }
            } 
            while (groups.Any(g => g.Army == Army.ImmuneSystem) && groups.Any(g => g.Army == Army.Infection));

            var survivingArmy = groups.First().Army;
            var survivingUnitCount = groups.Sum(g => g.UnitCount);

            return (survivingArmy, survivingUnitCount);
        }

        private static bool ArmiesDeadlocked(List<Group> groups)
        {
            var infectionArmy = groups.Where(g => g.Army == Army.Infection);
            var immuneSystemArmy = groups.Where(g => g.Army == Army.ImmuneSystem);

            var infectionCanAttack = infectionArmy.Any(inf => immuneSystemArmy.Any(imm => !imm.Immunities.Contains(inf.AttackType)));
            var immuneCanAttack = immuneSystemArmy.Any(imm => infectionArmy.Any(inf => !inf.Immunities.Contains(inf.AttackType)));

            return !(infectionCanAttack && immuneCanAttack);
        }

        private static void BoostImmuneSystem(IEnumerable<Group> groups, int boost)
        {
            foreach (var g in groups)
            {
                g.BoostAttackDamage(boost);
            }
        }

        private static void Fight(List<Group> groups)
        {
            // target selection
            var combatGroups = groups.OrderByDescending(g => g.UnitCount * g.AttackDamage).ThenByDescending(g => g.Initiative);
            var fights = new List<(Group attacking, Group defending)>();

            foreach (var combatGroup in combatGroups)
            {
                var possibleTargets = combatGroups.Where(c => c.Army != combatGroup.Army);
                var orderedTargets = possibleTargets
                    .OrderByDescending(t => combatGroup.EffectiveDamage(t))
                    .ThenByDescending(t => t.AttackDamage * t.UnitCount)
                    .ThenByDescending(t => t.Initiative);

                var target = orderedTargets.Where(o => !fights.Any(s => s.defending == o) && !o.Immunities.Contains(combatGroup.AttackType)).FirstOrDefault();

                if (target != null)
                {
                    fights.Add((combatGroup, target));
                }
            }

            // attacking
            foreach (var fight in fights.OrderByDescending(f => f.attacking.Initiative))
            {
                if (fight.attacking.UnitCount > 0)
                {
                    fight.attacking.DealDamage(fight.defending);
                }
            }
        }

        private static List<Group> GetGroups(IEnumerable<string> inputLines)
        {
            var armyType = Army.ImmuneSystem;
            var groups = new List<Group>();

            foreach (var input in inputLines)
            {
                if (input.Equals("Immune System:")) { armyType = Army.ImmuneSystem; }
                else if (input.Equals("Infection:")) { armyType = Army.Infection; }
                else if (!string.IsNullOrEmpty(input))
                {
                    var group = new Group(input, armyType);
                    groups.Add(group);
                }
            }

            return groups;
        }
    }
}