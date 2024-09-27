using Stats;
using System.Runtime.InteropServices.Marshalling;

namespace Champions {
    public abstract class Champion {

        //----------Variables-----------
        internal int level;
        internal int qLevel, wLevel, eLevel, rLevel;
        internal StatHandler baseStats;
        internal StatHandler statPerLevel;


        //-----------Methods-------------

        public virtual Damage AutoAttack() {
            throw new NotImplementedException();
        }
        public virtual Damage AutoAttack(Champion target) {
            throw new NotImplementedException();
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
            switch (statType) {
                case StatType.Health:
                return baseStats.Get(StatType.Health) + (statPerLevel.Get(StatType.Health) * level);

                case StatType.Mana:
                return baseStats.Get(StatType.Mana) + (statPerLevel.Get(StatType.Mana) * level);

                case StatType.AttackDamage:
                return baseStats.Get(StatType.AttackDamage) + (statPerLevel.Get(StatType.AttackDamage) * level);

                case StatType.AbilityPower:
                return baseStats.Get(StatType.AbilityPower) + (statPerLevel.Get(StatType.AbilityPower) * level);

                case StatType.Armor:
                return baseStats.Get(StatType.Armor) + (statPerLevel.Get(StatType.Armor) * level);

                case StatType.MagicResistance:
                return baseStats.Get(StatType.MagicResistance) + (statPerLevel.Get(StatType.MagicResistance) * level);

                case StatType.AttackSpeed: //Todo: lav beregningen rigtigt
                return baseStats.Get(StatType.AttackSpeed) + (statPerLevel.Get(StatType.AttackSpeed) * level);

                case StatType.CriticalStrikeChance:
                return baseStats.Get(StatType.CriticalStrikeChance) + (statPerLevel.Get(StatType.CriticalStrikeChance) * level);

                case StatType.LifeSteal:
                return baseStats.Get(StatType.LifeSteal) + (statPerLevel.Get(StatType.LifeSteal) * level);

                case StatType.MovementSpeed:
                return baseStats.Get(StatType.MovementSpeed) + (statPerLevel.Get(StatType.MovementSpeed) * level);

                case StatType.CooldownReduction:
                return baseStats.Get(StatType.CooldownReduction) + (statPerLevel.Get(StatType.CooldownReduction) * level);

                case StatType.ManaRegeneration:
                return baseStats.Get(StatType.ManaRegeneration) + (statPerLevel.Get(StatType.ManaRegeneration) * level);

                case StatType.HealthRegeneration:
                return baseStats.Get(StatType.HealthRegeneration) + (statPerLevel.Get(StatType.HealthRegeneration) * level);

                case StatType.Tenacity:
                return baseStats.Get(StatType.Tenacity) + (statPerLevel.Get(StatType.Tenacity) * level);

                case StatType.SlowResistance:
                return baseStats.Get(StatType.SlowResistance) + (statPerLevel.Get(StatType.SlowResistance) * level);

                case StatType.ArmorPenetration:
                return baseStats.Get(StatType.ArmorPenetration) + (statPerLevel.Get(StatType.ArmorPenetration) * level);

                case StatType.MagicPenetration:
                return baseStats.Get(StatType.MagicPenetration) + (statPerLevel.Get(StatType.MagicPenetration) * level);

                case StatType.SpellVamp:
                return baseStats.Get(StatType.SpellVamp) + (statPerLevel.Get(StatType.SpellVamp) * level);

                default:
                return baseStats.Get(statType);
            }
        }

        public void SetStat(StatType type, double value) {
            baseStats.Set(type, value);
        }

        protected virtual void Test() {
            throw new NotImplementedException();
        }

        //--------------UtilityMethods-------------------
        protected virtual void LevelAbilities(int level) {
            throw new NotImplementedException();
        }

    }
}
