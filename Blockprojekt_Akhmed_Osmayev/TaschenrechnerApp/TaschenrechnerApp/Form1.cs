using System;
using System.Data;
using System.Windows.Forms;

namespace TaschenrechnerApp
{
    public partial class Form1 : Form
    {
        private Taschenrechner rechner;
        private string eingabe = "";

        public Form1()
        {
            InitializeComponent();
            rechner = new Taschenrechner();
        }

        private void buttonZahl_Click(object sender, EventArgs e) // Event-Handler für Zahlen-Buttons
        {
            Button btn = sender as Button;
            eingabe += btn.Text;
            textBoxDisplay.Text = eingabe; // Hier wird der Text der TextBox gesetzt
        }

        private void buttonOperation_Click(object sender, EventArgs e) // Event-Handler für Operations-Buttons
        {
            Button btn = sender as Button;
            eingabe += " " + btn.Text + " ";
            textBoxDisplay.Text = eingabe;
        }

        private void buttonGleich_Click(object sender, EventArgs e) // Event-Handler für '='
        {
            try
            {
                double ergebnis = Eval(eingabe);
                textBoxDisplay.Text = ergebnis.ToString();
                eingabe = ergebnis.ToString();
            }
            catch (Exception)
            {
                textBoxDisplay.Text = "Fehler";
            }
        }

