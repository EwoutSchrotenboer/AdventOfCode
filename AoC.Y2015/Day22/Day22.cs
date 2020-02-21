using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day22 : BaseDay
    {
        public Day22() : base(2015, 22)
        {
        }

        public Day22(IEnumerable<string> inputLines) : base(2015, 22, inputLines)
        {
        }

		protected override IConvertible PartOne() => SimulateFight(ParseInput(inputLines), (50, 500), false);

        protected override IConvertible PartTwo() => SimulateFight(ParseInput(inputLines), (50, 500), true);

		private static int SimulateFight((int hp, int damage) boss, (int hp, int mana) player, bool hard)
		{
			var currentMinimumMana = int.MaxValue;

			var stateQueue = new Queue<GameState>(new GameState[] { GameState.StartingState(boss.hp, boss.damage) });
			var seen = new Dictionary<GameState, int>();

			while (stateQueue.Any())
			{
				var currentState = stateQueue.Dequeue();

				if (seen.TryGetValue(currentState, out var manaSpent))
				{
					if (manaSpent <= currentState.ManaSpent) { continue; }
					seen[currentState] = currentState.ManaSpent;
				}
				else
				{
					seen.Add(currentState, currentState.ManaSpent);
				}

				if (currentState.BossHp <= 0)
				{
					currentMinimumMana = Math.Min(currentMinimumMana, currentState.ManaSpent);
					continue;
				}

				foreach (Spell spell in Enum.GetValues(typeof(Spell)))
				{
					if (Spells[spell].cost > currentState.CurrentMana
						|| (spell == Spell.Poison && currentState.PoisonTurnsLeft > 1)
						|| (spell == Spell.Recharge && currentState.RechargeTurnsLeft > 1)
						|| (spell == Spell.Shield && currentState.ShieldTurnsLeft > 1))
					{
						continue;
					}

					var simulatedTurn = SimulateTurn(currentState, spell, hard);

					if (simulatedTurn.PlayerHp > 0 && simulatedTurn.CurrentMana > 0)
					{
						stateQueue.Enqueue(simulatedTurn);
					}
				}
			}

			return currentMinimumMana;
		}

		private static GameState SimulateTurn(GameState previousState, Spell spell, bool hard)
		{
			var state = GameState.Clone(previousState);
			var playerArmor = 0;

			// PLAYER TURN
			if (hard) { state.PlayerHp--; }
			if (state.PlayerHp <= 0) { return state; }

			// Handle effects
			if (state.PoisonTurnsLeft > 0) { state.BossHp -= Spells[Spell.Poison].damage; state.PoisonTurnsLeft--; }
			if (state.ShieldTurnsLeft > 0) { state.ShieldTurnsLeft--; }
			if (state.RechargeTurnsLeft > 0) { state.CurrentMana += Spells[Spell.Recharge].mana; state.RechargeTurnsLeft--; }

			// Cast spell
			var (cost, damage, _, _, turns) = Spells[spell];

			switch (spell)
			{
				case Spell.MagicMissile: state.BossHp -= damage; break;
				case Spell.Drain: state.BossHp -= damage; state.PlayerHp += damage; break;
				case Spell.Shield: state.ShieldTurnsLeft = turns; break;
				case Spell.Poison: state.PoisonTurnsLeft = turns; break;
				case Spell.Recharge: state.RechargeTurnsLeft = turns; break;
			}

			state.CurrentMana -= cost;
			state.ManaSpent += cost;

			if (state.PlayerHp <= 0 || state.CurrentMana <= 0) { return state; }

			// BOSS TURN
			// Handle effects
			if (state.PoisonTurnsLeft > 0) { state.BossHp -= Spells[Spell.Poison].damage; state.PoisonTurnsLeft--; }
			if (state.ShieldTurnsLeft > 0) { playerArmor = Spells[Spell.Shield].armor; state.ShieldTurnsLeft--; }
			if (state.RechargeTurnsLeft > 0) { state.CurrentMana += Spells[Spell.Recharge].mana; state.RechargeTurnsLeft--; }

			if (state.BossHp > 0)
			{
				state.PlayerHp -= Math.Max(1, state.BossDamage - playerArmor);
			}

			return state;
		}


		private static readonly Dictionary<Spell, (int cost, int damage, int armor, int mana, int turns)> Spells = new Dictionary<Spell, (int cost, int damage, int armor, int mana, int turns)>()
		{
			[Spell.MagicMissile] = (53, 4, 0, 0, 0),
			[Spell.Drain] = (73, 2, 0, 0, 0),
			[Spell.Poison] = (173, 3, 0, 0, 6),
			[Spell.Recharge] = (229, 0, 0, 101, 5),
			[Spell.Shield] = (113, 0, 7, 0, 6)
		};

		private static (int hp, int damage) ParseInput(IEnumerable<string> inputLines)
		{
			var values = inputLines.Select(l => int.Parse(l.Split(':')[1].Trim()));
			return (values.First(), values.Last());
		}
	}
}
