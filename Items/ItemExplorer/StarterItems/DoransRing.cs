using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.ItemExplorer.StarterItems
{
    public class DoransRing : Item {
        private readonly double abillityPower = 18;
        private readonly double health = 90;
        
        public DoransRing() {
            statHandler.Set(StatType.AbilityPower, abillityPower);
            statHandler.Set(StatType.Health, health);
        }
    }
}
