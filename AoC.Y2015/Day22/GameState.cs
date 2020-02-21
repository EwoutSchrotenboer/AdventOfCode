using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2015.Days
{
	internal class GameState : IEquatable<GameState>
	{
		public int BossHp { get; set; }
		public int BossDamage { get; set; }
		public int PlayerHp { get; set; }
		public int CurrentMana { get; set; }
		public int ShieldTurnsLeft { get; set; }
		public int PoisonTurnsLeft { get; set; }
		public int RechargeTurnsLeft { get; set; }
		public int ManaSpent { get; set; }

		public GameState() { }

		public GameState(int bossHp, int bossAttack, int playerHp, int currentMana, int shieldLeft, int poisonLeft, int rechargeLeft, int manaSpent)
		{
			BossHp = bossHp;
			BossDamage = bossAttack;
			PlayerHp = playerHp;
			CurrentMana = currentMana;
			ShieldTurnsLeft = shieldLeft;
			PoisonTurnsLeft = poisonLeft;
			RechargeTurnsLeft = rechargeLeft;
			ManaSpent = manaSpent;
		}

		public static GameState StartingState(int bossHp, int bossDamage) => new GameState(bossHp, bossDamage, 50, 500, 0, 0, 0, 0);
		public static GameState Clone(GameState current) =>
				  new GameState(current.BossHp, current.BossDamage, current.PlayerHp, current.CurrentMana, current.ShieldTurnsLeft, current.PoisonTurnsLeft, current.RechargeTurnsLeft, current.ManaSpent);

		public bool Equals(GameState other)
		{
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;
			return BossHp == other.BossHp
				&& BossDamage == other.BossDamage
				&& PlayerHp == other.PlayerHp
				&& CurrentMana == other.CurrentMana
				&& ShieldTurnsLeft == other.ShieldTurnsLeft
				&& PoisonTurnsLeft == other.PoisonTurnsLeft
				&& RechargeTurnsLeft == other.RechargeTurnsLeft;
		}

		public override int GetHashCode() =>
			HashCode.Combine(BossHp, BossDamage, PlayerHp, CurrentMana, ShieldTurnsLeft, PoisonTurnsLeft, RechargeTurnsLeft) ^ 397;
	}
}
