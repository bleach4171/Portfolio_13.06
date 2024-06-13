using System;
using System.Windows.Forms;

namespace ZahlensystemumrechnerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private int GetSelectedBase()
        {
            if (radioButton1.Checked) return 2;
            if (radioButton2.Checked) return 8;
            if (radioButton3.Checked) return 10;
            if (radioButton4.Checked) return 16;
            throw new InvalidOperationException("Kein Zahlensystem ausgewählt!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerformOperation((num1, num2) => num1 + num2, "Addition");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformOperation((num1, num2) => num1 - num2, "Subtraktion");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PerformOperation((num1, num2) => num1 * num2, "Multiplikation");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PerformOperation((num1, num2) => num1 / num2, "Division");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConvertAndDisplay(num => num.ToBinary(), "Binär");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ConvertAndDisplay(num => num.ToOctal(), "Oktal");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ConvertAndDisplay(num => num.ToDecimal(), "Dezimal");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ConvertAndDisplay(num => num.ToHexadecimal(), "Hexadezimal");
        }

        private void PerformOperation(Func<NummerSystem, NummerSystem, NummerSystem> operation, string operationName)
        {
            try
            {
                int baseValue = GetSelectedBase();
                NummerSystem num1 = new NummerSystem(textBox1.Text, baseValue);
                NummerSystem num2 = new NummerSystem(textBox2.Text, baseValue);

                NummerSystem result = operation(num1, num2);
                textBox3.Text = result.ToDecimal(); // Ergebnis in Dezimal anzeigen
                MessageBox.Show($"{operationName}: {result.GetValue()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.Message);
            }
        }

        private void ConvertAndDisplay(Func<NummerSystem, string> conversionFunc, string conversionName)
        {
            try
            {
                int baseValue = GetSelectedBase();
                NummerSystem num1 = new NummerSystem(textBox1.Text, baseValue);

                string result = conversionFunc(num1);
                textBox3.Text = result;
                MessageBox.Show($"{conversionName}: {result}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.Message);
            }
        }

        // Event-Handler Methoden
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Platzhalter für das TextChanged-Ereignis von textBox1
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Platzhalter für das TextChanged-Ereignis von textBox2
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Platzhalter für das TextChanged-Ereignis von textBox3
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Platzhalter für das CheckedChanged-Ereignis von radioButton1
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Platzhalter für das CheckedChanged-Ereignis von radioButton2
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // Platzhalter für das CheckedChanged-Ereignis von radioButton3
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            // Platzhalter für das CheckedChanged-Ereignis von radioButton4
        }
    }

    class NummerSystem
    {
        private string value;
        private int baseValue;

        public NummerSystem(string value, int baseValue)
        {
            this.value = value.ToUpper();
            this.baseValue = baseValue;
        }

        public string GetValue()
        {
            return value;
        }

        private int ToDecimalValue()
        {
            return Convert.ToInt32(value, baseValue);
        }

        public string ToBinary()
        {
            return Convert.ToString(ToDecimalValue(), 2);
        }

        public string ToOctal()
        {
            return Convert.ToString(ToDecimalValue(), 8);
        }

        public string ToDecimal()
        {
            return ToDecimalValue().ToString();
        }

        public string ToHexadecimal()
        {
            return Convert.ToString(ToDecimalValue(), 16).ToUpper();
        }

        public static NummerSystem operator +(NummerSystem num1, NummerSystem num2)
        {
            int result = num1.ToDecimalValue() + num2.ToDecimalValue();
            return new NummerSystem(result.ToString(), 10);
        }

        public static NummerSystem operator -(NummerSystem num1, NummerSystem num2)
        {
            int result = num1.ToDecimalValue() - num2.ToDecimalValue();
            return new NummerSystem(result.ToString(), 10);
        }

        public static NummerSystem operator *(NummerSystem num1, NummerSystem num2)
        {
            int result = num1.ToDecimalValue() * num2.ToDecimalValue();
            return new NummerSystem(result.ToString(), 10);
        }

        public static NummerSystem operator /(NummerSystem num1, NummerSystem num2)
        {
            int result = num1.ToDecimalValue() / num2.ToDecimalValue();
            return new NummerSystem(result.ToString(), 10);
        }
    }
}
