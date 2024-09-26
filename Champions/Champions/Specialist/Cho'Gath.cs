using Items;
using Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions.Champions.Specialist {
    internal class Cho_Gath : Champion {
        
        

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


        public override Damage AutoAttack() {
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
    }
}
