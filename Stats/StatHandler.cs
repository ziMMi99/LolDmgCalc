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
            StatHandler result = new StatHandler();

            //Loops through every key in the stats dictionary
            foreach (var key in a.stats.Keys) {
                //Adds the two parameter's values for each key
                result.stats[key] = a.stats[key] + b.stats[key];
            }

            return result;
        }

        public static StatHandler operator -(StatHandler a, StatHandler b) {
            StatHandler result = new StatHandler();

            //Loops through every key in the stats dictionary
            foreach (var key in a.stats.Keys) {
                //Subtracts the two parameter's values for each key
                result.stats[key] = a.stats[key] - b.stats[key];
            }

            return result;
        }

        public static StatHandler operator *(StatHandler a, StatHandler b) {
            StatHandler result = new StatHandler();

            //Loops through every key in the stats dictionary
            foreach (var key in a.stats.Keys) {
                //Multiplies the two parameter's values for each key
                result.stats[key] = a.stats[key] * b.stats[key];
            }

            return result;
        }

        public static StatHandler operator /(StatHandler a, StatHandler b) {
            StatHandler result = new StatHandler();

            //Loops through every key in the stats dictionary
            foreach (var key in a.stats.Keys) {
                //Divides the two parameter's values for each key
                result.stats[key] = a.stats[key] / b.stats[key];
            }

            return result;
        }
    }
}
