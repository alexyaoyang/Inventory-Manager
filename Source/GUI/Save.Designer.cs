namespace ProjectFinalGui
{
    partial class Save
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Save));
            this.label1 = new System.Windows.Forms.Label();
            this.Save_txt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_rbtn = new System.Windows.Forms.RadioButton();
            this.csv_rbtn = new System.Windows.Forms.RadioButton();
            this.save_lbl = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter File Name:";
            // 
            // Save_txt
            // 
            this.Save_txt.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_txt.Location = new System.Drawing.Point(25, 32);
            this.Save_txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Save_txt.Name = "Save_txt";
            this.Save_txt.Size = new System.Drawing.Size(431, 27);
            this.Save_txt.TabIndex = 1;
            this.Save_txt.TextChanged += new System.EventHandler(this.Save_txt_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_rbtn);
            this.groupBox1.Controls.Add(this.csv_rbtn);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(148, 62);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File type:";
            // 
            // txt_rbtn
            // 
            this.txt_rbtn.AutoSize = true;
            this.txt_rbtn.Checked = true;
            this.txt_rbtn.Location = new System.Drawing.Point(8, 23);
            this.txt_rbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_rbtn.Name = "txt_rbtn";
            this.txt_rbtn.Size = new System.Drawing.Size(55, 21);
            this.txt_rbtn.TabIndex = 1;
            this.txt_rbtn.TabStop = true;
            this.txt_rbtn.Text = ".txt";
            this.txt_rbtn.UseVisualStyleBackColor = true;
            // 
            // csv_rbtn
            // 
            this.csv_rbtn.AutoSize = true;
            this.csv_rbtn.Location = new System.Drawing.Point(77, 23);
            this.csv_rbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.csv_rbtn.Name = "csv_rbtn";
            this.csv_rbtn.Size = new System.Drawing.Size(59, 21);
            this.csv_rbtn.TabIndex = 0;
            this.csv_rbtn.TabStop = true;
            this.csv_rbtn.Text = ".csv";
            this.csv_rbtn.UseVisualStyleBackColor = true;
            // 
            // save_lbl
            // 
            this.save_lbl.AutoSize = true;
            this.save_lbl.Location = new System.Drawing.Point(52, 249);
            this.save_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.save_lbl.Name = "save_lbl";
            this.save_lbl.Size = new System.Drawing.Size(0, 17);
            this.save_lbl.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::ProjectFinalGui.Properties.Resources.exit;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(351, 76);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 98);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // save_btn
            // 
            this.save_btn.BackgroundImage = global::ProjectFinalGui.Properties.Resources.Save;
            this.save_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.save_btn.Enabled = false;
            this.save_btn.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.save_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_btn.Location = new System.Drawing.Point(227, 76);
            this.save_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(117, 98);
            this.save_btn.TabIndex = 2;
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(241, 183);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 18);
            this.label12.TabIndex = 30;
            this.label12.Text = "Save File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(383, 183);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "Exit";
            // 
            // Save
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 212);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.save_lbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.Save_txt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Save";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CICSM";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Save_txt;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton txt_rbtn;
        private System.Windows.Forms.RadioButton csv_rbtn;
        private System.Windows.Forms.Label save_lbl;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
    }
}