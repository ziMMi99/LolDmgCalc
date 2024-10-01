using Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions {
    public class Damage {

        /*
         * Usikker på om damage må være negativt eller ej, da det matematisk er praktisk,
         * men kan også blive problematisk, hvis en negativ damage trækker fra noget andet damage i en udregning.
         * Min umidbare tanke er at det er bedst at lave damage kunne blive negativt,
         * men at holde sig ops på det problem når man arbejder med det.
         */

        private double trueDmg;
        private double magicDmg;
        private double physicalDamage;

        //----------Constructors-----------
        public Damage() : this(0, 0, 0) { }

        public Damage(Damage damage) {
            this.trueDmg = damage.trueDmg;
            this.magicDmg = damage.magicDmg;
            this.physicalDamage = damage.physicalDamage;
        }

        public Damage(double trueDmg, double magicDmg, double physicalDamage) {
            this.trueDmg = trueDmg;
            this.magicDmg = magicDmg;
            this.physicalDamage = physicalDamage;
        }

        //-------------Methods---------------------

        public double GetTotalPremitigatedDmg() {
            return trueDmg + magicDmg + physicalDamage;
        }

        public double GetTotalPostmitigatedDmg(Champion target) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes damage based off the targets resistances.
        /// </summary>
        /// <param name="target"></param>
        public void CalcResistances(Champion attacker, Champion target) {
            //-------Variables--------
            //Defensive
            double armor = target.GetStat(StatType.Armor);
            double mr = target.GetStat(StatType.MagicResistance); //mr is short for magic resistance
            //Offensive
            double flatArmorRed = attacker.GetStat(StatType.FlatArmorReduction); //Flat armor reduction
            double pctArmorRed = attacker.GetStat(StatType.PercentageArmorReduction); //Percentage armor reduction
            double pctArmorPen = attacker.GetStat(StatType.PercentageArmorPenetration); //Percentage armor penetration
            double lethality = attacker.GetStat(StatType.Lethality); 
            double flatMrRed = attacker.GetStat(StatType.FlatMagicResistReduction); //Flat mr reduction
            double pctMrRed = attacker.GetStat(StatType.PercentageMagicResistReduction); //Percentage mr reduction
            double pctMrPen = attacker.GetStat(StatType.PercentageMagicPenetration); //Percentage magic penetration
            double flatMrPen = attacker.GetStat(StatType.FlatMagicPenetration); //Flat magic penetration

			//-------Armor reduction and penetration-------
			//--Flat armor reduction--
            armor -= flatArmorRed;
            //--Percentage armor reduction--
            armor = armor * (1-pctArmorRed);
            //--Percentage armor penetration--
            armor = armor * (1 - pctArmorPen);
            //--Flat armor penetration (Lethality)--
            armor -= lethality;


			//-------Magic Resist reduction and penetration-------
			//--Flat magic resist reduction--
            mr -= flatMrRed;
			//--Percentage magic resist reduction--
            mr = mr * (1 - pctMrRed);
			//--Percentage magic penetration--
            mr = mr * (1 - pctMrPen);
			//--Flat magic penetration--
            mr -= flatMrPen;

			//-------Damage mitigation-------

			/*                               raw dmg
             *  post mitigated dmg =  ----------------------
             *                          1 + resistance/100
             */
			physicalDamage = (physicalDamage) / (1 + armor/100);
            magicDmg = (magicDmg) / (1 + mr/100);
        }

        //--------------Getters&Setters---------------
        public double GetDmg(DamageType damageType) {
			switch (damageType) {
				case DamageType.TrueDmg:
				return trueDmg;
				case DamageType.MagicDmg:
				return magicDmg;
				case DamageType.PhysicalDmg:
				return physicalDamage;
                default:
                return 0;
			}
		}
		public void AddDmg(DamageType damageType, double dmg) {
			switch (damageType) {
				case DamageType.TrueDmg:
				trueDmg += dmg;
				break;
				case DamageType.MagicDmg:
				magicDmg += dmg;
				break;
				case DamageType.PhysicalDmg:
				physicalDamage += dmg;
				break;
			}
		}

		public void SetDmg(DamageType damageType, double dmg) {
			switch (damageType) {
				case DamageType.TrueDmg:
				trueDmg = dmg;
				break;
				case DamageType.MagicDmg:
				magicDmg = dmg;
				break;
				case DamageType.PhysicalDmg:
                physicalDamage = dmg;
                break;
			}
		}

		//-------------Operators(+-*/)---------------

		public static Damage operator +(Damage a, Damage b) {
            return new Damage(a.trueDmg + b.trueDmg,
                              a.magicDmg + b.magicDmg,
                              a.physicalDamage + b.physicalDamage);
        }

        public static Damage operator -(Damage a, Damage b) {
            return new Damage(a.trueDmg - b.trueDmg,
                              a.magicDmg - b.magicDmg,
                              a.physicalDamage - b.physicalDamage);
        }

        public static Damage operator *(Damage a, Damage b) {
            return new Damage(a.trueDmg * b.trueDmg,
                              a.magicDmg * b.magicDmg,
                              a.physicalDamage * b.physicalDamage);
        }

        public static Damage operator /(Damage a, Damage b) {
            return new Damage(a.trueDmg / b.trueDmg,
                              a.magicDmg / b.magicDmg,
                              a.physicalDamage / b.physicalDamage);
        }

	}
}
