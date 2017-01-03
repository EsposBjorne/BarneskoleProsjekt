using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barneskole
{
    //Form for oppretting av ny bruker om ingen andre finnes
    public partial class frmNyBruker : Form
    {
        //Oppretter databaseklassen
        Database database = new Database();

        //Initsierer formen
        public frmNyBruker()
        {
            InitializeComponent();
        }

        //Sjekker at alle boksene er fylt ut før man kan registrere brukeren
        private void txtNyBruker_TextChanged(object sender, EventArgs e)
        {
            if (txtBrukernavn.Text != "" & txtFornavn.Text != "" & txtEtternavn.Text != "" & txtPassord.Text != "")
            {
                butNyBruker.Enabled = true;
            }
            else
            {
                butNyBruker.Enabled = false;
            }
        }

        //Når man registrerer ny bruker
        private void butNyBruker_Click(object sender, EventArgs e)
        {
            try
            {
                //Brukeren registreres i databasen
                database.InsertBrukere(txtBrukernavn.Text, txtPassord.Text, txtFornavn.Text, txtEtternavn.Text, 1);
                MessageBox.Show("Bruker er registrert!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
