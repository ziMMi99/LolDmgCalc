using Stats;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;

namespace Champions {
    public abstract class Champion {

        //----------Variables-----------
        internal int level;
        internal int qRank, wRank, eRank, rRank;
        internal StatHandler baseStats;
        internal StatHandler statPerLevel;


        //-----------Methods-------------

        public virtual Damage AutoAttack() {
            throw new NotImplementedException();
        }
        public virtual Damage AutoAttack(Champion target) {
            Damage dmg = new Damage();
            //-----Calc dmg-----
            //AD + (AD * critDmg * critchance)
            dmg.SetDmg(DamageType.PhysicalDmg, GetStat(StatType.AttackDamage) + (GetStat(StatType.AttackDamage) * GetStat(StatType.CriticalStrikeDmg) * GetStat(StatType.CriticalStrikeChance)));
			//-----Subtract dmg based on resistances------
			/*                               raw dmg
             *  post mitigated dmg =  ----------------------
             *                          1 + resistance/100
             */
			dmg.SetDmg(DamageType.PhysicalDmg, dmg.GetDmg(DamageType.PhysicalDmg)/(1 + target.GetStat(StatType.Armor)/100));


            return dmg;
        }

        public virtual Damage CastQ() {
            throw new NotImplementedException();
        }

        public virtual Damage CastQ(Champion target) {
            throw new NotImplementedException();
        }

        public virtual Damage CastW() {
            throw new NotImplementedException();
        }

        public virtual Damage CastW(Champion target) {
            throw new NotImplementedException();
        }

        public virtual Damage CastE() {
            throw new NotImplementedException();
        }

        public virtual Damage CastE(Champion target) {
            throw new NotImplementedException();
        }

        public virtual Damage CastR() {
            throw new NotImplementedException();
        }

        public virtual Damage CastR(Champion target) {
            throw new NotImplementedException();
        }


        //----------Getters&Setters---------------
        public virtual double GetStat(StatType statType) {
			return baseStats.Get(statType) + (statPerLevel.Get(statType) * level);
		}

		public void SetBaseStat(StatType type, double value) {
            baseStats.Set(type, value);
        }

		public void SetStatPerLevel(StatType type, double value) {
			statPerLevel.Set(type, value);
		}

        //--------------UtilityMethods------------------

        /// <summary>
        /// Levels abilities with prioritizing r, and then q->w->e. 
        /// It levels the abilities in the same way as in LoL.
        /// </summary>
        /// <param name="level">Level of the champion</param>
        protected virtual void LevelAbilities(int level) {
			//makes sure all abilites aren't leveled
			qRank = 0;
			wRank = 0;
			eRank = 0;
			rRank = 0;

			for (int i = 0; i < level; i++) {
				//level qwe to 1 first. Continue cuts the iteration short
				if (qRank == 0) { qRank++; continue; }
				if (wRank == 0) { wRank++; continue; }
				if (eRank == 0) { eRank++; continue; }
				//level r if level = 6, 11, 16
				if (level == 6 || level == 11 || level == 16) { rRank++; continue; }

				/* The rule for if abilities can be leveled up:
                 * The current ability level cannot be higher than half the champion level(rounded up)
                 * Aka: highest ability level = champion level/2 (rounded up)
                 * For the sake of putting this into an if-statement the formular is modified
                 * Instead of dividing champion level by 2, we instead multiply the ability level by 2
                 * The only place this has effect is at level 8 where q=4 and level=8
                 */
				//prioritize leveling q
				if (qRank < 5 && qRank * 2 < level) { qRank++; continue; }
				//then prioritize leveling w
				if (wRank < 5 && wRank * 2 < level) { wRank++; continue; }
				//then prioritize leveling e
				if (eRank < 5 && eRank * 2 < level) { eRank++; continue; }
			}
		}

		/// <summary>
		/// Sets the ability ranks to the parameters, but if the parameters aren't legal by being too big or small,
		/// then the ranks are made legal. This is done by making ranks too big the maxRank,
		/// and ranks too small the minRank.
		/// </summary>
		/// <param name="qRank">The rank/level of q</param>
		/// <param name="wRank">The rank/level of w</param>
		/// <param name="eRank">The rank/level of e</param>
		/// <param name="rRank">The rank/level of r</param>
		protected virtual void SetAbilityRanks(int qRank, int wRank, int eRank, int rRank) {
            this.qRank = MakeRankLegal(qRank, 0, 5);
            this.wRank = MakeRankLegal(wRank, 0, 5);
            this.eRank = MakeRankLegal(eRank, 0, 5);
            this.rRank = MakeRankLegal(rRank, 0, 3);
            level = qRank + wRank + eRank + rRank;
        }

        /// <summary>
        /// Checks if the ability rank is within the legal rank range. 
        /// If the rank is outside the range then the rank is changed to be the closest legal rank.
        /// </summary>
        /// <param name="rank">The rank to validate/make legal</param>
        /// <param name="minRank">The minimum rank of the ability</param>
        /// <param name="maxRank">The maximum rank of the ability</param>
        /// <returns>Returns the closest legal rank</returns>
        protected virtual int MakeRankLegal(int rank, int minRank, int maxRank) {
			if (minRank <= rank && rank <= maxRank) { //Checks if the rank is legal
                return rank;
			} else if (rank > maxRank) { //Rank is too big, and returns the max rank
				return maxRank;
			} else { //Rank is too small, and returns the min rank
				return minRank;
			}
		}

        /// <summary>
        /// Sets the baseStats and statsPerLevel statHandlers. Default sets everything to 0.
        /// It should be overriden in every champion class, to specify the stats.
        /// </summary>
        protected virtual void SetBaseStats() {
			baseStats = new StatHandler(new Dictionary<StatType, double>() {
				{StatType.CriticalStrikeDmg, 1.75}
			});
			statPerLevel = new StatHandler(new Dictionary<StatType, double>() {
				
			});
		}
	}
}
