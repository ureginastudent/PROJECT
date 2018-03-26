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

        public Analyst()
        {
            InitializeComponent();
        }

        private void Analyst_Load(object sender, EventArgs e)
        {

        }

        public void SetUserSession(Data.Analyst _userSession)
        {
            userSession = _userSession;
        }
    }
}
