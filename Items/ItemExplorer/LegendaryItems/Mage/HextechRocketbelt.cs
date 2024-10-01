using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stats;

namespace Items.ItemExplorer.LegendaryItems.Mage
{
    internal class HextechRocketbelt : Item
    {
        private readonly double abilityPower = 60;
        private readonly double health = 350;
        private readonly double abilityHaste = 15;

        public HextechRocketbelt()
        {
            statHandler.Set(StatType.AbilityPower, abilityPower);
            statHandler.Set(StatType.Health, health);
            statHandler.Set(StatType.AbilityHaste, abilityHaste);
        }
        /// <summary>
        /// Returns the calculated damage that the hextech rocketbelt active does.
        /// Takes the current Ap to calculate the total damage of the active.
        /// </summary>
        /// <param name="currentAp"></param>
        /// <returns></returns>
        private double ActiveSupersonic(double currentAp)
        {
            double baseDmg = 100;
            return baseDmg + currentAp * 0.10;
        }
    }
}
