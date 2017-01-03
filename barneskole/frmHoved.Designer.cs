using System.Windows.Forms;
namespace Barneskole
{
    partial class frmHoved
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoved));
            this.butTest = new System.Windows.Forms.Button();
            this.butBruker = new System.Windows.Forms.Button();
            this.butElev = new System.Windows.Forms.Button();
            this.butKlasse = new System.Windows.Forms.Button();
            this.menyLinje = new System.Windows.Forms.MenuStrip();
            this.menyFil = new System.Windows.Forms.ToolStripMenuItem();
            this.menyBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnyAvslutt = new System.Windows.Forms.ToolStripMenuItem();
            this.menyLoggUt = new System.Windows.Forms.ToolStripMenuItem();
            this.menyHjelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menyVisHjelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menyOm = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDato = new System.Windows.Forms.Label();
            this.panelMeny = new System.Windows.Forms.Panel();
            this.butDeltest = new System.Windows.Forms.Button();
            this.butResultat = new System.Windows.Forms.Button();
            this.lblBrukerStatus = new System.Windows.Forms.Label();
            this.tabDeltest = new System.Windows.Forms.TabPage();
            this.panelDeltest = new System.Windows.Forms.Panel();
            this.cmbDeltestFag = new System.Windows.Forms.ComboBox();
            this.lblDeltestFag = new System.Windows.Forms.Label();
            this.cmbDeltestTest = new System.Windows.Forms.ComboBox();
            this.numDeltestKritisk = new System.Windows.Forms.NumericUpDown();
            this.numDeltestMaks = new System.Windows.Forms.NumericUpDown();
            this.txtDeltestNavn = new System.Windows.Forms.TextBox();
            this.cmbDeltestSem = new System.Windows.Forms.ComboBox();
            this.lblDeltestTest = new System.Windows.Forms.Label();
            this.lblDeltestMakspoeng = new System.Windows.Forms.Label();
            this.lblDeltestSemester = new System.Windows.Forms.Label();
            this.lblDeltestNavn = new System.Windows.Forms.Label();
            this.lblDeltestKritisk = new System.Windows.Forms.Label();
            this.butDeltestTøm = new System.Windows.Forms.Button();
            this.butDeltestReg = new System.Windows.Forms.Button();
            this.butDeltestSlett = new System.Windows.Forms.Button();
            this.butDeltestEndre = new System.Windows.Forms.Button();
            this.dgvDeltest = new System.Windows.Forms.DataGridView();
            this.tabKlasser = new System.Windows.Forms.TabPage();
            this.panelKlasser = new System.Windows.Forms.Panel();
            this.cmbKlasserFag = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKlasserTest = new System.Windows.Forms.ComboBox();
            this.txtKlasserBet = new System.Windows.Forms.TextBox();
            this.txtKlasserÅr = new System.Windows.Forms.TextBox();
            this.lblKlasserSkoleår = new System.Windows.Forms.Label();
            this.lblKlasserBetegnelse = new System.Windows.Forms.Label();
            this.lblKlasseTester = new System.Windows.Forms.Label();
            this.butKlasserTøm = new System.Windows.Forms.Button();
            this.butKlasserReg = new System.Windows.Forms.Button();
            this.butKlasserSlett = new System.Windows.Forms.Button();
            this.butKlasserEndre = new System.Windows.Forms.Button();
            this.butKlasserRegTest = new System.Windows.Forms.Button();
            this.dgvKlasser = new System.Windows.Forms.DataGridView();
            this.dgvKlasserTest = new System.Windows.Forms.DataGridView();
            this.tabBrukere = new System.Windows.Forms.TabPage();
            this.panelBrukere = new System.Windows.Forms.Panel();
            this.txtBrukerPassord = new System.Windows.Forms.TextBox();
            this.txtBrukerBrukernavn = new System.Windows.Forms.TextBox();
            this.cmbBrukerType = new System.Windows.Forms.ComboBox();
            this.txtBrukerFornavn = new System.Windows.Forms.TextBox();
            this.txtBrukerEtternavn = new System.Windows.Forms.TextBox();
            this.lblBrukerFornavn = new System.Windows.Forms.Label();
            this.lblBrukerPassord = new System.Windows.Forms.Label();
            this.lblBrukerBrukernavn = new System.Windows.Forms.Label();
            this.lblBrukerEtternavn = new System.Windows.Forms.Label();
            this.lblBrukerType = new System.Windows.Forms.Label();
            this.butBrukerTøm = new System.Windows.Forms.Button();
            this.butBrukerReg = new System.Windows.Forms.Button();
            this.butBrukerSlett = new System.Windows.Forms.Button();
            this.butBrukerEndre = new System.Windows.Forms.Button();
            this.dgvBrukere = new System.Windows.Forms.DataGridView();
            this.tabTester = new System.Windows.Forms.TabPage();
            this.panelTester = new System.Windows.Forms.Panel();
            this.txtTesterFil = new System.Windows.Forms.TextBox();
            this.lblTesterFil = new System.Windows.Forms.Label();
            this.txtTesterNavn = new System.Windows.Forms.TextBox();
            this.cmbTesterFag = new System.Windows.Forms.ComboBox();
            this.lblTesterFag = new System.Windows.Forms.Label();
            this.lblTesterNavn = new System.Windows.Forms.Label();
            this.butTesterTøm = new System.Windows.Forms.Button();
            this.butTesterReg = new System.Windows.Forms.Button();
            this.butTesterSlett = new System.Windows.Forms.Button();
            this.butTesterEndre = new System.Windows.Forms.Button();
            this.dgvTester = new System.Windows.Forms.DataGridView();
            this.dgvFiler = new System.Windows.Forms.DataGridView();
            this.tabElever = new System.Windows.Forms.TabPage();
            this.panelElever = new System.Windows.Forms.Panel();
            this.lblEleverStatus = new System.Windows.Forms.Label();
            this.chkEleverStatus = new System.Windows.Forms.CheckBox();
            this.cmbEleverSkoleår = new System.Windows.Forms.ComboBox();
            this.cmbEleverKlasse = new System.Windows.Forms.ComboBox();
            this.cmbEleverKjønn = new System.Windows.Forms.ComboBox();
            this.txtEleverEtternavn = new System.Windows.Forms.TextBox();
            this.txtEleverFornavn = new System.Windows.Forms.TextBox();
            this.txtEleverFNummer = new System.Windows.Forms.TextBox();
            this.lblEleverSkoleår = new System.Windows.Forms.Label();
            this.lblEleverKlasse = new System.Windows.Forms.Label();
            this.lblEleverKjønn = new System.Windows.Forms.Label();
            this.lblEleverEtternavn = new System.Windows.Forms.Label();
            this.lblEleverFNummer = new System.Windows.Forms.Label();
            this.lblEleverFornavn = new System.Windows.Forms.Label();
            this.butEleverTøm = new System.Windows.Forms.Button();
            this.butEleverReg = new System.Windows.Forms.Button();
            this.butEleverSlett = new System.Windows.Forms.Button();
            this.butEleverEndre = new System.Windows.Forms.Button();
            this.butEleverFlyttAlle = new System.Windows.Forms.Button();
            this.dgvElever = new System.Windows.Forms.DataGridView();
            this.dgvEleverKlasse = new System.Windows.Forms.DataGridView();
            this.tabResultat = new System.Windows.Forms.TabPage();
            this.panelResultat = new System.Windows.Forms.Panel();
            this.lblResVisning = new System.Windows.Forms.Label();
            this.chkResDeltest = new System.Windows.Forms.CheckBox();
            this.chkResTest = new System.Windows.Forms.CheckBox();
            this.chkResFag = new System.Windows.Forms.CheckBox();
            this.cmbResFag = new System.Windows.Forms.ComboBox();
            this.chkResElev = new System.Windows.Forms.CheckBox();
            this.cmbResSem = new System.Windows.Forms.ComboBox();
            this.cmbResÅr = new System.Windows.Forms.ComboBox();
            this.numResPoeng = new System.Windows.Forms.NumericUpDown();
            this.cmbResBet = new System.Windows.Forms.ComboBox();
            this.cmbResElev = new System.Windows.Forms.ComboBox();
            this.butResTøm = new System.Windows.Forms.Button();
            this.butResReg = new System.Windows.Forms.Button();
            this.butResSlett = new System.Windows.Forms.Button();
            this.butResEndre = new System.Windows.Forms.Button();
            this.txtResKommentar = new System.Windows.Forms.TextBox();
            this.lblResKommentar = new System.Windows.Forms.Label();
            this.cmbResTest = new System.Windows.Forms.ComboBox();
            this.cmbResDeltest = new System.Windows.Forms.ComboBox();
            this.lblResPoeng = new System.Windows.Forms.Label();
            this.lblResFag = new System.Windows.Forms.Label();
            this.lblResTest = new System.Windows.Forms.Label();
            this.lblResDeltest = new System.Windows.Forms.Label();
            this.lblResElev = new System.Windows.Forms.Label();
            this.lblResSemester = new System.Windows.Forms.Label();
            this.chkResKlasse = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResKlasse = new System.Windows.Forms.Label();
            this.rbResReg = new System.Windows.Forms.RadioButton();
            this.rbResVisning = new System.Windows.Forms.RadioButton();
            this.butEksporter = new System.Windows.Forms.Button();
            this.dgvResultat = new System.Windows.Forms.DataGridView();
            this.tabMeny = new System.Windows.Forms.TabControl();
            this.hjelp = new System.Windows.Forms.HelpProvider();
            this.menyLinje.SuspendLayout();
            this.panelMeny.SuspendLayout();
            this.tabDeltest.SuspendLayout();
            this.panelDeltest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeltestKritisk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeltestMaks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeltest)).BeginInit();
            this.tabKlasser.SuspendLayout();
            this.panelKlasser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlasser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlasserTest)).BeginInit();
            this.tabBrukere.SuspendLayout();
            this.panelBrukere.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrukere)).BeginInit();
            this.tabTester.SuspendLayout();
            this.panelTester.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiler)).BeginInit();
            this.tabElever.SuspendLayout();
            this.panelElever.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElever)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEleverKlasse)).BeginInit();
            this.tabResultat.SuspendLayout();
            this.panelResultat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numResPoeng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultat)).BeginInit();
            this.tabMeny.SuspendLayout();
            this.SuspendLayout();
            // 
            // butTest
            // 
            this.butTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butTest.AutoSize = true;
            this.butTest.BackColor = System.Drawing.Color.Transparent;
            this.butTest.FlatAppearance.BorderSize = 0;
            this.butTest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTest.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTest.ForeColor = System.Drawing.SystemColors.Control;
            this.butTest.Location = new System.Drawing.Point(0, 128);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(135, 35);
            this.butTest.TabIndex = 1;
            this.butTest.Text = "Tester";
            this.butTest.UseVisualStyleBackColor = false;
            this.butTest.Click += new System.EventHandler(this.butTester_Click);
            this.butTest.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.butTest.MouseHover += new System.EventHandler(this.butTest_MouseHover);
            // 
            // butBruker
            // 
            this.butBruker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butBruker.AutoSize = true;
            this.butBruker.BackColor = System.Drawing.Color.Transparent;
            this.butBruker.FlatAppearance.BorderSize = 0;
            this.butBruker.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butBruker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butBruker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butBruker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBruker.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBruker.ForeColor = System.Drawing.SystemColors.Control;
            this.butBruker.Location = new System.Drawing.Point(0, 424);
            this.butBruker.Name = "butBruker";
            this.butBruker.Size = new System.Drawing.Size(135, 35);
            this.butBruker.TabIndex = 5;
            this.butBruker.Text = "Brukere";
            this.butBruker.UseVisualStyleBackColor = false;
            this.butBruker.Click += new System.EventHandler(this.butBrukere_Click);
            this.butBruker.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.butBruker.MouseHover += new System.EventHandler(this.butBruker_MouseHover);
            // 
            // butElev
            // 
            this.butElev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butElev.AutoSize = true;
            this.butElev.BackColor = System.Drawing.Color.Transparent;
            this.butElev.FlatAppearance.BorderSize = 0;
            this.butElev.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butElev.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butElev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butElev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butElev.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butElev.ForeColor = System.Drawing.SystemColors.Control;
            this.butElev.Location = new System.Drawing.Point(0, 349);
            this.butElev.Name = "butElev";
            this.butElev.Size = new System.Drawing.Size(135, 35);
            this.butElev.TabIndex = 4;
            this.butElev.Text = "Elever";
            this.butElev.UseVisualStyleBackColor = false;
            this.butElev.Click += new System.EventHandler(this.butElever_Click);
            this.butElev.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.butElev.MouseHover += new System.EventHandler(this.butElev_MouseHover);
            // 
            // butKlasse
            // 
            this.butKlasse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butKlasse.AutoSize = true;
            this.butKlasse.BackColor = System.Drawing.Color.Transparent;
            this.butKlasse.FlatAppearance.BorderSize = 0;
            this.butKlasse.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butKlasse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butKlasse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butKlasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butKlasse.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKlasse.ForeColor = System.Drawing.SystemColors.Control;
            this.butKlasse.Location = new System.Drawing.Point(0, 274);
            this.butKlasse.Name = "butKlasse";
            this.butKlasse.Size = new System.Drawing.Size(135, 35);
            this.butKlasse.TabIndex = 3;
            this.butKlasse.Text = "Klasser";
            this.butKlasse.UseVisualStyleBackColor = false;
            this.butKlasse.Click += new System.EventHandler(this.butKlasser_Click);
            this.butKlasse.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.butKlasse.MouseHover += new System.EventHandler(this.butKlasse_MouseHover);
            // 
            // menyLinje
            // 
            this.menyLinje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menyLinje.AutoSize = false;
            this.menyLinje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.menyLinje.Dock = System.Windows.Forms.DockStyle.None;
            this.menyLinje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menyLinje.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menyFil,
            this.menyLoggUt,
            this.menyHjelp});
            this.menyLinje.Location = new System.Drawing.Point(1, 0);
            this.menyLinje.Name = "menyLinje";
            this.menyLinje.Size = new System.Drawing.Size(1263, 31);
            this.menyLinje.TabIndex = 9;
            this.menyLinje.Text = "menyLinje";
            // 
            // menyFil
            // 
            this.menyFil.BackColor = System.Drawing.Color.Transparent;
            this.menyFil.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menyBackup,
            this.mnyAvslutt});
            this.menyFil.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menyFil.ForeColor = System.Drawing.Color.White;
            this.menyFil.Name = "menyFil";
            this.menyFil.Size = new System.Drawing.Size(40, 27);
            this.menyFil.Text = "Fil";
            this.menyFil.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.menyFil.MouseHover += new System.EventHandler(this.filToolStripMenuItem_MouseHover);
            // 
            // menyBackup
            // 
            this.menyBackup.BackColor = System.Drawing.SystemColors.Control;
            this.menyBackup.ForeColor = System.Drawing.Color.Black;
            this.menyBackup.Name = "menyBackup";
            this.menyBackup.Size = new System.Drawing.Size(136, 26);
            this.menyBackup.Text = "Backup";
            this.menyBackup.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            this.menyBackup.MouseHover += new System.EventHandler(this.filToolStripMenuItem_MouseHover);
            // 
            // mnyAvslutt
            // 
            this.mnyAvslutt.BackColor = System.Drawing.SystemColors.Control;
            this.mnyAvslutt.ForeColor = System.Drawing.Color.Black;
            this.mnyAvslutt.Name = "mnyAvslutt";
            this.mnyAvslutt.Size = new System.Drawing.Size(136, 26);
            this.mnyAvslutt.Text = "Avslutt";
            this.mnyAvslutt.Click += new System.EventHandler(this.mnyAvslutt_Click);
            this.mnyAvslutt.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.mnyAvslutt.MouseHover += new System.EventHandler(this.filToolStripMenuItem_MouseHover);
            // 
            // menyLoggUt
            // 
            this.menyLoggUt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menyLoggUt.BackColor = System.Drawing.Color.Transparent;
            this.menyLoggUt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menyLoggUt.ForeColor = System.Drawing.Color.White;
            this.menyLoggUt.Name = "menyLoggUt";
            this.menyLoggUt.Size = new System.Drawing.Size(80, 27);
            this.menyLoggUt.Text = "Logg ut";
            this.menyLoggUt.Click += new System.EventHandler(this.frmHoved_Loggut);
            this.menyLoggUt.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.menyLoggUt.MouseHover += new System.EventHandler(this.loggUtToolStripMenuItem_MouseHover);
            // 
            // menyHjelp
            // 
            this.menyHjelp.BackColor = System.Drawing.Color.Transparent;
            this.menyHjelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menyVisHjelp,
            this.menyOm});
            this.menyHjelp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menyHjelp.ForeColor = System.Drawing.Color.White;
            this.menyHjelp.Name = "menyHjelp";
            this.menyHjelp.Size = new System.Drawing.Size(63, 27);
            this.menyHjelp.Text = "Hjelp";
            this.menyHjelp.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.menyHjelp.MouseHover += new System.EventHandler(this.filToolStripMenuItem_MouseHover);
            // 
            // menyVisHjelp
            // 
            this.menyVisHjelp.Name = "menyVisHjelp";
            this.menyVisHjelp.Size = new System.Drawing.Size(152, 26);
            this.menyVisHjelp.Text = "Vis hjelp";
            this.menyVisHjelp.Click += new System.EventHandler(this.visHjelpToolStripMenuItem_Click);
            this.menyVisHjelp.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.menyVisHjelp.MouseHover += new System.EventHandler(this.filToolStripMenuItem_MouseHover);
            // 
            // menyOm
            // 
            this.menyOm.Name = "menyOm";
            this.menyOm.Size = new System.Drawing.Size(152, 26);
            this.menyOm.Text = "Om";
            this.menyOm.Click += new System.EventHandler(this.omToolStripMenuItem_Click);
            this.menyOm.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.menyOm.MouseHover += new System.EventHandler(this.filToolStripMenuItem_MouseHover);
            // 
            // lblDato
            // 
            this.lblDato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDato.AutoSize = true;
            this.lblDato.BackColor = System.Drawing.Color.Transparent;
            this.lblDato.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDato.ForeColor = System.Drawing.Color.White;
            this.lblDato.Location = new System.Drawing.Point(1110, 658);
            this.lblDato.Name = "lblDato";
            this.lblDato.Size = new System.Drawing.Size(126, 21);
            this.lblDato.TabIndex = 11;
            this.lblDato.Text = "Dato og klokke";
            // 
            // panelMeny
            // 
            this.panelMeny.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMeny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.panelMeny.Controls.Add(this.butDeltest);
            this.panelMeny.Controls.Add(this.butKlasse);
            this.panelMeny.Controls.Add(this.butBruker);
            this.panelMeny.Controls.Add(this.butResultat);
            this.panelMeny.Controls.Add(this.butTest);
            this.panelMeny.Controls.Add(this.butElev);
            this.panelMeny.Location = new System.Drawing.Point(0, 32);
            this.panelMeny.Name = "panelMeny";
            this.panelMeny.Size = new System.Drawing.Size(135, 623);
            this.panelMeny.TabIndex = 12;
            // 
            // butDeltest
            // 
            this.butDeltest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butDeltest.AutoSize = true;
            this.butDeltest.BackColor = System.Drawing.Color.Transparent;
            this.butDeltest.FlatAppearance.BorderSize = 0;
            this.butDeltest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butDeltest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butDeltest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butDeltest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeltest.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDeltest.ForeColor = System.Drawing.SystemColors.Control;
            this.butDeltest.Location = new System.Drawing.Point(0, 201);
            this.butDeltest.Name = "butDeltest";
            this.butDeltest.Size = new System.Drawing.Size(135, 35);
            this.butDeltest.TabIndex = 2;
            this.butDeltest.Text = "Deltester";
            this.butDeltest.UseVisualStyleBackColor = false;
            this.butDeltest.Click += new System.EventHandler(this.butDeltest_Click);
            this.butDeltest.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.butDeltest.MouseHover += new System.EventHandler(this.butDeltest_MouseHover);
            // 
            // butResultat
            // 
            this.butResultat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butResultat.AutoSize = true;
            this.butResultat.BackColor = System.Drawing.Color.Transparent;
            this.butResultat.FlatAppearance.BorderSize = 0;
            this.butResultat.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butResultat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butResultat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.butResultat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butResultat.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butResultat.ForeColor = System.Drawing.SystemColors.Control;
            this.butResultat.Location = new System.Drawing.Point(0, 59);
            this.butResultat.Name = "butResultat";
            this.butResultat.Size = new System.Drawing.Size(135, 35);
            this.butResultat.TabIndex = 0;
            this.butResultat.Text = "Resultater";
            this.butResultat.UseVisualStyleBackColor = false;
            this.butResultat.Click += new System.EventHandler(this.butResultat_Click);
            this.butResultat.MouseLeave += new System.EventHandler(this.frmHoved_MouseHover);
            this.butResultat.MouseHover += new System.EventHandler(this.butResultat_MouseHover);
            // 
            // lblBrukerStatus
            // 
            this.lblBrukerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBrukerStatus.AutoSize = true;
            this.lblBrukerStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblBrukerStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrukerStatus.ForeColor = System.Drawing.Color.White;
            this.lblBrukerStatus.Location = new System.Drawing.Point(3, 657);
            this.lblBrukerStatus.Name = "lblBrukerStatus";
            this.lblBrukerStatus.Size = new System.Drawing.Size(121, 21);
            this.lblBrukerStatus.TabIndex = 14;
            this.lblBrukerStatus.Text = "Innlogget som";
            // 
            // tabDeltest
            // 
            this.tabDeltest.Controls.Add(this.panelDeltest);
            this.tabDeltest.Controls.Add(this.dgvDeltest);
            this.tabDeltest.Location = new System.Drawing.Point(4, 22);
            this.tabDeltest.Name = "tabDeltest";
            this.tabDeltest.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeltest.Size = new System.Drawing.Size(1122, 602);
            this.tabDeltest.TabIndex = 7;
            this.tabDeltest.Text = "Deltest";
            this.tabDeltest.UseVisualStyleBackColor = true;
            // 
            // panelDeltest
            // 
            this.panelDeltest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDeltest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.panelDeltest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDeltest.Controls.Add(this.cmbDeltestFag);
            this.panelDeltest.Controls.Add(this.lblDeltestFag);
            this.panelDeltest.Controls.Add(this.cmbDeltestTest);
            this.panelDeltest.Controls.Add(this.numDeltestKritisk);
            this.panelDeltest.Controls.Add(this.numDeltestMaks);
            this.panelDeltest.Controls.Add(this.txtDeltestNavn);
            this.panelDeltest.Controls.Add(this.cmbDeltestSem);
            this.panelDeltest.Controls.Add(this.lblDeltestTest);
            this.panelDeltest.Controls.Add(this.lblDeltestMakspoeng);
            this.panelDeltest.Controls.Add(this.lblDeltestSemester);
            this.panelDeltest.Controls.Add(this.lblDeltestNavn);
            this.panelDeltest.Controls.Add(this.lblDeltestKritisk);
            this.panelDeltest.Controls.Add(this.butDeltestTøm);
            this.panelDeltest.Controls.Add(this.butDeltestReg);
            this.panelDeltest.Controls.Add(this.butDeltestSlett);
            this.panelDeltest.Controls.Add(this.butDeltestEndre);
            this.panelDeltest.Location = new System.Drawing.Point(0, 0);
            this.panelDeltest.Name = "panelDeltest";
            this.panelDeltest.Size = new System.Drawing.Size(1120, 93);
            this.panelDeltest.TabIndex = 73;
            // 
            // cmbDeltestFag
            // 
            this.cmbDeltestFag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbDeltestFag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeltestFag.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbDeltestFag.FormattingEnabled = true;
            this.cmbDeltestFag.Location = new System.Drawing.Point(24, 18);
            this.cmbDeltestFag.MaxDropDownItems = 30;
            this.cmbDeltestFag.Name = "cmbDeltestFag";
            this.cmbDeltestFag.Size = new System.Drawing.Size(218, 33);
            this.cmbDeltestFag.TabIndex = 87;
            this.cmbDeltestFag.TextChanged += new System.EventHandler(this.cmbDeltestFag_TextChanged);
            // 
            // lblDeltestFag
            // 
            this.lblDeltestFag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDeltestFag.AutoSize = true;
            this.lblDeltestFag.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeltestFag.Location = new System.Drawing.Point(106, -3);
            this.lblDeltestFag.Name = "lblDeltestFag";
            this.lblDeltestFag.Size = new System.Drawing.Size(37, 21);
            this.lblDeltestFag.TabIndex = 88;
            this.lblDeltestFag.Text = "Fag";
            // 
            // cmbDeltestTest
            // 
            this.cmbDeltestTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbDeltestTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeltestTest.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbDeltestTest.FormattingEnabled = true;
            this.cmbDeltestTest.Location = new System.Drawing.Point(257, 18);
            this.cmbDeltestTest.MaxDropDownItems = 30;
            this.cmbDeltestTest.Name = "cmbDeltestTest";
            this.cmbDeltestTest.Size = new System.Drawing.Size(246, 33);
            this.cmbDeltestTest.TabIndex = 39;
            this.cmbDeltestTest.TextChanged += new System.EventHandler(this.cmbDeltestTest_TextChanged);
            // 
            // numDeltestKritisk
            // 
            this.numDeltestKritisk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numDeltestKritisk.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.numDeltestKritisk.Location = new System.Drawing.Point(776, 19);
            this.numDeltestKritisk.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numDeltestKritisk.Name = "numDeltestKritisk";
            this.numDeltestKritisk.ReadOnly = true;
            this.numDeltestKritisk.Size = new System.Drawing.Size(100, 32);
            this.numDeltestKritisk.TabIndex = 41;
            this.numDeltestKritisk.ValueChanged += new System.EventHandler(this.txtDeltestNavn_TextChanged);
            // 
            // numDeltestMaks
            // 
            this.numDeltestMaks.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numDeltestMaks.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.numDeltestMaks.Location = new System.Drawing.Point(886, 19);
            this.numDeltestMaks.Name = "numDeltestMaks";
            this.numDeltestMaks.ReadOnly = true;
            this.numDeltestMaks.Size = new System.Drawing.Size(100, 32);
            this.numDeltestMaks.TabIndex = 42;
            this.numDeltestMaks.ValueChanged += new System.EventHandler(this.txtDeltestNavn_TextChanged);
            // 
            // txtDeltestNavn
            // 
            this.txtDeltestNavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDeltestNavn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtDeltestNavn.Location = new System.Drawing.Point(509, 19);
            this.txtDeltestNavn.MaxLength = 45;
            this.txtDeltestNavn.Name = "txtDeltestNavn";
            this.txtDeltestNavn.Size = new System.Drawing.Size(257, 32);
            this.txtDeltestNavn.TabIndex = 40;
            this.txtDeltestNavn.TextChanged += new System.EventHandler(this.txtDeltestNavn_TextChanged);
            // 
            // cmbDeltestSem
            // 
            this.cmbDeltestSem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbDeltestSem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeltestSem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbDeltestSem.FormattingEnabled = true;
            this.cmbDeltestSem.Location = new System.Drawing.Point(994, 18);
            this.cmbDeltestSem.Name = "cmbDeltestSem";
            this.cmbDeltestSem.Size = new System.Drawing.Size(100, 33);
            this.cmbDeltestSem.TabIndex = 43;
            this.cmbDeltestSem.TextChanged += new System.EventHandler(this.txtDeltestNavn_TextChanged);
            // 
            // lblDeltestTest
            // 
            this.lblDeltestTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDeltestTest.AutoSize = true;
            this.lblDeltestTest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeltestTest.Location = new System.Drawing.Point(356, -1);
            this.lblDeltestTest.Name = "lblDeltestTest";
            this.lblDeltestTest.Size = new System.Drawing.Size(40, 21);
            this.lblDeltestTest.TabIndex = 86;
            this.lblDeltestTest.Text = "Test";
            // 
            // lblDeltestMakspoeng
            // 
            this.lblDeltestMakspoeng.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDeltestMakspoeng.AutoSize = true;
            this.lblDeltestMakspoeng.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeltestMakspoeng.Location = new System.Drawing.Point(887, -1);
            this.lblDeltestMakspoeng.Name = "lblDeltestMakspoeng";
            this.lblDeltestMakspoeng.Size = new System.Drawing.Size(99, 21);
            this.lblDeltestMakspoeng.TabIndex = 66;
            this.lblDeltestMakspoeng.Text = "Makspoeng";
            // 
            // lblDeltestSemester
            // 
            this.lblDeltestSemester.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDeltestSemester.AutoSize = true;
            this.lblDeltestSemester.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeltestSemester.Location = new System.Drawing.Point(1002, -1);
            this.lblDeltestSemester.Name = "lblDeltestSemester";
            this.lblDeltestSemester.Size = new System.Drawing.Size(80, 21);
            this.lblDeltestSemester.TabIndex = 79;
            this.lblDeltestSemester.Text = "Semester";
            // 
            // lblDeltestNavn
            // 
            this.lblDeltestNavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDeltestNavn.AutoSize = true;
            this.lblDeltestNavn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeltestNavn.Location = new System.Drawing.Point(608, -1);
            this.lblDeltestNavn.Name = "lblDeltestNavn";
            this.lblDeltestNavn.Size = new System.Drawing.Size(51, 21);
            this.lblDeltestNavn.TabIndex = 67;
            this.lblDeltestNavn.Text = "Navn";
            // 
            // lblDeltestKritisk
            // 
            this.lblDeltestKritisk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDeltestKritisk.AutoSize = true;
            this.lblDeltestKritisk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeltestKritisk.Location = new System.Drawing.Point(772, -1);
            this.lblDeltestKritisk.Name = "lblDeltestKritisk";
            this.lblDeltestKritisk.Size = new System.Drawing.Size(113, 21);
            this.lblDeltestKritisk.TabIndex = 69;
            this.lblDeltestKritisk.Text = "Kritisk grense";
            // 
            // butDeltestTøm
            // 
            this.butDeltestTøm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butDeltestTøm.AutoSize = true;
            this.butDeltestTøm.FlatAppearance.BorderSize = 0;
            this.butDeltestTøm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butDeltestTøm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeltestTøm.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butDeltestTøm.Location = new System.Drawing.Point(643, 51);
            this.butDeltestTøm.Name = "butDeltestTøm";
            this.butDeltestTøm.Size = new System.Drawing.Size(67, 40);
            this.butDeltestTøm.TabIndex = 47;
            this.butDeltestTøm.Text = "Tøm";
            this.butDeltestTøm.UseVisualStyleBackColor = true;
            this.butDeltestTøm.Click += new System.EventHandler(this.butDeltestTøm_Click);
            // 
            // butDeltestReg
            // 
            this.butDeltestReg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butDeltestReg.AutoSize = true;
            this.butDeltestReg.Enabled = false;
            this.butDeltestReg.FlatAppearance.BorderSize = 0;
            this.butDeltestReg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butDeltestReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeltestReg.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butDeltestReg.Location = new System.Drawing.Point(362, 51);
            this.butDeltestReg.Name = "butDeltestReg";
            this.butDeltestReg.Size = new System.Drawing.Size(110, 40);
            this.butDeltestReg.TabIndex = 44;
            this.butDeltestReg.Text = "Registrer";
            this.butDeltestReg.UseVisualStyleBackColor = true;
            this.butDeltestReg.Click += new System.EventHandler(this.butDeltestReg_Click);
            // 
            // butDeltestSlett
            // 
            this.butDeltestSlett.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butDeltestSlett.AutoSize = true;
            this.butDeltestSlett.Enabled = false;
            this.butDeltestSlett.FlatAppearance.BorderSize = 0;
            this.butDeltestSlett.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butDeltestSlett.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeltestSlett.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butDeltestSlett.Location = new System.Drawing.Point(565, 51);
            this.butDeltestSlett.Name = "butDeltestSlett";
            this.butDeltestSlett.Size = new System.Drawing.Size(68, 40);
            this.butDeltestSlett.TabIndex = 46;
            this.butDeltestSlett.Text = "Slett";
            this.butDeltestSlett.UseVisualStyleBackColor = true;
            this.butDeltestSlett.Click += new System.EventHandler(this.butDeltestSlett_Click);
            // 
            // butDeltestEndre
            // 
            this.butDeltestEndre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butDeltestEndre.AutoSize = true;
            this.butDeltestEndre.Enabled = false;
            this.butDeltestEndre.FlatAppearance.BorderSize = 0;
            this.butDeltestEndre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butDeltestEndre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeltestEndre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butDeltestEndre.Location = new System.Drawing.Point(477, 51);
            this.butDeltestEndre.Name = "butDeltestEndre";
            this.butDeltestEndre.Size = new System.Drawing.Size(79, 40);
            this.butDeltestEndre.TabIndex = 45;
            this.butDeltestEndre.Text = "Endre";
            this.butDeltestEndre.UseVisualStyleBackColor = true;
            this.butDeltestEndre.Click += new System.EventHandler(this.butDeltestEndre_Click);
            // 
            // dgvDeltest
            // 
            this.dgvDeltest.AllowUserToAddRows = false;
            this.dgvDeltest.AllowUserToDeleteRows = false;
            this.dgvDeltest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeltest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeltest.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDeltest.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeltest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDeltest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeltest.Location = new System.Drawing.Point(0, 93);
            this.dgvDeltest.MultiSelect = false;
            this.dgvDeltest.Name = "dgvDeltest";
            this.dgvDeltest.ReadOnly = true;
            this.dgvDeltest.RowHeadersVisible = false;
            this.dgvDeltest.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dgvDeltest.RowTemplate.Height = 18;
            this.dgvDeltest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeltest.Size = new System.Drawing.Size(1120, 509);
            this.dgvDeltest.TabIndex = 48;
            this.dgvDeltest.TabStop = false;
            this.dgvDeltest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeltest_CellClick);
            this.dgvDeltest.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDeltest_ColumnHeaderMouseClick);
            this.dgvDeltest.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDeltest_ColumnHeaderMouseClick);
            // 
            // tabKlasser
            // 
            this.tabKlasser.Controls.Add(this.panelKlasser);
            this.tabKlasser.Controls.Add(this.dgvKlasser);
            this.tabKlasser.Controls.Add(this.dgvKlasserTest);
            this.tabKlasser.Location = new System.Drawing.Point(4, 22);
            this.tabKlasser.Name = "tabKlasser";
            this.tabKlasser.Padding = new System.Windows.Forms.Padding(3);
            this.tabKlasser.Size = new System.Drawing.Size(1122, 602);
            this.tabKlasser.TabIndex = 6;
            this.tabKlasser.Text = "Klasse";
            this.tabKlasser.UseVisualStyleBackColor = true;
            // 
            // panelKlasser
            // 
            this.panelKlasser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelKlasser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.panelKlasser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKlasser.Controls.Add(this.cmbKlasserFag);
            this.panelKlasser.Controls.Add(this.label6);
            this.panelKlasser.Controls.Add(this.cmbKlasserTest);
            this.panelKlasser.Controls.Add(this.txtKlasserBet);
            this.panelKlasser.Controls.Add(this.txtKlasserÅr);
            this.panelKlasser.Controls.Add(this.lblKlasserSkoleår);
            this.panelKlasser.Controls.Add(this.lblKlasserBetegnelse);
            this.panelKlasser.Controls.Add(this.lblKlasseTester);
            this.panelKlasser.Controls.Add(this.butKlasserTøm);
            this.panelKlasser.Controls.Add(this.butKlasserReg);
            this.panelKlasser.Controls.Add(this.butKlasserSlett);
            this.panelKlasser.Controls.Add(this.butKlasserEndre);
            this.panelKlasser.Controls.Add(this.butKlasserRegTest);
            this.panelKlasser.Location = new System.Drawing.Point(0, 0);
            this.panelKlasser.Name = "panelKlasser";
            this.panelKlasser.Size = new System.Drawing.Size(1120, 93);
            this.panelKlasser.TabIndex = 66;
            // 
            // cmbKlasserFag
            // 
            this.cmbKlasserFag.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbKlasserFag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKlasserFag.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbKlasserFag.FormattingEnabled = true;
            this.cmbKlasserFag.Location = new System.Drawing.Point(655, 19);
            this.cmbKlasserFag.MaxDropDownItems = 30;
            this.cmbKlasserFag.Name = "cmbKlasserFag";
            this.cmbKlasserFag.Size = new System.Drawing.Size(195, 33);
            this.cmbKlasserFag.TabIndex = 91;
            this.cmbKlasserFag.TextChanged += new System.EventHandler(this.cmbKlasseFag_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(732, -2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 21);
            this.label6.TabIndex = 92;
            this.label6.Text = "Fag";
            // 
            // cmbKlasserTest
            // 
            this.cmbKlasserTest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbKlasserTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKlasserTest.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbKlasserTest.FormattingEnabled = true;
            this.cmbKlasserTest.Location = new System.Drawing.Point(855, 19);
            this.cmbKlasserTest.Name = "cmbKlasserTest";
            this.cmbKlasserTest.Size = new System.Drawing.Size(257, 33);
            this.cmbKlasserTest.TabIndex = 70;
            // 
            // txtKlasserBet
            // 
            this.txtKlasserBet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtKlasserBet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKlasserBet.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtKlasserBet.Location = new System.Drawing.Point(323, 20);
            this.txtKlasserBet.MaxLength = 10;
            this.txtKlasserBet.Name = "txtKlasserBet";
            this.txtKlasserBet.Size = new System.Drawing.Size(160, 32);
            this.txtKlasserBet.TabIndex = 64;
            this.txtKlasserBet.TextChanged += new System.EventHandler(this.txtKlasser_TextChanged);
            // 
            // txtKlasserÅr
            // 
            this.txtKlasserÅr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtKlasserÅr.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtKlasserÅr.Location = new System.Drawing.Point(500, 20);
            this.txtKlasserÅr.MaxLength = 10;
            this.txtKlasserÅr.Name = "txtKlasserÅr";
            this.txtKlasserÅr.ShortcutsEnabled = false;
            this.txtKlasserÅr.Size = new System.Drawing.Size(149, 32);
            this.txtKlasserÅr.TabIndex = 65;
            this.txtKlasserÅr.TextChanged += new System.EventHandler(this.txtKlasser_TextChanged);
            this.txtKlasserÅr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKlasserSkoleår_KeyPress);
            // 
            // lblKlasserSkoleår
            // 
            this.lblKlasserSkoleår.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblKlasserSkoleår.AutoSize = true;
            this.lblKlasserSkoleår.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKlasserSkoleår.Location = new System.Drawing.Point(536, 0);
            this.lblKlasserSkoleår.Name = "lblKlasserSkoleår";
            this.lblKlasserSkoleår.Size = new System.Drawing.Size(67, 21);
            this.lblKlasserSkoleår.TabIndex = 66;
            this.lblKlasserSkoleår.Text = "Skoleår";
            // 
            // lblKlasserBetegnelse
            // 
            this.lblKlasserBetegnelse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblKlasserBetegnelse.AutoSize = true;
            this.lblKlasserBetegnelse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKlasserBetegnelse.Location = new System.Drawing.Point(355, 0);
            this.lblKlasserBetegnelse.Name = "lblKlasserBetegnelse";
            this.lblKlasserBetegnelse.Size = new System.Drawing.Size(94, 21);
            this.lblKlasserBetegnelse.TabIndex = 67;
            this.lblKlasserBetegnelse.Text = "Betegnelse";
            // 
            // lblKlasseTester
            // 
            this.lblKlasseTester.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblKlasseTester.AutoSize = true;
            this.lblKlasseTester.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKlasseTester.Location = new System.Drawing.Point(953, -2);
            this.lblKlasseTester.Name = "lblKlasseTester";
            this.lblKlasseTester.Size = new System.Drawing.Size(55, 21);
            this.lblKlasseTester.TabIndex = 90;
            this.lblKlasseTester.Text = "Tester";
            // 
            // butKlasserTøm
            // 
            this.butKlasserTøm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butKlasserTøm.AutoSize = true;
            this.butKlasserTøm.FlatAppearance.BorderSize = 0;
            this.butKlasserTøm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butKlasserTøm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butKlasserTøm.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butKlasserTøm.Location = new System.Drawing.Point(593, 52);
            this.butKlasserTøm.Name = "butKlasserTøm";
            this.butKlasserTøm.Size = new System.Drawing.Size(67, 40);
            this.butKlasserTøm.TabIndex = 69;
            this.butKlasserTøm.Text = "Tøm";
            this.butKlasserTøm.UseVisualStyleBackColor = true;
            this.butKlasserTøm.Click += new System.EventHandler(this.butKlasseTøm_Click);
            // 
            // butKlasserReg
            // 
            this.butKlasserReg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butKlasserReg.AutoSize = true;
            this.butKlasserReg.Enabled = false;
            this.butKlasserReg.FlatAppearance.BorderSize = 0;
            this.butKlasserReg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butKlasserReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butKlasserReg.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butKlasserReg.Location = new System.Drawing.Point(323, 52);
            this.butKlasserReg.Name = "butKlasserReg";
            this.butKlasserReg.Size = new System.Drawing.Size(110, 40);
            this.butKlasserReg.TabIndex = 66;
            this.butKlasserReg.Text = "Registrer";
            this.butKlasserReg.UseVisualStyleBackColor = true;
            this.butKlasserReg.Click += new System.EventHandler(this.butKlasseReg_Click);
            // 
            // butKlasserSlett
            // 
            this.butKlasserSlett.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butKlasserSlett.AutoSize = true;
            this.butKlasserSlett.Enabled = false;
            this.butKlasserSlett.FlatAppearance.BorderSize = 0;
            this.butKlasserSlett.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butKlasserSlett.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butKlasserSlett.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butKlasserSlett.Location = new System.Drawing.Point(520, 52);
            this.butKlasserSlett.Name = "butKlasserSlett";
            this.butKlasserSlett.Size = new System.Drawing.Size(68, 40);
            this.butKlasserSlett.TabIndex = 68;
            this.butKlasserSlett.Text = "Slett";
            this.butKlasserSlett.UseVisualStyleBackColor = true;
            this.butKlasserSlett.Click += new System.EventHandler(this.butKlasseSlett_Click);
            // 
            // butKlasserEndre
            // 
            this.butKlasserEndre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butKlasserEndre.AutoSize = true;
            this.butKlasserEndre.Enabled = false;
            this.butKlasserEndre.FlatAppearance.BorderSize = 0;
            this.butKlasserEndre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butKlasserEndre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butKlasserEndre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butKlasserEndre.Location = new System.Drawing.Point(438, 52);
            this.butKlasserEndre.Name = "butKlasserEndre";
            this.butKlasserEndre.Size = new System.Drawing.Size(79, 40);
            this.butKlasserEndre.TabIndex = 67;
            this.butKlasserEndre.Text = "Endre";
            this.butKlasserEndre.UseVisualStyleBackColor = true;
            this.butKlasserEndre.Click += new System.EventHandler(this.butKlasseEndre_Click);
            // 
            // butKlasserRegTest
            // 
            this.butKlasserRegTest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.butKlasserRegTest.AutoSize = true;
            this.butKlasserRegTest.FlatAppearance.BorderSize = 0;
            this.butKlasserRegTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butKlasserRegTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butKlasserRegTest.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butKlasserRegTest.Location = new System.Drawing.Point(890, 52);
            this.butKlasserRegTest.Name = "butKlasserRegTest";
            this.butKlasserRegTest.Size = new System.Drawing.Size(196, 40);
            this.butKlasserRegTest.TabIndex = 71;
            this.butKlasserRegTest.Text = "Reg test på klasse";
            this.butKlasserRegTest.UseVisualStyleBackColor = true;
            this.butKlasserRegTest.Click += new System.EventHandler(this.butKlasseRegTest_Click);
            // 
            // dgvKlasser
            // 
            this.dgvKlasser.AllowUserToAddRows = false;
            this.dgvKlasser.AllowUserToDeleteRows = false;
            this.dgvKlasser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKlasser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKlasser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvKlasser.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKlasser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKlasser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlasser.Location = new System.Drawing.Point(0, 93);
            this.dgvKlasser.MultiSelect = false;
            this.dgvKlasser.Name = "dgvKlasser";
            this.dgvKlasser.ReadOnly = true;
            this.dgvKlasser.RowHeadersVisible = false;
            this.dgvKlasser.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dgvKlasser.RowTemplate.Height = 18;
            this.dgvKlasser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlasser.Size = new System.Drawing.Size(1120, 325);
            this.dgvKlasser.TabIndex = 72;
            this.dgvKlasser.TabStop = false;
            this.dgvKlasser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKlasser_CellClick);
            this.dgvKlasser.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvKlasser_ColumnHeaderMouseClick);
            this.dgvKlasser.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvKlasser_ColumnHeaderMouseClick);
            // 
            // dgvKlasserTest
            // 
            this.dgvKlasserTest.AllowUserToAddRows = false;
            this.dgvKlasserTest.AllowUserToDeleteRows = false;
            this.dgvKlasserTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKlasserTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKlasserTest.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvKlasserTest.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKlasserTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKlasserTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlasserTest.Location = new System.Drawing.Point(0, 418);
            this.dgvKlasserTest.MultiSelect = false;
            this.dgvKlasserTest.Name = "dgvKlasserTest";
            this.dgvKlasserTest.ReadOnly = true;
            this.dgvKlasserTest.RowHeadersVisible = false;
            this.dgvKlasserTest.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dgvKlasserTest.RowTemplate.Height = 18;
            this.dgvKlasserTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlasserTest.Size = new System.Drawing.Size(1120, 184);
            this.dgvKlasserTest.TabIndex = 73;
            this.dgvKlasserTest.TabStop = false;
            this.dgvKlasserTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKlasseTest_CellClick);
            this.dgvKlasserTest.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseClick);
            this.dgvKlasserTest.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseClick);
            // 
            // tabBrukere
            // 
            this.tabBrukere.Controls.Add(this.panelBrukere);
            this.tabBrukere.Controls.Add(this.dgvBrukere);
            this.tabBrukere.Location = new System.Drawing.Point(4, 22);
            this.tabBrukere.Name = "tabBrukere";
            this.tabBrukere.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrukere.Size = new System.Drawing.Size(1122, 602);
            this.tabBrukere.TabIndex = 5;
            this.tabBrukere.Text = "Bruker";
            this.tabBrukere.UseVisualStyleBackColor = true;
            // 
            // panelBrukere
            // 
            this.panelBrukere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBrukere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.panelBrukere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBrukere.Controls.Add(this.txtBrukerPassord);
            this.panelBrukere.Controls.Add(this.txtBrukerBrukernavn);
            this.panelBrukere.Controls.Add(this.cmbBrukerType);
            this.panelBrukere.Controls.Add(this.txtBrukerFornavn);
            this.panelBrukere.Controls.Add(this.txtBrukerEtternavn);
            this.panelBrukere.Controls.Add(this.lblBrukerFornavn);
            this.panelBrukere.Controls.Add(this.lblBrukerPassord);
            this.panelBrukere.Controls.Add(this.lblBrukerBrukernavn);
            this.panelBrukere.Controls.Add(this.lblBrukerEtternavn);
            this.panelBrukere.Controls.Add(this.lblBrukerType);
            this.panelBrukere.Controls.Add(this.butBrukerTøm);
            this.panelBrukere.Controls.Add(this.butBrukerReg);
            this.panelBrukere.Controls.Add(this.butBrukerSlett);
            this.panelBrukere.Controls.Add(this.butBrukerEndre);
            this.panelBrukere.Location = new System.Drawing.Point(0, 0);
            this.panelBrukere.Name = "panelBrukere";
            this.panelBrukere.Size = new System.Drawing.Size(1120, 93);
            this.panelBrukere.TabIndex = 15;
            // 
            // txtBrukerPassord
            // 
            this.txtBrukerPassord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBrukerPassord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtBrukerPassord.Location = new System.Drawing.Point(701, 22);
            this.txtBrukerPassord.MaxLength = 20;
            this.txtBrukerPassord.Name = "txtBrukerPassord";
            this.txtBrukerPassord.Size = new System.Drawing.Size(168, 29);
            this.txtBrukerPassord.TabIndex = 77;
            this.txtBrukerPassord.UseSystemPasswordChar = true;
            this.txtBrukerPassord.TextChanged += new System.EventHandler(this.txtBruker_TextChanged);
            // 
            // txtBrukerBrukernavn
            // 
            this.txtBrukerBrukernavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBrukerBrukernavn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtBrukerBrukernavn.Location = new System.Drawing.Point(528, 22);
            this.txtBrukerBrukernavn.MaxLength = 20;
            this.txtBrukerBrukernavn.Name = "txtBrukerBrukernavn";
            this.txtBrukerBrukernavn.Size = new System.Drawing.Size(167, 29);
            this.txtBrukerBrukernavn.TabIndex = 76;
            this.txtBrukerBrukernavn.TextChanged += new System.EventHandler(this.txtBruker_TextChanged);
            // 
            // cmbBrukerType
            // 
            this.cmbBrukerType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbBrukerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrukerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmbBrukerType.FormattingEnabled = true;
            this.cmbBrukerType.Location = new System.Drawing.Point(875, 22);
            this.cmbBrukerType.Name = "cmbBrukerType";
            this.cmbBrukerType.Size = new System.Drawing.Size(119, 32);
            this.cmbBrukerType.TabIndex = 78;
            // 
            // txtBrukerFornavn
            // 
            this.txtBrukerFornavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBrukerFornavn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtBrukerFornavn.Location = new System.Drawing.Point(142, 22);
            this.txtBrukerFornavn.MaxLength = 45;
            this.txtBrukerFornavn.Name = "txtBrukerFornavn";
            this.txtBrukerFornavn.Size = new System.Drawing.Size(193, 29);
            this.txtBrukerFornavn.TabIndex = 74;
            this.txtBrukerFornavn.TextChanged += new System.EventHandler(this.txtBruker_TextChanged);
            this.txtBrukerFornavn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNavn_KeyPress);
            // 
            // txtBrukerEtternavn
            // 
            this.txtBrukerEtternavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBrukerEtternavn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtBrukerEtternavn.Location = new System.Drawing.Point(340, 22);
            this.txtBrukerEtternavn.MaxLength = 45;
            this.txtBrukerEtternavn.Name = "txtBrukerEtternavn";
            this.txtBrukerEtternavn.Size = new System.Drawing.Size(181, 29);
            this.txtBrukerEtternavn.TabIndex = 75;
            this.txtBrukerEtternavn.TextChanged += new System.EventHandler(this.txtBruker_TextChanged);
            this.txtBrukerEtternavn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNavn_KeyPress);
            // 
            // lblBrukerFornavn
            // 
            this.lblBrukerFornavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBrukerFornavn.AutoSize = true;
            this.lblBrukerFornavn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBrukerFornavn.Location = new System.Drawing.Point(199, 0);
            this.lblBrukerFornavn.Name = "lblBrukerFornavn";
            this.lblBrukerFornavn.Size = new System.Drawing.Size(72, 21);
            this.lblBrukerFornavn.TabIndex = 66;
            this.lblBrukerFornavn.Text = "Fornavn";
            // 
            // lblBrukerPassord
            // 
            this.lblBrukerPassord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBrukerPassord.AutoSize = true;
            this.lblBrukerPassord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBrukerPassord.Location = new System.Drawing.Point(744, 2);
            this.lblBrukerPassord.Name = "lblBrukerPassord";
            this.lblBrukerPassord.Size = new System.Drawing.Size(69, 21);
            this.lblBrukerPassord.TabIndex = 79;
            this.lblBrukerPassord.Text = "Passord";
            // 
            // lblBrukerBrukernavn
            // 
            this.lblBrukerBrukernavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBrukerBrukernavn.AutoSize = true;
            this.lblBrukerBrukernavn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBrukerBrukernavn.Location = new System.Drawing.Point(557, 0);
            this.lblBrukerBrukernavn.Name = "lblBrukerBrukernavn";
            this.lblBrukerBrukernavn.Size = new System.Drawing.Size(98, 21);
            this.lblBrukerBrukernavn.TabIndex = 67;
            this.lblBrukerBrukernavn.Text = "Brukernavn";
            // 
            // lblBrukerEtternavn
            // 
            this.lblBrukerEtternavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBrukerEtternavn.AutoSize = true;
            this.lblBrukerEtternavn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBrukerEtternavn.Location = new System.Drawing.Point(392, 0);
            this.lblBrukerEtternavn.Name = "lblBrukerEtternavn";
            this.lblBrukerEtternavn.Size = new System.Drawing.Size(84, 21);
            this.lblBrukerEtternavn.TabIndex = 68;
            this.lblBrukerEtternavn.Text = "Etternavn";
            // 
            // lblBrukerType
            // 
            this.lblBrukerType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBrukerType.AutoSize = true;
            this.lblBrukerType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBrukerType.Location = new System.Drawing.Point(908, 1);
            this.lblBrukerType.Name = "lblBrukerType";
            this.lblBrukerType.Size = new System.Drawing.Size(46, 21);
            this.lblBrukerType.TabIndex = 69;
            this.lblBrukerType.Text = "Type";
            // 
            // butBrukerTøm
            // 
            this.butBrukerTøm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butBrukerTøm.AutoSize = true;
            this.butBrukerTøm.FlatAppearance.BorderSize = 0;
            this.butBrukerTøm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butBrukerTøm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBrukerTøm.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butBrukerTøm.Location = new System.Drawing.Point(643, 51);
            this.butBrukerTøm.Name = "butBrukerTøm";
            this.butBrukerTøm.Size = new System.Drawing.Size(67, 40);
            this.butBrukerTøm.TabIndex = 82;
            this.butBrukerTøm.Text = "Tøm";
            this.butBrukerTøm.UseVisualStyleBackColor = true;
            this.butBrukerTøm.Click += new System.EventHandler(this.butBrukerTøm_Click);
            // 
            // butBrukerReg
            // 
            this.butBrukerReg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butBrukerReg.AutoSize = true;
            this.butBrukerReg.Enabled = false;
            this.butBrukerReg.FlatAppearance.BorderSize = 0;
            this.butBrukerReg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butBrukerReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBrukerReg.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butBrukerReg.Location = new System.Drawing.Point(362, 51);
            this.butBrukerReg.Name = "butBrukerReg";
            this.butBrukerReg.Size = new System.Drawing.Size(110, 40);
            this.butBrukerReg.TabIndex = 79;
            this.butBrukerReg.Text = "Registrer";
            this.butBrukerReg.UseVisualStyleBackColor = true;
            this.butBrukerReg.Click += new System.EventHandler(this.butBrukerReg_Click);
            // 
            // butBrukerSlett
            // 
            this.butBrukerSlett.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butBrukerSlett.AutoSize = true;
            this.butBrukerSlett.Enabled = false;
            this.butBrukerSlett.FlatAppearance.BorderSize = 0;
            this.butBrukerSlett.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butBrukerSlett.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBrukerSlett.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butBrukerSlett.Location = new System.Drawing.Point(565, 51);
            this.butBrukerSlett.Name = "butBrukerSlett";
            this.butBrukerSlett.Size = new System.Drawing.Size(68, 40);
            this.butBrukerSlett.TabIndex = 81;
            this.butBrukerSlett.Text = "Slett";
            this.butBrukerSlett.UseVisualStyleBackColor = true;
            this.butBrukerSlett.Click += new System.EventHandler(this.butBrukerSlett_Click_1);
            // 
            // butBrukerEndre
            // 
            this.butBrukerEndre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butBrukerEndre.AutoSize = true;
            this.butBrukerEndre.Enabled = false;
            this.butBrukerEndre.FlatAppearance.BorderSize = 0;
            this.butBrukerEndre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butBrukerEndre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBrukerEndre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butBrukerEndre.Location = new System.Drawing.Point(477, 51);
            this.butBrukerEndre.Name = "butBrukerEndre";
            this.butBrukerEndre.Size = new System.Drawing.Size(79, 40);
            this.butBrukerEndre.TabIndex = 80;
            this.butBrukerEndre.Text = "Endre";
            this.butBrukerEndre.UseVisualStyleBackColor = true;
            this.butBrukerEndre.Click += new System.EventHandler(this.butBrukerEndre_Click);
            // 
            // dgvBrukere
            // 
            this.dgvBrukere.AllowUserToAddRows = false;
            this.dgvBrukere.AllowUserToDeleteRows = false;
            this.dgvBrukere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBrukere.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBrukere.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvBrukere.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBrukere.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBrukere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrukere.Location = new System.Drawing.Point(0, 93);
            this.dgvBrukere.MultiSelect = false;
            this.dgvBrukere.Name = "dgvBrukere";
            this.dgvBrukere.ReadOnly = true;
            this.dgvBrukere.RowHeadersVisible = false;
            this.dgvBrukere.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dgvBrukere.RowTemplate.Height = 18;
            this.dgvBrukere.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBrukere.Size = new System.Drawing.Size(1120, 509);
            this.dgvBrukere.TabIndex = 83;
            this.dgvBrukere.TabStop = false;
            this.dgvBrukere.VirtualMode = true;
            this.dgvBrukere.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBrukere_CellClick);
            this.dgvBrukere.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBrukere_ColumnHeaderMouseClick);
            this.dgvBrukere.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBrukere_ColumnHeaderMouseClick);
            // 
            // tabTester
            // 
            this.tabTester.Controls.Add(this.panelTester);
            this.tabTester.Controls.Add(this.dgvTester);
            this.tabTester.Controls.Add(this.dgvFiler);
            this.tabTester.Location = new System.Drawing.Point(4, 22);
            this.tabTester.Name = "tabTester";
            this.tabTester.Padding = new System.Windows.Forms.Padding(3);
            this.tabTester.Size = new System.Drawing.Size(1122, 602);
            this.tabTester.TabIndex = 4;
            this.tabTester.Text = "Test";
            this.tabTester.UseVisualStyleBackColor = true;
            // 
            // panelTester
            // 
            this.panelTester.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.panelTester.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTester.Controls.Add(this.txtTesterFil);
            this.panelTester.Controls.Add(this.lblTesterFil);
            this.panelTester.Controls.Add(this.txtTesterNavn);
            this.panelTester.Controls.Add(this.cmbTesterFag);
            this.panelTester.Controls.Add(this.lblTesterFag);
            this.panelTester.Controls.Add(this.lblTesterNavn);
            this.panelTester.Controls.Add(this.butTesterTøm);
            this.panelTester.Controls.Add(this.butTesterReg);
            this.panelTester.Controls.Add(this.butTesterSlett);
            this.panelTester.Controls.Add(this.butTesterEndre);
            this.panelTester.Location = new System.Drawing.Point(0, 0);
            this.panelTester.Name = "panelTester";
            this.panelTester.Size = new System.Drawing.Size(1120, 93);
            this.panelTester.TabIndex = 17;
            // 
            // txtTesterFil
            // 
            this.txtTesterFil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTesterFil.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtTesterFil.Location = new System.Drawing.Point(724, 18);
            this.txtTesterFil.Name = "txtTesterFil";
            this.txtTesterFil.ReadOnly = true;
            this.txtTesterFil.Size = new System.Drawing.Size(308, 32);
            this.txtTesterFil.TabIndex = 31;
            this.txtTesterFil.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTesterFil_MouseClick);
            // 
            // lblTesterFil
            // 
            this.lblTesterFil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTesterFil.AutoSize = true;
            this.lblTesterFil.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTesterFil.Location = new System.Drawing.Point(857, -2);
            this.lblTesterFil.Name = "lblTesterFil";
            this.lblTesterFil.Size = new System.Drawing.Size(28, 21);
            this.lblTesterFil.TabIndex = 79;
            this.lblTesterFil.Text = "Fil";
            // 
            // txtTesterNavn
            // 
            this.txtTesterNavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTesterNavn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtTesterNavn.Location = new System.Drawing.Point(200, 18);
            this.txtTesterNavn.MaxLength = 45;
            this.txtTesterNavn.Name = "txtTesterNavn";
            this.txtTesterNavn.Size = new System.Drawing.Size(260, 32);
            this.txtTesterNavn.TabIndex = 29;
            this.txtTesterNavn.TextChanged += new System.EventHandler(this.txtTester_TextChanged);
            // 
            // cmbTesterFag
            // 
            this.cmbTesterFag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbTesterFag.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbTesterFag.FormattingEnabled = true;
            this.cmbTesterFag.Location = new System.Drawing.Point(465, 18);
            this.cmbTesterFag.MaxDropDownItems = 30;
            this.cmbTesterFag.MaxLength = 45;
            this.cmbTesterFag.Name = "cmbTesterFag";
            this.cmbTesterFag.Size = new System.Drawing.Size(253, 33);
            this.cmbTesterFag.TabIndex = 30;
            this.cmbTesterFag.TextChanged += new System.EventHandler(this.cmbTesterFag_TextChanged);
            // 
            // lblTesterFag
            // 
            this.lblTesterFag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTesterFag.AutoSize = true;
            this.lblTesterFag.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTesterFag.Location = new System.Drawing.Point(568, -3);
            this.lblTesterFag.Name = "lblTesterFag";
            this.lblTesterFag.Size = new System.Drawing.Size(37, 21);
            this.lblTesterFag.TabIndex = 69;
            this.lblTesterFag.Text = "Fag";
            // 
            // lblTesterNavn
            // 
            this.lblTesterNavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTesterNavn.AutoSize = true;
            this.lblTesterNavn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTesterNavn.Location = new System.Drawing.Point(305, -2);
            this.lblTesterNavn.Name = "lblTesterNavn";
            this.lblTesterNavn.Size = new System.Drawing.Size(51, 21);
            this.lblTesterNavn.TabIndex = 67;
            this.lblTesterNavn.Text = "Navn";
            // 
            // butTesterTøm
            // 
            this.butTesterTøm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butTesterTøm.AutoSize = true;
            this.butTesterTøm.FlatAppearance.BorderSize = 0;
            this.butTesterTøm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butTesterTøm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTesterTøm.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butTesterTøm.Location = new System.Drawing.Point(643, 51);
            this.butTesterTøm.Name = "butTesterTøm";
            this.butTesterTøm.Size = new System.Drawing.Size(67, 40);
            this.butTesterTøm.TabIndex = 36;
            this.butTesterTøm.Text = "Tøm";
            this.butTesterTøm.UseVisualStyleBackColor = true;
            this.butTesterTøm.Click += new System.EventHandler(this.butTesterTøm_Click);
            // 
            // butTesterReg
            // 
            this.butTesterReg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butTesterReg.AutoSize = true;
            this.butTesterReg.Enabled = false;
            this.butTesterReg.FlatAppearance.BorderSize = 0;
            this.butTesterReg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butTesterReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTesterReg.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butTesterReg.Location = new System.Drawing.Point(362, 51);
            this.butTesterReg.Name = "butTesterReg";
            this.butTesterReg.Size = new System.Drawing.Size(110, 40);
            this.butTesterReg.TabIndex = 32;
            this.butTesterReg.Text = "Registrer";
            this.butTesterReg.UseVisualStyleBackColor = true;
            this.butTesterReg.Click += new System.EventHandler(this.butTesterReg_Click);
            // 
            // butTesterSlett
            // 
            this.butTesterSlett.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butTesterSlett.AutoSize = true;
            this.butTesterSlett.Enabled = false;
            this.butTesterSlett.FlatAppearance.BorderSize = 0;
            this.butTesterSlett.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butTesterSlett.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTesterSlett.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butTesterSlett.Location = new System.Drawing.Point(565, 51);
            this.butTesterSlett.Name = "butTesterSlett";
            this.butTesterSlett.Size = new System.Drawing.Size(68, 40);
            this.butTesterSlett.TabIndex = 34;
            this.butTesterSlett.Text = "Slett";
            this.butTesterSlett.UseVisualStyleBackColor = true;
            this.butTesterSlett.Click += new System.EventHandler(this.butTesterSlett_Click);
            // 
            // butTesterEndre
            // 
            this.butTesterEndre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butTesterEndre.AutoSize = true;
            this.butTesterEndre.Enabled = false;
            this.butTesterEndre.FlatAppearance.BorderSize = 0;
            this.butTesterEndre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butTesterEndre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTesterEndre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butTesterEndre.Location = new System.Drawing.Point(477, 51);
            this.butTesterEndre.Name = "butTesterEndre";
            this.butTesterEndre.Size = new System.Drawing.Size(79, 40);
            this.butTesterEndre.TabIndex = 33;
            this.butTesterEndre.Text = "Endre";
            this.butTesterEndre.UseVisualStyleBackColor = true;
            this.butTesterEndre.Click += new System.EventHandler(this.butTesterEndre_Click);
            // 
            // dgvTester
            // 
            this.dgvTester.AllowUserToAddRows = false;
            this.dgvTester.AllowUserToDeleteRows = false;
            this.dgvTester.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTester.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTester.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvTester.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTester.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTester.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTester.Location = new System.Drawing.Point(0, 93);
            this.dgvTester.MultiSelect = false;
            this.dgvTester.Name = "dgvTester";
            this.dgvTester.ReadOnly = true;
            this.dgvTester.RowHeadersVisible = false;
            this.dgvTester.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dgvTester.RowTemplate.Height = 18;
            this.dgvTester.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTester.Size = new System.Drawing.Size(1120, 353);
            this.dgvTester.TabIndex = 37;
            this.dgvTester.TabStop = false;
            this.dgvTester.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTester_CellClick);
            this.dgvTester.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTester_ColumnHeaderMouseClick);
            this.dgvTester.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTester_ColumnHeaderMouseClick);
            // 
            // dgvFiler
            // 
            this.dgvFiler.AllowUserToAddRows = false;
            this.dgvFiler.AllowUserToDeleteRows = false;
            this.dgvFiler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiler.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvFiler.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiler.Location = new System.Drawing.Point(0, 446);
            this.dgvFiler.MultiSelect = false;
            this.dgvFiler.Name = "dgvFiler";
            this.dgvFiler.ReadOnly = true;
            this.dgvFiler.RowHeadersVisible = false;
            this.dgvFiler.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dgvFiler.RowTemplate.Height = 18;
            this.dgvFiler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiler.Size = new System.Drawing.Size(1120, 156);
            this.dgvFiler.TabIndex = 38;
            this.dgvFiler.TabStop = false;
            this.dgvFiler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFil_CellClick);
            this.dgvFiler.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseClick);
            this.dgvFiler.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseClick);
            // 
            // tabElever
            // 
            this.tabElever.Controls.Add(this.panelElever);
            this.tabElever.Controls.Add(this.dgvElever);
            this.tabElever.Controls.Add(this.dgvEleverKlasse);
            this.tabElever.Location = new System.Drawing.Point(4, 22);
            this.tabElever.Name = "tabElever";
            this.tabElever.Padding = new System.Windows.Forms.Padding(3);
            this.tabElever.Size = new System.Drawing.Size(1122, 602);
            this.tabElever.TabIndex = 2;
            this.tabElever.Text = "Elev";
            this.tabElever.UseVisualStyleBackColor = true;
            // 
            // panelElever
            // 
            this.panelElever.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelElever.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.panelElever.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelElever.Controls.Add(this.lblEleverStatus);
            this.panelElever.Controls.Add(this.chkEleverStatus);
            this.panelElever.Controls.Add(this.cmbEleverSkoleår);
            this.panelElever.Controls.Add(this.cmbEleverKlasse);
            this.panelElever.Controls.Add(this.cmbEleverKjønn);
            this.panelElever.Controls.Add(this.txtEleverEtternavn);
            this.panelElever.Controls.Add(this.txtEleverFornavn);
            this.panelElever.Controls.Add(this.txtEleverFNummer);
            this.panelElever.Controls.Add(this.lblEleverSkoleår);
            this.panelElever.Controls.Add(this.lblEleverKlasse);
            this.panelElever.Controls.Add(this.lblEleverKjønn);
            this.panelElever.Controls.Add(this.lblEleverEtternavn);
            this.panelElever.Controls.Add(this.lblEleverFNummer);
            this.panelElever.Controls.Add(this.lblEleverFornavn);
            this.panelElever.Controls.Add(this.butEleverTøm);
            this.panelElever.Controls.Add(this.butEleverReg);
            this.panelElever.Controls.Add(this.butEleverSlett);
            this.panelElever.Controls.Add(this.butEleverEndre);
            this.panelElever.Controls.Add(this.butEleverFlyttAlle);
            this.panelElever.Location = new System.Drawing.Point(0, 0);
            this.panelElever.Name = "panelElever";
            this.panelElever.Size = new System.Drawing.Size(1120, 93);
            this.panelElever.TabIndex = 69;
            // 
            // lblEleverStatus
            // 
            this.lblEleverStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEleverStatus.AutoSize = true;
            this.lblEleverStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEleverStatus.Location = new System.Drawing.Point(1015, -1);
            this.lblEleverStatus.Name = "lblEleverStatus";
            this.lblEleverStatus.Size = new System.Drawing.Size(57, 21);
            this.lblEleverStatus.TabIndex = 94;
            this.lblEleverStatus.Text = "Status";
            this.lblEleverStatus.Visible = false;
            // 
            // chkEleverStatus
            // 
            this.chkEleverStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkEleverStatus.AutoSize = true;
            this.chkEleverStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.chkEleverStatus.Location = new System.Drawing.Point(1009, 23);
            this.chkEleverStatus.Name = "chkEleverStatus";
            this.chkEleverStatus.Size = new System.Drawing.Size(69, 25);
            this.chkEleverStatus.TabIndex = 56;
            this.chkEleverStatus.Text = "Aktiv";
            this.chkEleverStatus.UseVisualStyleBackColor = true;
            this.chkEleverStatus.Visible = false;
            // 
            // cmbEleverSkoleår
            // 
            this.cmbEleverSkoleår.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbEleverSkoleår.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEleverSkoleår.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbEleverSkoleår.FormattingEnabled = true;
            this.cmbEleverSkoleår.Location = new System.Drawing.Point(51, 18);
            this.cmbEleverSkoleår.MaxDropDownItems = 30;
            this.cmbEleverSkoleår.Name = "cmbEleverSkoleår";
            this.cmbEleverSkoleår.Size = new System.Drawing.Size(164, 33);
            this.cmbEleverSkoleår.TabIndex = 50;
            this.cmbEleverSkoleår.TextChanged += new System.EventHandler(this.cmbEleverSkoleår_TextChanged);
            // 
            // cmbEleverKlasse
            // 
            this.cmbEleverKlasse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbEleverKlasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEleverKlasse.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbEleverKlasse.FormattingEnabled = true;
            this.cmbEleverKlasse.Location = new System.Drawing.Point(221, 18);
            this.cmbEleverKlasse.MaxDropDownItems = 30;
            this.cmbEleverKlasse.Name = "cmbEleverKlasse";
            this.cmbEleverKlasse.Size = new System.Drawing.Size(128, 33);
            this.cmbEleverKlasse.TabIndex = 51;
            this.cmbEleverKlasse.TextChanged += new System.EventHandler(this.cmbEleverKlasse_TextChanged);
            // 
            // cmbEleverKjønn
            // 
            this.cmbEleverKjønn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbEleverKjønn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEleverKjønn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbEleverKjønn.FormattingEnabled = true;
            this.cmbEleverKjønn.Location = new System.Drawing.Point(882, 19);
            this.cmbEleverKjønn.Name = "cmbEleverKjønn";
            this.cmbEleverKjønn.Size = new System.Drawing.Size(121, 33);
            this.cmbEleverKjønn.TabIndex = 55;
            // 
            // txtEleverEtternavn
            // 
            this.txtEleverEtternavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEleverEtternavn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtEleverEtternavn.Location = new System.Drawing.Point(690, 19);
            this.txtEleverEtternavn.MaxLength = 45;
            this.txtEleverEtternavn.Name = "txtEleverEtternavn";
            this.txtEleverEtternavn.Size = new System.Drawing.Size(186, 32);
            this.txtEleverEtternavn.TabIndex = 54;
            this.txtEleverEtternavn.TextChanged += new System.EventHandler(this.txtElever_TextChanged);
            this.txtEleverEtternavn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNavn_KeyPress);
            // 
            // txtEleverFornavn
            // 
            this.txtEleverFornavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEleverFornavn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtEleverFornavn.Location = new System.Drawing.Point(482, 19);
            this.txtEleverFornavn.MaxLength = 45;
            this.txtEleverFornavn.Name = "txtEleverFornavn";
            this.txtEleverFornavn.Size = new System.Drawing.Size(202, 32);
            this.txtEleverFornavn.TabIndex = 53;
            this.txtEleverFornavn.TextChanged += new System.EventHandler(this.txtElever_TextChanged);
            this.txtEleverFornavn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNavn_KeyPress);
            // 
            // txtEleverFNummer
            // 
            this.txtEleverFNummer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEleverFNummer.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtEleverFNummer.Location = new System.Drawing.Point(355, 19);
            this.txtEleverFNummer.MaxLength = 11;
            this.txtEleverFNummer.Name = "txtEleverFNummer";
            this.txtEleverFNummer.ShortcutsEnabled = false;
            this.txtEleverFNummer.Size = new System.Drawing.Size(121, 32);
            this.txtEleverFNummer.TabIndex = 52;
            this.txtEleverFNummer.TextChanged += new System.EventHandler(this.txtElever_TextChanged);
            this.txtEleverFNummer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEleverFNummer_KeyPress);
            // 
            // lblEleverSkoleår
            // 
            this.lblEleverSkoleår.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEleverSkoleår.AutoSize = true;
            this.lblEleverSkoleår.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEleverSkoleår.Location = new System.Drawing.Point(102, -1);
            this.lblEleverSkoleår.Name = "lblEleverSkoleår";
            this.lblEleverSkoleår.Size = new System.Drawing.Size(67, 21);
            this.lblEleverSkoleår.TabIndex = 88;
            this.lblEleverSkoleår.Text = "Skoleår";
            // 
            // lblEleverKlasse
            // 
            this.lblEleverKlasse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEleverKlasse.AutoSize = true;
            this.lblEleverKlasse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEleverKlasse.Location = new System.Drawing.Point(241, -1);
            this.lblEleverKlasse.Name = "lblEleverKlasse";
            this.lblEleverKlasse.Size = new System.Drawing.Size(94, 21);
            this.lblEleverKlasse.TabIndex = 82;
            this.lblEleverKlasse.Text = "Betegnelse";
            // 
            // lblEleverKjønn
            // 
            this.lblEleverKjønn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEleverKjønn.AutoSize = true;
            this.lblEleverKjønn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEleverKjønn.Location = new System.Drawing.Point(914, -1);
            this.lblEleverKjønn.Name = "lblEleverKjønn";
            this.lblEleverKjønn.Size = new System.Drawing.Size(55, 21);
            this.lblEleverKjønn.TabIndex = 73;
            this.lblEleverKjønn.Text = "Kjønn";
            // 
            // lblEleverEtternavn
            // 
            this.lblEleverEtternavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEleverEtternavn.AutoSize = true;
            this.lblEleverEtternavn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEleverEtternavn.Location = new System.Drawing.Point(740, -1);
            this.lblEleverEtternavn.Name = "lblEleverEtternavn";
            this.lblEleverEtternavn.Size = new System.Drawing.Size(84, 21);
            this.lblEleverEtternavn.TabIndex = 72;
            this.lblEleverEtternavn.Text = "Etternavn";
            // 
            // lblEleverFNummer
            // 
            this.lblEleverFNummer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEleverFNummer.AutoSize = true;
            this.lblEleverFNummer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEleverFNummer.Location = new System.Drawing.Point(360, -1);
            this.lblEleverFNummer.Name = "lblEleverFNummer";
            this.lblEleverFNummer.Size = new System.Drawing.Size(116, 21);
            this.lblEleverFNummer.TabIndex = 71;
            this.lblEleverFNummer.Text = "FNummer(11)";
            // 
            // lblEleverFornavn
            // 
            this.lblEleverFornavn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEleverFornavn.AutoSize = true;
            this.lblEleverFornavn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEleverFornavn.Location = new System.Drawing.Point(544, -1);
            this.lblEleverFornavn.Name = "lblEleverFornavn";
            this.lblEleverFornavn.Size = new System.Drawing.Size(72, 21);
            this.lblEleverFornavn.TabIndex = 68;
            this.lblEleverFornavn.Text = "Fornavn";
            // 
            // butEleverTøm
            // 
            this.butEleverTøm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butEleverTøm.AutoSize = true;
            this.butEleverTøm.FlatAppearance.BorderSize = 0;
            this.butEleverTøm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butEleverTøm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEleverTøm.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butEleverTøm.Location = new System.Drawing.Point(643, 51);
            this.butEleverTøm.Name = "butEleverTøm";
            this.butEleverTøm.Size = new System.Drawing.Size(67, 40);
            this.butEleverTøm.TabIndex = 60;
            this.butEleverTøm.Text = "Tøm";
            this.butEleverTøm.UseVisualStyleBackColor = true;
            this.butEleverTøm.Click += new System.EventHandler(this.butEleverTøm_Click);
            // 
            // butEleverReg
            // 
            this.butEleverReg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butEleverReg.AutoSize = true;
            this.butEleverReg.Enabled = false;
            this.butEleverReg.FlatAppearance.BorderSize = 0;
            this.butEleverReg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butEleverReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEleverReg.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butEleverReg.Location = new System.Drawing.Point(362, 51);
            this.butEleverReg.Name = "butEleverReg";
            this.butEleverReg.Size = new System.Drawing.Size(110, 40);
            this.butEleverReg.TabIndex = 57;
            this.butEleverReg.Text = "Registrer";
            this.butEleverReg.UseVisualStyleBackColor = true;
            this.butEleverReg.Click += new System.EventHandler(this.butEleverReg_Click);
            // 
            // butEleverSlett
            // 
            this.butEleverSlett.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butEleverSlett.AutoSize = true;
            this.butEleverSlett.Enabled = false;
            this.butEleverSlett.FlatAppearance.BorderSize = 0;
            this.butEleverSlett.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butEleverSlett.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEleverSlett.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butEleverSlett.Location = new System.Drawing.Point(565, 51);
            this.butEleverSlett.Name = "butEleverSlett";
            this.butEleverSlett.Size = new System.Drawing.Size(68, 40);
            this.butEleverSlett.TabIndex = 59;
            this.butEleverSlett.Text = "Slett";
            this.butEleverSlett.UseVisualStyleBackColor = true;
            this.butEleverSlett.Click += new System.EventHandler(this.butEleverSlett_Click);
            // 
            // butEleverEndre
            // 
            this.butEleverEndre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butEleverEndre.AutoSize = true;
            this.butEleverEndre.Enabled = false;
            this.butEleverEndre.FlatAppearance.BorderSize = 0;
            this.butEleverEndre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butEleverEndre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEleverEndre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butEleverEndre.Location = new System.Drawing.Point(477, 51);
            this.butEleverEndre.Name = "butEleverEndre";
            this.butEleverEndre.Size = new System.Drawing.Size(79, 40);
            this.butEleverEndre.TabIndex = 58;
            this.butEleverEndre.Text = "Endre";
            this.butEleverEndre.UseVisualStyleBackColor = true;
            this.butEleverEndre.Click += new System.EventHandler(this.butEleverEndre_Click);
            // 
            // butEleverFlyttAlle
            // 
            this.butEleverFlyttAlle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butEleverFlyttAlle.AutoSize = true;
            this.butEleverFlyttAlle.FlatAppearance.BorderSize = 0;
            this.butEleverFlyttAlle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butEleverFlyttAlle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEleverFlyttAlle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.butEleverFlyttAlle.Location = new System.Drawing.Point(966, 52);
            this.butEleverFlyttAlle.Name = "butEleverFlyttAlle";
            this.butEleverFlyttAlle.Size = new System.Drawing.Size(152, 40);
            this.butEleverFlyttAlle.TabIndex = 61;
            this.butEleverFlyttAlle.Text = "Flytt alle opp";
            this.butEleverFlyttAlle.UseVisualStyleBackColor = true;
            this.butEleverFlyttAlle.Click += new System.EventHandler(this.butEleverFlyttopp_Click);
            // 
            // dgvElever
            // 
            this.dgvElever.AllowUserToAddRows = false;
            this.dgvElever.AllowUserToDeleteRows = false;
            this.dgvElever.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvElever.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvElever.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvElever.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvElever.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvElever.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElever.Location = new System.Drawing.Point(0, 93);
            this.dgvElever.MultiSelect = false;
            this.dgvElever.Name = "dgvElever";
            this.dgvElever.ReadOnly = true;
            this.dgvElever.RowHeadersVisible = false;
            this.dgvElever.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dgvElever.RowTemplate.Height = 18;
            this.dgvElever.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvElever.Size = new System.Drawing.Size(1120, 325);
            this.dgvElever.TabIndex = 62;
            this.dgvElever.TabStop = false;
            this.dgvElever.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElever_CellClick);
            this.dgvElever.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvElever_ColumnHeaderMouseClick);
            this.dgvElever.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvElever_ColumnHeaderMouseClick);
            // 
            // dgvEleverKlasse
            // 
            this.dgvEleverKlasse.AllowUserToAddRows = false;
            this.dgvEleverKlasse.AllowUserToDeleteRows = false;
            this.dgvEleverKlasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEleverKlasse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEleverKlasse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvEleverKlasse.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEleverKlasse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvEleverKlasse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEleverKlasse.Location = new System.Drawing.Point(0, 418);
            this.dgvEleverKlasse.MultiSelect = false;
            this.dgvEleverKlasse.Name = "dgvEleverKlasse";
            this.dgvEleverKlasse.ReadOnly = true;
            this.dgvEleverKlasse.RowHeadersVisible = false;
            this.dgvEleverKlasse.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dgvEleverKlasse.RowTemplate.Height = 18;
            this.dgvEleverKlasse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEleverKlasse.Size = new System.Drawing.Size(1120, 184);
            this.dgvEleverKlasse.TabIndex = 63;
            this.dgvEleverKlasse.TabStop = false;
            this.dgvEleverKlasse.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseClick);
            this.dgvEleverKlasse.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseClick);
            // 
            // tabResultat
            // 
            this.tabResultat.Controls.Add(this.panelResultat);
            this.tabResultat.Controls.Add(this.dgvResultat);
            this.tabResultat.Location = new System.Drawing.Point(4, 22);
            this.tabResultat.Name = "tabResultat";
            this.tabResultat.Padding = new System.Windows.Forms.Padding(3);
            this.tabResultat.Size = new System.Drawing.Size(1122, 602);
            this.tabResultat.TabIndex = 1;
            this.tabResultat.Text = "Resultat";
            this.tabResultat.UseVisualStyleBackColor = true;
            // 
            // panelResultat
            // 
            this.panelResultat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelResultat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.panelResultat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResultat.Controls.Add(this.lblResVisning);
            this.panelResultat.Controls.Add(this.chkResDeltest);
            this.panelResultat.Controls.Add(this.chkResTest);
            this.panelResultat.Controls.Add(this.chkResFag);
            this.panelResultat.Controls.Add(this.cmbResFag);
            this.panelResultat.Controls.Add(this.chkResElev);
            this.panelResultat.Controls.Add(this.cmbResSem);
            this.panelResultat.Controls.Add(this.cmbResÅr);
            this.panelResultat.Controls.Add(this.numResPoeng);
            this.panelResultat.Controls.Add(this.cmbResBet);
            this.panelResultat.Controls.Add(this.cmbResElev);
            this.panelResultat.Controls.Add(this.butResTøm);
            this.panelResultat.Controls.Add(this.butResReg);
            this.panelResultat.Controls.Add(this.butResSlett);
            this.panelResultat.Controls.Add(this.butResEndre);
            this.panelResultat.Controls.Add(this.txtResKommentar);
            this.panelResultat.Controls.Add(this.lblResKommentar);
            this.panelResultat.Controls.Add(this.cmbResTest);
            this.panelResultat.Controls.Add(this.cmbResDeltest);
            this.panelResultat.Controls.Add(this.lblResPoeng);
            this.panelResultat.Controls.Add(this.lblResFag);
            this.panelResultat.Controls.Add(this.lblResTest);
            this.panelResultat.Controls.Add(this.lblResDeltest);
            this.panelResultat.Controls.Add(this.lblResElev);
            this.panelResultat.Controls.Add(this.lblResSemester);
            this.panelResultat.Controls.Add(this.chkResKlasse);
            this.panelResultat.Controls.Add(this.label2);
            this.panelResultat.Controls.Add(this.lblResKlasse);
            this.panelResultat.Controls.Add(this.rbResReg);
            this.panelResultat.Controls.Add(this.rbResVisning);
            this.panelResultat.Controls.Add(this.butEksporter);
            this.panelResultat.Location = new System.Drawing.Point(0, 0);
            this.panelResultat.Name = "panelResultat";
            this.panelResultat.Size = new System.Drawing.Size(1120, 93);
            this.panelResultat.TabIndex = 71;
            // 
            // lblResVisning
            // 
            this.lblResVisning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResVisning.AutoSize = true;
            this.lblResVisning.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResVisning.Location = new System.Drawing.Point(2, 76);
            this.lblResVisning.Name = "lblResVisning";
            this.lblResVisning.Size = new System.Drawing.Size(74, 13);
            this.lblResVisning.TabIndex = 146;
            this.lblResVisning.Text = "Valgt visning";
            // 
            // chkResDeltest
            // 
            this.chkResDeltest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkResDeltest.AutoSize = true;
            this.chkResDeltest.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkResDeltest.Location = new System.Drawing.Point(989, 2);
            this.chkResDeltest.Name = "chkResDeltest";
            this.chkResDeltest.Size = new System.Drawing.Size(15, 14);
            this.chkResDeltest.TabIndex = 28;
            this.chkResDeltest.UseVisualStyleBackColor = true;
            this.chkResDeltest.CheckedChanged += new System.EventHandler(this.chkResDeltest_CheckedChanged);
            // 
            // chkResTest
            // 
            this.chkResTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkResTest.AutoSize = true;
            this.chkResTest.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkResTest.Location = new System.Drawing.Point(748, 3);
            this.chkResTest.Name = "chkResTest";
            this.chkResTest.Size = new System.Drawing.Size(15, 14);
            this.chkResTest.TabIndex = 27;
            this.chkResTest.UseVisualStyleBackColor = true;
            this.chkResTest.CheckedChanged += new System.EventHandler(this.chkResTest_CheckedChanged);
            // 
            // chkResFag
            // 
            this.chkResFag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkResFag.AutoSize = true;
            this.chkResFag.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkResFag.Location = new System.Drawing.Point(602, 3);
            this.chkResFag.Name = "chkResFag";
            this.chkResFag.Size = new System.Drawing.Size(15, 14);
            this.chkResFag.TabIndex = 26;
            this.chkResFag.UseVisualStyleBackColor = true;
            this.chkResFag.CheckedChanged += new System.EventHandler(this.chkResFag_CheckedChanged);
            // 
            // cmbResFag
            // 
            this.cmbResFag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbResFag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResFag.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbResFag.FormattingEnabled = true;
            this.cmbResFag.Location = new System.Drawing.Point(582, 18);
            this.cmbResFag.MaxDropDownItems = 30;
            this.cmbResFag.Name = "cmbResFag";
            this.cmbResFag.Size = new System.Drawing.Size(90, 33);
            this.cmbResFag.TabIndex = 13;
            this.cmbResFag.TextChanged += new System.EventHandler(this.cmbResFag_TextChanged);
            // 
            // chkResElev
            // 
            this.chkResElev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkResElev.AutoSize = true;
            this.chkResElev.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkResElev.Location = new System.Drawing.Point(337, 3);
            this.chkResElev.Name = "chkResElev";
            this.chkResElev.Size = new System.Drawing.Size(15, 14);
            this.chkResElev.TabIndex = 24;
            this.chkResElev.UseVisualStyleBackColor = true;
            this.chkResElev.CheckStateChanged += new System.EventHandler(this.chkResElev_CheckStateChanged);
            // 
            // cmbResSem
            // 
            this.cmbResSem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbResSem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResSem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbResSem.FormattingEnabled = true;
            this.cmbResSem.Location = new System.Drawing.Point(877, 18);
            this.cmbResSem.Name = "cmbResSem";
            this.cmbResSem.Size = new System.Drawing.Size(60, 33);
            this.cmbResSem.TabIndex = 15;
            this.cmbResSem.TextChanged += new System.EventHandler(this.cmbResSemester_TextChanged);
            // 
            // cmbResÅr
            // 
            this.cmbResÅr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbResÅr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResÅr.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbResÅr.FormattingEnabled = true;
            this.cmbResÅr.Location = new System.Drawing.Point(103, 18);
            this.cmbResÅr.MaxDropDownItems = 30;
            this.cmbResÅr.Name = "cmbResÅr";
            this.cmbResÅr.Size = new System.Drawing.Size(84, 33);
            this.cmbResÅr.TabIndex = 10;
            this.cmbResÅr.TextChanged += new System.EventHandler(this.cmbResKlasseÅr_TextChanged);
            // 
            // numResPoeng
            // 
            this.numResPoeng.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numResPoeng.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.numResPoeng.Location = new System.Drawing.Point(646, 55);
            this.numResPoeng.Name = "numResPoeng";
            this.numResPoeng.Size = new System.Drawing.Size(54, 32);
            this.numResPoeng.TabIndex = 17;
            // 
            // cmbResBet
            // 
            this.cmbResBet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbResBet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResBet.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbResBet.FormattingEnabled = true;
            this.cmbResBet.Location = new System.Drawing.Point(193, 18);
            this.cmbResBet.MaxDropDownItems = 30;
            this.cmbResBet.Name = "cmbResBet";
            this.cmbResBet.Size = new System.Drawing.Size(54, 33);
            this.cmbResBet.TabIndex = 11;
            this.cmbResBet.TextChanged += new System.EventHandler(this.cmbResKlasseBet_TextChanged);
            // 
            // cmbResElev
            // 
            this.cmbResElev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbResElev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResElev.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbResElev.FormattingEnabled = true;
            this.cmbResElev.Location = new System.Drawing.Point(252, 18);
            this.cmbResElev.MaxDropDownItems = 50;
            this.cmbResElev.Name = "cmbResElev";
            this.cmbResElev.Size = new System.Drawing.Size(324, 33);
            this.cmbResElev.TabIndex = 12;
            this.cmbResElev.TextChanged += new System.EventHandler(this.cmbResElev_TextChanged);
            // 
            // butResTøm
            // 
            this.butResTøm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butResTøm.AutoSize = true;
            this.butResTøm.FlatAppearance.BorderSize = 0;
            this.butResTøm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butResTøm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butResTøm.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butResTøm.Location = new System.Drawing.Point(514, 51);
            this.butResTøm.Name = "butResTøm";
            this.butResTøm.Size = new System.Drawing.Size(67, 40);
            this.butResTøm.TabIndex = 22;
            this.butResTøm.Text = "Tøm";
            this.butResTøm.UseVisualStyleBackColor = true;
            this.butResTøm.Click += new System.EventHandler(this.butResTøm_Click);
            // 
            // butResReg
            // 
            this.butResReg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butResReg.AutoSize = true;
            this.butResReg.FlatAppearance.BorderSize = 0;
            this.butResReg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butResReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butResReg.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butResReg.Location = new System.Drawing.Point(253, 51);
            this.butResReg.Name = "butResReg";
            this.butResReg.Size = new System.Drawing.Size(110, 40);
            this.butResReg.TabIndex = 19;
            this.butResReg.Text = "Registrer";
            this.butResReg.UseVisualStyleBackColor = true;
            this.butResReg.Click += new System.EventHandler(this.butResReg_Click);
            // 
            // butResSlett
            // 
            this.butResSlett.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butResSlett.AutoSize = true;
            this.butResSlett.FlatAppearance.BorderSize = 0;
            this.butResSlett.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butResSlett.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butResSlett.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butResSlett.Location = new System.Drawing.Point(447, 51);
            this.butResSlett.Name = "butResSlett";
            this.butResSlett.Size = new System.Drawing.Size(68, 40);
            this.butResSlett.TabIndex = 21;
            this.butResSlett.Text = "Slett";
            this.butResSlett.UseVisualStyleBackColor = true;
            this.butResSlett.Click += new System.EventHandler(this.butResSlett_Click);
            // 
            // butResEndre
            // 
            this.butResEndre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butResEndre.AutoSize = true;
            this.butResEndre.FlatAppearance.BorderSize = 0;
            this.butResEndre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butResEndre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butResEndre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butResEndre.Location = new System.Drawing.Point(367, 51);
            this.butResEndre.Name = "butResEndre";
            this.butResEndre.Size = new System.Drawing.Size(79, 40);
            this.butResEndre.TabIndex = 20;
            this.butResEndre.Text = "Endre";
            this.butResEndre.UseVisualStyleBackColor = true;
            this.butResEndre.Click += new System.EventHandler(this.butResEndre_Click);
            // 
            // txtResKommentar
            // 
            this.txtResKommentar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtResKommentar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtResKommentar.Location = new System.Drawing.Point(800, 56);
            this.txtResKommentar.MaxLength = 1000;
            this.txtResKommentar.Name = "txtResKommentar";
            this.txtResKommentar.Size = new System.Drawing.Size(315, 32);
            this.txtResKommentar.TabIndex = 18;
            // 
            // lblResKommentar
            // 
            this.lblResKommentar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblResKommentar.AutoSize = true;
            this.lblResKommentar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblResKommentar.Location = new System.Drawing.Point(702, 61);
            this.lblResKommentar.Name = "lblResKommentar";
            this.lblResKommentar.Size = new System.Drawing.Size(100, 21);
            this.lblResKommentar.TabIndex = 84;
            this.lblResKommentar.Text = "Kommentar";
            // 
            // cmbResTest
            // 
            this.cmbResTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbResTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResTest.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbResTest.FormattingEnabled = true;
            this.cmbResTest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbResTest.Location = new System.Drawing.Point(678, 18);
            this.cmbResTest.MaxDropDownItems = 30;
            this.cmbResTest.Name = "cmbResTest";
            this.cmbResTest.Size = new System.Drawing.Size(195, 33);
            this.cmbResTest.TabIndex = 14;
            this.cmbResTest.TextChanged += new System.EventHandler(this.cmbResTest_TextChanged);
            // 
            // cmbResDeltest
            // 
            this.cmbResDeltest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbResDeltest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResDeltest.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbResDeltest.FormattingEnabled = true;
            this.cmbResDeltest.Location = new System.Drawing.Point(943, 18);
            this.cmbResDeltest.MaxDropDownItems = 30;
            this.cmbResDeltest.Name = "cmbResDeltest";
            this.cmbResDeltest.Size = new System.Drawing.Size(172, 33);
            this.cmbResDeltest.TabIndex = 16;
            this.cmbResDeltest.TextChanged += new System.EventHandler(this.cmbResDeltest_TextChanged);
            // 
            // lblResPoeng
            // 
            this.lblResPoeng.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblResPoeng.AutoSize = true;
            this.lblResPoeng.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblResPoeng.Location = new System.Drawing.Point(588, 60);
            this.lblResPoeng.Name = "lblResPoeng";
            this.lblResPoeng.Size = new System.Drawing.Size(59, 21);
            this.lblResPoeng.TabIndex = 73;
            this.lblResPoeng.Text = "Poeng";
            // 
            // lblResFag
            // 
            this.lblResFag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblResFag.AutoSize = true;
            this.lblResFag.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResFag.Location = new System.Drawing.Point(617, -2);
            this.lblResFag.Name = "lblResFag";
            this.lblResFag.Size = new System.Drawing.Size(37, 21);
            this.lblResFag.TabIndex = 145;
            this.lblResFag.Text = "Fag";
            // 
            // lblResTest
            // 
            this.lblResTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblResTest.AutoSize = true;
            this.lblResTest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResTest.Location = new System.Drawing.Point(763, -2);
            this.lblResTest.Name = "lblResTest";
            this.lblResTest.Size = new System.Drawing.Size(40, 21);
            this.lblResTest.TabIndex = 144;
            this.lblResTest.Text = "Test";
            // 
            // lblResDeltest
            // 
            this.lblResDeltest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblResDeltest.AutoSize = true;
            this.lblResDeltest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResDeltest.Location = new System.Drawing.Point(1004, -2);
            this.lblResDeltest.Name = "lblResDeltest";
            this.lblResDeltest.Size = new System.Drawing.Size(64, 21);
            this.lblResDeltest.TabIndex = 143;
            this.lblResDeltest.Text = "Deltest";
            // 
            // lblResElev
            // 
            this.lblResElev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblResElev.AutoSize = true;
            this.lblResElev.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResElev.Location = new System.Drawing.Point(352, -2);
            this.lblResElev.Name = "lblResElev";
            this.lblResElev.Size = new System.Drawing.Size(42, 21);
            this.lblResElev.TabIndex = 142;
            this.lblResElev.Text = "Elev";
            // 
            // lblResSemester
            // 
            this.lblResSemester.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblResSemester.AutoSize = true;
            this.lblResSemester.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResSemester.Location = new System.Drawing.Point(872, -2);
            this.lblResSemester.Name = "lblResSemester";
            this.lblResSemester.Size = new System.Drawing.Size(80, 21);
            this.lblResSemester.TabIndex = 141;
            this.lblResSemester.Text = "Semester";
            // 
            // chkResKlasse
            // 
            this.chkResKlasse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkResKlasse.AutoSize = true;
            this.chkResKlasse.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkResKlasse.Location = new System.Drawing.Point(404, -2);
            this.chkResKlasse.Name = "chkResKlasse";
            this.chkResKlasse.Size = new System.Drawing.Size(97, 24);
            this.chkResKlasse.TabIndex = 25;
            this.chkResKlasse.Text = "Per klasse";
            this.chkResKlasse.UseVisualStyleBackColor = true;
            this.chkResKlasse.CheckStateChanged += new System.EventHandler(this.chkResKlasse_CheckStateChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 21);
            this.label2.TabIndex = 95;
            this.label2.Text = "År";
            // 
            // lblResKlasse
            // 
            this.lblResKlasse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblResKlasse.AutoSize = true;
            this.lblResKlasse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResKlasse.Location = new System.Drawing.Point(193, -2);
            this.lblResKlasse.Name = "lblResKlasse";
            this.lblResKlasse.Size = new System.Drawing.Size(57, 21);
            this.lblResKlasse.TabIndex = 92;
            this.lblResKlasse.Text = "Klasse";
            // 
            // rbResReg
            // 
            this.rbResReg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbResReg.AutoSize = true;
            this.rbResReg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbResReg.Location = new System.Drawing.Point(2, 45);
            this.rbResReg.Name = "rbResReg";
            this.rbResReg.Size = new System.Drawing.Size(101, 21);
            this.rbResReg.TabIndex = 8;
            this.rbResReg.TabStop = true;
            this.rbResReg.Text = "Registrering";
            this.rbResReg.UseVisualStyleBackColor = true;
            this.rbResReg.CheckedChanged += new System.EventHandler(this.rbResReg_CheckedChanged);
            // 
            // rbResVisning
            // 
            this.rbResVisning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbResVisning.AutoSize = true;
            this.rbResVisning.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbResVisning.Location = new System.Drawing.Point(3, 25);
            this.rbResVisning.Name = "rbResVisning";
            this.rbResVisning.Size = new System.Drawing.Size(73, 21);
            this.rbResVisning.TabIndex = 9;
            this.rbResVisning.TabStop = true;
            this.rbResVisning.Text = "Visning";
            this.rbResVisning.UseVisualStyleBackColor = true;
            this.rbResVisning.CheckedChanged += new System.EventHandler(this.rbResVisning_CheckedChanged);
            // 
            // butEksporter
            // 
            this.butEksporter.AutoSize = true;
            this.butEksporter.FlatAppearance.BorderSize = 0;
            this.butEksporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEksporter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butEksporter.Location = new System.Drawing.Point(-1, 0);
            this.butEksporter.Name = "butEksporter";
            this.butEksporter.Size = new System.Drawing.Size(110, 23);
            this.butEksporter.TabIndex = 7;
            this.butEksporter.Text = "Eksporter/Skriv ut";
            this.butEksporter.UseVisualStyleBackColor = true;
            this.butEksporter.Click += new System.EventHandler(this.butEksporter_Click);
            // 
            // dgvResultat
            // 
            this.dgvResultat.AllowUserToAddRows = false;
            this.dgvResultat.AllowUserToDeleteRows = false;
            this.dgvResultat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvResultat.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvResultat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultat.Location = new System.Drawing.Point(0, 93);
            this.dgvResultat.MultiSelect = false;
            this.dgvResultat.Name = "dgvResultat";
            this.dgvResultat.ReadOnly = true;
            this.dgvResultat.RowHeadersVisible = false;
            this.dgvResultat.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dgvResultat.RowTemplate.Height = 18;
            this.dgvResultat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultat.Size = new System.Drawing.Size(1120, 509);
            this.dgvResultat.TabIndex = 23;
            this.dgvResultat.TabStop = false;
            this.dgvResultat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultat_CellClick);
            this.dgvResultat.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRes_ColumnHeaderMouseClick);
            this.dgvResultat.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRes_ColumnHeaderMouseClick);
            // 
            // tabMeny
            // 
            this.tabMeny.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMeny.Controls.Add(this.tabResultat);
            this.tabMeny.Controls.Add(this.tabTester);
            this.tabMeny.Controls.Add(this.tabDeltest);
            this.tabMeny.Controls.Add(this.tabKlasser);
            this.tabMeny.Controls.Add(this.tabElever);
            this.tabMeny.Controls.Add(this.tabBrukere);
            this.tabMeny.Location = new System.Drawing.Point(134, 27);
            this.tabMeny.Name = "tabMeny";
            this.tabMeny.SelectedIndex = 0;
            this.tabMeny.Size = new System.Drawing.Size(1130, 628);
            this.tabMeny.TabIndex = 13;
            // 
            // hjelp
            // 
            this.hjelp.HelpNamespace = "";
            // 
            // frmHoved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.menyLinje);
            this.Controls.Add(this.lblBrukerStatus);
            this.Controls.Add(this.panelMeny);
            this.Controls.Add(this.lblDato);
            this.Controls.Add(this.tabMeny);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.hjelp.SetHelpKeyword(this, "");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menyLinje;
            this.Name = "frmHoved";
            this.hjelp.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nes Barneskole";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHoved_Closing);
            this.Load += new System.EventHandler(this.frmHoved_Load);
            this.MouseHover += new System.EventHandler(this.frmHoved_MouseHover);
            this.menyLinje.ResumeLayout(false);
            this.menyLinje.PerformLayout();
            this.panelMeny.ResumeLayout(false);
            this.panelMeny.PerformLayout();
            this.tabDeltest.ResumeLayout(false);
            this.panelDeltest.ResumeLayout(false);
            this.panelDeltest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeltestKritisk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeltestMaks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeltest)).EndInit();
            this.tabKlasser.ResumeLayout(false);
            this.panelKlasser.ResumeLayout(false);
            this.panelKlasser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlasser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlasserTest)).EndInit();
            this.tabBrukere.ResumeLayout(false);
            this.panelBrukere.ResumeLayout(false);
            this.panelBrukere.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrukere)).EndInit();
            this.tabTester.ResumeLayout(false);
            this.panelTester.ResumeLayout(false);
            this.panelTester.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiler)).EndInit();
            this.tabElever.ResumeLayout(false);
            this.panelElever.ResumeLayout(false);
            this.panelElever.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElever)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEleverKlasse)).EndInit();
            this.tabResultat.ResumeLayout(false);
            this.panelResultat.ResumeLayout(false);
            this.panelResultat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numResPoeng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultat)).EndInit();
            this.tabMeny.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butTest;
        private System.Windows.Forms.Button butBruker;
        private System.Windows.Forms.Button butElev;
        private System.Windows.Forms.Button butKlasse;
        private System.Windows.Forms.MenuStrip menyLinje;
        private System.Windows.Forms.ToolStripMenuItem menyFil;
        private System.Windows.Forms.ToolStripMenuItem menyHjelp;
        private System.Windows.Forms.ToolStripMenuItem menyLoggUt;
        private System.Windows.Forms.Label lblDato;
        private System.Windows.Forms.Panel panelMeny;
        private System.Windows.Forms.ToolStripMenuItem mnyAvslutt;
        private ToolStripMenuItem menyOm;
        private Label lblBrukerStatus;
        private Button butDeltest;
        private Button butResultat;
        private TabPage tabDeltest;
        private Panel panelDeltest;
        private Label lblDeltestTest;
        private ComboBox cmbDeltestTest;
        private NumericUpDown numDeltestKritisk;
        private NumericUpDown numDeltestMaks;
        private Button butDeltestTøm;
        private Label lblDeltestMakspoeng;
        private Button butDeltestReg;
        private Label lblDeltestSemester;
        private Label lblDeltestNavn;
        private Button butDeltestSlett;
        private Label lblDeltestKritisk;
        private Button butDeltestEndre;
        private TextBox txtDeltestNavn;
        private ComboBox cmbDeltestSem;
        private DataGridView dgvDeltest;
        private TabPage tabKlasser;
        private Panel panelKlasser;
        private Button butKlasserRegTest;
        private Label lblKlasseTester;
        private ComboBox cmbKlasserTest;
        private Button butKlasserTøm;
        private Label lblKlasserSkoleår;
        private Button butKlasserReg;
        private Label lblKlasserBetegnelse;
        private Button butKlasserSlett;
        private Button butKlasserEndre;
        private TextBox txtKlasserBet;
        private TextBox txtKlasserÅr;
        private DataGridView dgvKlasser;
        private DataGridView dgvKlasserTest;
        private TabPage tabBrukere;
        private Panel panelBrukere;
        private Button butBrukerTøm;
        private Label lblBrukerFornavn;
        private TextBox txtBrukerPassord;
        private Button butBrukerReg;
        private Label lblBrukerPassord;
        private Label lblBrukerBrukernavn;
        private Label lblBrukerEtternavn;
        private Button butBrukerSlett;
        private Label lblBrukerType;
        private Button butBrukerEndre;
        private TextBox txtBrukerBrukernavn;
        private ComboBox cmbBrukerType;
        private TextBox txtBrukerFornavn;
        private TextBox txtBrukerEtternavn;
        private DataGridView dgvBrukere;
        private TabPage tabTester;
        private Panel panelTester;
        private TextBox txtTesterFil;
        private Button butTesterTøm;
        private Button butTesterReg;
        private Label lblTesterFil;
        private Label lblTesterNavn;
        private Button butTesterSlett;
        private Label lblTesterFag;
        private Button butTesterEndre;
        private TextBox txtTesterNavn;
        private ComboBox cmbTesterFag;
        private DataGridView dgvTester;
        private DataGridView dgvFiler;
        private TabPage tabElever;
        private Panel panelElever;
        private Label lblEleverStatus;
        private CheckBox chkEleverStatus;
        private Button butEleverFlyttAlle;
        private ComboBox cmbEleverSkoleår;
        private Label lblEleverSkoleår;
        private Button butEleverTøm;
        private Button butEleverReg;
        private Button butEleverSlett;
        private Button butEleverEndre;
        private ComboBox cmbEleverKlasse;
        private Label lblEleverKlasse;
        private ComboBox cmbEleverKjønn;
        private TextBox txtEleverEtternavn;
        private TextBox txtEleverFornavn;
        private TextBox txtEleverFNummer;
        private Label lblEleverKjønn;
        private Label lblEleverEtternavn;
        private Label lblEleverFNummer;
        private Label lblEleverFornavn;
        private DataGridView dgvElever;
        private DataGridView dgvEleverKlasse;
        private TabPage tabResultat;
        private Panel panelResultat;
        private ComboBox cmbResSem;
        private ComboBox cmbResÅr;
        private Label label2;
        private NumericUpDown numResPoeng;
        private ComboBox cmbResBet;
        private Label lblResKlasse;
        private ComboBox cmbResElev;
        private Button butResTøm;
        private Button butResReg;
        private Button butResSlett;
        private Button butResEndre;
        private TextBox txtResKommentar;
        private Label lblResKommentar;
        private ComboBox cmbResTest;
        private ComboBox cmbResDeltest;
        private Label lblResPoeng;
        private DataGridView dgvResultat;
        private TabControl tabMeny;
        private CheckBox chkResElev;
        private ComboBox cmbResFag;
        private CheckBox chkResKlasse;
        private RadioButton rbResReg;
        private RadioButton rbResVisning;
        private CheckBox chkResFag;
        private CheckBox chkResDeltest;
        private CheckBox chkResTest;
        private Label lblResSemester;
        private Label lblResElev;
        private Label lblResFag;
        private Label lblResTest;
        private Label lblResDeltest;
        private ToolStripMenuItem menyBackup;
        private Button butEksporter;
        private Label lblResVisning;
        private HelpProvider hjelp;
        private ToolStripMenuItem menyVisHjelp;
        private ComboBox cmbDeltestFag;
        private Label lblDeltestFag;
        private ComboBox cmbKlasserFag;
        private Label label6;
    }
}

