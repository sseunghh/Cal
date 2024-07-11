using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Calculator_Pro.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Calculator_Pro
{

    public partial class Form1 : Form
    {
        string strNumber = "";
        List<string> list = new List<string>();
        double result = 0;

        private History history = new History();

        private void Clicknum(string num)
        {
            if (textBox_output.Text.Contains("="))
            {
                textBox_output.Text = "";
                textBox_input.Text = num;
            }
            else
            {
                textBox_input.Text += num;
            }
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_input.Text, out double result))
            {
                if (radioButton1.Checked) // 2진수
                {
                    textBox_input.Text = Convert.ToString((int)result, 2);
                }
                else if (radioButton2.Checked) // 10진수
                {
                    textBox_input.Text = result.ToString();
                }
                else if (radioButton3.Checked) // 16진수
                {
                    textBox_input.Text = Convert.ToString((int)result, 16).ToUpper();
                }
            }
            else
            {
                MessageBox.Show("유효한 숫자가 아닙니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public Form1()
        {
            InitializeComponent();
            radioButton1.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            radioButton3.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
        }
    }


    private void button10_Click(object sender, EventArgs e)
        {
            textBox_output.Text += textBox_input.Text + "+";
            textBox_input.Text = "";

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_input.Text))
            {
                textBox_output.Text += textBox_input.Text + " = ";
                //strNumber = textBox_output.Text.Substring(0, textBox_output.Text.Length - 3); ;
                //string[] arrStr = strNumber.Split();
                //foreach(string arr in arrStr)
                //{
                //    list.Add(arr);
                //}
                //textBox_output.Text += result.ToString("N0");
                //textBox_input.Text = result.ToString("N0");
                string strCalc = textBox_output.Text.Substring(0, textBox_output.Text.Length - 3); // 이거
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
                // Perform the calculation with operator precedence
                for (int i = 0; i < arrOp.Count; i++)
                {

                    if (arrOp[i] == '×' || arrOp[i] == '÷' || arrOp[i] == '%')

                    {
                        double tempResult = arrNum[i];
                        switch (arrOp[i])
                        {
                            case '×':
                                tempResult *= arrNum[i + 1];
                                break;
                            case '÷':
                                tempResult /= arrNum[i + 1];
                                break;

                            case '%':
                                tempResult %= arrNum[i + 1];
                                break;

                        }
                        arrNum[i] = tempResult;
                        arrNum.RemoveAt(i + 1);
                        arrOp.RemoveAt(i);
                        i--;
                    }


                }

                    // 변동사항


                

                double result = arrNum[0];
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
                // textBox_output.Text += result.ToString("N10").TrimEnd('0').TrimEnd('.');
                textBox_input.Text = result.ToString("N10").TrimEnd('0').TrimEnd('.');
                string historyEntry = $"{strCalc} = {result}";
                history.AddHistory(historyEntry);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_output.Text) && string.IsNullOrEmpty(textBox_input.Text))
            {
                textBox_input.Text += "-";
            }
            else if (!string.IsNullOrEmpty(textBox_input.Text))
            {
                textBox_output.Text += textBox_input.Text + "-";
                textBox_input.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Clicknum("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clicknum("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clicknum("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clicknum("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clicknum("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clicknum("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Clicknum("7");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Clicknum("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Clicknum("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (textBox_input.Text == String.Empty)
            {
                textBox_input.Text = "";
            }
            else
            {
                Clicknum("0");
            }

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
                textBox_output.Text += textBox_input.Text + "×";
                textBox_input.Text = "";
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_input.Text))
            {
                textBox_output.Text += textBox_input.Text+"÷";
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
            Form2 form2 = new Form2();
            form2.Show();
            string historyOutput = history.AllHistory();
            // MessageBox.Show(historyOutput, "History");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
