using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator_Pro
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        public void AddHistory(string historyOutput)
        {
            listBox.Items.Clear();
            string[] historyEntries = historyOutput.Split(new[] { '\n' }, StringSplitOptions.None);
            foreach (var entry in historyEntries)
            {
                if (!string.IsNullOrWhiteSpace(entry))
                {
                    listBox.Items.Add(entry.Trim());
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
        }
    }
}
