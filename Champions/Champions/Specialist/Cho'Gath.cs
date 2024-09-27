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
            this.LevelAbilities(level);

            //------stats------
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

        //--------------Abilities---------------
        public override Damage AutoAttack() {
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

        //------------UtilityMethods----------------
        protected override void LevelAbilities(int level) {
            //makes sure all abilites aren't leveled
            qLevel = 0;
            wLevel = 0;
            eLevel = 0;
            rLevel = 0;

            for (int i = 0; i < level; i++) {
                //level qwe to 1 first. Continue cuts the iteration short
                if (qLevel == 0) { qLevel++; continue; } 
                if (wLevel == 0) { wLevel++; continue; }
                if (eLevel == 0) { eLevel++; continue; }
                //level r if level = 6, 11, 16
                if (level == 6 || level == 11 || level == 16) { rLevel++; continue; }

                /* The rule for if abilities can be leveled up:
                 * The current ability level cannot be higher than half the champion level(rounded up)
                 * Aka: highest ability level = champion level/2 (rounded up)
                 * For the sake of putting this into an if-statement the formular is modified
                 * Instead of dividing champion level by 2, we instead multiply the ability level by 2
                 * The only place this has effect is at level 8 where q=4 and level=8
                 */
                //prioritize leveling q
                if (qLevel < 5 && qLevel * 2 < level) { qLevel++; continue; }
				//then prioritize leveling w
				if (wLevel < 5 && wLevel * 2 < level) { wLevel++; continue; }
				//then prioritize leveling e
				if (eLevel < 5 && eLevel * 2 < level) { eLevel++; continue; }
			}
        }
    }
}
