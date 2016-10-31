using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Molles_Moms
{
    public partial class Form1 : Form
    {

        public bool MomsTil = false;
        public float input = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "0";
            input = float.Parse(textBox1.Text);
            MOMS(input);
        }
        private void MOMS(float input)
        {
            if (MomsTil == false)
            {
                float MOMS = ((float)input) * 20 / 100;
                float Base = input - MOMS;
                
                MomsAmount.Text = MOMS.ToString("C", CultureInfo.CurrentCulture) ;
                BaseAmount.Text = Base.ToString("C", CultureInfo.CurrentCulture);
            }
            else
            {
                float MOMS = ((float)input) * 25 / 100; ;
                float Base = input + MOMS;

                MomsAmount.Text = MOMS.ToString("C", CultureInfo.CurrentCulture);
                BaseAmount.Text = Base.ToString("C", CultureInfo.CurrentCulture);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MomsTil = false;
            label3.Text = "Beløb uden MOMS";
            textBox1.Focus();
            MOMS(input);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MomsTil = true;
            label3.Text = "Beløb med MOMS";
            textBox1.Focus();
            MOMS(input);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == 8)
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}
