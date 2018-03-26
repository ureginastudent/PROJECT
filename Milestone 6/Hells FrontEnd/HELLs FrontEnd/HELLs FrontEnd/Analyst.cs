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
        private Data.Analyst userSession;
        private CollectionList<ListViewItem> pendingApprovalList = new CollectionList<ListViewItem>();
        private CollectionList<ListViewItem> pendingAccessList = new CollectionList<ListViewItem>();


        public Analyst()
        {
            InitializeComponent();
        }

        private void OnPendingApproval(object sender, EventArgs e)
        {
            listView1.Items.Add((ListViewItem)sender);
        }

        private void OnPendingAccess(object sender, EventArgs e)
        {
            listView2.Items.Add((ListViewItem)sender);
        }

        private void AddSoftwareToList(Web.Software.RootObject softwarePiece, Web.Software.Request software, CollectionList<ListViewItem> List)
        {
            ListViewItem item = new ListViewItem(softwarePiece.software_name);

            item.SubItems.Add(softwarePiece.software_acronym);
            item.SubItems.Add(softwarePiece.first_name + " " + softwarePiece.last_name);
            item.SubItems.Add(softwarePiece.software_province);
            item.SubItems.Add(software.user_id);

            List.Add(item);
        }

        private void Analyst_Load(object sender, EventArgs e)
        {
            var softwareRequestList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareRequests("*")).Result; //parse all requests

            pendingApprovalList.OnAdd += OnPendingApproval;
            pendingAccessList.OnAdd += OnPendingAccess;

            foreach (var software in softwareRequestList)
            {
                var softwareList = Task.Run(() => Web.SoftwareRequest.RetrieveSoftwareList(software.software_id, software.approver_id)).Result;

                if (softwareList == null)
                    continue;

                var softwarePiece = softwareList[0];

                if (software.approved_status == "pending")
                {
                    AddSoftwareToList(softwarePiece, software, pendingApprovalList);
                }
                else if (software.approved_status == "approved|invalid")
                {
                    AddSoftwareToList(softwarePiece, software, pendingAccessList);
                }
            }
        }

        public void SetUserSession(Data.Analyst _userSession)
        {
            userSession = _userSession;
        }
    }
}
