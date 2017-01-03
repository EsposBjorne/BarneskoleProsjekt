namespace Barneskole
{
    partial class frmDbPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDbPass));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDbPass = new System.Windows.Forms.TextBox();
            this.butDbPassord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Passord";
            // 
            // txtDbPass
            // 
            this.txtDbPass.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtDbPass.Location = new System.Drawing.Point(105, 28);
            this.txtDbPass.Name = "txtDbPass";
            this.txtDbPass.Size = new System.Drawing.Size(158, 33);
            this.txtDbPass.TabIndex = 1;
            this.txtDbPass.UseSystemPasswordChar = true;
            // 
            // butDbPassord
            // 
            this.butDbPassord.AutoSize = true;
            this.butDbPassord.FlatAppearance.BorderSize = 0;
            this.butDbPassord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butDbPassord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDbPassord.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDbPassord.ForeColor = System.Drawing.Color.White;
            this.butDbPassord.Location = new System.Drawing.Point(96, 76);
            this.butDbPassord.Name = "butDbPassord";
            this.butDbPassord.Size = new System.Drawing.Size(102, 35);
            this.butDbPassord.TabIndex = 9;
            this.butDbPassord.Text = "Lagre";
            this.butDbPassord.UseVisualStyleBackColor = true;
            this.butDbPassord.Click += new System.EventHandler(this.butDbPassord_Click);
            // 
            // frmDbPass
            // 
            this.AcceptButton = this.butDbPassord;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(288, 114);
            this.Controls.Add(this.butDbPassord);
            this.Controls.Add(this.txtDbPass);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDbPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skriv inn root passord for MySQL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDbPass;
        private System.Windows.Forms.Button butDbPassord;
    }
}