using Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions.Champions.Specialist {
    internal class Cho_Gath : Champion {
        private int rStacks;
		private int empoweredAttacks;
        
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
		//--basic attack--
        public override Damage BasicAttack(Champion target) {
			Damage dmg = new Damage();
			//-----Calc dmg-----
			//AD + (AD * critDmg * critChance)
			dmg.AddDmg(DamageType.PhysicalDmg,
				GetStat(StatType.AttackDamage) + (GetStat(StatType.AttackDamage) * GetStat(StatType.CriticalStrikeDmg) * GetStat(StatType.CriticalStrikeChance)));
			//If e has been used
			if (empoweredAttacks > 0) { 
				//eRank * 20 + AP * 0.3 + target.health * (0.03 + (0.05 * rStacks))
				dmg.AddDmg(DamageType.MagicDmg, 
					eRank * 20 + GetStat(StatType.AbilityPower) * 0.3 + target.GetStat(StatType.Health) * (0.03 + 0.05 * rStacks));
				//Uses one empowered basic attack
				empoweredAttacks--;	
			}
			
			
			//-----Subtract dmg based on resistances------
			dmg.CalcResistances(this, target);

			return dmg;
		}

		public override Damage BasicAttack() {
			return this.BasicAttack(new TargetDummy());
		}

		//--q--
		public override Damage CastQ(Champion target) {

			Damage dmg = new Damage();
			//-----Calc dmg-------
			if (qRank > 0) {
				//15 + 65 * qRank + AP
				dmg.AddDmg(DamageType.MagicDmg, 
					15 + 65 * qRank + GetStat(StatType.AbilityPower));
			}
			//-----Subtract dmg based on resistances-------
			dmg.CalcResistances(this, target);

			return dmg;
		}

		public override Damage CastQ() {
            return this.CastQ(new TargetDummy());
        }

		//--w--
		public override Damage CastW(Champion target) {

			Damage dmg = new Damage();
			//-----Calc dmg-------
			if (wRank > 0) {
				//25 + 55 * wRank + AP * 0.7
				dmg.AddDmg(DamageType.MagicDmg,
					25 + 55 * wRank + GetStat(StatType.AbilityPower) * 0.7);
			}
			//-----Subtract dmg based on resistances-------
			dmg.CalcResistances(this, target);

			return dmg;
		}

		public override Damage CastW() {
            return this.CastW(new TargetDummy());
        }

		//--e--
		public override Damage CastE(Champion target) {
			empoweredAttacks = 3;
			return new Damage();
        }
		public override Damage CastE() {
			return this.CastE(new TargetDummy());
		}

		//--r--
		public override Damage CastR(Champion target) {
			
			Damage dmg = new Damage();
			//-----Calc dmg-------
			if (rRank > 0) {
				double bonusHP = GetStat(StatType.Health) - GetBaseStat(StatType.Health);
				//125 + 175 * rRank + AP * 0.5 + bonusHP * 0.1
				dmg.AddDmg(DamageType.TrueDmg,
					15 + 65 * qRank + GetStat(StatType.AbilityPower) + bonusHP * 0.1);
			}
			//-----Subtract dmg based on resistances-------
			dmg.CalcResistances(this, target);

			return dmg;
		}

		public override Damage CastR() {
            return this.CastR(new TargetDummy());
        }

		//------------Getters&Setters---------------
		public override double GetStat(StatType statType) {
			switch (statType) {
				case StatType.Health:
					//rStacks calculation looks weird but (40 + 40 * rRank) is to follow the bonus hp pr rRank which is 80/120/160
					return flatStats.Get(statType) + (statPerLevel.Get(statType) * level) + (rStacks * (40 + 40 * rRank));
				default:
					return base.GetStat(statType);
			}
		}

		//------------UtilityMethods----------------

		protected override void SetBaseStats() {
			flatStats = new StatHandler(new Dictionary<StatType, double>() {
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
