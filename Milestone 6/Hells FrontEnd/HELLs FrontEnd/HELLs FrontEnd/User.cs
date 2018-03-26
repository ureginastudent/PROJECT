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
        private CollectionList<ListViewItem> pendingItems = new CollectionList<ListViewItem>();
        private List<Web.Software.RootObject> softwareList;

        public User()
        {
            InitializeComponent();
        }

        private void OnPendingAdd(object sender, EventArgs e)
        {
            listView2.Items.Add((ListViewItem)sender);
        }

        private void User_Load(object sender, EventArgs e)
        {
            softwareList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareList()).Result;


            if (softwareList == null)
            {
                MessageBox.Show("Error retrieving software list, closing");
                this.Close();
            }

            namelbl.Text = "Logged in as " + userSession.UserName;
            pendingItems.OnAdd += new EventHandler(OnPendingAdd);

            foreach (var software in softwareList)
            {
                ListViewItem lvi = new ListViewItem(software.software_name);

                lvi.SubItems.Add(software.software_acronym);
                lvi.SubItems.Add(software.first_name + " " + software.last_name);
                lvi.SubItems.Add(software.software_province);

                listView1.Items.Add(lvi);
            }

            var softwareRequestList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareRequests(userSession.Id.ToString())).Result;

            if (softwareRequestList.Count > 0)
            {
                foreach (var softwareRequest in softwareRequestList)
                {
                    foreach (var software in softwareList)
                    {
                        if (softwareRequest.software_id == software.software_id && softwareRequest.approver_id == software.approver_id)
                        {
                            foreach (ListViewItem item in listView1.Items)
                            {
                                if (item.Text == software.software_name && item.SubItems[2].Text == (software.first_name + " " + software.last_name))
                                {
                                    listView1.Items.Remove(item);
                                    pendingItems.Add(item);
                                }
                            }
                        }
                    }
                    
                }
            }
        }

        public void SetUserSession(Data.User _userSession)
        {
            userSession = _userSession;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
