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
    public partial class Approver : Form
    {

        private Dictionary<string, string> Decisions = new Dictionary<string, string>();
        private Data.Approver userSession;
        private CollectionList<ListViewItem> pendingApprovalList = new CollectionList<ListViewItem>();
        private CollectionList<ListViewItem> approvedList = new CollectionList<ListViewItem>();

        private void submitApprovalRequest(string decision, ListView List)
        {
            foreach (ListViewItem Item in List.CheckedItems)
            {
                Web.Software.Request software = (Web.Software.Request)(Item.Tag);

                bool success = Task.Run(() => Web.SoftwareRequest.Approve(software.software_id, software.user_id, decision)).Result;
                if (success)
                {
                    Item.Checked = false;
                    software.approved_status = Decisions[decision];
                    if (decision == "1")
                    {
                        pendingApprovalList.Remove(Item);
                        approvedList.Add(Item);
                    }
                    else if (decision == "2")
                    {
                        pendingApprovalList.Remove(Item);
                    }
                    else
                    {
                        approvedList.Remove(Item);
                    }
                }
            }
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

        public Approver()
        {
            InitializeComponent();
        }

        private void OnApprovedListAdd(object sender, EventArgs e)
        {
            listView2.Items.Add((ListViewItem)sender);
        }

        private void OnApprovedListRemove(object sender, EventArgs e)
        {
            listView2.Items.Remove((ListViewItem)sender);
        }

        private void OnPendingApprovalAdd(object sender, EventArgs e)
        {
            listView1.Items.Add((ListViewItem)sender);
        }

        private void OnPendingApprovalRemove(object sender, EventArgs e)
        {
            listView1.Items.Remove((ListViewItem)sender);
        }

        private void Approver_Load(object sender, EventArgs e)
        {
            var softwareRequestList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareRequests("*")).Result; //parse all requests

            Decisions.Add("1", "approved|invalid");
            Decisions.Add("2", "denied");
            Decisions.Add("3", "pending");

            pendingApprovalList.OnAdd += new EventHandler(OnPendingApprovalAdd);
            pendingApprovalList.OnRemove += new EventHandler(OnPendingApprovalRemove);

            approvedList.OnAdd += new EventHandler(OnApprovedListAdd);
            approvedList.OnRemove += new EventHandler(OnApprovedListRemove);

            namelbl.Text = "Logged in as " + userSession.UserName;

            foreach (var software in softwareRequestList)
            {
                var softwareList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareList(software.software_id)).Result;

                if (softwareList == null)
                    continue;

                var softwarePiece = softwareList[0];

                if (software.approved_status == "pending approval" && software.approver_id == userSession.Id.ToString())
                {
                    AddSoftwareToList(softwarePiece, software, pendingApprovalList, DefaultForeColor, software, false);
                }
                else if (software.approved_status.Length >= 8 && software.approved_status.Substring(0, 8) == "approved" && software.approver_id == userSession.Id.ToString())
                {
                    AddSoftwareToList(softwarePiece, software, approvedList, DefaultForeColor, software, false);
                }
            }


        }

        public void SetUserSession(Data.Approver _userSession)
        {
            userSession = _userSession;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            submitApprovalRequest("1", listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            submitApprovalRequest("2", listView1); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            submitApprovalRequest("3", listView2);
        }
    }
}
