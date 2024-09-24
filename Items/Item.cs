using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items.ItemExplorer.StarterItems;
using Stats;

namespace Items {
	public abstract class Item {
		public StatHandler statHandler = new StatHandler();
		
		public double Get(StatType statType) {
			return statHandler.Get(statType);
		}

		public void Set(StatType statType, double value) {
			statHandler.Set(statType, value);
		}
	}
}
