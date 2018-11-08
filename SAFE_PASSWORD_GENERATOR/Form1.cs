using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Media;

namespace SAFE_PASSWORD_GENERATOR
{
    public partial class Form1 : Form
    {
        SoundPlayer player = new SoundPlayer(SAFE_PASSWORD_GENERATOR.Properties.Resources.keygen);
        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.PlayLooping();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (!(int.Parse(textBox2.Text) > 256 || int.Parse(textBox2.Text) < 3))
                {
                    Random r = new Random();
                    StringBuilder stodvacetosmbit = new StringBuilder();
                    String letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    String special_char = "#?!";
                    char[] first_code = ("0123456789" + letters + special_char).ToCharArray();
                    for (int i = 0; i < int.Parse(textBox2.Text); i++)
                    {
                        stodvacetosmbit.Append(first_code[(r.Next(first_code.Length))]);
                    }
                    MessageBox.Show("Lenght of Your Password is " + textBox2.Text, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = stodvacetosmbit.ToString();
                }else{
                    MessageBox.Show("Your Integer is " + textBox2.Text + " but must be lower then 256 and higher then 3.Minimum save password is 15 power.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You must write power of your password !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != null)
            {
                Clipboard.SetText(textBox1.Text);
                MessageBox.Show("Your password was Copied !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You can't copy password when password not generated !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
