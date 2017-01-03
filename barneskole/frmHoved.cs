using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Barneskole
{
    public partial class frmHoved : Form
    {
        //Databasen
        Database database;
        
        //Variabler brukt til i forbindelse med registrering/endring/sletting
        string gmlBrukernavn;
        string gmlBetegnelse;
        string gmlSkoleår;
        string gmlDeltestID;
        string gmlDeltestDato;
        string filnavn;
        string filtype;
        string testID;
        string fnummer;
        
        //Brukernavn og bruker ID til den som er logget inn
        string brukernavn;
        string brukerid;

        //Filbanen til temp mappen som eksporteringen av PDF bruker
        string mappe;

        //Hvilken type visning av resultat som er valgt
        string valgtVisning;

        //Konstanter for menyvalgene
        const string menyResultater = "Resultater";
        const string menyTester = "Tester";
        const string menyDeltester = "Deltester";
        const string menyKlasser = "Klasser";
        const string menyElever = "Elever";
        const string menyBrukere = "Brukere";

        //Variabler brukt til å ta vare på valg
        int årIndex = 0;
        int betIndex = 0;
        int elevIndex = 0;
        int fagIndex = 0;

        //Variabel brukt for å holde orden på sortering av datagrid
        string sortering = "asc";

        #region Form
        //Initsierer hovedformen
        public frmHoved()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Hovedformen lastes inn
        private void frmHoved_Load(object sender, EventArgs e)
        {
            try
            {
                //Oppretter databasenklassen
                database = new Database();

                //Hvis temp mappen finnes så slettes innhold fra denne
                mappe = Path.GetTempPath() + @"Barneskole\";
                slettTempMappe();
                
                //Setter startposisjon og størrelse på form til skjermoppløsning
                this.Location = new Point(0, 0);
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;

                //Fjerner fanene i tabcontrollen
                tabMeny.ItemSize = new Size(0, 1);
                tabMeny.SizeMode = TabSizeMode.Fixed;

                //Setter hjelp til riktig hjelpefil
                hjelp.HelpNamespace = System.IO.Directory.GetParent(Application.ExecutablePath) + @"\Hjelp\barneskole.chm";

                //For overført fra innlogging hvem som logget inn
                var log = this.Tag as frmInnlogging;
                lblBrukerStatus.Text = log.bruker.ToString();
                brukernavn = log.bruker.getBrukernavn();
                brukerid = log.bruker.getBrukerID();

                //Setter begrensninger i menyen i forhold til om man er admin eller bruker
                if (log.bruker.getBrukertype().ToString() == "Bruker")
                {
                    butBruker.Visible = false;
                    butElev.Visible = false;
                    menyBackup.Visible = false;
                }

                //Timer for å vise klokkeslett
                Timer tmr = new Timer();
                tmr.Interval = 1000;//ticks every 1 second
                tmr.Tick += new EventHandler(tmr_Tick);
                tmr.Start();

                //Går til resultater i menyen
                menyValg(menyResultater);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Hovedformen avsluttes
        private void frmHoved_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Sletter det som er i temp mappen om det ikke er i bruk
                slettTempMappe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Avslutter programmet
            Application.Exit();
        }

        //Hoved form logg ut
        private void frmHoved_Loggut(object sender, EventArgs e)
        {
            //Disposer hovedformen, og viser innloggingsformen
            this.Dispose();
            var log = this.Tag as frmInnlogging;
            log.Show();
        }

        #endregion
        #region Diverse
        //Sletter det som er i temp mappen om det ikke er i bruk
        private void slettTempMappe()
        {
            try
            {
                //Hvis temp mappen finnes
                if (Directory.Exists(mappe))
                {
                    //For hver fil i mappen
                    DirectoryInfo dir1 = new DirectoryInfo(mappe);
                    foreach (FileInfo fi in dir1.GetFiles())
                    {
                        //Hvis filen ikke er i bruk så slettes den
                        if (!filIBruk(fi))
                        {
                            fi.Delete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sjekker om filen er i bruk
        protected virtual bool filIBruk(FileInfo file)
        {
            //Filestream for lesing av filer
            FileStream stream = null;

            try
            {
                //Prøver å åpne filen
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //Returnerer true hvis filen er i bruk
                return true;
            }
            finally
            {
                //Lukker streamen
                if (stream != null)
                    stream.Close();
            }

            //Returnerer false hvis den ikke er i bruk
            return false;
        }
        
        //Setter dato og klokkeslett på timer tick
        private void tmr_Tick(object sender, EventArgs e)
        {
            lblDato.Text = DateTime.Now.ToString();
        }

        //Menyvalg for å avslutte programmet
        private void mnyAvslutt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Viser aboutboks for programmet
        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about abt = new about();
            abt.ShowDialog();
        }

        //Case for meny valg
        private void menyValg(string valgt)
        {
            try
            {
                //Setter bakgrunnsfargen på knappene i menyen til gjennomsiktig
                butResultat.BackColor = Color.Transparent;
                butTest.BackColor = Color.Transparent;
                butDeltest.BackColor = Color.Transparent;
                butElev.BackColor = Color.Transparent;
                butKlasse.BackColor = Color.Transparent;
                butBruker.BackColor = Color.Transparent;

                //Case switch for meny valg
                switch (valgt)
                {
                    //Går til resultater og velger visning
                    case menyResultater:
                        tabMeny.SelectedTab = tabResultat;
                        rbResVisning.Checked = false;
                        rbResVisning.Checked = true;

                        butResultat.BackColor = Color.Black;

                        //Setter acceptbutton til butResReg
                        this.AcceptButton = butResReg;

                        //Laster inn klasser i comboboksen
                        cmbResÅr.DataSource = database.LastKlasseÅr().Tables[0];
                        cmbResÅr.ValueMember = "Skoleår";

                        //Hvis det ikke finnes noen klasser så blir panelet disabled.
                        if (cmbResÅr.Items.Count == 0)
                        {
                            panelResultat.Enabled = false;
                        }
                        else
                        {
                            panelResultat.Enabled = true;
                        }
                        break;

                    //Velger tester og laster dem inn
                    case menyTester:
                        tabMeny.SelectedTab = tabTester;
                        lastTester();
                        butTest.BackColor = Color.Black;
                        this.AcceptButton = butTesterReg;
                        break;

                    //Velger deltester og laster dem inn
                    case menyDeltester:
                        tabMeny.SelectedTab = tabDeltest;
                        
                        //Laster inn fag i comboboks
                        cmbDeltestFag.DataSource = null;
                        cmbDeltestFag.DataSource = database.LastFag().Tables[0];
                        cmbDeltestFag.DisplayMember = "fagnavn";

                        //Laster inn deltester til valgt fag og test
                        lastDeltest();
                        butDeltest.BackColor = Color.Black;
                        this.AcceptButton = butDeltestReg;

                        //Legger til semester i comboboks
                        cmbDeltestSem.Items.Clear();
                        cmbDeltestSem.Items.Add("Høst");
                        cmbDeltestSem.Items.Add("Vår");
                        cmbDeltestSem.SelectedIndex = 0;
                        break;

                    //Velger elever og laster inn klasser
                    case menyElever:
                        tabMeny.SelectedTab = tabElever;
                        cmbEleverSkoleår.DataSource = database.LastKlasseÅr().Tables[0];
                        cmbEleverSkoleår.ValueMember = "Skoleår";
                        lastElever();
                        butElev.BackColor = Color.Black;
                        this.AcceptButton = butEleverReg;
                        break;

                    //Velger klasser og laster dem inn
                    case menyKlasser:
                        tabMeny.SelectedTab = tabKlasser;

                        //Laster inn fag i comboboks
                        cmbKlasserFag.DataSource = null;
                        cmbKlasserFag.DataSource = database.LastFag().Tables[0];
                        cmbKlasserFag.DisplayMember = "fagnavn";

                        //Bruker som er logget inn
                        var log = this.Tag as frmInnlogging;
                        lblBrukerStatus.Text = log.bruker.ToString();
                        brukernavn = log.bruker.getBrukernavn();

                        //Hvis bruker som er logget inn er vanlig bruker så kan man ikke administrere klasser
                        if (log.bruker.getBrukertype().ToString() == "Bruker")
                        {
                            lblKlasserBetegnelse.Visible = false;
                            lblKlasserSkoleår.Visible = false;
                            txtKlasserBet.Visible = false;
                            txtKlasserÅr.Visible = false;
                            butKlasserReg.Visible = false;
                            butKlasserEndre.Visible = false;
                            butKlasserSlett.Visible = false;
                            butKlasserTøm.Visible = false;
                        }

                        lastKlasser();
                        butKlasse.BackColor = Color.Black;
                        this.AcceptButton = butKlasserReg;
                        break;

                    //Velger brukere og laster dem inn
                    case menyBrukere:
                        tabMeny.SelectedTab = tabBrukere;
                        lastBrukere();
                        butBruker.BackColor = Color.Black;
                        this.AcceptButton = butBrukerReg;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man klikker på backup i meny linjen øverts
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Tar backup av databasen
                database.Backup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man klikker på headeren i datagridden
        private void dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Fjerner blå markering i datagriddene
                dgvEleverKlasse.CurrentCell = null;
                dgvFiler.CurrentCell = null;
                dgvKlasserTest.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Når man klikker på headeren i datagridden
        private void dgvBrukere_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Fjerner blå markering i datagriden og fjerner informasjon lagt inn om bruker
                dgvBrukere.CurrentCell = null;
                txtBrukerBrukernavn.Clear();
                txtBrukerEtternavn.Clear();
                txtBrukerPassord.Clear();
                txtBrukerFornavn.Clear();
                cmbBrukerType.Enabled = true;
                butBrukerSlett.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Når man klikker på headeren i datagridden
        private void dgvTester_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Fjerner blå markering i datagriddene og informasjon lagt inn om tester
                dgvTester.CurrentCell = null;
                txtTesterNavn.Clear();
                txtTesterFil.Clear();
                butTesterSlett.Enabled = false;
                dgvFiler.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Når man klikker på headeren i datagridden
        private void dgvDeltest_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Fjerner blå markering i datagridene og informasjon lagt inn om deltester
                dgvDeltest.CurrentCell = null;
                txtDeltestNavn.Clear();
                numDeltestKritisk.Value = 0;
                numDeltestMaks.Value = 0;
                butDeltestSlett.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Når man klikker på headeren i datagridden
        private void dgvKlasser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Fjerner blå markering i datagridene og informasjon om klasser
                dgvKlasser.CurrentCell = null;
                txtKlasserBet.Clear();
                txtKlasserÅr.Clear();
                dgvKlasserTest.DataSource = null;
                butKlasserSlett.Enabled = false;
                butKlasserRegTest.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Når man klikker på headeren i datagridden
        private void dgvElever_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Fjerner blå markering i datagridene og informasjon om elever
                dgvElever.CurrentCell = null;
                txtEleverFNummer.Clear();
                txtEleverFNummer.Enabled = true;
                txtEleverEtternavn.Clear();
                txtEleverFornavn.Clear();
                cmbEleverKjønn.Enabled = true;
                lblEleverStatus.Visible = false;
                chkEleverStatus.Visible = false;
                chkEleverStatus.Checked = false;
                butEleverSlett.Enabled = false;
                dgvEleverKlasse.DataSource = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Når man klikker på headeren i resultat datagridden
        private void dgvRes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Hvis datagridden har angitt datasource
                if (dgvResultat.Rows.Count > 0)
                {
                    //Fjerner blå markering i datagridden
                    dgvResultat.CurrentCell = null;

                    //Hvis registreirng er valgt så reseterer den visningen og gjør klar for ny registrering
                    if (rbResReg.Checked == true)
                    {
                        resetResultat();
                    }

                    //Hvis man trykker på elevnavn kolonnen
                    if (e.ColumnIndex == dgvResultat.Columns["Elevnavn"].Index)
                    {
                        //Hvis tidligere sortering er ascending så sorterer den descending
                        if (sortering.Equals("asc"))
                        {
                            dgvResultat.Sort(dgvResultat.Columns["Fornavn"], System.ComponentModel.ListSortDirection.Descending);
                            sortering = "desc";
                        }

                        //Hvis tidligere storering er descending så sorterer den ascending
                        else
                        {
                            dgvResultat.Sort(dgvResultat.Columns["Fornavn"], System.ComponentModel.ListSortDirection.Ascending);
                            sortering = "asc";
                        }
                    }
                    //Oppdaterer visningen
                    kritiskgrense();
                    resultatnavn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Resultat
        //Går til resultat tabben
        private void butResultat_Click(object sender, EventArgs e)
        {
            try
            {
                menyValg(menyResultater);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Gjør registrering klar ved å sette synlighet og enabled verdier på komponentene
        private void lastRegistrering()
        {
            try
            {
                dgvResultat.Columns.Clear();
                butResSlett.Enabled = false;
                butResEndre.Enabled = false;
                butResSlett.Visible = true;
                butResEndre.Visible = true;
                butResReg.Visible = true;
                butResTøm.Visible = true;
                lblResKommentar.Visible = true;
                lblResPoeng.Visible = true;
                chkResElev.Visible = false;
                chkResKlasse.Visible = false;
                chkResFag.Visible = false;
                chkResTest.Visible = false;
                chkResDeltest.Visible = false;
                cmbResBet.Visible = true;
                cmbResÅr.Visible = true;
                txtResKommentar.Visible = true;
                numResPoeng.Visible = true;
                txtResKommentar.Clear();
                numResPoeng.Value = 0;
                numResPoeng.Focus();

                //Lagrer valt år og betegnelse
                årIndex = cmbResÅr.SelectedIndex;
                betIndex = cmbResBet.SelectedIndex;

                //Oppdaterer informasjon med valgt år og betegnelse
                klasseEndret();

                //Hvis det finnes klasser
                if (cmbResÅr.Items.Count > 0)
                {
                    cmbResÅr.Enabled = true;
                    cmbResBet.Enabled = true;
                }

                //Hvis det finnes elever i klassen så velges lagret elev
                //if (cmbResElev.Items.Count > 0)
               // {
                 //   cmbResElev.SelectedIndex = elevIndex;
               // }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Gjør visning klar ved å sette synlighet og enabled verdier på komponentene
        private void lastVisning()
        {
            try
            {
                butResSlett.Visible = false;
                butResEndre.Visible = false;
                butResReg.Visible = false;
                butResTøm.Visible = false;
                lblResKommentar.Visible = false;
                lblResPoeng.Visible = false;
                numResPoeng.Visible = false;
                txtResKommentar.Visible = false;
                chkResElev.Visible = true;
                chkResKlasse.Visible = true;
                chkResFag.Visible = true;
                chkResTest.Visible = true;
                chkResDeltest.Visible = true;
                cmbResBet.Visible = true;
                cmbResÅr.Visible = true;
                cmbResSem.Visible = true;
                cmbResDeltest.Visible = true;
                chkResElev.Checked = false;
                chkResFag.Checked = false;
                chkResKlasse.Checked = false;
                chkResTest.Checked = false;
                chkResDeltest.Checked = false;
                cmbResTest.Enabled = false;
                cmbResFag.Enabled = false;
                cmbResSem.Enabled = false;
                cmbResDeltest.Enabled = false;
                cmbResElev.Enabled = false;
                chkResKlasse.Enabled = false;
                chkResDeltest.Enabled = false;
                cmbResElev.Items.Clear();
                cmbResFag.DataSource = null;
                cmbResTest.DataSource = null;
                cmbResSem.Items.Clear();
                cmbResDeltest.DataSource = null;

                //Lagrer valgt år og betegnelse
                årIndex = cmbResÅr.SelectedIndex;
                betIndex = cmbResBet.SelectedIndex;

                //Oppdaterer informasjon med valgt år og betegnelse
                klasseEndret();

                //Hvis det finnes klasser
                if (cmbResÅr.Items.Count > 0)
                {
                    cmbResÅr.Enabled = true;
                    cmbResBet.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        //Når man velger klasse år
        private void cmbResKlasseÅr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Fyller comboboksen med klasse betegnelser fra databasen til tilhørende år
                cmbResBet.DataSource = database.LastKlasserBet(cmbResÅr.Text).Tables[0];
                cmbResBet.DisplayMember = "Betegnelse";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Hvis det ikke finnes noen elever så blir registreringsknappen disabled
            if (cmbResElev.Items.Count == 0)
            {
                butResReg.Enabled = false;
            }
        }
        
        //Fyller elev comboboksen med elever
        private void comboElev()
        {
            try
            {
                DataTable dt = null;

                //Sjekker om man er på visning eller registrering
                if (rbResReg.Checked)
                {
                    //Henter elever som kun er aktive til valgt klasse
                    dt = database.LastEleverResultat(cmbResÅr.Text, cmbResBet.Text).Tables[0];
                }
                else
                {
                    //Henter elever fra databasen til valgt klasse
                    dt = database.LastElever(cmbResÅr.Text, cmbResBet.Text).Tables[0];
                }
                
                string fornavn;
                string etternavn;
                string FNummer;

                //Tømmer elever før det fylles med nye for å unngå duplicates
                cmbResElev.Items.Clear();

                //Hvis det finnes elever
                if (dt.Rows.Count > 0)
                {
                    //For hver elev så legges fødselsnummer og navn til i comboboks
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FNummer = dt.Rows[i]["FNummer"].ToString();
                        fornavn = dt.Rows[i]["Fornavn"].ToString();
                        etternavn = dt.Rows[i]["Etternavn"].ToString();
                        cmbResElev.Items.Add(fornavn + " " + etternavn + "," + FNummer);
                    }

                    //Hvis lagret elev index er over antall elever i comboboksen
                    if (elevIndex >= cmbResElev.Items.Count)
                    {
                        //Setter comboboks til siste elev i comboboksen
                        cmbResElev.SelectedIndex = cmbResElev.Items.Count - 1;
                    }
                    //Hvis lagret elev index ikke er over antall elever i comboboksen
                    else
                    {
                        //Setter comboboks til lagret valgt elev
                        cmbResElev.SelectedIndex = elevIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger klasse betegnelse
        private void cmbResKlasseBet_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Oppdaterer informasjon om valgt år og betegnelse
                klasseEndret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        //Sjekker og velger hvilke resultat som skal vises i datagrid på visning, og henter elever på registrering
        private void klasseEndret()
        {
            try
            {
                //Hvis visning er valgt
                if (rbResVisning.Checked == true)
                {
                    //Hvis elev er krysset av
                    if (chkResElev.Checked == true)
                    {
                        //Henter elever
                        comboElev();

                        //Sjekker om fag/test eller deltest er krysset av
                        if (chkResFag.Checked == true)
                        {
                            visResultat("FagElevKlasse");
                        }
                        else if (chkResTest.Checked == true)
                        {
                            cmbResTest.DataSource = database.LastTesterKlasse(cmbResÅr.Text, cmbResBet.Text).Tables[0];

                            if (cmbResTest.Items.Count == 0)
                            {
                                dgvResultat.Columns.Clear();
                            }
                            else
                            {
                                if (chkResDeltest.Checked == true)
                                {
                                    cmbResDeltest.DataSource = database.LastResDeltest(cmbResTest.SelectedValue.ToString(), cmbResSem.Text).Tables[0];
                                    visResultat("DeltestElevKlasse");
                                }
                                else
                                {
                                    visResultat("TestElevKlasse");
                                }
                            }
                        }
                        else
                        {
                            visResultat("AlleElevKlasse");
                        }
                    }
                    //Hvis ikke elev er krysset av
                    else
                    {
                        //Sjekker om fag/test eller deltest er krysset av
                        if (chkResFag.Checked == true)
                        {
                            visResultat("FagKlasse");
                        }
                        else if (chkResTest.Checked == true)
                        {
                            cmbResTest.DataSource = database.LastTesterKlasse(cmbResÅr.Text, cmbResBet.Text).Tables[0];

                            if (cmbResTest.Items.Count == 0)
                            {
                                dgvResultat.Columns.Clear();
                            }
                            else
                            {
                                if (chkResDeltest.Checked == true)
                                {
                                    cmbResDeltest.DataSource = database.LastResDeltest(cmbResTest.SelectedValue.ToString(), cmbResSem.Text).Tables[0];
                                    visResultat("DeltestKlasse");
                                }
                                else
                                {
                                    visResultat("TestKlasse");
                                }
                            }
                        }
                        else
                        {
                            visResultat("AlleKlasse");
                        }
                    }
                }
                //Hvis registrering er valgt
                else
                {
                    //Fjerner resultat i datagrid
                    dgvResultat.Columns.Clear();

                    //Henter elever
                    comboElev();

                    cmbResFag.Enabled = true;
                    cmbResFag.DataSource = database.LastFag().Tables[0];
                    cmbResFag.DisplayMember = "Fagnavn";

                    //Hvis det finnes elever
                    if (cmbResElev.Items.Count > 0)
                    {
                        cmbResElev.Enabled = true;
                    }
                    //Hvis det ikke finnes elever
                    else
                    {
                        cmbResElev.Enabled = false;
                        cmbResFag.Enabled = false;
                        cmbResTest.Enabled = false;
                        cmbResSem.Enabled = false;
                        cmbResDeltest.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Ordner datagridden for visning av resultat
        private void resultatnavn()
        {
            try
            {
                string elevnavn;

                //For hvert resultat i datagridden så samler den flere kolonner sammen i elevnavn kolonnen og fjerner markering i datagridden
                foreach (DataGridViewRow row in this.dgvResultat.Rows)
                {
                    elevnavn = row.Cells["Fornavn"].Value.ToString() +
                        " " + row.Cells["Etternavn"].Value.ToString() +
                        " " + row.Cells["Skoleår"].Value.ToString() +
                        " " + row.Cells["Betegnelse"].Value.ToString();
                    row.Cells["Elevnavn"].Value = elevnavn;
                    dgvResultat.CurrentCell = null;
                }

                //Endrer tekst, og gjemmer unødvendige kolonner
                dgvResultat.Columns["Elevnavn"].HeaderText = "Navn";
                dgvResultat.Columns["Deltestnavn"].HeaderText = "Deltest";
                dgvResultat.Columns["Testnavn"].HeaderText = "Test";
                dgvResultat.Columns["Fagnavn"].HeaderText = "Fag";
                dgvResultat.Columns["Elevnavn"].DisplayIndex = 1;
                dgvResultat.Columns["Fornavn"].Visible = false;
                dgvResultat.Columns["FNummer"].Visible = false;
                dgvResultat.Columns["Etternavn"].Visible = false;
                dgvResultat.Columns["Skoleår"].Visible = false;
                dgvResultat.Columns["Betegnelse"].Visible = false;
                dgvResultat.Columns["DeltestID"].Visible = false;
                dgvResultat.Columns["Kritiskgrense"].Visible = false;

                //Setter autosizemode på kolonner så de endrer seg automatisk eller innhold
                dgvResultat.Columns["Kommentar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvResultat.Columns["Elevnavn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvResultat.Columns["Testnavn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvResultat.Columns["Fagnavn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvResultat.Columns["Semester"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvResultat.Columns["Prosent"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvResultat.Columns["MaksPoeng"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvResultat.Columns["Poeng"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvResultat.Columns["Deltestnavn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvResultat.Columns["Dato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvResultat.Columns["Brukernavn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //Hvis resultat ikke får plass, så lages scrollbar så man kan scrolle vertikalt
                var vScrollbar = dgvResultat.Controls.OfType<HScrollBar>().First();
                if (vScrollbar.Visible == false)
                {
                    //Endrer bredde og setter autosizemode på kolonnen
                    dgvResultat.Columns["Elevnavn"].Width = 150;
                    dgvResultat.Columns["Kommentar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man trykker i datagriden resultat
        private void dgvResultat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Hvis registrering er valgt, og det finnes resultater
                if (rbResReg.Checked == true && e.RowIndex >= 0)
                {
                    //Setter verdier til variabler når man trykker på en rad
                    DataGridViewRow row = dgvResultat.Rows[e.RowIndex];
                    fnummer = row.Cells["FNummer"].Value.ToString();
                    gmlDeltestID = row.Cells["DeltestID"].Value.ToString();
                    gmlDeltestDato = row.Cells["Dato"].Value.ToString().Substring(6, 4) + "-" + row.Cells["Dato"].Value.ToString().Substring(3, 2) + "-" + row.Cells["Dato"].Value.ToString().Substring(0, 2);
                    numResPoeng.Maximum = int.Parse(row.Cells["MaksPoeng"].Value.ToString());
                    numResPoeng.Value = int.Parse(row.Cells["Poeng"].Value.ToString());
                    txtResKommentar.Text = row.Cells["Kommentar"].Value.ToString();

                    //Gjør klar for endring av resultat
                    butResReg.Enabled = false;
                    butResEndre.Enabled = true;
                    butResSlett.Enabled = true;
                    cmbResDeltest.Enabled = false;
                    cmbResSem.Enabled = false;
                    cmbResTest.Enabled = false;
                    cmbResFag.Enabled = false;
                    cmbResElev.Enabled = false;
                    cmbResBet.Enabled = false;
                    cmbResÅr.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Registrering av resultat
        private void butResReg_Click(object sender, EventArgs e)
        {
            try
            {
                //Registrerer nytt resultat, og oppdaterer visningen
                database.InsertResultat(fnummer, cmbResDeltest.SelectedValue.ToString(), cmbResBet.Text, cmbResÅr.Text, numResPoeng.Value.ToString(), txtResKommentar.Text.Trim(), brukerid);
                resetResultat();
                visResultat("TestElevKlasse");

                //Velger neste deltest hvis det er over 1 deltest i comboboks, og deltest som er valgt ikke er den siste i comboboks
                if (cmbResDeltest.Items.Count > 1 && cmbResDeltest.SelectedIndex != cmbResDeltest.Items.Count - 1)
                {
                    cmbResDeltest.SelectedIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Endring av resultat
        private void butResEndre_Click(object sender, EventArgs e)
        {
            try
            {
                //Endrer resultatet og oppdaterer visningen
                database.UpdateResultat(gmlDeltestID, fnummer, gmlDeltestDato, numResPoeng.Value.ToString(), txtResKommentar.Text.Trim());
                resetResultat();

                //Oppdaterer resultat
                 visResultat("TestElevKlasse");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sletting av resultat
        private void butResSlett_Click(object sender, EventArgs e)
        {
            try
            {
                //Sletter resultatet og oppdaterer visningen
                database.SlettResultat(fnummer, gmlDeltestID, gmlDeltestDato);
                resetResultat();

                //Oppdaterer resultat
                visResultat("TestElevKlasse");

                //Hvis datagriden er tom så slettes kolonnene
                if (dgvResultat.Rows.Count == 0)
                {
                    dgvResultat.Columns.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Tilbakestiller deler av registrering for ny registrering
        private void butResTøm_Click(object sender, EventArgs e)
        {
            try
            {
                dgvResultat.CurrentCell = null;
                if (valgtVisning == "TestElevKlasse")
                {
                    resetResultat();
                }
                else
                {
                    numResPoeng.Value = 0;
                    txtResKommentar.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Tilbakestiller resultatklar for ny registrering
        private void resetResultat()
        {
            //Hvis elever, tester og deltester finnes
            if (cmbResElev.Items.Count > 0 && cmbResTest.Items.Count > 0 && cmbResDeltest.Items.Count > 0)
            {
                butResReg.Enabled = true;
                butResSlett.Enabled = false;
                butResEndre.Enabled = false;
                numResPoeng.Value = 0;
                txtResKommentar.Clear();
                cmbResDeltest.Enabled = true;
                cmbResTest.Enabled = true;
                cmbResSem.Enabled = true;
                cmbResElev.Enabled = true;
                cmbResBet.Enabled = true;
                cmbResÅr.Enabled = true;
                cmbResFag.Enabled = true;
                numResPoeng.Focus();
            }
        }

        //Når man trykker på checkboksen til elev
        private void chkResElev_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis elev er krysset
                if (chkResElev.Checked == true)
                {
                    chkResKlasse.Enabled = true;
                    cmbResElev.Enabled = true;

                    //Henter alle elever
                    comboElev();
                }
                //Hvis ikke elev er krysset av
                else
                {
                    chkResKlasse.Enabled = false;
                    chkResKlasse.Checked = false;
                    cmbResElev.Enabled = false;
                    cmbResElev.Items.Clear();

                    //Hvis fag er krysset av
                    if (chkResFag.Checked == true)
                    {
                        //Viser resultat
                        visResultat("FagKlasse");
                    }

                    //Eller hvis  test er krysset av
                    else if (chkResTest.Checked == true)
                    {
                        //Hvis det ikke finnes tester
                        if (cmbResTest.Items.Count == 0)
                        {
                            //Tøm datagridden
                            dgvResultat.Columns.Clear();
                        }

                        //Hvis det finnes tester
                        else
                        {
                            //Hvis deltest er krysset av
                            if (chkResDeltest.Checked == true)
                            {
                                //Viser resultat
                                visResultat("DeltestKlasse");
                            }

                            //Hvis deltest ikke er krysset av
                            else
                            {
                                //Viser resultat
                                visResultat("TestKlasse");
                            }
                        }
                    }

                    //Hvis verken fag, eller test er krysset av
                    else
                    {
                        //Viser resultat
                        visResultat("AlleKlasse");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger elev
        private void cmbResElev_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Lagrer index for valgt elev
                elevIndex = cmbResElev.SelectedIndex;

                //Hvis visning er valgt
                if (rbResVisning.Checked == true)
                {
                    //Lagrer fødselsnummer til valgt elev
                    fnummer = cmbResElev.Text.Substring(cmbResElev.Text.LastIndexOf(',') + 1).ToString();

                    //Hvis klasse er krysset av
                    if (chkResKlasse.Checked == true)
                    {
                        //Hvis fag er krysset av
                        if (chkResFag.Checked == true)
                        {
                            //Viser resultat
                            visResultat("FagElevKlasse");
                        }

                        //Eller hvis test er krysset av
                        else if (chkResTest.Checked == true)
                        {
                            //Hvis det ikke finnes elever
                            if (cmbResTest.Items.Count == 0)
                            {
                                //Tømmer datagridden
                                dgvResultat.Columns.Clear();
                            }

                            //Hvis det finnes elever
                            else
                            {
                                //Hvis deltest er krysset av
                                if (chkResDeltest.Checked == true)
                                {
                                    //Viser resultat
                                    visResultat("DeltestElevKlasse");
                                }
                                //Hvis deltest ikke er krysset av
                                else
                                {
                                    //Viser resultat
                                    visResultat("TestElevKlasse");
                                }
                            }
                        }

                        //Hvis verken fag eller test er krysset av
                        else
                        {
                            //Viser resultat
                            visResultat("AlleElevKlasse");
                        }
                    }

                    //Hvis klasse ikke er krysset av
                    else
                    {
                        //Hvis fag er krysset av
                        if (chkResFag.Checked == true)
                        {
                            //Viser resultat
                            visResultat("FagElev");
                        }

                        //Eller hvis test er krysset av
                        else if (chkResTest.Checked == true)
                        {
                            //Hvis det ikke finnes tester
                            if (cmbResTest.Items.Count == 0)
                            {
                                //Tømmer datagridden
                                dgvResultat.Columns.Clear();
                            }

                            //Hvis det finnes tester
                            else
                            {
                                //Hvis deltest er krysset av
                                if (chkResDeltest.Checked == true)
                                {
                                    //Viser resultat
                                    visResultat("DeltestElev");
                                }

                                //Hvis deltest ikke er krysset av
                                else
                                {
                                    //Viser resultat
                                    visResultat("TestElev");
                                }
                            }
                        }
                        //Hvis verken fag eller test er krysset av
                        else
                        {
                            //Viser resultat
                            visResultat("AlleElev");
                        }
                    }
                }

                //Hvis registrering er valgt
                else
                {
                    //Lagrer fødselsnummer til valgt elev
                    fnummer = cmbResElev.Text.Substring(cmbResElev.Text.LastIndexOf(',') + 1).ToString();

                    //Hvis det finnes testr
                    if (cmbResTest.Items.Count > 0)
                    {
                        //Tømmer datagridden og viser resultat
                        dgvResultat.Columns.Clear();
                        dgvResultat.Columns.Add("Elevnavn", "Elevnavn");
                        visResultat("TestElevKlasse");
                    }

                    //Hvis det finnes fag
                    if (cmbResFag.Items.Count > 0)
                    {
                        cmbResFag.Enabled = true;
                    }

                    //Hvis det ikke finnes fag
                    else
                    {
                        cmbResFag.Enabled = false;
                    }
                }

                //Fjerner markering i datagridden
                dgvResultat.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger fag
        private void cmbResFag_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis visning er valgt
                if (rbResVisning.Checked == true)
                {
                    //Hvis elev er krysset av
                    if (chkResElev.Checked == true)
                    {
                        //Hvis klasse er krysset av
                        if (chkResKlasse.Checked == true)
                        {
                            //Viser resultat
                            visResultat("FagElevKlasse");
                        }

                        //Hvis klasse ikke er krysset av
                        else
                        {
                            //Viser resultat
                            visResultat("FagElev");
                        }
                    }

                    //Hvis elev ikke er krysset av
                    else
                    {
                        //Viser resultat
                        visResultat("FagKlasse");
                    }
                }

                //Hvis registrering er valgt
                else
                {
                    //Laster inn tester til valgt klasse og fag
                    cmbResTest.DataSource = database.LastTesterKlasseFag(cmbResÅr.Text, cmbResBet.Text, cmbResFag.Text).Tables[0];
                    cmbResTest.ValueMember = "TestID";
                    cmbResTest.DisplayMember = "Testnavn";

                    //Hvis det ikke finnes tester
                    if (cmbResTest.Items.Count == 0)
                    {
                        cmbResTest.Enabled = false;
                        cmbResDeltest.Enabled = false;
                        cmbResSem.Enabled = false;
                        butResReg.Enabled = false;
                        cmbResDeltest.DataSource = null;
                        cmbResSem.Items.Clear();
                        dgvResultat.Columns.Clear();
                    }

                    //Hvis det finnes tester
                    else
                    {
                        cmbResTest.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger test
        private void cmbResTest_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis visning er valgt
                if (rbResVisning.Checked == true)
                {
                    //Hvis comboboks test ikke har tom datasource
                    if (cmbResTest.DataSource != null)
                    {
                        //Hvis elev er krysset av
                        if (chkResElev.Checked == true)
                        {
                            //Hvis deltest er krysset av
                            if (chkResDeltest.Checked == true)
                            {
                                //Laster inn deltester til valgt test
                                cmbResDeltest.DataSource = database.LastResDeltest(cmbResTest.SelectedValue.ToString(), cmbResSem.Text).Tables[0];
                            }

                            //Hvis deltest ikke er krysset av
                            else
                            {
                                //Hvis klasse er krysset av
                                if (chkResKlasse.Checked == true)
                                {
                                    //Viser resultat
                                    visResultat("TestElevKlasse");
                                }

                                //Hvis klasse ikke er krysset av
                                else
                                {
                                    //Viser resultat
                                    visResultat("TestElev");
                                }
                            }
                        }

                        //Hvis elev ikke er krysset av
                        else
                        {
                            //Hvis deltest er krysset av
                            if (chkResDeltest.Checked == true)
                            {
                                //Laster inn deltester til valgt test
                                cmbResDeltest.DataSource = database.LastResDeltest(cmbResTest.SelectedValue.ToString(), cmbResSem.Text).Tables[0];
                            }

                            //Hvis deltest ikke er krysset av
                            else
                            {
                                //Viser resultat
                                visResultat("TestKlasse");
                            }
                        }

                        //Setter display og value verdier til comboboksen deltest
                        cmbResDeltest.ValueMember = "DeltestID";
                        cmbResDeltest.DisplayMember = "Deltestnavn";
                    }
                }

                //Hvis registrering er valgt
                else
                {
                    //Hvis comboboks test ikke har tom datasource
                    if (cmbResTest.DataSource != null)
                    {
                        cmbResTest.Enabled = true;
                        cmbResSem.Enabled = true;
                        cmbResSem.Items.Clear();
                        cmbResSem.Items.Add("Høst");
                        cmbResSem.Items.Add("Vår");
                        cmbResSem.SelectedIndex = 0;

                        //Tømmer datagridden og viser resultat
                        dgvResultat.Columns.Clear();
                        dgvResultat.Columns.Add("Elevnavn", "Elevnavn");
                        visResultat("TestElevKlasse");

                        //Laster inn deltester
                        deltesterCombo();
                    }

                    //Hvis det ikke finnes noen resultater
                    if (dgvResultat.Rows.Count == 0)
                    {
                        //Tømmer datagridden
                        dgvResultat.Columns.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Laster inn deltester
        private void deltesterCombo()
        {
            try
            {
                //Hvis det finnes tester
                if (cmbResTest.Items.Count > 0)
                {
                    //Henter inn deltester og fyller comboboksen
                    DataTable deltester = database.LastResDeltest(cmbResTest.SelectedValue.ToString(), cmbResSem.Text).Tables[0];
                    cmbResDeltest.DataSource = deltester;

                    //Hvis det ikke finnes deltester
                    if (cmbResDeltest.Items.Count == 0)
                    {
                        cmbResDeltest.Enabled = false;
                        butResReg.Enabled = false;
                    }

                    //Hvis det finnes deltester
                    else
                    {
                        cmbResDeltest.Enabled = true;
                        butResReg.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger deltest
        private void cmbResDeltest_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis visning er valgt
                if (rbResVisning.Checked == true)
                {
                    //Hvis comboboks deltest ikke har tom datasource
                    if (cmbResDeltest.DataSource != null)
                    {
                        //Hvis elev er krysset av
                        if (chkResElev.Checked == true)
                        {
                            //Hvis klasse er krysset av
                            if (chkResKlasse.Checked == true)
                            {
                                //Viser resultat
                                visResultat("DeltestElevKlasse");
                            }

                            //Hvis klasse ikke er krysset av
                            else
                            {
                                //Viser resultat
                                visResultat("DeltestElev");
                            }
                        }

                        //Hvis elev ikke er krysset av
                        else
                        {
                            //Viser resultat
                            visResultat("DeltestKlasse");
                        }
                    }
                }

                //Hvis registrering er valgt
                else
                {
                    butResEndre.Enabled = false;

                    //Hvis comboboks deltest ikke har tom datasource
                    if (cmbResDeltest.DataSource != null)
                    {
                        //Prøver å gjøre om comboboks deltest sin valuemember til et tall
                        int n;
                        bool isNumeric = int.TryParse(cmbResDeltest.SelectedValue.ToString(), out n);

                        //Hvis det er tall
                        if (isNumeric)
                        {
                            //Henter deltest sin makspoeng
                            DataTable dt = database.LastDeltestPoeng(cmbResDeltest.SelectedValue.ToString()).Tables[0];
                            string poeng = dt.Rows[0]["MaksPoeng"].ToString();

                            //Hvis poeng ikke er 0
                            if (poeng != "0")
                            {
                                //Setter maximum verdi for numeric up and down til makspoeng
                                numResPoeng.Maximum = int.Parse(poeng);
                            }

                            //Hvis poeng er 0
                            else
                            {
                                //Setter maximum for numeric up and down til høyeste integer
                                numResPoeng.Maximum = int.MaxValue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger semester
        private void cmbResSemester_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Henter deltester til valgt test og semester
                deltesterCombo();
                cmbResDeltest.ValueMember = "DeltestID";
                cmbResDeltest.DisplayMember = "Deltestnavn";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Viser resultat til den måten man har valgt
        private void visResultat(string vis)
        {
            try
            {
                //Legger til kolonnen elevnavn i datagridden
                dgvResultat.Columns.Clear();
                dgvResultat.Columns.Add("Elevnavn", "Elevnavn");

                //Velger riktig case for henting av resultat
                valgtVisning = vis;
                switch (vis)
                {
                    //Alle resultater per klasse
                    case "AlleKlasse":
                        dgvResultat.DataSource = database.LastResultatKlasse(cmbResÅr.Text, cmbResBet.Text).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per klasse";
                        break;

                    //Alle resultater per elev
                    case "AlleElev":
                        dgvResultat.DataSource = database.LastResultatAlleElev(fnummer).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per elev";
                        break;

                    //Alle resultater per elev til valgt klasse
                    case "AlleElevKlasse":
                        dgvResultat.DataSource = database.LastResultatAlleElevKlasse(fnummer, cmbResBet.Text, cmbResÅr.Text).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per elev til valgt klasse";
                        break;

                    //Alle resultater per fag til valgt klasse
                    case "FagKlasse":
                        dgvResultat.DataSource = database.LastResultatFagKlasse(cmbResFag.Text, cmbResÅr.Text, cmbResBet.Text).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per fag til valgt klasse";
                        break;

                    //Alle resultater per elev til valgt fag
                    case "FagElev":
                        dgvResultat.DataSource = database.LastResultatFagElev(cmbResFag.Text, fnummer).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per elev til valgt fag";
                        break;

                    //Alle resultater per elev til valgt fag og klasse
                    case "FagElevKlasse":
                        dgvResultat.DataSource = database.LastResultatFagElevKlasse(cmbResFag.Text, fnummer, cmbResBet.Text, cmbResÅr.Text).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per elev til valgt fag og klasse";
                        break;

                    //Alle resultater per test til valgt klasse
                    case "TestKlasse":
                        dgvResultat.DataSource = database.LastTestResultatKlasse(cmbResTest.SelectedValue.ToString(), cmbResÅr.Text, cmbResBet.Text).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per test til valgt klasse";
                        break;

                    //Alle resultater per elev til valgt test
                    case "TestElev":
                        dgvResultat.DataSource = database.LastResultatTestElev(cmbResTest.SelectedValue.ToString(), fnummer).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per elev til valgt test";
                        break;

                    //Alle resultater per elev til valgt test og klasse
                    case "TestElevKlasse":
                        dgvResultat.DataSource = database.LastResultatTestElevKlasse(cmbResTest.SelectedValue.ToString(), fnummer, cmbResBet.Text, cmbResÅr.Text).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per elev til valgt test og klasse";
                        break;

                    //Alle resultater per deltest til valgt klasse
                    case "DeltestKlasse":
                        dgvResultat.DataSource = database.LastResultatDelTestKlasse(cmbResDeltest.SelectedValue.ToString(), cmbResÅr.Text, cmbResBet.Text).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per deltest til valgt klasse";
                        break;

                    //Alle resultater per elev til valgt deltest
                    case "DeltestElev":
                        dgvResultat.DataSource = database.LastResultatElevDeltest(cmbResDeltest.SelectedValue.ToString(), fnummer).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per elev til valgt deltest";
                        break;

                    //Alle resultater per elev til valgt deltest og klasse
                    case "DeltestElevKlasse":
                        dgvResultat.DataSource = database.LastResultatElevDeltestKlasse(cmbResDeltest.SelectedValue.ToString(), fnummer, cmbResBet.Text, cmbResÅr.Text).Tables[0].DefaultView;
                        lblResVisning.Text = "Alle resultater per elev til valgt deltest og klasse";
                        break;
                }

                //Hvis det finnes resultater
                if (dgvResultat.Rows.Count > 0)
                {
                    //Setter rød skrift på resultater under kritisk grense
                    kritiskgrense();

                    //Ordner visningen av resultat
                    resultatnavn();
                }

                //Hvis det ikke finnes resultater
                else
                {
                    //Tømmer datagridden
                    dgvResultat.Columns.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Setter rød tekt på poeng under kritisk grense
        private void kritiskgrense()
        {
            try
            {
                //For hver rad i datagridden
                foreach (DataGridViewRow row in this.dgvResultat.Rows)
                {
                    //Hvis poeng er under eller like kritisk grense
                    if (int.Parse(row.Cells["Poeng"].Value.ToString()) <= int.Parse(row.Cells["Kritiskgrense"].Value.ToString()))
                    {
                        //Setter fargen på poeng til rød
                        row.Cells["Poeng"].Style.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man krysser av eller på klasse
        private void chkResKlasse_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis klasse er enabled
                if (chkResKlasse.Enabled == true)
                {
                    //Hvis klasse er krysset av
                    if (chkResKlasse.Checked == true)
                    {
                        //Hvis fag er krysset av
                        if (chkResFag.Checked == true)
                        {
                            //Viser resultat
                            visResultat("FagElevKlasse");
                        }

                        //Eller hvis test er krysset av
                        else if (chkResTest.Checked == true)
                        {
                            //Hvis det ikke finnes tester
                            if (cmbResTest.Items.Count == 0)
                            {
                                //Tømmer datagridden
                                dgvResultat.Columns.Clear();
                            }

                            //Hvis det finnes tester
                            else
                            {
                                //Hvis deltest er krysset av
                                if (chkResDeltest.Checked == true)
                                {
                                    //Viser resultat
                                    visResultat("DeltestElevKlasse");
                                }

                                //Hvis deltest ikke er krysset av
                                else
                                {
                                    //Viser resultat
                                    visResultat("TestElevKlasse");
                                }
                            }
                        }

                        //Hvis test ikke er krysset av
                        else
                        {
                            //Viser resultat
                            visResultat("AlleElevKlasse");
                        }
                    }

                    //Hvis klasse ikke er krysset av
                    else
                    {
                        //Hvis fag er krysset av
                        if (chkResFag.Checked == true)
                        {
                            //Viser resultat
                            visResultat("FagElev");
                        }

                        //Eller hvis test er krysset av
                        else if (chkResTest.Checked == true)
                        {
                            //Hvis det ikke finnes tester
                            if (cmbResTest.Items.Count == 0)
                            {
                                //Tømmer datagridden
                                dgvResultat.Columns.Clear();
                            }

                            //Hvis det finnes tester
                            else
                            {
                                //Hvis deltest er krysset av
                                if (chkResDeltest.Checked == true)
                                {
                                    //Viser resultat
                                    visResultat("DeltestElev");
                                }

                                //Hvis deltest ikke er krysset av
                                else
                                {
                                    //Viser resultat
                                    visResultat("TestElev");
                                }
                            }
                        }

                        //Hvis test ikke er krysset av
                        else
                        {
                            //Viser resultat
                            visResultat("AlleElev");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger registrering
        private void rbResReg_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis registrering er valgt
                if (rbResReg.Checked == true)
                {
                    butResReg.Enabled = false;

                    //Tømmer datagridden
                    dgvResultat.Columns.Clear();
                    dgvResultat.Columns.Add("Elevnavn", "Elevnavn");

                    //Gjør klart for registering og setter riktig synlighet
                    lastRegistrering();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man krysser av eller på fag
        private void chkResFag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis fag er krysset av
                if (chkResFag.Checked == true)
                {
                    chkResTest.Checked = false;
                    chkResDeltest.Checked = false;
                    cmbResFag.Enabled = true;

                    //Laster inn fag til comboboks
                    cmbResFag.DataSource = database.LastFag().Tables[0];
                    cmbResFag.DisplayMember = "Fagnavn";
                }

                //Hvis fag ikke er krysset av
                else
                {
                    //Setter datasource på fag comboboks til null
                    cmbResFag.DataSource = null;
                    cmbResFag.Enabled = false;

                    //Hvis elev er krysset av
                    if (chkResElev.Checked == true)
                    {
                        //Hvis klasse er krysset av
                        if (chkResKlasse.Checked == true)
                        {
                            //Viser resultat
                            visResultat("AlleElevKlasse");
                        }

                        //Hvis klasse ikke er krysset av
                        else
                        {
                            //Viser resultat
                            visResultat("AlleElev");
                        }
                    }

                    //Hvis elev ikke er krysset av
                    else
                    {
                        //Viser resultat
                        visResultat("AlleKlasse");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man krysser av eller på test
        private void chkResTest_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis test er krysset av
                if (chkResTest.Checked == true)
                {
                    chkResDeltest.Enabled = true;
                    chkResFag.Checked = false;
                    chkResDeltest.Checked = false;

                    //Laster inn tester til comboboks
                    cmbResTest.DataSource = database.LastTesterKlasse(cmbResÅr.Text, cmbResBet.Text).Tables[0];
                    cmbResTest.Enabled = true;
                    cmbResTest.ValueMember = "TestID";
                    cmbResTest.DisplayMember = "Testnavn";

                }

                //Hvis test ikke er krysset av
                else
                {
                    chkResDeltest.Checked = false;
                    chkResDeltest.Enabled = false;
                    cmbResTest.DataSource = null;
                    cmbResTest.Enabled = false;

                    //Hvis elev er krysset av
                    if (chkResElev.Checked == true)
                    {
                        //Hvis klasse er krysset av
                        if (chkResKlasse.Checked == true)
                        {
                            //Viser resultat
                            visResultat("AlleElevKlasse");
                        }

                        //Hvis klasse ikke er krysset av
                        else
                        {
                            //Viser resultat
                            visResultat("AlleElev");
                        }
                    }

                    //Hvis elev ikke er krysset av
                    else
                    {
                        //Viser resultat
                        visResultat("AlleKlasse");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man krysser av eller på deltest
        private void chkResDeltest_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis deltest er krysset av
                if (chkResDeltest.Checked == true)
                {
                    chkResFag.Checked = false;
                    cmbResSem.Enabled = true;
                    cmbResSem.Items.Clear();
                    cmbResSem.Items.Add("Høst");
                    cmbResSem.Items.Add("Vår");
                    cmbResSem.SelectedIndex = 0;
                    cmbResDeltest.Enabled = true;
                }

                //Hvis deltest ikke er krysset av
                else
                {
                    cmbResDeltest.DataSource = null;
                    cmbResSem.Enabled = false;
                    cmbResSem.Items.Clear();
                    cmbResDeltest.Enabled = false;

                    //Hvis elev er krysset av
                    if (chkResElev.Checked == true)
                    {

                        //Hvis klasse er krysset av
                        if (chkResKlasse.Checked == true)
                        {
                            //Viser resultatet
                            visResultat("AlleElevKlasse");
                        }

                        //Hvis klasse ikke er krysset av
                        else
                        {
                            //Viser resultatet
                            visResultat("AlleElev");
                        }
                    }

                    //Hvis elev ikke er krysset av
                    else
                    {
                        //Viser resultatet
                        visResultat("AlleKlasse");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger visning
        private void rbResVisning_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis visning er valgt
                if (rbResVisning.Checked == true)
                {
                    //Tømmer datagridden
                    dgvResultat.Columns.Clear();
                    dgvResultat.Columns.Add("Elevnavn", "Elevnavn");

                    //Gjør klart for visning og setter riktig synlighet
                    lastVisning();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Eksportering av resultat til PDF
        private void butEksporter_Click(object sender, EventArgs e)
        {
            try
            {
                //Lager temp mappe for midleritige pdf filer
                Directory.CreateDirectory(mappe);

                //Setter datoformat og lager filbane
                string format = "yyyy-MM-dd-HH-mm-ss";
                string path = mappe + (valgtVisning + " " + DateTime.Now.ToString(format) + ".pdf");

                Document doc = null;
                float[] widths = null;

                //Om man vil ha liggende eller stående papirretning
                DialogResult dialogResult = MessageBox.Show(this, "JA - Liggende / NEI - Stående", "Papirretning", MessageBoxButtons.YesNoCancel); ;

                //Hvis man ikke avbryter
                if (dialogResult != DialogResult.Cancel)
                {
                    //Hvis man trykker yes - liggende papirretning
                    if (dialogResult == DialogResult.Yes)
                    {
                        //Oppretter nytt liggende dokument og setter bredde på kolonner
                        doc = new Document(PageSize.A4.Rotate(), 10, 10, 30, 30);
                        widths = new float[] { 150, 150, 130, 110, 80, 90, 110, 250 };
                    }

                    //Hvis man trykker no - stående papirretning
                    else if (dialogResult == DialogResult.No)
                    {
                        //Oppretter nytt stående document og setter bredde på kolonner
                        doc = new Document(PageSize.A4, 10, 10, 30, 30);
                        widths = new float[] { 150, 150, 100, 135, 100, 120, 90, 250 };
                    }

                    //Oppretter en pdfwriter som oppretter filen og skriver til den
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

                    //Åpner dokumentet klart for skriving
                    doc.Open();

                    //Oppretter paragraf for data og valgt visning
                    Paragraph dato = new Paragraph(DateTime.Now.ToString());
                    Paragraph visning = new Paragraph(lblResVisning.Text);
                    dato.Alignment = Element.ALIGN_RIGHT;
                    visning.Alignment = Element.TITLE;

                    //Oppretter pdf tabellen med 8 kolonner
                    PdfPTable tabell = new PdfPTable(8);

                    //Setter bredden på tabellen
                    tabell.SetWidths(widths);

                    //Oppretter tabell headerne
                    PdfPCell cname = new PdfPCell(new Phrase("Navn"));
                    PdfPCell ctest = new PdfPCell(new Phrase("Test"));
                    PdfPCell cdeltest = new PdfPCell(new Phrase("Deltest"));
                    PdfPCell csemester = new PdfPCell(new Phrase("Semester"));
                    PdfPCell cpoeng = new PdfPCell(new Phrase("Poeng"));
                    PdfPCell cprosent = new PdfPCell(new Phrase("Prosent"));
                    PdfPCell cmakspoeng = new PdfPCell(new Phrase("Makspoeng"));
                    PdfPCell ckommentar = new PdfPCell(new Phrase("Kommentar"));

                    //Setter farge på tabell headerne
                    cname.BackgroundColor = BaseColor.LIGHT_GRAY;
                    ctest.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cdeltest.BackgroundColor = BaseColor.LIGHT_GRAY;
                    csemester.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cpoeng.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cprosent.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cmakspoeng.BackgroundColor = BaseColor.LIGHT_GRAY;
                    ckommentar.BackgroundColor = BaseColor.LIGHT_GRAY;

                    //Legger headerne inn i tabellen
                    tabell.AddCell(cname);
                    tabell.AddCell(ctest);
                    tabell.AddCell(cdeltest);
                    tabell.AddCell(csemester);
                    tabell.AddCell(cpoeng);
                    tabell.AddCell(cprosent);
                    tabell.AddCell(cmakspoeng);
                    tabell.AddCell(ckommentar);

                    //For hvert resultat i datagridden
                    foreach (DataGridViewRow rows in dgvResultat.Rows)
                    {
                        //Fyller variabler med informasjon om resultatene
                        string navn = dgvResultat.Rows[rows.Index].Cells["Elevnavn"].Value.ToString();
                        string test = dgvResultat.Rows[rows.Index].Cells["Testnavn"].Value.ToString();
                        string deltest = dgvResultat.Rows[rows.Index].Cells["Deltestnavn"].Value.ToString();
                        string semester = dgvResultat.Rows[rows.Index].Cells["Semester"].Value.ToString();
                        string poeng = dgvResultat.Rows[rows.Index].Cells["Poeng"].Value.ToString();
                        string prosent = dgvResultat.Rows[rows.Index].Cells["Prosent"].Value.ToString();
                        string makspoeng = dgvResultat.Rows[rows.Index].Cells["Makspoeng"].Value.ToString();
                        string kommentar = dgvResultat.Rows[rows.Index].Cells["Kommentar"].Value.ToString();

                        //Oppretter cellene for hver kolonne
                        PdfPCell c1 = new PdfPCell(new Phrase(navn));
                        PdfPCell c2 = new PdfPCell(new Phrase(test));
                        PdfPCell c3 = new PdfPCell(new Phrase(deltest));
                        PdfPCell c4 = new PdfPCell(new Phrase(semester));
                        PdfPCell c5 = new PdfPCell(new Phrase(poeng));
                        PdfPCell c6 = new PdfPCell(new Phrase(prosent));
                        PdfPCell c7 = new PdfPCell(new Phrase(makspoeng));
                        PdfPCell c8 = new PdfPCell(new Phrase(kommentar));

                        //Legger cellene inn i tabellen
                        tabell.AddCell(c1);
                        tabell.AddCell(c2);
                        tabell.AddCell(c3);
                        tabell.AddCell(c4);
                        tabell.AddCell(c5);
                        tabell.AddCell(c6);
                        tabell.AddCell(c7);
                        tabell.AddCell(c8);
                    }

                    //Legger dato, visning og tabellen til dokumentet
                    doc.Add(dato);
                    doc.Add(visning);
                    doc.Add(new Paragraph(" "));
                    doc.Add(tabell);

                    //Lukker dokumentet etter skriving
                    doc.Close();

                    //Starter program for å åpne PDF filen
                    Process prosess = new Process();
                    prosess.StartInfo.FileName = path;
                    prosess.EnableRaisingEvents = true;
                    prosess.Start();
                }

                //Hvis man avbryter spørsmålet om papirretning
                else
                {
                    //Viser melding til brukeren
                    MessageBox.Show("Avbrutt!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Test
        //Velger tester i menyen
        private void butTester_Click(object sender, EventArgs e)
        {
            try
            {
                menyValg(menyTester);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Laster inn tester fra databasen og tilbakestiller visning
        private void lastTester()
        {
            try
            {
                //Laster inn fag i comboboks
                cmbTesterFag.DataSource = null;
                cmbTesterFag.DataSource = database.LastFag().Tables[0];
                cmbTesterFag.DisplayMember = "fagnavn";

                //Henter tester fra database
                dgvTester.DataSource = database.LastTester(cmbTesterFag.Text.Trim()).Tables[0];
                dgvTester.CurrentCell = null;

                //Fjerner unødvendig kolonne og setter autosizemode
                dgvTester.Columns["TestID"].Visible = false;
                dgvTester.Columns["Fagnavn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                txtTesterNavn.Clear();
                txtTesterFil.Clear();

                //Tilbakestiller datagrid for fil
                dgvFiler.DataSource = null;
                dgvFiler.CurrentCell = null;

                ////Laster inn fag i comboboks
                //cmbTesterFag.DataSource = null;
                //cmbTesterFag.DataSource = database.LastFag().Tables[0];
                //cmbTesterFag.DisplayMember = "fagnavn";

                if (fagIndex == -1)
                {
                    cmbTesterFag.SelectedIndex=cmbTesterFag.Items.Count-1;
                }
                else if (fagIndex == cmbTesterFag.Items.Count)
                {
                    cmbTesterFag.SelectedIndex = fagIndex-1;
                }
                else
                {
                    cmbTesterFag.SelectedIndex = fagIndex;
                }
                
                butTesterSlett.Enabled = false;
                txtTesterNavn.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Laster inn filer
        private void lastFil(string testID)
        {
            try
            {
                //Legger til egendefinerte knapper, gjemmer unødvendige kolonner og henter filer fra databasen
                dgvFiler.Columns.Clear();
                DataGridViewButtonColumn butLastNed = new DataGridViewButtonColumn();
                DataGridViewButtonColumn butSlettFil = new DataGridViewButtonColumn();

                butLastNed.Text = "Last ned fil";
                butLastNed.HeaderText = "Fil";
                butLastNed.Name = "Fil";
                butSlettFil.Text = "Slett fil";
                butSlettFil.HeaderText = "Slett fil";
                butSlettFil.Name = "SlettFil";
                butLastNed.UseColumnTextForButtonValue = true;
                butSlettFil.UseColumnTextForButtonValue = true;

                dgvFiler.Columns.Add(butLastNed);
                dgvFiler.Columns.Add(butSlettFil);

                dgvFiler.DataSource = database.LastFiler(testID).Tables[0].DefaultView;
                dgvFiler.Columns["TestID"].Visible = false;
                dgvFiler.Columns["Filtype"].Visible = false;
                dgvFiler.Columns["FilID"].Visible = false;
                dgvFiler.Columns["Fil"].DisplayIndex = 3;
                dgvFiler.Columns["SlettFil"].DisplayIndex = 4;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Skjekker input og setter synlighet på knapper
        private void txtTester_TextChanged(object sender, EventArgs e)
        {
            //Hvis navn og fag ikke er tomme
            if (txtTesterNavn.Text.Trim() != "" & cmbTesterFag.Text.Trim() != "")
            {
                //Hvis  celle er valgt i datagridden
                if (dgvTester.CurrentCell != null)
                {
                    butTesterEndre.Enabled = true;
                    butTesterSlett.Enabled = true;
                }
                //Hvis ingen celle er valgt i datagridden
                else
                {
                    butTesterReg.Enabled = true;
                }
            }
            //Hvis tekstboksene er tomme
            else
            {
                butTesterReg.Enabled = false;
                butTesterEndre.Enabled = false;
            }
        }

        //Skjekker input og setter synlighet på knapper
        private void cmbTesterFag_TextChanged(object sender, EventArgs e)
        {
            //Laster inn tester til valgt fag
            dgvTester.DataSource = database.LastTester(cmbTesterFag.Text.Trim()).Tables[0];
            dgvTester.CurrentCell = null;

            //Hvis navn og fag ikke er tomme
            if (txtTesterNavn.Text.Trim() != "" & cmbTesterFag.Text.Trim() != "")
            {
                //Hvis  celle er valgt i datagridden
                if (dgvTester.CurrentCell != null)
                {
                    butTesterEndre.Enabled = true;
                    butTesterSlett.Enabled = true;
                }
                //Hvis ingen celle er valgt i datagridden
                else
                {
                    butTesterReg.Enabled = true;
                }
            }
            //Hvis tekstboksene er tomme
            else
            {
                butTesterReg.Enabled = false;
                butTesterEndre.Enabled = false;
            }
        }

        //Henter fil fra maskinen
        private void txtTesterFil_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //Åpne fil dialog for å velge fil man vil laste opp
                OpenFileDialog henteFil = new OpenFileDialog();

                //Hvis man trykker ok
                if (henteFil.ShowDialog() == DialogResult.OK)
                {
                    txtTesterFil.Text = Path.GetFileName(henteFil.FileName);
                    txtTesterFil.Tag = henteFil.FileName;
                    filnavn = Path.GetFileName(henteFil.FileName);
                    filtype = Path.GetExtension(filnavn);
                }
                //Hvis man avbryter
                else
                {
                    MessageBox.Show("Ingen fil valgt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Når man klikker på test i datagridden
        private void dgvTester_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Hvis man trykker på test i datagridden så fylles variabler med informasjon om testen
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvTester.Rows[e.RowIndex];
                    txtTesterNavn.Text = row.Cells["Testnavn"].Value.ToString();
                    testID = row.Cells["TestID"].Value.ToString();
                    lastFil(testID);
                    dgvFiler.CurrentCell = null;
                    butTesterReg.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man klikker på fil i datagridden
        private void dgvFil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string filID;
                //Hvis man trykker for å laste ned filen
                if (e.ColumnIndex == dgvFiler.Columns["Fil"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvFiler.Rows[e.RowIndex];
                    filID = row.Cells["filID"].Value.ToString();
                    filtype = row.Cells["filtype"].Value.ToString();
                    filnavn = row.Cells["filnavn"].Value.ToString();
                    database.LastNedFil(filID, filnavn, filtype);
                }
                //Hvis man trkker for å slette filen
                else if (e.ColumnIndex == dgvFiler.Columns["SlettFil"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvFiler.Rows[e.RowIndex];
                    filID = row.Cells["filID"].Value.ToString();
                    database.SlettFil(filID);
                    lastFil(testID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sjekker om test finnes
        private bool finnesTest(string valg)
        {
            //Deltesten finnes ikke fra før
            bool finnes = false;
            //Sjekker hver rad i datagridden om testen finnes fra før
            foreach (DataGridViewRow row in dgvTester.Rows)
            {
                if (valg == "reg")
                {
                    //Hvis testen finnes fra før
                    if (txtTesterNavn.Text.Trim().Equals(row.Cells["Testnavn"].Value.ToString()) && cmbTesterFag.Text.Trim().Equals(row.Cells["Fagnavn"].Value.ToString()))
                    {
                        finnes = true;
                    }
                }
                else if (valg == "endre")
                {
                    //Hvis testen finnes fra før
                    if (txtTesterNavn.Text.Trim().Equals(row.Cells["Testnavn"].Value.ToString()) && cmbTesterFag.Text.Trim().Equals(row.Cells["Fagnavn"].Value.ToString()) && testID != row.Cells["Testid"].Value.ToString())
                    {
                        finnes = true;
                    }
                }
            }
            //Returnerer om testen finnes eller ikke
            return finnes;
        }

        //Registrering av test
        private void butTesterReg_Click(object sender, EventArgs e)
        {
            try
            {
                //Setter fagindex til index i comboboks for å lagre plassering
                fagIndex = cmbTesterFag.SelectedIndex;

                //Hvis testen ikke finnes fra før
                if (finnesTest("reg") == false)
                {
                    //Registrerer testen i databasen
                    database.InsertTester(txtTesterNavn.Text.Trim(), cmbTesterFag.Text.Trim());
                    DataTable dt = database.LastTestID(txtTesterNavn.Text.Trim()).Tables[0];
                    testID = dt.Rows[0]["testID"].ToString();

                    //Hvis man laster opp fil samtidig som man registrerer testen
                    if (txtTesterFil.Text != "")
                    {
                        System.IO.FileStream fs = new FileStream(txtTesterFil.Tag.ToString(), FileMode.Open);
                        System.IO.BufferedStream bf = new BufferedStream(fs);
                        byte[] buffer = new byte[bf.Length];
                        bf.Read(buffer, 0, buffer.Length);
                        byte[] buffer_new = buffer;

                        //Registrerer filen i databasen
                        database.InsertFil(filnavn, buffer_new, filtype, testID);
                    }
                }

                //Hvis testen finnes fra før
                else
                {
                    MessageBox.Show("Testen finnes fra før!");
                    txtTesterNavn.Focus();
                    txtTesterNavn.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Oppdaterer tester og tilbakestiller visningen
            lastTester();
        }

        //Endring av test
        private void butTesterEndre_Click(object sender, EventArgs e)
        {
            try
            {
                //Setter fagindex til index i comboboks for å lagre plassering
                fagIndex = cmbTesterFag.SelectedIndex;

                //Hvis testen ikke finnes fra før
                if (finnesTest("endre") == false)
                {
                    //Endrer testen i databasen
                    database.UpdateTester(testID, txtTesterNavn.Text.Trim(), cmbTesterFag.Text.Trim());
                    
                    //Hvis man laster opp fil til testen 
                    if (txtTesterFil.Text != "")
                    {
                        System.IO.FileStream fs = new FileStream(txtTesterFil.Tag.ToString(), FileMode.Open);
                        System.IO.BufferedStream bf = new BufferedStream(fs);
                        byte[] buffer = new byte[bf.Length];
                        bf.Read(buffer, 0, buffer.Length);
                        byte[] buffer_new = buffer;

                        //Registrerer filen i databasen
                        database.InsertFil(filnavn, buffer_new, filtype, testID);
                    }
                }

                //Hvis testen finnes fra før
                else
                {
                    MessageBox.Show("Kan ikke endre test da den finnes fra før!");
                    txtTesterNavn.Focus();
                    txtTesterNavn.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Oppdaterer tester og tilbakestiller visningen
            lastTester();
        }
        
        //Sletting av test
        private void butTesterSlett_Click(object sender, EventArgs e)
        {
            try
            {
                //bool verdi for om deltester finnes til testen
                bool deltestFinnes = false;

                //Laster inn deltester til valgt test
                DataTable dt = database.LastDeltest(testID).Tables[0];

                //Hvis deltester finnes så settes deltestFinnes til true
                if (dt.Rows.Count > 0)
                {
                    deltestFinnes = true;
                }

                //Hvis deltest ikke finnes
                if (!deltestFinnes)
                {
                    //Sletter testen og filen til testen i databasen og 
                    database.SlettFiler(testID);
                    database.SlettTester(testID);
                }

                //Hvis deltest finnes
                else
                {
                    MessageBox.Show("Kan ikke slette testen da det finnes deltester på denne testen!");
                }

                //oppdaterer visningen
                fagIndex = cmbTesterFag.SelectedIndex;
                lastTester();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Oppdaterer tester og tilbakestiller visningen
        private void butTesterTøm_Click(object sender, EventArgs e)
        {
            try
            {
                lastTester();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Deltest
        //Velger deltester i menyen
        private void butDeltest_Click(object sender, EventArgs e)
        {
            try
            {
                menyValg(menyDeltester);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Laster inn deltester og tilbakestiller visningen
        private void lastDeltest()
        {
            try
            {
                //Hvis det ikke finnes noen fag
                if (cmbDeltestFag.Items.Count <= 0)
                {
                    panelDeltest.Enabled = false;
                }
                //Hvis det finnes fag
                else
                {
                    //Henter deltester til valgt test og tilbakestiller visningen
                    panelDeltest.Enabled = true;
                    txtDeltestNavn.Clear();
                    numDeltestKritisk.Value = 0;
                    numDeltestMaks.Value = 0;
                    butDeltestSlett.Enabled = false;
                    txtDeltestNavn.Focus();

                    //Laster inn deltester til valgt test
                    dgvDeltest.DataSource = database.LastDeltest(cmbDeltestTest.SelectedValue.ToString()).Tables[0].DefaultView;
                    dgvDeltest.CurrentCell = null;
                    dgvDeltest.Columns["Deltestid"].Visible = false;

                    //Setter autosizemode
                    dgvDeltest.Columns["Makspoeng"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvDeltest.Columns["Kritiskgrense"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvDeltest.Columns["Semester"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Skjekker input og setter synlighet på knapper
        private void txtDeltestNavn_TextChanged(object sender, EventArgs e)
        {
            //Hvis navn, test og semester ikke er tom, og maks poeng er større enn kritisk grense
            if (txtDeltestNavn.Text.Trim() != "" & cmbDeltestTest.Text != "" & numDeltestMaks.Value > numDeltestKritisk.Value & cmbDeltestSem.Text != "")
            {
                //Hvis ingen celle er valgt i datagridden
                if (dgvDeltest.CurrentCell != null)
                {
                    butDeltestEndre.Enabled = true;
                    butDeltestSlett.Enabled = true;
                }
                //Hvis celle er valgt i datagridden
                else
                {
                    butDeltestReg.Enabled = true;
                }
            }
            //Hvis tekstboksene er tomme
            else
            {
                butDeltestReg.Enabled = false;
                butDeltestEndre.Enabled = false;
            }
        }
        
        //Når man velger test
        private void cmbDeltestTest_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Når man velges test så lastes deltester til valgt test inn i datagriden
                dgvDeltest.DataSource = database.LastDeltest(cmbDeltestTest.SelectedValue.ToString()).Tables[0].DefaultView;
                dgvDeltest.CurrentCell = null;
                dgvDeltest.Columns["Deltestid"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger fag
        private void cmbDeltestFag_TextChanged(object sender, EventArgs e)
        {
            //Laster inn tester til valgt fag
            cmbDeltestTest.DataSource = database.LastTester(cmbDeltestFag.Text).Tables[0];
            cmbDeltestTest.DisplayMember = "testnavn";
            cmbDeltestTest.ValueMember = "Testid";
        }

        //Når man klikker på deltesti datagridden
        private void dgvDeltest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Hvis man klikker på deltest så fylles variabler med data om valgt deltest
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvDeltest.Rows[e.RowIndex];
                    txtDeltestNavn.Text = row.Cells["DeltestNavn"].Value.ToString();
                    numDeltestMaks.Value = int.Parse(row.Cells["MaksPoeng"].Value.ToString());
                    numDeltestKritisk.Value = int.Parse(row.Cells["Kritiskgrense"].Value.ToString());
                    cmbDeltestSem.Text = row.Cells["Semester"].Value.ToString();
                    gmlDeltestID = row.Cells["DeltestID"].Value.ToString();
                    butDeltestReg.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Registrering av deltester
        private void butDeltestReg_Click(object sender, EventArgs e)
        {
            try
            {
                //Hvis deltest ikke finnes fra før
                if (finnesDeltest() == false)
                {
                    //Registrerer deltest i databasen og oppdaterer visningen
                    database.InsertDeltest(txtDeltestNavn.Text.Trim(), numDeltestMaks.Value.ToString(), numDeltestKritisk.Value.ToString(), cmbDeltestSem.Text, cmbDeltestTest.SelectedValue.ToString());
                    lastDeltest();
                }

                //Hvis deltesten finnes fra før
                else
                {
                    MessageBox.Show("Deltesten finnes fra før!");
                    txtDeltestNavn.Focus();
                    txtDeltestNavn.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sjekker om deltest finnes
        private bool finnesDeltest()
        {
            //Deltesten finnes ikke fra før
            bool finnes = false;

            //Sjekker hver rad i datagridden om deltesten finnes fra før
            foreach (DataGridViewRow row in dgvDeltest.Rows)
            {
                //Hvis deltesten finnes fra før med likt navn og semester og det er ikke den man endrer
                if (txtDeltestNavn.Text.Trim().Equals(row.Cells["Deltestnavn"].Value.ToString()) && cmbDeltestSem.Text.Equals(row.Cells["Semester"].Value.ToString()) && gmlDeltestID != row.Cells["Deltestid"].Value.ToString())
                {
                    finnes = true;
                }
            }

            //Returnerer om deltest finnes eller ikke
            return finnes;
        }

        //Endring av deltester
        private void butDeltestEndre_Click(object sender, EventArgs e)
        {
            try
            {
                //Hvis deltesten ikke finnes fra før
                if (finnesDeltest() == false)
                {
                    //Endrer deltest i databasen og oppdaterer visningen
                    database.UpdateDelTest(gmlDeltestID, txtDeltestNavn.Text.Trim(), numDeltestMaks.Value.ToString(), numDeltestKritisk.Value.ToString(), cmbDeltestSem.Text, cmbDeltestTest.SelectedValue.ToString());
                    lastDeltest();
                }

                //Hvis deltesten finnes fra før
                else
                {
                    MessageBox.Show("Kan ikke endre deltest, da den finnes fra før");
                    txtDeltestNavn.Focus();
                    txtDeltestNavn.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sletting av deltester
        private void butDeltestSlett_Click(object sender, EventArgs e)
        {
            try
            {
                //Sletter deltest i databasen og oppdaterer visningen
                database.SlettDelTest(gmlDeltestID);
                lastDeltest();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Oppdaterer deltester og tilbakestiller visningen
        private void butDeltestTøm_Click(object sender, EventArgs e)
        {
            try
            {
                lastDeltest();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Klasser
        //Velger klasser i menyen
        private void butKlasser_Click(object sender, EventArgs e)
        {
            try
            {
                menyValg(menyKlasser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        //Laster inn klasser og tilbakestiller visningen
        private void lastKlasser()
        {
            try
            {
                //Fyller datagridden med klasser
                dgvKlasser.DataSource = database.LastKlasser().Tables[0].DefaultView;
                dgvKlasser.CurrentCell = null;
                dgvKlasserTest.DataSource = null;
                txtKlasserBet.Clear();
                txtKlasserÅr.Clear();
                txtKlasserBet.Focus();
                butKlasserSlett.Enabled = false;
                butKlasserRegTest.Enabled = false;

                int skoleår = 0;

                //Hvis det finnes klasser
                if (dgvKlasser.Rows.Count > 0)
                {
                    //Finner høyeste skoleår
                    foreach (DataGridViewRow row in dgvKlasser.Rows)
                    {
                        if (int.Parse(row.Cells["Skoleår"].Value.ToString()) > skoleår)
                        {
                            skoleår = int.Parse(row.Cells["Skoleår"].Value.ToString());
                        }
                    }

                    //Setter klasseår til høyeste funnet i datagridden
                    txtKlasserÅr.Text = skoleår.ToString();
                }

                //Hvis det ikke finnes klasser
                else
                {
                    //Setter klasseår til i år og neste år
                    int år = int.Parse(DateTime.Now.Year.ToString().Substring(2));
                    int år2 = int.Parse(DateTime.Now.Year.ToString().Substring(2)) + 1;
                    txtKlasserÅr.Text = år + år2.ToString();
                }

                //Setter fokus på tekstboksen
                txtKlasserBet.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sjekker input og setter riktig synlighet på knapper
        private void txtKlasser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Hvis betegnelse og skoleår ikke er tomme, og betegnelse inneholder minst ett tall
                if (txtKlasserBet.Text.Trim() != "" & txtKlasserÅr.Text.Trim() != "" && Regex.IsMatch(txtKlasserBet.Text.Trim(), "[0-9]"))
                {
                    //Hvis ingen celle er valgt i datagridden
                    if (dgvKlasser.CurrentCell != null)
                    {
                        butKlasserEndre.Enabled = true;
                        butKlasserSlett.Enabled = true;
                    }

                    //Hvis celle er valgt i datagridden
                    else
                    {
                        butKlasserReg.Enabled = true;
                    }
                }

                //Hvis tekstboksene er tomme
                else
                {
                    butKlasserReg.Enabled = false;
                    butKlasserEndre.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sjekker at man kun skriver inn tall i skoleår
        private void txtKlasserSkoleår_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Hvis man ikke skriver inn tall så blir char fjernet
                if (!char.IsNumber(e.KeyChar))
                {
                    e.Handled = e.KeyChar != (char)Keys.Back;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man klikker på en klasse i datagridden
        private void dgvKlasser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Hvis man klikker på en klasse så fylles variabler med verdi om klassen
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvKlasser.Rows[e.RowIndex];
                    gmlBetegnelse = row.Cells["Betegnelse"].Value.ToString();
                    txtKlasserBet.Text = row.Cells["Betegnelse"].Value.ToString();
                    gmlSkoleår = row.Cells["Skoleår"].Value.ToString();
                    txtKlasserÅr.Text = row.Cells["Skoleår"].Value.ToString();
                    lastKlasseTest(row.Cells["Betegnelse"].Value.ToString(), row.Cells["Skoleår"].Value.ToString());
                    dgvKlasserTest.CurrentCell = null;
                    butKlasserReg.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man klikker på test til klassen
        private void dgvKlasseTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Hvis man trykker på slett test til klassen
                if (e.ColumnIndex == dgvKlasserTest.Columns["SlettTest"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvKlasserTest.Rows[e.RowIndex];
                    testID = row.Cells["TestID"].Value.ToString();

                    //Laster inn resultat på valgt test til klasse
                    DataTable dt = database.LastTestResultatKlasse(testID, gmlSkoleår, gmlBetegnelse).Tables[0];

                    //Hvis det finnes resultat på valgt test til klasse
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Kan ikke slette testen da det finnes resultater på den!");
                    }

                    //Hvis det ikke finnes resultat på vlagt test til klasse så slettes den
                    else
                    {
                        database.SlettMottakerTest(gmlBetegnelse, gmlSkoleår, testID);
                    }

                    //Oppdaterer visningen
                    lastKlasseTest(gmlBetegnelse, gmlSkoleår);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Oppdatererer klasse tester og tilbakestiller visningen
        private void lastKlasseTest(string betegnelse, string skoleår)
        {
            try
            {
                //Legger til egendefinert knapp for sletting av fil
                dgvKlasserTest.Columns.Clear();
                DataGridViewButtonColumn butSlettFil = new DataGridViewButtonColumn();
                butSlettFil.Text = "Slett test fra klasse!";
                butSlettFil.HeaderText = "SlettTest";
                butSlettFil.Name = "SlettTest";
                butSlettFil.UseColumnTextForButtonValue = true;
                dgvKlasserTest.Columns.Add(butSlettFil);
                

                //Henter tester til valgt klasse
                dgvKlasserTest.DataSource = database.LastKlasseTest(betegnelse, skoleår).Tables[0].DefaultView;
                dgvKlasserTest.Columns["TestID"].Visible = false;
                dgvKlasserTest.Columns["SlettTest"].DisplayIndex = 3;

                //Hvis det ikke finnes noen tester til klassen
                if (cmbKlasserTest.Items.Count <= 0)
                {
                    butKlasserRegTest.Enabled = false;
                }
                //Hvis det finnes tester til klassen
                else
                {
                    lblKlasseTester.Enabled = true;
                    cmbKlasserTest.Enabled = true;
                    butKlasserRegTest.Enabled = true;
                }
                
                //Fjerner blå markering i klasse test datagridden
                dgvKlasserTest.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Registrering av klasser
        private void butKlasseReg_Click(object sender, EventArgs e)
        {
            try
            {
                //Registrerer klassen i databasen og oppdaterer visningen
                database.InsertKlasser(txtKlasserBet.Text.Trim(), int.Parse(txtKlasserÅr.Text.Trim()));
                lastKlasser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Registrering av klasse tester
        private void butKlasseRegTest_Click(object sender, EventArgs e)
        {
            try
            {
                //Registrerer klasse testen i databasen og oppdaterer visningen
                database.InsertKlasseTest(gmlBetegnelse, gmlSkoleår, cmbKlasserTest.SelectedValue.ToString());
                lastKlasseTest(gmlBetegnelse,gmlSkoleår);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Endring av klasser
        private void butKlasseEndre_Click(object sender, EventArgs e)
        {
            try
            {
                //Endrer klassen i databasen og oppdaterer visningen
                database.UpdateKlasser(gmlBetegnelse, txtKlasserBet.Text.Trim(), int.Parse(txtKlasserÅr.Text.Trim()));
                lastKlasser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sletting av klasser
        private void butKlasseSlett_Click(object sender, EventArgs e)
        {
            try
            {
                //bool verdier for om resultat eller elever finnes på klassen
                bool resFinnes = false;
                bool elevFinnes = false;

                //Laster inn elever til klassen
                DataTable dt = database.LastElever(gmlSkoleår, gmlBetegnelse).Tables[0];

                //Hvis elever finnes på klassen settes elevFinnes til true
                if (dt.Rows.Count > 0)
                {
                    elevFinnes = true;
                }

                //Laster inn testene til klassen
                DataTable dt1 = database.LastTesterKlasse(gmlSkoleår, gmlBetegnelse).Tables[0];

                //For hver test til klassen
                foreach (DataRow row in dt1.Rows)
                {
                    //Laster inn resultat til testen til klassen
                    DataTable dt2 = database.LastTestResultatKlasse(row["TestID"].ToString(), gmlSkoleår, gmlBetegnelse).Tables[0];
                    
                    //Hvis det finnes resultat til testen til klassen så settes resFinnes til true
                    if (dt2.Rows.Count > 0)
                    {
                        resFinnes = true;
                    }
                    
                }

                //Hvis det ikke finnes elever til klassen
                if (!elevFinnes)
                {
                    //Hvis det ikke finnes resultater til testen til klassen
                    if (!resFinnes)
                    {
                        //Sletter klassen og testene til klassen i databasen og oppdaterer visningen
                        database.SlettKlasseTester(gmlBetegnelse, gmlSkoleår);
                        database.SlettKlasser(gmlBetegnelse, int.Parse(gmlSkoleår));
                    }
                }

                //Hvis det finnes elever til klassen
                else
                {
                    MessageBox.Show("Kan ikke slette klassen da det finnes elever i denne klassen!");
                }

                //Oppdaterer visningen
                lastKlasser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Oppdaterer klasser og tilbakestiller visningen
        private void butKlasseTøm_Click(object sender, EventArgs e)
        {
            lastKlasser();
        }

        //Når man velger fag
        private void cmbKlasseFag_TextChanged(object sender, EventArgs e)
        {
            //Hvis det finnes fag
            if (cmbKlasserFag.Items.Count > 0)
            {
                //Laster inn tester til fag som man kan registrere på klasser
                cmbKlasserTest.DataSource = database.LastTester(cmbKlasserFag.Text).Tables[0];
                cmbKlasserTest.DisplayMember = "testnavn";
                cmbKlasserTest.ValueMember = "testid";
            }
        }
        #endregion
        #region Elever
        //Velger elever i menyen
        private void butElever_Click(object sender, EventArgs e)
        {
            try
            {
                menyValg(menyElever);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Laster inn elever og tilbakestiller visningen
        private void lastElever()
        {
            try
            {
                //Laster inn elever til valgt klasse
                dgvElever.DataSource = database.LastElever(cmbEleverSkoleår.Text, cmbEleverKlasse.Text).Tables[0].DefaultView;

                cmbEleverKjønn.Enabled = true;
                cmbEleverKjønn.Items.Clear();
                cmbEleverKjønn.Items.Add("Gutt");
                cmbEleverKjønn.Items.Add("Jente");
                cmbEleverKjønn.SelectedIndex = 0;
                txtEleverFNummer.Clear();
                txtEleverFornavn.Clear();
                txtEleverEtternavn.Clear();

                dgvElever.CurrentCell = null;
                dgvEleverKlasse.DataSource = null;

                lblEleverStatus.Visible = false;
                chkEleverStatus.Visible = false;
                txtEleverFNummer.Enabled = true;
                butEleverSlett.Enabled = false;
                txtEleverFNummer.Focus();

                //Setter autosizemode i datagridden
                dgvElever.Columns["Kjønn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvElever.Columns["Aktiv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvElever.Columns["Skoleår"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvElever.Columns["Betegnelse"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //Hvis det ikke finnes noen klasser
                if (cmbEleverSkoleår.Items.Count <= 0)
                {
                    panelElever.Enabled = false;
                }
                else
                {
                    panelElever.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger klasse
        private void cmbEleverKlasse_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Laster inn elever til valgt klasse
                dgvElever.DataSource = database.LastElever(cmbEleverSkoleår.Text, cmbEleverKlasse.Text).Tables[0].DefaultView;
                dgvElever.Columns["FNummer"].Visible = false;
                dgvElever.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sjekker input og setter synlighet på knapper
        private void txtElever_TextChanged(object sender, EventArgs e)
        {
            //Hvis navn ikke er tomt og fødselsnummer er 11 siffer
            if (txtEleverFNummer.Text.Trim().Length == 11 & txtEleverFornavn.Text.Trim() != "" & txtEleverEtternavn.Text.Trim() != "")
            {
                //Hvis ingen celle er valgt i datagridden
                if (dgvElever.CurrentCell != null || txtEleverFNummer.Enabled==false)
                {
                    butEleverEndre.Enabled = true;
                    butEleverSlett.Enabled = true;
                }
                //Hvis celle er valgt i datagridden
                else
                {
                    butEleverReg.Enabled = true;
                }
            }
            //Hvis tekstboksene er tomme
            else
            {
                butEleverReg.Enabled = false;
                butEleverEndre.Enabled = false;
            }
        }

        //Hvis man klikker på en elev i datagridden
        private void dgvElever_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Hvis man klikker på en elev så fylles variabler med informasjon om eleven
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvElever.Rows[e.RowIndex];
                    txtEleverFNummer.Text = row.Cells["FNummer"].Value.ToString();
                    fnummer = row.Cells["FNummer"].Value.ToString();
                    txtEleverFornavn.Text = row.Cells["Fornavn"].Value.ToString();
                    txtEleverEtternavn.Text = row.Cells["Etternavn"].Value.ToString();
                    cmbEleverKjønn.Text = row.Cells["Kjønn"].Value.ToString();
                    gmlBetegnelse = row.Cells["Betegnelse"].Value.ToString();
                    cmbEleverKlasse.Text = row.Cells["Betegnelse"].Value.ToString();
                    gmlSkoleår = row.Cells["Skoleår"].Value.ToString();
                    cmbEleverSkoleår.Text = row.Cells["Skoleår"].Value.ToString();
                    lblEleverStatus.Visible = true;
                    chkEleverStatus.Visible = true;
                    chkEleverStatus.Checked = bool.Parse(row.Cells["Aktiv"].Value.ToString());

                    //Laster inn klasser til eleven
                    dgvEleverKlasse.DataSource = database.LastElevKlasser(row.Cells["FNummer"].Value.ToString()).Tables[0].DefaultView;
                    dgvEleverKlasse.CurrentCell = null;
                    txtEleverFNummer.Enabled = false;
                    cmbEleverKjønn.Enabled = false;
                    butEleverReg.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Når man velger skoleår
        private void cmbEleverSkoleår_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Laster inn betegnelser til valgt skoleår
                cmbEleverKlasse.DataSource = database.LastKlasserBet(cmbEleverSkoleår.Text).Tables[0];
                cmbEleverKlasse.DisplayMember = "Betegnelse";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sjekker om man fyller inn tall i fødseslnummer
        private void txtEleverFNummer_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Hvis man ikke skriver inn tall så fjernes char
                if (!char.IsNumber(e.KeyChar))
                {
                    e.Handled = e.KeyChar != (char)Keys.Back;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        //Sjekker om input i navn ikke er tall
        private void txtNavn_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Hvis man skriver inn tall så fjernes char
                if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = e.KeyChar != (char)Keys.Back;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        //Registrering av elever
        private void butEleverReg_Click(object sender, EventArgs e)
        {
            try
            {
                //Registrerer eleven i databasen og oppdaterer visningen
                database.InsertElever(txtEleverFNummer.Text.Trim(), txtEleverFornavn.Text.Trim(), txtEleverEtternavn.Text.Trim(), cmbEleverKjønn.Text, cmbEleverKlasse.Text, int.Parse(cmbEleverSkoleår.Text));
                lastElever();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Endring av elever
        private void butEleverEndre_Click(object sender, EventArgs e)
        {
            try
            {
                int status = 0;

                //Setter status til aktiv om man krysser av på status
                if (chkEleverStatus.Checked == true)
                {
                    status = 1;
                }

                //Endrer eleven i databasen 
                database.UpdateElever(fnummer, txtEleverFornavn.Text.Trim(), txtEleverEtternavn.Text.Trim(), cmbEleverKjønn.Text, status);

                //Hvis gammel klasse ikke er lik som ny klasse
                if (!gmlBetegnelse.Equals(cmbEleverKlasse.Text))
                {
                    //Registrerer ny klasse på elev
                    database.InsertEleverKlasse(fnummer, cmbEleverKlasse.Text, int.Parse(cmbEleverSkoleår.Text));
                }

                //Oppdaterer elever og tilbakestiller visningen
                lastElever();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sletting av elever
        private void butEleverSlett_Click(object sender, EventArgs e)
        {
            try
            {
                 //Om man er sikker på at man vil slette elev
                DialogResult dialogResult = MessageBox.Show(this, "Sletting av elev vil slette tilhørende klasser og resulater også, er du sikker på at du vil slette?", "Sletting av elev", MessageBoxButtons.YesNo);

                //Hvis man trykker ja
                if (dialogResult == DialogResult.Yes)
                {

                //Sletter eleven i databasen og oppdaterer visningen
                database.SlettElever(fnummer);
                lastElever();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Oppdaterer elever og tilbakestiller visningen
        private void butEleverTøm_Click(object sender, EventArgs e)
        {
            lastElever();
        }

        //Flytter alle elever opp én klasse
        private void butEleverFlyttopp_Click(object sender, EventArgs e)
        {
            try
            {
                //For hver elev i datagridden
                foreach (DataGridViewRow row in dgvElever.Rows)
                {
                    //Hvis elev har status aktiv
                    if (bool.Parse(row.Cells["Aktiv"].Value.ToString()))
                    {
                        //Lagrer fødselsnummer og betegnelse til eleven
                        string fNr = row.Cells["FNummer"].Value.ToString();
                        string bet = row.Cells["Betegnelse"].Value.ToString();

                        //Nummer i betegnelsen
                        int betnr = int.Parse(Regex.Match(bet, @"\d+").Value);

                        //Hvis det ikke er 7.ende klasse
                        if (!betnr.ToString().Contains("7"))
                        {
                            //Bokstavene i betegnelsen
                            string betBokstav = Regex.Replace(bet, @"\d+", string.Empty);
                            //Ny betegnelse
                            string nyBet = betnr + betBokstav;

                            //Sjekker rekkefølge på tallene og bokstavene og øker nummer med 1
                            if (bet.Equals(nyBet))
                            {
                                betnr += 1;
                                nyBet = betnr + betBokstav;
                            }
                            else
                            {
                                betnr += 1;
                                nyBet = betBokstav + betnr;
                            }

                            //Nytt skoleår
                            string skoleår = row.Cells["Skoleår"].Value.ToString();
                            int skoleår1 = int.Parse(skoleår.Substring(0, skoleår.Length / 2));
                            int skoleår2 = int.Parse(skoleår.Substring(skoleår.Length / 2));
                            skoleår1 += 1;
                            skoleår2 += 1;
                            string nyttskoleår = skoleår1.ToString() + skoleår2.ToString();

                            //Registrerer ny klasse på eleven og oppdaterer visningen

                            database.InsertEleverKlasse(fNr, nyBet, int.Parse(nyttskoleår));
                            lastElever();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion 
        #region Brukere
        //Velger brukere i menyen
        private void butBrukere_Click(object sender, EventArgs e)
        {
            try
            {
                menyValg(menyBrukere);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Laster inn brukere og tilbakestiller visningen
        private void lastBrukere()
        {
            try
            {
                //Laster inn brukere fra databasen
                dgvBrukere.DataSource = database.LastBrukere().Tables[0].DefaultView;
                cmbBrukerType.DataSource = database.LastBrukertype().Tables[0];
                cmbBrukerType.DisplayMember = "beskrivelse";
                cmbBrukerType.ValueMember = "brukertypeID";
                cmbBrukerType.SelectedValue = 2;

                txtBrukerBrukernavn.Clear();
                txtBrukerFornavn.Clear();
                txtBrukerEtternavn.Clear();
                txtBrukerPassord.Clear();

                dgvBrukere.CurrentCell = null;
                butBrukerSlett.Enabled = false;
                cmbBrukerType.Enabled = true;
                txtBrukerFornavn.Focus();

                //Setter autosizemode i datagridden
                dgvBrukere.Columns["Brukernavn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBrukere.Columns["Passord"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBrukere.Columns["Beskrivelse"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sjekker input og setter riktig synlighet på knapper
        private void txtBruker_TextChanged(object sender, EventArgs e)
        {
            //Hvis tekstboksene ikke er tomme
            if (txtBrukerBrukernavn.Text.Trim() != "" & txtBrukerFornavn.Text.Trim() != "" & txtBrukerEtternavn.Text.Trim() != "" & txtBrukerPassord.Text.Trim() != "")
            {
                //Hvis ingen celle er valgt i datagridden
                if (dgvBrukere.CurrentCell != null)
                {
                    butBrukerEndre.Enabled = true;
                    butBrukerSlett.Enabled = true;
                }
                //Hvis celle er valgt i datagridden
                else
                {
                    butBrukerReg.Enabled = true;
                }
            }
            //Hvis tekstboksene er tomme
            else
            {
                butBrukerReg.Enabled = false;
                butBrukerEndre.Enabled = false;
            }
        }
        
        //Når man klikker på bruker i datagridden
        private void dgvBrukere_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Hvis man klikker på en bruker i datagridden så fyller variabler med informasjon om brukeren
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvBrukere.Rows[e.RowIndex];
                    gmlBrukernavn = row.Cells["Brukernavn"].Value.ToString();
                    txtBrukerBrukernavn.Text = row.Cells["Brukernavn"].Value.ToString();
                    txtBrukerFornavn.Text = row.Cells["Fornavn"].Value.ToString();
                    txtBrukerEtternavn.Text = row.Cells["Etternavn"].Value.ToString();
                    txtBrukerPassord.Text = row.Cells["Passord"].Value.ToString();
                    cmbBrukerType.Text = row.Cells["Beskrivelse"].Value.ToString();
                    butBrukerReg.Enabled = false;
                    cmbBrukerType.Enabled = true;

                    //Hvis man prøver å endre seg selv, så får man ikke endret type
                    var log = this.Tag as frmInnlogging;
                    if (log.bruker.getBrukernavn().Equals(gmlBrukernavn))
                    {
                        cmbBrukerType.Enabled = false;
                        butBrukerSlett.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Registrering av bruker
        private void butBrukerReg_Click(object sender, EventArgs e)
        {
            try
            {
                //Registrerer brukeren i databasen
                database.InsertBrukere(txtBrukerBrukernavn.Text.Trim(), txtBrukerPassord.Text.Trim(), txtBrukerFornavn.Text.Trim(), txtBrukerEtternavn.Text.Trim(), int.Parse(cmbBrukerType.SelectedValue.ToString()));
                lastBrukere();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtBrukerBrukernavn.Focus();
                txtBrukerBrukernavn.SelectAll();
            }
        }

        //Endring av bruker
        private void butBrukerEndre_Click(object sender, EventArgs e)
        {
            try
            {
                //Endrer brukeren i databasen
                database.UpdateBrukere(gmlBrukernavn, txtBrukerBrukernavn.Text.Trim(), txtBrukerPassord.Text.Trim(), txtBrukerFornavn.Text.Trim(), txtBrukerEtternavn.Text.Trim(), int.Parse(cmbBrukerType.SelectedValue.ToString()));

                //Oppdaterer brukeren som er logget inn om man endrer seg selv
                var log = this.Tag as frmInnlogging;
                if (log.bruker.getBrukernavn().Equals(gmlBrukernavn))
                {
                    log.bruker.setBrukernavn(txtBrukerBrukernavn.Text.Trim());
                    log.bruker.setFornavn(txtBrukerFornavn.Text.Trim());
                    log.bruker.setEtternavn(txtBrukerEtternavn.Text.Trim());
                    log.bruker.setPassord(txtBrukerPassord.Text.Trim());
                    log.bruker.setBrukertype(cmbBrukerType.Text);
                    lblBrukerStatus.Text = log.bruker.ToString();
                }

                //Lagrer hvem som er logget inn
                brukernavn = log.bruker.getBrukernavn();

                //Oppdaterer visningen
                lastBrukere();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sletting av bruker
        private void butBrukerSlett_Click_1(object sender, EventArgs e)
        {
            try
            {
                var log = this.Tag as frmInnlogging;

                //Hvis man ikke har trykket på seg selv
                if (!log.bruker.getBrukernavn().Equals(gmlBrukernavn))
                {
                    //Sletteren brukeren fra databasen og oppdaterer visningen
                    database.SlettBruker(gmlBrukernavn);
                    lastBrukere();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Oppdaterer brukere og tilbakestiller visningen
        private void butBrukerTøm_Click(object sender, EventArgs e)
        {
            try
            {
                lastBrukere();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Hjelp
        //Setter hjelpefilen til å se på topicid, og at hjelp skal vises
        private void Hjelpe()
        {
             hjelp.SetHelpNavigator(this, HelpNavigator.TopicId);
             hjelp.SetShowHelp(this, true);
        }

        //Hvis man holder over resultat så vises hjelp for resultat
        private void butResultat_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "70");
        }

        //Hvis man holder over test så vises hjelp for test
        private void butTest_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "80");
        }

        //Hvis man holder over deltest så vises hjelp for deltest
        private void butDeltest_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "90");
        }

        //Hvis man holder over klasse så vises hjelp for klasse
        private void butKlasse_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "100");
        }

        //Hvis man holder over elev så vises hjelp for elev
        private void butElev_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "110");
        }

        //Hvis man holder over bruker så vises hjelp for bruker
        private void butBruker_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "120");
        }

        //Hvis man holder over formen så vises velkomsthjelpen 
        private void frmHoved_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "40");
        }

        //Hvis man trykker på vis hjelp i menylinjen så vises velkomsthjelpen
        private void visHjelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = Process.Start(System.IO.Directory.GetParent(Application.ExecutablePath) + @"\Hjelp\barneskole.chm");
        }

        //Hvis man holder over fil i menylinjen så vises hjelp for fil
        private void filToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "50");
        }

        //Hvis man holder over logg ut så vises hjelp for logg ut
        private void loggUtToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "130");
        }
    }
#endregion
}
