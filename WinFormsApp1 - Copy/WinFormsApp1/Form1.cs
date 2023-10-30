using System.Data;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string currentCalculation = "";
        Dictionary<double, double> pow_minusOne = new Dictionary<double, double>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text;

            textBox1.Text = currentCalculation;
        }
        private void button_Equals_Click(object sender, EventArgs e)
        {
            string formattedCalculation = currentCalculation.ToString().Replace("×", "*")
                .ToString().Replace("÷", "/").ToString().Replace(",", ".");

            try
            {
                textBox1.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                decimal number = decimal.Parse(textBox1.Text);
                number = Math.Round(number, 11);
                currentCalculation = number.ToString();
                textBox1.Text = currentCalculation;
            }
            catch
            {
                textBox1.Text = "0";
                currentCalculation = "";
            }
        }
        private void button_Clear_Click(object sender, EventArgs e)
        {
            currentCalculation = "";
            textBox1.Text = "0";
            textBox1.Font = new Font(textBox1.Font.FontFamily, 28);
            pow_minusOne.Clear();
        }
        private void button_ClearLastElement_Click(object sender, EventArgs e)
        {
            if (currentCalculation != string.Empty)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1);
                textBox1.Text = currentCalculation;
                int textLength = textBox1.Text.Length;
                int maxLength = 11;
                if (textLength <= maxLength)
                {

                    textBox1.Font = new Font(textBox1.Font.FontFamily, 28);
                }
            }
            else
            {
                textBox1.Text = "0";
                textBox1.Font = new Font(textBox1.Font.FontFamily, 28);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float fontSize = textBox1.Font.Size;
            int textLength = textBox1.Text.Length;
            int maxLength = 11;
            if (textLength > maxLength)
            {
                float newFontSize = (textBox1.Width / textLength) * 0.8f;

                textBox1.Font = new Font(textBox1.Font.FontFamily, newFontSize);
            }
            else if (textLength <= maxLength)
            {
                textBox1.Font = new Font(textBox1.Font.FontFamily, 28);
            }
        }
        private void button_PowerOfMinusOne(object sender, EventArgs e)
        {
            double operate_on = 0;
            for (int i = currentCalculation.Length - 1; i >= 0; i--)
            {
                if (!Char.IsDigit(currentCalculation[i]) && currentCalculation[i] != ',')
                {
                    operate_on += double.Parse(currentCalculation.Substring(i + 1));
                    currentCalculation = currentCalculation.Remove(i + 1);
                    double value = operate_on;
                    operate_on = Math.Pow(operate_on, -1);
                    if (!pow_minusOne.ContainsKey(value) && !pow_minusOne.ContainsValue(value))
                    {
                        pow_minusOne.Add(operate_on, value);
                        pow_minusOne.Add(value, operate_on);
                    }
                    else
                    {
                        operate_on = pow_minusOne[value];
                    }
                    currentCalculation += operate_on.ToString();
                    textBox1.Text = currentCalculation;
                    break;
                }
                if (i == 0)
                {
                    operate_on += double.Parse(currentCalculation.Substring(i));
                    double value = operate_on;
                    operate_on = Math.Pow(operate_on, -1);
                    if (!pow_minusOne.ContainsKey(value) && !pow_minusOne.ContainsValue(value))
                    {
                        pow_minusOne.Add(operate_on, value);
                        pow_minusOne.Add(value, operate_on);
                    }
                    else
                    {
                        operate_on = pow_minusOne[value];
                    }
                    currentCalculation = operate_on.ToString();
                    textBox1.Text = currentCalculation;
                    break;
                }
            }
        }
        private void button_PowerOfTwo(object sender, EventArgs e)
        {
            double operate_on = 0;
            for (int i = currentCalculation.Length - 1; i >= 0; i--)
            {
                if (!Char.IsDigit(currentCalculation[i]) && currentCalculation[i] != ',')
                {
                    operate_on += double.Parse(currentCalculation.Substring(i + 1));
                    currentCalculation = currentCalculation.Remove(i + 1);
                    double value = operate_on;
                    operate_on = Math.Pow(operate_on, 2);
                    currentCalculation += operate_on.ToString();
                    textBox1.Text = currentCalculation;
                    break;
                }
                if (i == 0)
                {
                    operate_on += double.Parse(currentCalculation.Substring(i));
                    double value = operate_on;
                    operate_on = Math.Pow(operate_on, 2);
                    currentCalculation = operate_on.ToString();
                    textBox1.Text = currentCalculation;
                    break;
                }
            }
        }
        private void button_PowerOfThree(object sender, EventArgs e)
        {
            double operate_on = 0;
            for (int i = currentCalculation.Length - 1; i >= 0; i--)
            {
                if (!Char.IsDigit(currentCalculation[i]) && currentCalculation[i] != ',')
                {
                    operate_on += double.Parse(currentCalculation.Substring(i + 1));
                    currentCalculation = currentCalculation.Remove(i + 1);
                    double value = operate_on;
                    operate_on = Math.Pow(operate_on, 3);
                    currentCalculation += operate_on.ToString();
                    textBox1.Text = currentCalculation;
                    break;
                }
                if (i == 0)
                {
                    operate_on += double.Parse(currentCalculation.Substring(i));
                    double value = operate_on;
                    operate_on = Math.Pow(operate_on, 3);
                    currentCalculation = operate_on.ToString();
                    textBox1.Text = currentCalculation;
                    break;
                }
            }
        }
        private void button_RootNumber(object sender, EventArgs e)
        {
            double operate_on = 0;
            for (int i = currentCalculation.Length - 1; i >= 0; i--)
            {
                if (!Char.IsDigit(currentCalculation[i]) && currentCalculation[i] != ',')
                {
                    operate_on += double.Parse(currentCalculation.Substring(i + 1));
                    currentCalculation = currentCalculation.Remove(i + 1);
                    double value = operate_on;
                    operate_on = Math.Pow(operate_on, 0.5);
                    currentCalculation += operate_on.ToString();
                    textBox1.Text = currentCalculation;
                    break;
                }
                if (i == 0)
                {
                    operate_on += double.Parse(currentCalculation.Substring(i));
                    double value = operate_on;
                    operate_on = Math.Pow(operate_on, 0.5);
                    currentCalculation = operate_on.ToString();
                    textBox1.Text = currentCalculation;
                    break;
                }
            }
        }
        private void button_PercentClick(object sender, EventArgs e)
        {
            double operate_on = 0;
            for (int i = currentCalculation.Length - 1; i >= 0; i--)
            {
                if (!Char.IsDigit(currentCalculation[i]) && currentCalculation[i] != ',')
                {
                    operate_on += double.Parse(currentCalculation.Substring(i + 1));
                    currentCalculation = currentCalculation.Remove(i + 1);
                    operate_on /= 100;
                    currentCalculation += operate_on.ToString();
                    textBox1.Text = currentCalculation;
                    break;
                }
                if (i == 0)
                {
                    operate_on += double.Parse(currentCalculation.Substring(i));
                    operate_on /= 100;
                    currentCalculation = operate_on.ToString();
                    textBox1.Text = currentCalculation;
                    break;
                }
            }
        }
        private void button_Divide_Plus_Mult(object sender, EventArgs e)
        {
            if (currentCalculation != string.Empty &&
                currentCalculation[currentCalculation.Length - 1] != '+' &&
                currentCalculation[currentCalculation.Length - 1] != '-' &&
                currentCalculation[currentCalculation.Length - 1] != '×' &&
                currentCalculation[currentCalculation.Length - 1] != '÷')
            {
                currentCalculation += (sender as Button).Text;

                textBox1.Text = currentCalculation;
            }
        }
        private void button_Minus(object sender, EventArgs e)
        {
            if (currentCalculation == string.Empty)
            {
                currentCalculation += (sender as Button).Text;
                textBox1.Text = currentCalculation;
            }
            else
            {
                int count = 0;
                for (int i = currentCalculation.Length - 1; i >= 0; i--)
                {
                    if (currentCalculation[i] == '-')
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count <= 1)
                {
                    currentCalculation += (sender as Button).Text;
                    textBox1.Text = currentCalculation;
                }
            }
        }
    }
}