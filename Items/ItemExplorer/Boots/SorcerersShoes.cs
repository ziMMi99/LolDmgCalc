using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stats;

namespace Items.ItemExplorer.Boots {
  internal class SorcerersShoes : Item {
    private readonly double magicPen = 15;
    private readonly double movementSpeed = 45;

    public SorcerersShoes() {
      statHandler.Set(StatType.MagicPenetration, magicPen);
      statHandler.Set(StatType.MovementSpeed, movementSpeed);
    }
  }
}
