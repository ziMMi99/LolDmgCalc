using Items;

namespace Stats {
    public class Stats {
        private Dictionary<StatType, double> stats = new Dictionary<StatType, double>();

        //-------------Constructors------------
        /// <summary>
        /// Default Constructor. Clears stats
        /// </summary>
        public Stats() { 
            stats.Clear();
        }

        public Stats(Dictionary<StatType, double> stats) {
            this.stats = stats;
        }
    }
}
