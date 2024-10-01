using Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions {
	internal class TargetDummy : Champion {

		//---------Constructors----------
		public TargetDummy() : this(5000, 0, 0) { }

		public TargetDummy(double health, double armor, double magicResistance) {
			baseStats = new StatHandler(new Dictionary<StatType, double>() {
				{StatType.Health, health},
				{StatType.Armor, armor},
				{StatType.MagicResistance, magicResistance},
			});
		}

	}
}
