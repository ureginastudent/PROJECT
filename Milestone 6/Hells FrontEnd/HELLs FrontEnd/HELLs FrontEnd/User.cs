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
        private CollectionList<ListViewItem> softwareItems = new CollectionList<ListViewItem>();
        private CollectionList<ListViewItem> approvedItems = new CollectionList<ListViewItem>();

        public User()
        {
            InitializeComponent();
        }

        private void OnPendingAdd(object sender, EventArgs e)
        {
            listView2.Items.Add((ListViewItem)sender);
        }

        private void OnApprovedAdd(object sender, EventArgs e)
        {
            listView3.Items.Add((ListViewItem)sender);
        }

        private void OnSoftwareAdd(object sender, EventArgs e)
        {
            listView1.Items.Add((ListViewItem)sender);
        }

        private void OnSoftwareRemove(object sender, EventArgs e)
        {
            listView1.Items.Remove((ListViewItem)sender);
        }

        private void OnApprovedRemove(object sender, EventArgs e)
        {
            listView3.Items.Remove((ListViewItem)sender);
        }

        private void OnPendingRemove(object sender, EventArgs e)
        {
            listView2.Items.Remove((ListViewItem)sender);
        }

        private void AddSoftwareToList(Web.Software.RootObject softwarePiece, CollectionList<ListViewItem> List)
        {
            ListViewItem item = new ListViewItem(softwarePiece.software_name);

            item.SubItems.Add(softwarePiece.software_acronym);
            item.SubItems.Add(softwarePiece.first_name + " " + softwarePiece.last_name);
            item.SubItems.Add(softwarePiece.software_province);

            List.Add(item);
        }

        private void User_Load(object sender, EventArgs e)
        {
            var softwareList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareList()).Result;


            if (softwareList == null)
            {
                MessageBox.Show("Error retrieving software list, closing");
                this.Close();
            }

            namelbl.Text = "Logged in as " + userSession.UserName;

            pendingItems.OnAdd += new EventHandler(OnPendingAdd);
            approvedItems.OnAdd += new EventHandler(OnApprovedAdd);
            softwareItems.OnAdd += new EventHandler(OnSoftwareAdd);

            pendingItems.OnRemove += new EventHandler(OnPendingRemove);
            approvedItems.OnRemove += new EventHandler(OnApprovedRemove);
            softwareItems.OnRemove += new EventHandler(OnSoftwareRemove);

            foreach (var software in softwareList)
            {
                AddSoftwareToList(software, softwareItems);

                /*ListViewItem lvi = new ListViewItem(software.software_name);

                lvi.SubItems.Add(software.software_acronym);
                lvi.SubItems.Add(software.first_name + " " + software.last_name);
                lvi.SubItems.Add(software.software_province);

                listView1.Items.Add(lvi);*/
            }

            var softwareRequestList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareRequests(userSession.Id.ToString())).Result;

            if (softwareRequestList.Count > 0)
            {
                foreach (var softwareRequest in softwareRequestList)
                {
                    var softwareName = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareList(softwareRequest.software_id, softwareRequest.approver_id)).Result;

                    if (softwareName == null)
                        continue;

                    var software = softwareName[0];

                    foreach (var item in softwareItems)
                    {
                        if (item.Text == software.software_name && item.SubItems[2].Text == (software.first_name + " " + software.last_name))
                        {
                            softwareItems.Remove(item);

                            if (softwareRequest.approved_status == "pending")
                            {
                                pendingItems.Add(item);
                            }
                            else if (softwareRequest.approved_status == "approved")
                            {
                                approvedItems.Add(item);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
