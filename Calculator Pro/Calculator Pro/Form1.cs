using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Pro
{
    public class History
    {
        private List<string> historyList = new List<string>();
        public void AddHistory(string history)
        {
            if (historyList.Count >= 5)
            {
                historyList.RemoveAt(0);
            }
            historyList.Add(history);
        }
        public string AllHistory()
        {
            return string.Join("\n", historyList);
        }
    }

    public partial class Form1 : Form
    {
        string strNumber = "";
        List<string> list = new List<string>();
        double result = 0;

        private History history = new History();

        public Form1()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_input.Text))
            {
                textBox_output.Text += textBox_input.Text + "+";
                textBox_input.Text = "";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox_output.Text += textBox_input.Text + " = ";
            string strCalc = textBox_output.Text.Substring(0, textBox_output.Text.Length - 3);
            char[] arrCalc = strCalc.ToCharArray();
            List<double> arrNum = new List<double>();
            List<char> arrOp = new List<char>();
            string currentNum = "";

            foreach (char ch in arrCalc)
            {
                if (char.IsDigit(ch) || ch == '.' || (ch == '-' && currentNum == ""))
                {
                    currentNum += ch;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentNum))
                    {
                        arrNum.Add(double.Parse(currentNum));
                        currentNum = "";
                    }
                    arrOp.Add(ch);
                }
            }
            if (!string.IsNullOrEmpty(currentNum))
            {
                arrNum.Add(double.Parse(currentNum));
            }

            for (int i = 0; i < arrOp.Count; i++)
            {
                if (arrOp[i] == '¡¿' || arrOp[i] == '¡À')
                {
                    double tempResult = arrNum[i];
                    switch (arrOp[i])
                    {
                        case '¡¿':
                            tempResult *= arrNum[i + 1];
                            break;
                        case '¡À':
                            tempResult /= arrNum[i + 1];
                            break;
                    }
                    arrNum[i] = tempResult;
                    arrNum.RemoveAt(i + 1);
                    arrOp.RemoveAt(i);
                    i--;
                }
            }

            result = arrNum[0];
            for (int i = 0; i < arrOp.Count; i++)
            {
                switch (arrOp[i])
                {
                    case '+':
                        result += arrNum[i + 1];
                        break;
                    case '-':
                        result -= arrNum[i + 1];
                        break;
                }
            }

            textBox_input.Text = result.ToString("N0");
            string historyEntry = $"{strCalc} = {result}";
            history.AddHistory(historyEntry);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox_input.Text == "-")
            {
                // Remove the minus sign if already present
                textBox_input.Text = "";
            }
            else if (string.IsNullOrEmpty(textBox_input.Text))
            {
                textBox_input.Text = "-";
            }
            else
            {
                textBox_output.Text += textBox_input.Text + "-";
                textBox_input.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "0";
        }

        private void textBox_output_TextChanged(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_input.Text))
            {
                if (!textBox_input.Text.Contains("."))
                {
                    textBox_input.Text += ".";
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_input.Text))
            {
                textBox_output.Text += textBox_input.Text + "¡¿";
                textBox_input.Text = "";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_input.Text))
            {
                textBox_output.Text += textBox_input.Text + "¡À";
                textBox_input.Text = "";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_input.Text))
            {
                textBox_output.Text += textBox_input.Text + "%";
                textBox_input.Text = "";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_input.Text))
            {
                string check = textBox_input.Text.ToString();
                textBox_input.Text = check.Substring(0, check.Length - 1);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox_input.Text = "";
            textBox_output.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string historyOutput = history.AllHistory();
            MessageBox.Show(historyOutput, "History");
        }
    }
}
