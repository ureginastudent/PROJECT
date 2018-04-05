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
        private CollectionList<ListViewItem> deniedItems = new CollectionList<ListViewItem>();

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

        private void OnDeniedAdd(object sender, EventArgs e)
        {
            listView4.Items.Add((ListViewItem)sender);
        }

        private void OnDeniedRemove(object sender, EventArgs e)
        {
            listView4.Items.Remove((ListViewItem)sender);
        }

        private void AddSoftwareToList(Web.Software.RootObject softwarePiece, CollectionList<ListViewItem> List, object Tag)
        {
            ListViewItem item = new ListViewItem(softwarePiece.software_name);

            item.SubItems.Add(softwarePiece.software_acronym);
            item.SubItems.Add(softwarePiece.first_name + " " + softwarePiece.last_name);
            item.SubItems.Add(softwarePiece.software_province);
            item.Tag = Tag;

            List.Add(item);
        }

        private void LoadSoftware()
        {
            var softwareList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareList()).Result;

            if (softwareList == null)
            {
                MessageBox.Show("Error retrieving software list, closing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            foreach (var software in softwareList)
            {
                AddSoftwareToList(software, softwareItems, software);
            }

            var softwareRequestList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareRequests()).Result;

            foreach (var softwareRequest in softwareRequestList)
            {
                var softwareName = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareList(softwareRequest.software_id)).Result;

                if (softwareName == null)
                    continue;

                var software = softwareName[0];

                /*Need to copy the list of items to enumerate through, for some reason listview does not implement cloneable*/

                ListViewItem[] Copy = new ListViewItem[softwareItems.Count];

                softwareItems.CopyTo(Copy);

                foreach (var item in Copy)
                {
                    if (item.Text == software.software_name && item.SubItems[2].Text == (software.first_name + " " + software.last_name))
                    {
                        softwareItems.Remove(item);

                        if (softwareRequest.approved_status == "pending" || softwareRequest.approved_status == "pending approval" || softwareRequest.approved_status == "approved|invalid")
                        {
                            if (softwareRequest.approved_status == "pending approval")
                                item.ForeColor = Color.SlateBlue;
                            else if (softwareRequest.approved_status == "approved|invalid")
                                item.ForeColor = Color.Green;

                            pendingItems.Add(item);
                        }
                        else if (softwareRequest.approved_status == "approved|access")
                        {
                            approvedItems.Add(item);
                        }
                        else if (softwareRequest.approved_status == "denied" || softwareRequest.approved_status == "approved|denied")
                        {
                            deniedItems.Add(item);
                        }
                    }
                }
            }
        }

        private void User_Load(object sender, EventArgs e)
        {


            namelbl.Text = "Logged in as " + userSession.UserName;

            pendingItems.OnAdd += new EventHandler(OnPendingAdd);
            approvedItems.OnAdd += new EventHandler(OnApprovedAdd);
            softwareItems.OnAdd += new EventHandler(OnSoftwareAdd);
            deniedItems.OnAdd += new EventHandler(OnDeniedAdd);

            pendingItems.OnRemove += new EventHandler(OnPendingRemove);
            approvedItems.OnRemove += new EventHandler(OnApprovedRemove);
            softwareItems.OnRemove += new EventHandler(OnSoftwareRemove);
            deniedItems.OnRemove += new EventHandler(OnDeniedRemove);

            LoadSoftware();

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
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                Web.Software.RootObject root = (Web.Software.RootObject)item.Tag;

                bool success = Task.Run(() => Web.SoftwareRequest.RequestSoftware(root.software_id)).Result;

                if (success)
                {
                    item.BackColor = DefaultBackColor;
                    item.ForeColor = DefaultForeColor;

                    softwareItems.Remove(item);
                    pendingItems.Add(item);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView4.CheckedItems)
            {
                Web.Software.RootObject root = (Web.Software.RootObject)item.Tag;

                bool success = Task.Run(() => Web.SoftwareRequest.RequestSoftware(root.software_id, true)).Result;

                if (success)
                {
                    deniedItems.Remove(item);
                    pendingItems.Add(item);
                }

            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }


        private void Search(ListView List, TextBox Text, int Index)
        {
            if (Text.Text != "")
            {
                foreach (ListViewItem item in List.Items)
                {
                    if (item.SubItems[Index].Text.ToLower().Contains(Text.Text.ToLower()))
                    {
                        item.BackColor = SystemColors.Highlight;
                        item.ForeColor = SystemColors.HighlightText;
                    }
                    else
                    {
                        List.Items.Remove(item);
                    }

                }

                if (List.SelectedItems.Count == 1)
                {
                    List.Focus();
                }

            }
            else
            {
                List.Items.Clear();
                listView2.Items.Clear();
                listView3.Items.Clear();
                listView4.Items.Clear();

                LoadSoftware();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search(listView1, textBox1, 0);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Search(listView1, textBox2, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();

            log.FormClosed += (s, args) => this.Close();

            this.Hide();
        }
    }
}
