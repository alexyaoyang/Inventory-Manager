namespace ProjectFinalGui
{
    partial class passwordForm
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnPassOk = new System.Windows.Forms.Button();
            this.lblPassError = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(11, 46);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(328, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnPassOk
            // 
            this.btnPassOk.Image = global::ProjectFinalGui.Properties.Resources.Tick1;
            this.btnPassOk.Location = new System.Drawing.Point(180, 117);
            this.btnPassOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPassOk.Name = "btnPassOk";
            this.btnPassOk.Size = new System.Drawing.Size(88, 80);
            this.btnPassOk.TabIndex = 2;
            this.btnPassOk.UseVisualStyleBackColor = true;
            this.btnPassOk.Click += new System.EventHandler(this.btnPassOk_Click);
            // 
            // lblPassError
            // 
            this.lblPassError.AutoSize = true;
            this.lblPassError.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassError.ForeColor = System.Drawing.Color.Red;
            this.lblPassError.Location = new System.Drawing.Point(12, 81);
            this.lblPassError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassError.Name = "lblPassError";
            this.lblPassError.Size = new System.Drawing.Size(152, 14);
            this.lblPassError.TabIndex = 4;
            this.lblPassError.Text = "Wrong password entered.";
            this.lblPassError.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 14);
            this.label10.TabIndex = 27;
            this.label10.Text = "Please enter your password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "Confirm";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(312, 205);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 14);
            this.label19.TabIndex = 35;
            this.label19.Text = "Cancel";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.Image = global::ProjectFinalGui.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(292, 117);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.MaximumSize = new System.Drawing.Size(88, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 80);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // passwordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(391, 222);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPassError);
            this.Controls.Add(this.btnPassOk);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "passwordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentication Required";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnPassOk;
        public System.Windows.Forms.Label lblPassError;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnCancel;
    }
}