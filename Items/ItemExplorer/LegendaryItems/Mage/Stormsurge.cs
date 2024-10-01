using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stats;

namespace Items.ItemExplorer.LegendaryItems.Mage {

  /// <summary>
  /// Stormsurge
  /// </summary>
  internal class Stormsurge : Item {
    private readonly double abilityPower = 95;
    private readonly double magicPen = 15;
    private readonly double movementSpeedPercent = 4;

    public Stormsurge(double currentMovemenSpeed) {
      statHandler.Set(StatType.AbilityPower, abilityPower);
      statHandler.Set(StatType.MagicPenetration, magicPen);
      statHandler.Set(StatType.MovementSpeedPercentage, movementSpeedPercent);
    }

    /// <summary>
    /// Since this is a dmg simulation program, we assume that the passive is always gonna be activated.
    /// </summary>
    /// <param name="currentAp"></param>
    /// <returns></returns>
    private double PassiveSquall(double currentAp) {
      double baseDmg = 150;

      return 150 * 1.15;
    }
  }
}
