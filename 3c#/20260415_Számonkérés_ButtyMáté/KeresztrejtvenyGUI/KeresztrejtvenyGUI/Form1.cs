using System;
using System.IO;
using System.Windows.Forms;

namespace KeresztrejtvenyGUI
{
    public partial class Form1 : Form
    {
        TextBox[,] tabla;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sor = Convert.ToInt32(comboBox1.SelectedItem);
            int oszlop = Convert.ToInt32(comboBox2.SelectedItem);

            tabla = new TextBox[sor, oszlop];

            // régi elemek törlése (ha újragenerálod)
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && c != textBox1)
                    this.Controls.Remove(c);
            }

            int startX = 50;
            int startY = 100;

            for (int i = 0; i < sor; i++)
            {
                for (int j = 0; j < oszlop; j++)
                {
                    TextBox tb = new TextBox();

                    tb.Width = 25;
                    tb.Height = 25;
                    tb.Left = startX + j * 27;
                    tb.Top = startY + i * 27;

                    tb.Text = "-";
                    tb.MaxLength = 1;
                    tb.TextAlign = HorizontalAlignment.Center;

                    tb.DoubleClick += (s, ev) =>
                    {
                        tb.Text = tb.Text == "-" ? "#" : "-";
                    };

                    tabla[i, j] = tb;
                    this.Controls.Add(tb);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabla == null) return;

            int index = Convert.ToInt32(comboBox3.SelectedItem);
            string file = $"kr{index}.txt";

            using (StreamWriter sw = new StreamWriter(file))
            {
                for (int i = 0; i < tabla.GetLength(0); i++)
                {
                    string line = "";

                    for (int j = 0; j < tabla.GetLength(1); j++)
                    {
                        line += tabla[i, j].Text;
                    }

                    sw.WriteLine(line);
                }
            }

            MessageBox.Show("Mentés kész!");
        }
    }
}