        private void buttonKomma_Click(object sender, EventArgs e) // Event-Handler für Beistriche ','
        {
            if (!eingabe.EndsWith(","))
            {
                eingabe += ",";
                textBoxDisplay.Text = eingabe;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e) // Clear Button wo alles gelöscht/cleared werden soll
        {
            eingabe = "";
            textBoxDisplay.Text = "";
        }

        private void buttonNegativ_Click(object sender, EventArgs e) // Ermöglicht es negative Zahlen zu verwenden
        {
            if (eingabe.Length == 0 || eingabe.EndsWith(" "))
            {
                eingabe += "-";
                textBoxDisplay.Text = eingabe;
            }
        }

        private void buttonSpezial_Click(object sender, EventArgs e) // Event-Handler für spezielle Funktionen (Fakultät, Sinus, etc.)
        {
            Button btn = sender as Button;
            string funktion = btn.Text;
            double zahl = Convert.ToDouble(textBoxDisplay.Text);
            double ergebnis = 0.0;

            try
            {
                switch (funktion)
                {
                    case "sin":
                        ergebnis = rechner.Sinus(zahl);
                        break;
                    case "cos":
                        ergebnis = rechner.Cosinus(zahl);
                        break;
                    case "tan":
                        ergebnis = rechner.Tangens(zahl);
                        break;
                    case "√":
                        ergebnis = rechner.WurzelZiehen(zahl);
                        break;
                    case "^":
                        eingabe += "^";
                        textBoxDisplay.Text = eingabe;
                        return;
                    case "log":
                        ergebnis = rechner.Logarithmus(zahl);
                        break;
                    case "n!":
                        ergebnis = rechner.Fakultaet(zahl);
                        break;
                }
            }
            catch (Exception ex)
            {
                textBoxDisplay.Text = "Fehler: " + ex.Message;
                return;
            }

            textBoxDisplay.Text = ergebnis.ToString();
            eingabe = ergebnis.ToString();
        }

        private double Eval(string expression)
        {
            var dataTable = new DataTable();
            return Convert.ToDouble(dataTable.Compute(expression, ""));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hier können Initialisierungen durchgeführt werden, wenn das Formular geladen wird
        }

        private void textBoxDisplay_TextChanged(object sender, EventArgs e) // Textfeld, wo alles eingetippt wird mit Buttons, und Ergebnis ausgegeben wird
        {
            // Hier könnte Logik hinzugefügt werden, wenn der Text in der TextBox sich ändert
        }

        // Dies sind die Event-Handler für die einzelnen Buttons
        private void button1_Click(object sender, EventArgs e) { buttonZahl_Click(sender, e); } // Button für die Zahl 7
        private void button2_Click(object sender, EventArgs e) { buttonZahl_Click(sender, e); } // Button für die Zahl 8
        private void button3_Click(object sender, EventArgs e) { buttonZahl_Click(sender, e); } // Button für die Zahl 9
        private void button4_Click(object sender, EventArgs e) { buttonZahl_Click(sender, e); } // Button für die Zahl 4
        private void button5_Click(object sender, EventArgs e) { buttonZahl_Click(sender, e); } // Button für die Zahl 5
        private void button6_Click(object sender, EventArgs e) { buttonZahl_Click(sender, e); } // Button für die Zahl 6
        private void button7_Click(object sender, EventArgs e) { buttonZahl_Click(sender, e); } // Button für die Zahl 1
        private void button8_Click(object sender, EventArgs e) { buttonZahl_Click(sender, e); } // Button für die Zahl 2
        private void button9_Click(object sender, EventArgs e) { buttonZahl_Click(sender, e); } // Button für die Zahl 3
        private void button10_Click(object sender, EventArgs e) { buttonZahl_Click(sender, e); } // Button für die Zahl 0

        private void button11_Click(object sender, EventArgs e) { buttonKomma_Click(sender, e); } // Button für Beistriche ','
        private void button12_Click(object sender, EventArgs e) { buttonGleich_Click(sender, e); } // Button für '='
        private void button13_Click(object sender, EventArgs e) { buttonClear_Click(sender, e); } // Clear Button
        private void button14_Click(object sender, EventArgs e) { buttonOperation_Click(sender, e); } // Button für Addition '+'
        private void button15_Click(object sender, EventArgs e) { buttonOperation_Click(sender, e); } // Button für Subtraktion '-'
        private void button16_Click(object sender, EventArgs e) { buttonOperation_Click(sender, e); } // Button für Multiplikation 'x'
        private void button17_Click(object sender, EventArgs e) { buttonOperation_Click(sender, e); } // Button für Division '/'

        private void button18_Click(object sender, EventArgs e) { buttonNegativ_Click(sender, e); } // Ermöglicht negative Zahlen
        private void button19_Click(object sender, EventArgs e) { buttonSpezial_Click(sender, e); } // Button für Sinus 'sin'
        private void button20_Click(object sender, EventArgs e) { buttonSpezial_Click(sender, e); } // Button für Wurzelziehen '√'
        private void button21_Click(object sender, EventArgs e) { buttonSpezial_Click(sender, e); } // Button für Logarithmus 'log'
        private void button22_Click(object sender, EventArgs e) { buttonSpezial_Click(sender, e); } // Button für Potenzieren '^'
        private void button23_Click(object sender, EventArgs e) { buttonSpezial_Click(sender, e); } // Button für Fakultät '!'
        private void button24_Click(object sender, EventArgs e) { buttonSpezial_Click(sender, e); } // Button für Cosinus 'cos'
        private void button25_Click(object sender, EventArgs e) { buttonSpezial_Click(sender, e); } // Button für Tangens 'tan'
    }

    public class Taschenrechner
    {
        public double Addition(double x, double y) => x + y;
        public double Subtraktion(double x, double y) => x - y;
        public double Multiplikation(double x, double y) => x * y;
        public double Division(double x, double y) => x / y;

        public double Sinus(double x) => Math.Sin(x);
        public double Cosinus(double x) => Math.Cos(x);
        public double Tangens(double x) => Math.Tan(x);

        public double Potenzieren(double x, double y) => Math.Pow(x, y);
        public double WurzelZiehen(double x) => Math.Sqrt(x);
        public double Logarithmus(double x) => Math.Log(x);

        public double Fakultaet(double x)
        {
            if (x < 0 || x % 1 != 0)
            {
                throw new ArgumentException("Die Fakultät ist nur für nicht-negative ganze Zahlen definiert.");
            }

            int n = (int)x;
            double result = 1;
            for (int i = n; i > 0; i--)
            {
                result *= i;
            }
            return result;
        }
    }
}
