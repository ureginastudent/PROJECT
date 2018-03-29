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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            authBox.SelectedIndex = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup signupFrm = new Signup();
            signupFrm.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            object userSession = null;

            if (authBox.SelectedIndex == 2)
            {
                userSession = await Web.LoginRequest.Login<Data.User>(textBox1.Text, textBox2.Text);
                if (userSession != null)
                {
                    User userFrm = new User();
                    userFrm.Closed += (s, args) => this.Close();
                    userFrm.SetUserSession((Data.User)userSession);
                    userFrm.Show();
                }

            }
            else if (authBox.SelectedIndex == 1)
            {
                userSession = await Web.LoginRequest.Login<Data.Approver>(textBox1.Text, textBox2.Text);
                if (userSession != null)
                {
                    Approver userFrm = new Approver();
                    userFrm.Closed += (s, args) => this.Close();
                    userFrm.SetUserSession((Data.Approver)userSession);
                    userFrm.Show();
                }
            }
            else if (authBox.SelectedIndex == 0)
            {
                userSession = await Web.LoginRequest.Login<Data.Analyst>(textBox1.Text, textBox2.Text);
                if (userSession != null)
                {
                    Analyst userFrm = new Analyst();
                    userFrm.Closed += (s, args) => this.Close();
                    userFrm.SetUserSession((Data.Analyst)userSession);
                    userFrm.Show();
                   
                }
            }

            if (userSession == null)
                MessageBox.Show("Invalid login credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.Hide();
            }
            
        }
    }
}
