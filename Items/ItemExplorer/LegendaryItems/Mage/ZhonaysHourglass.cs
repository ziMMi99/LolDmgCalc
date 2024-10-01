using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stats;

namespace Items.ItemExplorer.LegendaryItems.Mage
{
    internal class ZhonaysHourglass : Item
    {
        private readonly double abilityPower = 105;
        private readonly double armor = 50;

        public ZhonaysHourglass()
        {
            statHandler.Set(StatType.AbilityPower, abilityPower);
            statHandler.Set(StatType.Armor, armor);
        }
    }
}
