using Items;

namespace Stats {
    public class StatHandler {
        //A dictionary is an array 'keys' which have a 'value',
        //in this case the 'keys' are the statTypes, which then have a double as their value
        private Dictionary<StatType, double> stats = new Dictionary<StatType, double>();

        //-------------Constructors------------
        /// <summary>
        /// Default Constructor. Clears stats
        /// </summary>
        public StatHandler() {
            //Loops through every key in the stats dictionary
            foreach (var key in stats.Keys) {
                //Sets the value at every key to 0.0
                stats[key] = 0.0;
            }
        }

        /// <summary>
        /// Constructor that takes a dictionary(hashmap) of the stats.
        /// </summary>
        /// <param name="stats"></param>
        public StatHandler(Dictionary<StatType, double> stats) {
            this.stats = stats;
        }

        /// <summary>
        /// Copy Constructor.
        /// </summary>
        /// <param name="stats"></param>
        public StatHandler(StatHandler stats) {
            this.stats = stats.stats;
        }

        //-----------Methods------------

        public double Get(StatType statType) {
            //Returns the double of the requested statType
            return stats[statType];
        }

        public void Set(StatType statType, double value) {
            //Sets the value of the requested statType
            stats[statType] = value;
        }


        //------------Utility Methods--------------


        //------------Operators------------------- currently +-*/

        public static StatHandler operator +(StatHandler a, StatHandler b) {
            StatHandler addedStats = new StatHandler();

            //Loops through every key in the stats dictionary
            foreach (var key in a.stats.Keys) {
                //Adds the two parameter's values for each key
                addedStats.stats[key] = a.stats[key] + b.stats[key];
            }

            return addedStats;
        }

        public static StatHandler operator -(StatHandler a, StatHandler b) {
            StatHandler subtractedStats = new StatHandler();

            //Loops through every key in the stats dictionary
            foreach (var key in a.stats.Keys) {
                //Subtracts the two parameter's values for each key
                subtractedStats.stats[key] = a.stats[key] - b.stats[key];
            }

            return subtractedStats;
        }

        public static StatHandler operator *(StatHandler a, StatHandler b) {
            StatHandler multipliedStats = new StatHandler();

            //Loops through every key in the stats dictionary
            foreach (var key in a.stats.Keys) {
                //Multiplies the two parameter's values for each key
                multipliedStats.stats[key] = a.stats[key] * b.stats[key];
            }

            return multipliedStats;
        }

        public static StatHandler operator /(StatHandler a, StatHandler b) {
            StatHandler dividedStats = new StatHandler();

            //Loops through every key in the stats dictionary
            foreach (var key in a.stats.Keys) {
                //Divides the two parameter's values for each key
                dividedStats.stats[key] = a.stats[key] / b.stats[key];
            }

            return dividedStats;
        }
    }
}
