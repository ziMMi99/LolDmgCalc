using Items;
using Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions.Champions.Specialist {
    internal class Cho_Gath : IChampion {
        private int level;
        private StatHandler stats;
        //todo: noget med range både value'en og om de tæller som melee eller ranged

        public Cho_Gath() {
            level = 18;
            stats = new StatHandler(new Dictionary<StatType, double>() {
                {StatType.Health, 644},
                {StatType.Mana, 270},
                {StatType.AttackDamage, 69},
                {StatType.Armor, 38},
                {StatType.MagicResistance, 32},
                {StatType.AttackSpeed, 0.625},
                {StatType.MovementSpeed, 345},
                {StatType.ManaRegeneration, 7.2},
                {StatType.HealthRegeneration, 9},
                {StatType.HealthPerLevel, 94},
                {StatType.ManaPerLevel, 60},
                {StatType.AttackDamagePerLevel, 4.2},
                {StatType.ArmorPerLevel, 5},
                {StatType.MagicResistancePerLevel, 2.05},
                {StatType.AttackSpeedPerLevel, 0},//Todo: Lav attack speed calculations der er rigtige
                {StatType.ManaRegenerationPerLevel, 0.45},
                {StatType.HealthRegenerationPerLevel, 0.85}
            });
        }


        public void AutoAttack() {
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
