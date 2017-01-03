namespace Barneskole
{
    partial class frmInnlogging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInnlogging));
            this.lblBrukernavn = new System.Windows.Forms.Label();
            this.lblPassord = new System.Windows.Forms.Label();
            this.txtBrukernavn = new System.Windows.Forms.TextBox();
            this.txtPassord = new System.Windows.Forms.TextBox();
            this.butLogginn = new System.Windows.Forms.Button();
            this.butRestore = new System.Windows.Forms.Button();
            this.butOpprettBruker = new System.Windows.Forms.Button();
            this.lblIngenBrukere = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.hjelp = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBrukernavn
            // 
            this.lblBrukernavn.AutoSize = true;
            this.lblBrukernavn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrukernavn.ForeColor = System.Drawing.Color.White;
            this.lblBrukernavn.Location = new System.Drawing.Point(210, 76);
            this.lblBrukernavn.Name = "lblBrukernavn";
            this.lblBrukernavn.Size = new System.Drawing.Size(117, 25);
            this.lblBrukernavn.TabIndex = 1;
            this.lblBrukernavn.Text = "Brukernavn";
            // 
            // lblPassord
            // 
            this.lblPassord.AutoSize = true;
            this.lblPassord.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassord.ForeColor = System.Drawing.Color.White;
            this.lblPassord.Location = new System.Drawing.Point(210, 116);
            this.lblPassord.Name = "lblPassord";
            this.lblPassord.Size = new System.Drawing.Size(82, 25);
            this.lblPassord.TabIndex = 2;
            this.lblPassord.Text = "Passord";
            // 
            // txtBrukernavn
            // 
            this.txtBrukernavn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrukernavn.Location = new System.Drawing.Point(329, 73);
            this.txtBrukernavn.Name = "txtBrukernavn";
            this.txtBrukernavn.Size = new System.Drawing.Size(201, 33);
            this.txtBrukernavn.TabIndex = 3;
            // 
            // txtPassord
            // 
            this.txtPassord.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassord.Location = new System.Drawing.Point(329, 113);
            this.txtPassord.Name = "txtPassord";
            this.txtPassord.Size = new System.Drawing.Size(201, 33);
            this.txtPassord.TabIndex = 4;
            this.txtPassord.UseSystemPasswordChar = true;
            // 
            // butLogginn
            // 
            this.butLogginn.FlatAppearance.BorderSize = 0;
            this.butLogginn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butLogginn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLogginn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLogginn.ForeColor = System.Drawing.Color.White;
            this.butLogginn.Location = new System.Drawing.Point(215, 152);
            this.butLogginn.Name = "butLogginn";
            this.butLogginn.Size = new System.Drawing.Size(315, 47);
            this.butLogginn.TabIndex = 5;
            this.butLogginn.Text = "Logg inn";
            this.butLogginn.UseVisualStyleBackColor = true;
            this.butLogginn.Click += new System.EventHandler(this.butLogginn_Click);
            // 
            // butRestore
            // 
            this.butRestore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butRestore.AutoSize = true;
            this.butRestore.FlatAppearance.BorderSize = 0;
            this.butRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRestore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRestore.ForeColor = System.Drawing.Color.White;
            this.butRestore.Location = new System.Drawing.Point(544, 416);
            this.butRestore.Name = "butRestore";
            this.butRestore.Size = new System.Drawing.Size(185, 31);
            this.butRestore.TabIndex = 149;
            this.butRestore.Text = "Gjenopprett database";
            this.butRestore.UseVisualStyleBackColor = true;
            this.butRestore.Click += new System.EventHandler(this.butRestore_Click);
            this.butRestore.MouseLeave += new System.EventHandler(this.frmInnlogging_MouseHover);
            this.butRestore.MouseHover += new System.EventHandler(this.butRestore_MouseHover);
            // 
            // butOpprettBruker
            // 
            this.butOpprettBruker.AutoSize = true;
            this.butOpprettBruker.FlatAppearance.BorderSize = 0;
            this.butOpprettBruker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butOpprettBruker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOpprettBruker.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOpprettBruker.ForeColor = System.Drawing.Color.White;
            this.butOpprettBruker.Location = new System.Drawing.Point(302, 37);
            this.butOpprettBruker.Name = "butOpprettBruker";
            this.butOpprettBruker.Size = new System.Drawing.Size(158, 35);
            this.butOpprettBruker.TabIndex = 150;
            this.butOpprettBruker.Text = "Opprett bruker";
            this.butOpprettBruker.UseVisualStyleBackColor = true;
            this.butOpprettBruker.Click += new System.EventHandler(this.butOpprettBruker_Click);
            // 
            // lblIngenBrukere
            // 
            this.lblIngenBrukere.AutoSize = true;
            this.lblIngenBrukere.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngenBrukere.ForeColor = System.Drawing.Color.White;
            this.lblIngenBrukere.Location = new System.Drawing.Point(281, 9);
            this.lblIngenBrukere.Name = "lblIngenBrukere";
            this.lblIngenBrukere.Size = new System.Drawing.Size(205, 25);
            this.lblIngenBrukere.TabIndex = 151;
            this.lblIngenBrukere.Text = "Ingen brukere finnes!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(215, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 235);
            this.pictureBox1.TabIndex = 152;
            this.pictureBox1.TabStop = false;
            // 
            // frmInnlogging
            // 
            this.AcceptButton = this.butLogginn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(727, 449);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblIngenBrukere);
            this.Controls.Add(this.butOpprettBruker);
            this.Controls.Add(this.butRestore);
            this.Controls.Add(this.butLogginn);
            this.Controls.Add(this.txtPassord);
            this.Controls.Add(this.txtBrukernavn);
            this.Controls.Add(this.lblPassord);
            this.Controls.Add(this.lblBrukernavn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInnlogging";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nes Barneskole - Innlogging";
            this.Load += new System.EventHandler(this.frmInnlogging_Load);
            this.MouseHover += new System.EventHandler(this.frmInnlogging_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBrukernavn;
        private System.Windows.Forms.Label lblPassord;
        private System.Windows.Forms.TextBox txtBrukernavn;
        private System.Windows.Forms.TextBox txtPassord;
        private System.Windows.Forms.Button butLogginn;
        private System.Windows.Forms.Button butRestore;
        private System.Windows.Forms.Button butOpprettBruker;
        private System.Windows.Forms.Label lblIngenBrukere;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.HelpProvider hjelp;




    }
}