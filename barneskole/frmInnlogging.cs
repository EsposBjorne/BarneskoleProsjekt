using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Microsoft.Win32;
using System.Management;
using System.IO;

namespace Barneskole
{
    public partial class frmInnlogging : Form
    {
        public Bruker bruker;
        Database Database;
        bool mysqlInstallert = false;

        //Initialiserer innlogginsformen
        public frmInnlogging()
        {
            InitializeComponent();
        }

        //Innloggingsformens load
        private void frmInnlogging_Load(object sender, EventArgs e)
        {
                //Sjekker om MySQL er installert
                startInstallasjon();

                //Hvis MySQL Server og Notifier er installert
                if (mysqlInstallert)
                {
                    //Klargjør innlogging
                    klargjørLoggin();
                }

                //Hvis ikke er installert så avsluttes programmet
                else
                {
                    Application.Exit();
                }
        }

        //Klargjør innlogging for om det finnes brukere eller ikke
        private void klargjørLoggin()
        {
            try
            {
                //Oppretter databaseklassen
                Database = new Database();

                //Setter hjelp til riktig hjelpefil
                hjelp.HelpNamespace = System.IO.Directory.GetParent(Application.ExecutablePath) + @"\Hjelp\barneskole.chm";

                //Setter fokus på brukernavn boksen
                txtBrukernavn.Select();

                //Hvis det finnes noen brukere i databasen så kan man logge inn
                if (Database.LastBrukere().Tables[0].Rows.Count > 0)
                {
                    lblBrukernavn.Visible = true;
                    lblPassord.Visible = true;
                    txtBrukernavn.Visible = true;
                    txtPassord.Visible = true;
                    butLogginn.Visible = true;
                    lblIngenBrukere.Visible = false;
                    butOpprettBruker.Visible = false;
                    this.AcceptButton = butLogginn;
                }

                //Hvis ikke det finnes brukere i databasen så kan man få mulighet til å lage ny bruker
                else
                {
                    lblBrukernavn.Visible = false;
                    lblPassord.Visible = false;
                    txtBrukernavn.Visible = false;
                    txtPassord.Visible = false;
                    butLogginn.Visible = false;
                    lblIngenBrukere.Visible = true;
                    butOpprettBruker.Visible = true;
                    this.AcceptButton = butOpprettBruker;
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                        //Hvis serveren er på, og mysql ikke får kontakt, da er mest sannsynlig root passordet feil
                    case 0:
                        MessageBox.Show("Kan ikke koble til MySQL serveren, mulig root passord er feil?");

                        //Viser dialog hvor man kan skrive inn hva root passord er for å få kontakt med databasen
                        Form dbPass = new frmDbPass();

                        //Hvis man trykker ok 
                        if (dbPass.ShowDialog(this) == DialogResult.OK)
                        {
                            //Prøver å klargjøre innlogging på nytt
                            klargjørLoggin();
                        }

                        //Hvis man ikke trykker ok så avsluttes programmet
                        else
                        {
                            Application.Exit();
                        }
                        break;

                        //Hvis serveren ikke er på
                    case 1042:
                        MessageBox.Show("Kan ikke koble til MySQL serveren, sjekk at serveren kjører!");
                        Application.Exit();
                        break;
                }   
            }
        }

        //Starter installasjon av MySQL om de ikke allerede er installert
        public void startInstallasjon()
        {
            try
            {
                //Hvis MySQL server  eller MySQL Notifier ikke er installert
                if (ErProgramInstallert("MySQL Server") == false | (ErProgramInstallert("MySQL Notifier") == false))
                {
                    //False hvis ikke installert
                    mysqlInstallert = false;

                    //Installerer MySQL
                    DialogResult result = MessageBox.Show("MySQL Server og/eller MySQL Notifier er ikke installert! Vil du starte installasjon?", "Installasjon", MessageBoxButtons.YesNo);
                    
                    //Hvis man trykker ja så starter installasjon av mysql
                    if (result == DialogResult.Yes)
                    {
                        string installerFilePath;
                        installerFilePath = @"mysqlinstall.msi";
                        System.Diagnostics.Process installerProcess;
                        installerProcess = System.Diagnostics.Process.Start(installerFilePath);

                        //Mens installasjonen ikke har avsluttet
                        while (installerProcess.HasExited == false)
                        {
                            //indicate progress to user
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(250);
                        }

                        //Mens MySQLInstaller fortsatt kjører
                        while (Process.GetProcessesByName("MySQLInstaller").Length > 0)
                        {
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(250);
                        }

                        //Hvis programmet fortsatt ikke er installert så slås programmet av
                        if (ErProgramInstallert("MySQL Server") == false | (ErProgramInstallert("MySQL Notifier") == false))
                        {
                            mysqlInstallert = false;
                        }

                        //Hvis programmet nå har blitt installert
                        else
                        {
                            mysqlInstallert = true;
                        }
                    }

                    //Hvis man trykker nei så slås programmet av
                    else
                    {
                        Application.Exit();
                    }
                }

                //Hvis det er intallert så er den true
                else
                {
                    mysqlInstallert = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sjekker om program er installert via windows register
        public static bool ErProgramInstallert(string p_name)
        {
            string displayName;
            RegistryKey key;

            try
            {
                //Søker etter MySQL i CurrentUser
                key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MySQL AB");
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.Name.ToString();

                    if (displayName.Contains(p_name) == true)
                    {

                        displayName = subkey.GetValue("Installed").ToString();
                        if (displayName.Contains("1") == true)
                        {
                            return true;
                        }
                    }
                }

                // Søker etter MySQL i ClassesRoot
                key = Registry.ClassesRoot.OpenSubKey(@"Installer\Products");
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue("ProductName").ToString();
                    if (displayName.Contains(p_name) == true)
                    {
                        return true;
                    }
                }

                // Søker etter MySQL i LocalMachine_32_installer
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\Installer\Products");
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue("ProductName").ToString();
                    if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return true;
                    }
                }

                // Søker etter MySQL i LocalMachine_32_uninstaller
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue("DisplayName").ToString();
                    if (displayName.Contains(p_name) == true)
                    {
                        return true;
                    }
                }

