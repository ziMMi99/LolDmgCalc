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
