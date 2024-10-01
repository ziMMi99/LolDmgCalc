using Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions.Champions.Specialist {
    internal class Cho_Gath : Champion {
        private int rStacks;
        
        //----------Constructors----------
        public Cho_Gath() : this(18, 0) { }

        public Cho_Gath(int level, int rStacks) {
            this.rStacks = rStacks;
            this.level = level;
            LevelAbilities(level);
            SetBaseStats();
        }

        public Cho_Gath(int qRank, int wRank, int eRank, int rRank, int rStacks) {
            this.rStacks = rStacks;
            SetAbilityRanks(qRank, wRank, eRank, rRank);
			SetBaseStats();
		}

        //--------------Abilities---------------
        public override Damage BasicAttack() {
            throw new NotImplementedException();
        }
        public override Damage CastQ() {
            throw new NotImplementedException();
        }
        public override Damage CastW() {
            throw new NotImplementedException();
        }

        public override Damage CastE() {
            throw new NotImplementedException();
        }

        public override Damage CastR() {
            throw new NotImplementedException();
        }

		//------------Getters&Setters---------------
		public override double GetStat(StatType statType) {
			switch (statType) {
				case StatType.Health:
					//rStacks calculation looks weird but (40 + 40 * rRank) is to follow the bonus hp pr rRank which is 80/120/160
					return baseStats.Get(statType) + (statPerLevel.Get(statType) * level) + (rStacks * (40 + 40 * rRank));
				default:
					return base.GetStat(statType);
			}
		}

		//------------UtilityMethods----------------

		protected override void SetBaseStats() {
			baseStats = new StatHandler(new Dictionary<StatType, double>() {
				{StatType.Health, 644},
				{StatType.Mana, 270},
				{StatType.AttackDamage, 69},
				{StatType.Armor, 38},
				{StatType.MagicResistance, 32},
				{StatType.AttackSpeed, 0.625},
				{StatType.MovementSpeed, 345},
				{StatType.ManaRegeneration, 7.2},
				{StatType.HealthRegeneration, 9}
			});
			statPerLevel = new StatHandler(new Dictionary<StatType, double>() {
				{StatType.Health, 94},
				{StatType.Mana, 60},
				{StatType.AttackDamage, 4.2},
				{StatType.Armor, 5},
				{StatType.MagicResistance, 2.05},
				{StatType.AttackSpeed, 0},
				{StatType.MovementSpeed, 345},
				{StatType.ManaRegeneration, 0.45},
				{StatType.HealthRegeneration, 0.85}
			});
		}
	}
}
