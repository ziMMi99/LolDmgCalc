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
		
		/// <summary>
		/// Returns the specified StatType of an item
		/// </summary>
		/// <param name="statType"></param>
		/// <returns></returns>
		public double Get(StatType statType) {
			return statHandler.Get(statType);
		}

		/// <summary>
		/// Sets the specified statType of and items to the specified value
		/// </summary>
		/// <param name="statType"></param>
		/// <param name="value"></param>
		public void Set(StatType statType, double value) {
			statHandler.Set(statType, value);
		}
	}
}
