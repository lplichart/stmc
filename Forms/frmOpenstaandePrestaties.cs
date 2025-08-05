using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mertens.Forms
{
    public partial class frmOpenstaandePrestaties : Form
    {
        static frmOpenstaandePrestaties instance = null;
        static readonly object padlock = new object();

        public frmOpenstaandePrestaties()
        {
            InitializeComponent();
        }

        public static frmOpenstaandePrestaties Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmOpenstaandePrestaties();
                    }
                    return instance;
                }
            }
        }

        private void btnbtn_Click(object sender, EventArgs e)
        {
            String query = "Select * From Dossier Where Id in(Select dossierId From prestatie Where ((totaal_erelonen+totaal_onkosten)*1.21 )>=\'" + txtHoeveelheid.Text + "\"');";
            frmOverview.Instance.buildListView(query);
            txtHoeveelheid.Text = "";
            this.Close();
        }

        private void frmOpenstaandePrestaties_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
