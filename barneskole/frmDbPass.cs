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
    public partial class frmDbPass : Form
    {
        //Initialiserer frmDBPass formen
        public frmDbPass()
        {
            InitializeComponent();

            //Setter knappen til dialogresultat ok
            butDbPassord.DialogResult = DialogResult.OK;

            //Setter fokus på tekstboksen
            txtDbPass.Focus();
        }

        //Når man trykker på knappen så settes dbpassord i settings til det som står i tekstboksen
        private void butDbPassord_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbpassord = txtDbPass.Text.Trim();
            Properties.Settings.Default.Save();
        }
    }
}
