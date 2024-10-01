using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stats;

namespace Items.ItemExplorer.LegendaryItems.Mage
{
    internal class RabadonsDeathcap : Item
    {
        private readonly double abilityPower = 130;

        public RabadonsDeathcap()
        {
            statHandler.Set(StatType.AbilityPower, abilityPower);
        }
        /// <summary>
        /// Passive: Magical Opus 30% ap.
        /// Takes the current ap and returns a new value which has added an extra 30% ap.
        /// </summary>
        /// <param name="ap"></param>
        /// <returns></returns>
        private double PassiveMagicalOpus(double ap)
        {
            return ap * 1.3;
        }
    }
}
