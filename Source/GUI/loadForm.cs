using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjectFinalGui
{
    public partial class loadForm : Form
    {
        IntPtr logicobj;
      
     //   LinkedListNode<int> llist;

        public loadForm()
        {
            InitializeComponent();
            logicobj = Logicdll.init(); 
 
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loadForm));
            this.Load_txtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exit_btn = new System.Windows.Forms.Button();
            this.load_btn = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Load_txtbox
            // 
            this.Load_txtbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Load_txtbox.Location = new System.Drawing.Point(11, 146);
            this.Load_txtbox.Name = "Load_txtbox";
            this.Load_txtbox.ReadOnly = true;
            this.Load_txtbox.Size = new System.Drawing.Size(383, 20);
            this.Load_txtbox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(188, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "Welcome!";
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoad.Location = new System.Drawing.Point(8, 117);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(92, 16);
            this.lblLoad.TabIndex = 10;
            this.lblLoad.Text = "Product File:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.Filter = "TXT files|*.txt|CSV files|*.csv";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrowse.Image = global::ProjectFinalGui.Properties.Resources.browse;
            this.btnBrowse.Location = new System.Drawing.Point(400, 111);
            this.btnBrowse.MaximumSize = new System.Drawing.Size(117, 98);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(88, 80);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::ProjectFinalGui.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 85);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // exit_btn
            // 
            this.exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exit_btn.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.exit_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exit_btn.Image = global::ProjectFinalGui.Properties.Resources.exit;
            this.exit_btn.Location = new System.Drawing.Point(449, 223);
            this.exit_btn.MaximumSize = new System.Drawing.Size(88, 80);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(88, 80);
            this.exit_btn.TabIndex = 7;
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // load_btn
            // 
            this.load_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.load_btn.Enabled = false;
            this.load_btn.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.load_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.load_btn.Image = global::ProjectFinalGui.Properties.Resources.Load;
            this.load_btn.Location = new System.Drawing.Point(338, 223);
            this.load_btn.MaximumSize = new System.Drawing.Size(88, 80);
            this.load_btn.Name = "load_btn";
            this.load_btn.Size = new System.Drawing.Size(88, 80);
            this.load_btn.TabIndex = 0;
            this.load_btn.UseVisualStyleBackColor = true;
            this.load_btn.Click += new System.EventHandler(this.load_btn_Click);
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(12, 189);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(382, 16);
            this.textBox4.TabIndex = 27;
            this.textBox4.Text = "Please \"Browse\" for a file to load . . .";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(412, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 14);
            this.label10.TabIndex = 28;
            this.label10.Text = "Browse";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(472, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 14);
            this.label1.TabIndex = 29;
            this.label1.Text = "Exit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(353, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "Confirm";
            // 
            // loadForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(543, 327);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.Load_txtbox);
            this.Controls.Add(this.load_btn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "loadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CICMS";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void load_btn_Click(object sender, EventArgs e)
        {
            Product ProductForm = new Product();
            this.Hide();
            if (Path.GetExtension(openFileDialog.FileName) == ".csv")
                ProductForm.splashScreenLoad(Load_txtbox.Text, 1);
            else
                ProductForm.splashScreenLoad(Load_txtbox.Text, 2);
            File.WriteAllText("batchjobs.txt", string.Empty);
            File.WriteAllText("log.txt", string.Empty);
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            Load_txtbox.Text = Path.GetFileName(openFileDialog.FileName);
            load_btn.Enabled = true;
                
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

       
    }
}
