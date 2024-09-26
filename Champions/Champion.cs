

using Items;
using Stats;

namespace Champions {
    public abstract class Champion {

        //----------Variables-----------
        internal int level;
        internal StatHandler stats;


        //-----------Methods-------------

        public virtual void AutoAttack() {
            throw new NotImplementedException();
        }
        public void CastQ() {
            throw new NotImplementedException();
        }
        public void CastW() {
            throw new NotImplementedException();
        }

        public void CastE() {
            throw new NotImplementedException();
        }

        public void CastR() {
            throw new NotImplementedException();
        }




        //----------Getters&Setters---------------
        public double GetStat(StatType type) {
            switch (type) {
                case StatType.Health:
                return stats.Get(StatType.Health) + (stats.Get(StatType.HealthPerLevel) * level);

                case StatType.Mana:
                return stats.Get(StatType.Mana) + (stats.Get(StatType.ManaPerLevel) * level);

                case StatType.AttackDamage:
                return stats.Get(StatType.AttackDamage) + (stats.Get(StatType.AttackDamagePerLevel) * level);

                case StatType.AbilityPower:
                return stats.Get(StatType.AbilityPower) + (stats.Get(StatType.AbilityPowerPerLevel) * level);

                case StatType.Armor:
                return stats.Get(StatType.Armor) + (stats.Get(StatType.ArmorPerLevel) * level);

                case StatType.MagicResistance:
                return stats.Get(StatType.MagicResistance) + (stats.Get(StatType.MagicResistancePerLevel) * level);

                case StatType.AttackSpeed: //Todo: lav beregningen rigtigt
                return stats.Get(StatType.AttackSpeed) + (stats.Get(StatType.AttackSpeedPerLevel) * level);

                case StatType.CriticalStrikeChance:
                return stats.Get(StatType.CriticalStrikeChance) + (stats.Get(StatType.CriticalStrikeChancePerLevel) * level);

                case StatType.LifeSteal:
                return stats.Get(StatType.LifeSteal) + (stats.Get(StatType.LifeStealPerLevel) * level);

                case StatType.MovementSpeed:
                return stats.Get(StatType.MovementSpeed) + (stats.Get(StatType.MovementSpeedPerLevel) * level);

                case StatType.CooldownReduction:
                return stats.Get(StatType.CooldownReduction) + (stats.Get(StatType.CooldownReductionPerLevel) * level);

                case StatType.ManaRegeneration:
                return stats.Get(StatType.ManaRegeneration) + (stats.Get(StatType.ManaRegenerationPerLevel) * level);

                case StatType.HealthRegeneration:
                return stats.Get(StatType.HealthRegeneration) + (stats.Get(StatType.HealthRegenerationPerLevel) * level);

                case StatType.Tenacity:
                return stats.Get(StatType.Tenacity) + (stats.Get(StatType.TenacityPerLevel) * level);

                case StatType.SlowResistance:
                return stats.Get(StatType.SlowResistance) + (stats.Get(StatType.SlowResistancePerLevel) * level);

                case StatType.ArmorPenetration:
                return stats.Get(StatType.ArmorPenetration) + (stats.Get(StatType.ArmorPenetrationPerLevel) * level);

                case StatType.MagicPenetration:
                return stats.Get(StatType.MagicPenetration) + (stats.Get(StatType.MagicPenetrationPerLevel) * level);

                case StatType.SpellVamp:
                return stats.Get(StatType.SpellVamp) + (stats.Get(StatType.SpellVampPerLevel) * level);

                default:
                return stats.Get(type);
            }
        }

        public void SetStat(StatType type, double value) {
            stats.Set(type, value);
        }

    }
}
