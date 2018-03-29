using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HELLs_FrontEnd
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder Errors = new StringBuilder();

            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Errors.Append("Password field is empty!\n");
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                Errors.Append("Username field is empty!\n");
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                Errors.Append("Email field is empty!\n");
            }

            if (textBox1.Text != textBox2.Text)
            {
                Errors.Append("Passwords do not match!\n");
            }

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool success = Task.Run(() => Web.SignupRequest.Signup(textBox4.Text, textBox1.Text, textBox3.Text)).Result;

                if (success)
                {
                    MessageBox.Show("Registeration success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Registeration failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }
    }
}
