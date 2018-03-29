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
    public partial class Analyst : Form
    {
        private Dictionary<string, string> Decisions = new Dictionary<string, string>();
        private Data.Analyst userSession;
        private CollectionList<ListViewItem> pendingApprovalList = new CollectionList<ListViewItem>();
        private CollectionList<ListViewItem> pendingAccessList = new CollectionList<ListViewItem>();


        public Analyst()
        {
            InitializeComponent();
        }

        private void OnPendingApprovalAdd(object sender, EventArgs e)
        {
            listView1.Items.Add((ListViewItem)sender);
        }

        private void OnPendingAccessAdd(object sender, EventArgs e)
        {
            listView2.Items.Add((ListViewItem)sender);
        }

        private void OnPendingAccessRemove(object sender, EventArgs e)
        {
            listView2.Items.Remove((ListViewItem)sender);
        }

        private void OnPendingApprovalRemove(object sender, EventArgs e)
        {
            listView1.Items.Remove((ListViewItem)sender);
        }

        private void AddSoftwareToList(Web.Software.RootObject softwarePiece, Web.Software.Request software, CollectionList<ListViewItem> List, Color col, object Tag, bool checkedState)
        {
            ListViewItem item = new ListViewItem(softwarePiece.software_name);

            item.SubItems.Add(softwarePiece.software_acronym);
            item.SubItems.Add(softwarePiece.first_name + " " + softwarePiece.last_name);
            item.SubItems.Add(softwarePiece.software_province);
            item.SubItems.Add(software.user_id);
            item.Tag = Tag;
            item.ForeColor = col;
            item.Checked = checkedState;

            List.Add(item);
        }

        private void Analyst_Load(object sender, EventArgs e)
        {
            var softwareRequestList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareRequests("*")).Result; //parse all requests

            Decisions.Add("1", "approved|access");
            Decisions.Add("2", "approved|denied");

            pendingApprovalList.OnAdd += new EventHandler(OnPendingApprovalAdd);
            pendingAccessList.OnAdd += new EventHandler(OnPendingAccessAdd);

            pendingAccessList.OnRemove += new EventHandler(OnPendingAccessRemove);
            pendingApprovalList.OnRemove += new EventHandler(OnPendingApprovalRemove);

            namelbl.Text = "Logged in as " + userSession.UserName;

            foreach (var software in softwareRequestList)
            {
                var softwareList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareList(software.software_id)).Result;

                if (softwareList == null)
                    continue;

                var softwarePiece = softwareList[0];

                if (software.approved_status == "pending")
                {
                    AddSoftwareToList(softwarePiece, software, pendingApprovalList, DefaultForeColor, software, false);
                }
                else if (software.approved_status == "approved|invalid")
                {
                    AddSoftwareToList(softwarePiece, software, pendingAccessList, DefaultForeColor, software, false);
                }
                else if (software.approved_status == "pending approval")
                {
                    AddSoftwareToList(softwarePiece, software, pendingApprovalList, Color.Green, software, true);
                }
            }
        }

        public void SetUserSession(Data.Analyst _userSession)
        {
            userSession = _userSession;
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListViewItem Item = listView1.Items[e.Index];
            if (((Web.Software.Request)(Item.Tag)).approved_status == "pending approval")
            {
                e.NewValue = CheckState.Checked;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in listView1.CheckedItems)
            {
                Web.Software.Request software = (Web.Software.Request)(Item.Tag);
                if(software.approved_status == "pending")
                {
                    bool success = Task.Run(() => Web.SoftwareRequest.RequestApproval(software.software_id, software.user_id)).Result;
                    if (success)
                    {
                        Item.ForeColor = Color.Green;
                        software.approved_status = "pending approval";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in listView2.CheckedItems)
            {
                Web.Software.Request software = (Web.Software.Request)(Item.Tag);
               
                bool success = Task.Run(() => Web.SoftwareRequest.GrantAccess(software.software_id, software.user_id, software.approver_id, "1")).Result;
                if (success)
                {
                    software.approved_status = Decisions["1"];
                    pendingAccessList.Remove(Item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in listView2.CheckedItems)
            {
                Web.Software.Request software = (Web.Software.Request)(Item.Tag);
                bool success = Task.Run(() => Web.SoftwareRequest.GrantAccess(software.software_id, software.user_id, software.approver_id, "2")).Result;
                if (success)
                {
                    software.approved_status = Decisions["2"];
                    pendingAccessList.Remove(Item);
                }
            }
        }
    }
}
