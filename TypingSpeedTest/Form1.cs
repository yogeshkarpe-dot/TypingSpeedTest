using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingSpeedTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] data;
        private void Form1_Load(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            data = input.Split(' ');
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
            textBox2.Focus();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
        }

        private static int Cnt = 60;

        /// <summary>
        /// timer click (added changes from local)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Cnt--;
            textBox3.Text = Cnt.ToString();
            
            if (Cnt < 1)
            {
                int NoOfWrongWords = 0;
                string output = textBox2.Text;
                string[] str = output.Split(' ');
                int Words = str.Length;
                for (int i = 0; i < Words; i++)
                {
                    if (str[i] != data[i])
                    {
                        NoOfWrongWords++;
                    }
                }

                textBox4.Text = Words.ToString();
                float Accuracy = 100 - (Convert.ToSingle(NoOfWrongWords) / Words * 100);
                textBox5.Text = Convert.ToInt32(Accuracy).ToString();

                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;

                textBox4.Visible = true;
                textBox5.Visible = true;

                textBox2.Text = "";
                textBox2.ReadOnly = true;
                timer1.Enabled = false;
                button2.Visible = true;
                Cnt = 60;
            }
        }

        /// <summary>
        /// used for timer (new changes added)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            textBox4.Visible = false;
            textBox5.Visible = false;

            
            textBox3.Text = "";
            button2.Visible = false;
        }
    }
}
