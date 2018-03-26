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
    public partial class User : Form
    {
        private Data.User userSession;

        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            var softwareList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareList()).Result;
            namelbl.Text = "Logged in as " + userSession.UserName;

            foreach (var software in softwareList)
            {
                ListViewItem lvi = new ListViewItem(software.software_name);

                lvi.SubItems.Add(software.software_acronym);
                lvi.SubItems.Add(software.first_name + " " + software.last_name);
                lvi.SubItems.Add(software.software_province);

                listView1.Items.Add(lvi);
            }
        }

        public void SetUserSession(Data.User _userSession)
        {
            userSession = _userSession;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
