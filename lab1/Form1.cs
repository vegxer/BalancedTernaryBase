using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            menuConvert.PerformClick();
            comboBoxActions.SelectedIndex = 0;
        }

        void buttonToThreeBase_Click(object sender, EventArgs e)
        {
            if (double.TryParse(inputTextbox.Text, out double num))
            {
                try
                {
                    outputTextbox.Text = ConvertTernaryToBalancedTernary(double.Parse(ConvertToBase(inputTextbox.Text, 10, 3))).Replace("!", "-1");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Неверно введено число в десятичной системе счисления", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void buttonToDecimalBase_Click(object sender, EventArgs e)
        {
            if (CheckBalancedTernaryInput(inputTextbox.Text.Replace("-1", "!")))
            {
                try
                {
                    string answer = ConvertToBase(inputTextbox.Text, -3, 10);
                    if (answer.Length > 1 && answer.Substring(0, 2) == "--")
                        answer = answer.Substring(2);
                    outputTextbox.Text = answer;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Неверно введено число в троичной уравновешенной системе счисления", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        bool CheckBalancedTernaryInput(string input)
        {
            return input.Count(chr => chr == ',') <= 1 && input[0] != ',' && input[input.Length - 1] != ','
                && input.All(chr => chr == '0' || chr == '!' || chr == '1' || chr == ',');
        }

        string ConvertTernaryToBalancedTernary(double num)
        {
            StringBuilder number = new StringBuilder(Math.Abs(num).ToString());
            string balancedNumber = "";
            int carryover = 0;

            for (int i = number.Length - 1; i >= 0; --i)
            {
                if (number[i] == ',')
                    balancedNumber = "," + balancedNumber;
                else
                {
                    number[i] = (int.Parse(number[i].ToString()) + carryover).ToString()[0];

                    carryover = 0;

                    if (int.Parse(number[i].ToString()) > 1)
                    {
                        balancedNumber = (number[i] == '2' ? "!" : "0") + balancedNumber;
                        carryover = 1;
                    }
                    else
                        balancedNumber = number[i] + balancedNumber;
                }
            }

            balancedNumber = (carryover.ToString() == "0" ? "" : carryover.ToString()) + balancedNumber;

            if (num < 0)
                balancedNumber = ReverseNumber(balancedNumber);

            return balancedNumber;
        }

        private string ReverseNumber(string number)
        {
            for (int i = 0; i < number.Length; ++i)
            {
                if (number[i] == '!')
                    number = number.Remove(i, 1).Insert(i, "1");
                else if (number[i] == '1')
                    number = number.Remove(i, 1).Insert(i, "!");
            }

            return number;
        }

        private string DigitSum(char a, char b)
        {
            if (a == '!' && b == '!')
                return "!1";
            else if (a == '1' && b == '1')
                return "1!";
            else return (int.Parse(a.ToString().Replace("!", "-1")) + int.Parse(b.ToString().Replace("!", "-1")))
                    .ToString().Replace("-1", "!");
        }

        private string Add(string a, string b)
        {
            if (!CheckBalancedTernaryInput(a) || !CheckBalancedTernaryInput(b))
                throw new ArgumentException("Неверно введено число в троичной уравновешенной системе счисления");

            a = RemovePointlessZeroes(a);
            b = RemovePointlessZeroes(b);

            EqualizeNumbersLengths(ref a, ref b);
            char carryover = '0';
            string sum = "";
            string currSum = "";

            for (int i = a.Length - 1; i >= 0; --i)
            {
                if (a[i] != ',')
                {
                    currSum = DigitSum(a[i], b[i]);
                    if (currSum.Length > 1)
                        currSum = RemovePointlessZeroes(Add(currSum, carryover.ToString()));
                    else
                        currSum = DigitSum(currSum[0], carryover);
                    carryover = currSum.Length > 1 ? currSum[0] : '0';
                    sum = currSum[currSum.Length - 1] + sum;
                }
                else
                    sum = "," + sum;
            }

            if (carryover == '0')
                sum = RemovePointlessZeroes(sum);

            return carryover == '0' ? sum : (carryover.ToString() + sum);
        }

        private string Multiply(string a, string b)
        {
            if (!CheckBalancedTernaryInput(a) || !CheckBalancedTernaryInput(a))
                throw new ArgumentException("Неверно введено число в троичной уравновешенной системе счисления");

            a = RemovePointlessZeroes(a);
            b = RemovePointlessZeroes(b);

            EqualizeNumbersLengths(ref a, ref b);
            string result = "0";
            int zeroCount = 0;

            for (int i = a.Length - 1; i >= 0; --i)
            {
                string multiplication = "";
                if (a[i] != ',')
                {
                    for (int j = a.Length - 1; j >= 0; --j)
                        if (b[j] != ',')
                            multiplication = (int.Parse(b[i].ToString().Replace("!", "-1")) * int.Parse(a[j].ToString().Replace("!", "-1"))).ToString() + multiplication;

                    result = Add(result, multiplication + new string('0', zeroCount++));
                }
            }

            return RemovePointlessZeroes(result.Insert(result.Length - GetCommaIndexFromEnd(a, b), ","));
        }

        private int GetCommaIndexFromEnd(string a, string b)
        {
            int index = 0;

            if (a.IndexOf(',') != -1)
                index += a.Substring(a.IndexOf(',') + 1).Length;
            if (b.IndexOf(',') != -1)
                index += b.Substring(b.IndexOf(',') + 1).Length;

            return index;
        }

        private string RemovePointlessZeroes(string num)
        {
            num = num.TrimStart('0');
            if (num.Length == 0)
                num = "0";
            if (num.Length > 0 && num[0] == ',')
                num = "0" + num;
            if (num.IndexOf(',') != -1)
                num = num.TrimEnd('0');
            if (num.Length > 0 && num[num.Length - 1] == ',')
                num = num.TrimEnd(',');

            return num;
        }

        private string Subtract(string a, string b)
        {
            return Add(a, ReverseNumber(b));
        }

        private void EqualizeNumbersLengths(ref string a, ref string b)
        {
            if (GetIntPartLength(a) != GetIntPartLength(b))
            {
                if (GetIntPartLength(a) > GetIntPartLength(b))
                    b = new string('0', GetIntPartLength(a) - GetIntPartLength(b)) + b;
                else
                    a = new string('0', GetIntPartLength(b) - GetIntPartLength(a)) + a;
            }

            if (GetFractPartLength(a) != GetFractPartLength(b))
            {
                if (a.IndexOf(',') == -1)
                    a += ",";
                if (b.IndexOf(',') == -1)
                    b += ",";

                if (GetFractPartLength(a) > GetFractPartLength(b))
                    b += new string('0', GetFractPartLength(a) - GetFractPartLength(b));
                else
                    a += new string('0', GetFractPartLength(b) - GetFractPartLength(a));
            }
        }

        private int GetIntPartLength(string a)
        {
            a += ",";
            return a.Substring(0, a.IndexOf(',')).Length;
        }

        private int GetFractPartLength(string a)
        {
            a += ",";
            return a.Substring(a.IndexOf(',')).Length - 1;
        }

        string ConvertToBase(string number, int from, int to)
        {
            if (!((from == 10 && to == 3) || (from == -3 && to == 10)))
                throw new ArgumentException("Неверные системы счисления");

            string minus = "";
            if ((from == -3 && number[0] == '-' && number[1] == '-') || (from == 10 && double.Parse(number) < 0))
            {
                number = number.Remove(0, 1);
                minus = "-";
            }

            string decimalPart = ",0", intPart = "";

            if (from == -3)
                number = number.Replace("-1", "!");

            if (number.IndexOf(',') > 0)
            {
                decimalPart = ConvertFractionalPartToBase(number.Substring(number.IndexOf(',') + 1), from, to);
                number = number.Substring(0, number.IndexOf(','));
            }

            intPart = ConvertIntegerPartToBase(number, from, to);

            if (to == 10)
                return minus + (double.Parse(intPart) + double.Parse(decimalPart)).ToString();
            return minus + intPart + decimalPart;
        }

        string ConvertFractionalPartToBase(string number, int from, int to)
        {
            double decNumber = ConvertFractionalPartToDecimal(number, from);
            string decimalPart = "";

            if (to != 10)
            {
                for (double decPart = decNumber; decimalPart.Length < 16 && decPart != 0; decPart -= (int)decPart)
                {
                    decPart *= to;
                    decimalPart += ((int)decPart).ToString();
                }
            }
            else
                return decNumber.ToString().Replace("0", "");

            return "," + decimalPart;
        }

        double ConvertFractionalPartToDecimal(string number, int from)
        {
            double result = 0;

            for (int i = 0; i < number.Length; ++i)
                result += (number[i] == '!' ? -1 : int.Parse(number[i].ToString())) * Math.Pow(Math.Abs(from), -i - 1);

            return Math.Round(result, 15);
        }

        string ConvertIntegerPartToBase(string number, int from, int to)
        {
            if (from == 10 && to == 3)
            {
                int num = Math.Abs(int.Parse(number));
                string intPart = "";

                while (num != 0)
                {
                    intPart = (num % 3).ToString() + intPart;
                    num /= 3;
                }

                return intPart;
            }
            else
            {
                double result = 0;

                for (int i = number.Length - 1; i >= 0; --i)
                    result += (number[i] == '!' ? -1 : int.Parse(number[i].ToString())) * Math.Pow(Math.Abs(from), number.Length - i - 1);

                return result.ToString();
            }
        }

        private void inputTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ',' || e.KeyChar == 8 || e.KeyChar == '-');
        }

        private void menuConvert_Click(object sender, EventArgs e)
        {
            menuArithAction.Checked = false;
            EnableConvertControls();
            DisableArithControls();
            Width = 690;
        }

        private void menuArithAction_Click(object sender, EventArgs e)
        {
            menuConvert.Checked = false;
            DisableConvertControls();
            EnableArithControls();
            Width = 780;
            //comboBoxActions.SelectedIndex = 0;
        }

        private void DisableConvertControls()
        {
            label1.Visible = label2.Visible = outputTextbox.Visible = inputTextbox.Visible
                = buttonToDecimalBase.Visible = buttonToThreeBase.Visible = false;
        }

        private void EnableConvertControls()
        {
            label1.Visible = label2.Visible = outputTextbox.Visible = inputTextbox.Visible
                = buttonToDecimalBase.Visible = buttonToThreeBase.Visible = true;
        }

        private void DisableArithControls()
        {
            textBoxFirst.Visible = textBoxSecond.Visible = textBoxResult.Visible
                = comboBoxActions.Visible = labelEquality.Visible = false;
        }

        private void EnableArithControls()
        {
            textBoxFirst.Visible = textBoxSecond.Visible = textBoxResult.Visible
                = comboBoxActions.Visible = labelEquality.Visible = true;
        }

        private void textBoxFirst_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxFirst.Text) && !string.IsNullOrWhiteSpace(textBoxSecond.Text))
            {
                try
                {
                    if (comboBoxActions.SelectedIndex == 0)
                        textBoxResult.Text = Add(textBoxFirst.Text.Replace("-1", "!"), textBoxSecond.Text.Replace("-1", "!")).Replace("!", "-1");
                    else if (comboBoxActions.SelectedIndex == 1)
                        textBoxResult.Text = Subtract(textBoxFirst.Text.Replace("-1", "!"), textBoxSecond.Text.Replace("-1", "!")).Replace("!", "-1");
                    else
                    {
                        textBoxResult.Text = Multiply(textBoxFirst.Text.Replace("-1", "!"), textBoxSecond.Text.Replace("-1", "!")).Replace("!", "-1");
                    }
                }
                catch (Exception error)
                {
                    textBoxResult.Text = error.Message.ToString();
                }
            }
        }

        private void textBoxFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(e.KeyChar == '0' || e.KeyChar == '1' || e.KeyChar == ',' || e.KeyChar == '-' || e.KeyChar == 8);
        }
    }
}
