namespace Barneskole
{
    partial class frmNyBruker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNyBruker));
            this.txtBrukernavn = new System.Windows.Forms.TextBox();
            this.txtPassord = new System.Windows.Forms.TextBox();
            this.txtFornavn = new System.Windows.Forms.TextBox();
            this.txtEtternavn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butNyBruker = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBrukernavn
            // 
            this.txtBrukernavn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrukernavn.Location = new System.Drawing.Point(125, 24);
            this.txtBrukernavn.Name = "txtBrukernavn";
            this.txtBrukernavn.Size = new System.Drawing.Size(158, 33);
            this.txtBrukernavn.TabIndex = 0;
            this.txtBrukernavn.TextChanged += new System.EventHandler(this.txtNyBruker_TextChanged);
            // 
            // txtPassord
            // 
            this.txtPassord.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassord.Location = new System.Drawing.Point(125, 58);
            this.txtPassord.Name = "txtPassord";
            this.txtPassord.PasswordChar = '*';
            this.txtPassord.Size = new System.Drawing.Size(158, 33);
            this.txtPassord.TabIndex = 1;
            this.txtPassord.UseSystemPasswordChar = true;
            this.txtPassord.TextChanged += new System.EventHandler(this.txtNyBruker_TextChanged);
            // 
            // txtFornavn
            // 
            this.txtFornavn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFornavn.Location = new System.Drawing.Point(125, 92);
            this.txtFornavn.Name = "txtFornavn";
            this.txtFornavn.Size = new System.Drawing.Size(158, 33);
            this.txtFornavn.TabIndex = 2;
            this.txtFornavn.TextChanged += new System.EventHandler(this.txtNyBruker_TextChanged);
            // 
            // txtEtternavn
            // 
            this.txtEtternavn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEtternavn.Location = new System.Drawing.Point(125, 126);
            this.txtEtternavn.Name = "txtEtternavn";
            this.txtEtternavn.Size = new System.Drawing.Size(158, 33);
            this.txtEtternavn.TabIndex = 3;
            this.txtEtternavn.TextChanged += new System.EventHandler(this.txtNyBruker_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Passord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fornavn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Etternavn";
            // 
            // butNyBruker
            // 
            this.butNyBruker.AutoSize = true;
            this.butNyBruker.Enabled = false;
            this.butNyBruker.FlatAppearance.BorderSize = 0;
            this.butNyBruker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butNyBruker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNyBruker.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butNyBruker.ForeColor = System.Drawing.Color.White;
            this.butNyBruker.Location = new System.Drawing.Point(98, 165);
            this.butNyBruker.Name = "butNyBruker";
            this.butNyBruker.Size = new System.Drawing.Size(102, 35);
            this.butNyBruker.TabIndex = 8;
            this.butNyBruker.Text = "Registrer";
            this.butNyBruker.UseVisualStyleBackColor = true;
            this.butNyBruker.Click += new System.EventHandler(this.butNyBruker_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Brukernavn";
            // 
            // frmNyBruker
            // 
            this.AcceptButton = this.butNyBruker;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(295, 208);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butNyBruker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEtternavn);
            this.Controls.Add(this.txtFornavn);
            this.Controls.Add(this.txtPassord);
            this.Controls.Add(this.txtBrukernavn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNyBruker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nes Barneskole - opprett bruker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBrukernavn;
        private System.Windows.Forms.TextBox txtPassord;
        private System.Windows.Forms.TextBox txtFornavn;
        private System.Windows.Forms.TextBox txtEtternavn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butNyBruker;
        private System.Windows.Forms.Label label5;
    }
}