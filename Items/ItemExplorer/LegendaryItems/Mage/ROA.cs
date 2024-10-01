using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stats;

namespace Items.ItemExplorer.LegendaryItems.Mage
{
    /// <summary>
    /// Rod of Ages
    /// </summary>
    internal class ROA : Item
    {
        private readonly double abilityPower = 50;
        private readonly double health = 400;
        private readonly double mana = 400;

        /// <summary>
        /// Rod of ages has a stacking passive that adds 3 ap, 10 health and 20 mana per stack upto 10 stacks.
        /// Since this is a simulation program, the stacks can be manually set. Otherwise you will get 1 stack per minute
        /// </summary>
        /// <param name="stacks"></param>
        public ROA(double stacks)
        {
            statHandler.Set(StatType.AbilityPower, abilityPower + 3 * stacks);
            statHandler.Set(StatType.Health, health + 10 * stacks);
            statHandler.Set(StatType.Mana, mana + 20 * stacks);
        }
    }
}