                // Søker etter MySQL i LocalMachine_64
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue("DisplayName").ToString();
                    if (displayName.Contains(p_name) == true)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                //Får feil om ikke finnes men velger å ikke vise denne da det er unødvendig, men fanger feilen for at programmet ikke skal krasje
            }
            return false;
        }

        //Innlogging
        public void butLogginn_Click(object sender, EventArgs e)
        {
            try
            {
                //Hvis det finnes brukere
                if (Database.LastBrukere().Tables[0].Rows.Count > 0)
                {
                    //Sjekker om det finnes noen bruker med valgt brukernavn og passord
                    bruker = Database.SjekkInnlogging(txtBrukernavn.Text, txtPassord.Text);

                    //Hvis det finnes, så vises hovedformen og man blir logget inn
                    if (bruker != null)
                    {
                        txtBrukernavn.Clear();
                        txtPassord.Clear();
                        txtBrukernavn.Select();
                        frmHoved frm = new frmHoved();
                        frm.Tag = this;
                        frm.Show();
                        this.Hide();
                    }

                    //Hvis det ikke finnes så får man opp en feilmelding og man får ikke logget inn
                    else
                    {
                        MessageBox.Show("Brukernavn og passord stemmer ikke overens!!!");
                        txtPassord.Focus();
                        txtPassord.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Avslutning av innlogginsformen
        private void frmInnlogging_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Gjennopprett database
        private void butRestore_Click(object sender, EventArgs e)
        {
            try
            {
                //Gjennoppretter databasen
                Database.Restore();

                //Hvis det finnes brukere kan man logge inn
                if (Database.LastBrukere().Tables[0].Rows.Count > 0)
                {
                    lblBrukernavn.Visible = true;
                    lblPassord.Visible = true;
                    txtBrukernavn.Visible = true;
                    txtPassord.Visible = true;
                    butLogginn.Visible = true;
                    lblIngenBrukere.Visible = false;
                    butOpprettBruker.Visible = false;
                    this.AcceptButton = butLogginn;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Knapp for å opprette ny bruker om ingen finnes
        private void butOpprettBruker_Click(object sender, EventArgs e)
        {
            try
            {
                //Viser form for registrering av ny bruker
                Form nyBruker = new frmNyBruker();
                nyBruker.ShowDialog();

                //Hvis det finnes brukere kan man logge inn
                if (Database.LastBrukere().Tables[0].Rows.Count > 0)
                {
                    lblBrukernavn.Visible = true;
                    lblPassord.Visible = true;
                    txtBrukernavn.Visible = true;
                    txtPassord.Visible = true;
                    butLogginn.Visible = true;
                    lblIngenBrukere.Visible = false;
                    butOpprettBruker.Visible = false;
                    this.AcceptButton = butLogginn;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Setter hjelp til å lete på topic id og viser hjelp om man trykker på F1
        private void Hjelpe()
        {
            hjelp.SetHelpNavigator(this, HelpNavigator.TopicId);
            hjelp.SetShowHelp(this, true);
        }

        //Viser hjelp til innloggin om man holder over formen
        private void frmInnlogging_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "20");
        }

        //Viser hjelp til gjennoppretting om man holder over gjennoppretting
        private void butRestore_MouseHover(object sender, EventArgs e)
        {
            Hjelpe();
            hjelp.SetHelpKeyword(this, "30");
        }
    }
}
