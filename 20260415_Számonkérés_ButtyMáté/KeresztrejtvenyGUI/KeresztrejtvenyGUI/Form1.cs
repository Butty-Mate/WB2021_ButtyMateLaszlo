using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeresztrejtvenyGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "15";
            comboBox2.Text = "15";
            comboBox3.Text = "3";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[,] text = new TextBox[16, 16];
            int a = int.Parse(comboBox1.Text);
            int b = int.Parse(comboBox2.Text);
            if (a < b) a = b;

            for (int i = 1; i < a; i++)
            {
                for (int j = 1; j < b; j++)
                {
                    text[a, b] = new System.Windows.Forms.TextBox();
                    text[a,b].BackColor = System.Drawing.SystemColors.Menu;
                    text[a,b].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    text[a,b].Location = new System.Drawing.Point(46+a, 26);
                    text[a,b].Name = "textBox1";
                    text[a,b].Size = new System.Drawing.Size(192, 13);
                    text[a,b].TabIndex = 0;
                }
            }
        }
    }
}
