using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.ItemExplorer.StarterItems
{
    public class DoransBlade : Item {
        private readonly double attackDamage = 10;
        private readonly double health = 80;
        private readonly double lifeSteal = 3;
        
        public DoransBlade() {
            statHandler.Set(StatType.AttackDamage, attackDamage);
            statHandler.Set(StatType.Health, health);
            statHandler.Set(StatType.LifeSteal, lifeSteal);
        }
    }
}
