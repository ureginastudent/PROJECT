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

        private Data.Approver userSession;

        public Approver()
        {
            InitializeComponent();
        }

        private void Approver_Load(object sender, EventArgs e)
        {

        }

        public void SetUserSession(Data.Approver _userSession)
        {
            userSession = _userSession;
        }


    }
}
