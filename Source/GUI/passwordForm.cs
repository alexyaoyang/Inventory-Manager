using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFinalGui
{
    public partial class passwordForm : Form
    {
        public passwordForm()
        {
            InitializeComponent();
        }

        private void btnPassOk_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "admin")
            {
                lblPassError.Text = "ok";
                this.Close();
            }
            else lblPassError.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}
