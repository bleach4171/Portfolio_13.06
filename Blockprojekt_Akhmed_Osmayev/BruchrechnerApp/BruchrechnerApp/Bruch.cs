using System;

namespace BruchrechnerApp
{
    public class Bruch
    {
        private int zaehler;
        private int nenner;

        public Bruch(int zaehler, int nenner)
        {
            this.zaehler = zaehler;
            this.nenner = nenner;
            Kuerzen();
        }

        public void Kuerzen()
        {
            int ggt = GGT(Math.Abs(zaehler), Math.Abs(nenner));
            zaehler /= ggt;
            nenner /= ggt;
        }

        private int GGT(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Bruch operator +(Bruch bruch1, Bruch bruch2)
        {
            int neuerNenner = bruch1.nenner * bruch2.nenner;
            int neuerZaehler = bruch1.zaehler * bruch2.nenner + bruch2.zaehler * bruch1.nenner;
            return new Bruch(neuerZaehler, neuerNenner);
        }

        public static Bruch operator -(Bruch bruch1, Bruch bruch2)
        {
            int neuerNenner = bruch1.nenner * bruch2.nenner;
            int neuerZaehler = bruch1.zaehler * bruch2.nenner - bruch2.zaehler * bruch1.nenner;
            return new Bruch(neuerZaehler, neuerNenner);
        }

        public static Bruch operator *(Bruch bruch1, Bruch bruch2)
        {
            int neuerNenner = bruch1.nenner * bruch2.nenner;
            int neuerZaehler = bruch1.zaehler * bruch2.zaehler;
            return new Bruch(neuerZaehler, neuerNenner);
        }

        public static Bruch operator /(Bruch bruch1, Bruch bruch2)
        {
            int neuerNenner = bruch1.nenner * bruch2.zaehler;
            int neuerZaehler = bruch1.zaehler * bruch2.nenner;
            return new Bruch(neuerZaehler, neuerNenner);
        }

        public double WurzelZiehen()
        {
            return Math.Sqrt((double)zaehler / nenner);
        }

        public Bruch Potenzieren(int exponent)
        {
            int neuerZaehler = (int)Math.Pow(zaehler, exponent);
            int neuerNenner = (int)Math.Pow(nenner, exponent);
            return new Bruch(neuerZaehler, neuerNenner);
        }

        public override string ToString()
        {
            return $"{zaehler}/{nenner}";
        }

        public int Zaehler
        {
            get { return zaehler; }
            set
            {
                zaehler = value;
                Kuerzen();
            }
        }

        public int Nenner
        {
            get { return nenner; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Nenner darf nicht 0 sein.");
                nenner = value;
                Kuerzen();
            }
        }
    }
}
