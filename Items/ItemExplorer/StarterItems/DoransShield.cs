using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stats;
using System.Threading.Tasks;

namespace Items.ItemExplorer.StarterItems
{
    public class DoransShield : Item {
        private readonly double health = 110;
        //4 health every 5 second
        private readonly double healthPerSec = 0.8;

        public DoransShield() {
            statHandler.Set(StatType.Health, health);
            statHandler.Set(StatType.HealthRegeneration, healthPerSec);
        }
    }
}
