using Champions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolDmgCalc {
    internal class Damage {

        /*
         * Usikker på om damage må være negativt eller ej, da det matematisk er praktisk,
         * men kan også blive problematisk, hvis en negativ damage trækker fra noget andet damage i en udregning.
         * Min umidbare tanke er at det er bedst at lave damage kunne blive negativt,
         * men at holde sig ops på det problem når man arbejder med det.
         */

        private double trueDmg { get => trueDmg; set => trueDmg = value; }
        private double magicDmg { get => magicDmg; set => magicDmg = value; }
        private double physicalDamage { get => physicalDamage; set => physicalDamage = value; }

        //----------Constructors-----------
        public Damage() {
            trueDmg = 0;
            magicDmg = 0;
            physicalDamage = 0;
        }

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
