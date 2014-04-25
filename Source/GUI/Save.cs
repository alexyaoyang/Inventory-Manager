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
    public partial class Save : Form
    {
        IntPtr logicobj;
        public Save()
        {
            InitializeComponent();
            logicobj = Logicdll.init(); 
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            int result;
            if (csv_rbtn.Checked == true)
                result = Logicdll.saveFileC(logicobj, Save_txt.Text, 1); // 1 for csv 2 for txt
            else
                result = Logicdll.saveFileC(logicobj, Save_txt.Text, 2); // 1 for csv 2 for txt
            if (result == 1)
                save_lbl.Text = "Successful";
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Save_txt_TextChanged(object sender, EventArgs e)
        {
            save_btn.Enabled = true;
        }
    }
}
