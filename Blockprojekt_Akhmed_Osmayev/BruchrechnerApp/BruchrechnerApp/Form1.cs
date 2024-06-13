using System;
using System.Windows.Forms;

namespace BruchrechnerApp
{
    public partial class Form1 : Form
    {
        private Bruch bruch1;
        private Bruch bruch2;
        private string operation;

        public Form1()
        {
            InitializeComponent();
        }

        private void BerechneErgebnis()
        {
            try
            {
                if (bruch1 == null || bruch2 == null)
                    throw new InvalidOperationException("Beide Brüche müssen definiert sein.");

                Bruch ergebnis;
                switch (operation)
                {
                    case "+":
                        ergebnis = bruch1 + bruch2;
                        break;
                    case "-":
                        ergebnis = bruch1 - bruch2;
                        break;
                    case "*":
                        ergebnis = bruch1 * bruch2;
                        break;
                    case "/":
                        ergebnis = bruch1 / bruch2;
                        break;
                    case "^":
                        int exponent = int.Parse(textBoxZaehler2.Text); // Exponent aus Zähler des zweiten Bruchs
                        ergebnis = bruch1.Potenzieren(exponent);
                        break;
                    default:
                        throw new InvalidOperationException("Ungültige Operation.");
                }

                textBoxErgebnisZaehler.Text = ergebnis.Zaehler.ToString();
                textBoxErgebnisNenner.Text = ergebnis.Nenner.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Button 1 ist Addition also '+'
        {
            operation = "+";
            SetBrueche();
        }

        private void button4_Click(object sender, EventArgs e) // Button 4 ist Subtraktion also '-'
        {
            operation = "-";
            SetBrueche();
        }

        private void button2_Click(object sender, EventArgs e) // Button 2 ist Multiplikation also 'x'
        {
            operation = "*";
            SetBrueche();
        }

        private void button5_Click(object sender, EventArgs e) // Button 5 ist Division also '/'
        {
            operation = "/";
            SetBrueche();
        }

        private void button3_Click(object sender, EventArgs e) // Button 3 ist Potenzieren also '^'
        {
            operation = "^";
            SetBrueche();
        }

        private void button6_Click(object sender, EventArgs e) // Button 6 ist Wurzelziehen also '√'
        {
            try
            {
                int zaehler1 = int.Parse(textBoxZaehler1.Text);
                int nenner1 = int.Parse(textBoxNenner1.Text);

                Bruch bruch1 = new Bruch(zaehler1, nenner1);
                double ergebnis = bruch1.WurzelZiehen();

                textBoxErgebnisZaehler.Text = ergebnis.ToString();
                textBoxErgebnisNenner.Text = "1"; // Wurzel ergibt eine Dezimalzahl, daher Nenner auf 1 setzen
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.Message);
            }
        }

        private void SetBrueche()
        {
            try
            {
                int zaehler1 = int.Parse(textBoxZaehler1.Text);
                int nenner1 = int.Parse(textBoxNenner1.Text);
                int zaehler2 = int.Parse(textBoxZaehler2.Text);
                int nenner2 = int.Parse(textBoxNenner2.Text);

                bruch1 = new Bruch(zaehler1, nenner1);
                bruch2 = new Bruch(zaehler2, nenner2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Setzen der Brüche: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxErgebnisZaehler_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxErgebnisNenner_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxZaehler1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNenner1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonBerechnen_Click(object sender, EventArgs e) // button Berechnen ist istgleich also '='
        {
            BerechneErgebnis();
        }
    }
}
