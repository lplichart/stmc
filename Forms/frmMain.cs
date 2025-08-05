using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mertens.BusinessLogic;

namespace Mertens.Forms
{
    public partial class frmMain : Form
    {
        static frmMain instance = null;
        static readonly object padlock = new object();
        private Form overview;
        private Form details;
        private Form maatschappijBeheer;
        private Form adresboekBeheer;
        private Form prestatie;
        private Form prijslijst;
        private string dialogText="";

        public string DialogText
        {
            get { return dialogText; }
            set { dialogText = value; }
        }

        public static frmMain Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmMain();
                    }
                    return instance;
                }
            }
        }

        public frmMain()
        {
            InitializeComponent();

            overview = frmOverview.Instance;
            overview.MdiParent = this;
            overview.Dock = DockStyle.Fill;
            details = frmDetails.Instance;
            details.MdiParent = this;
            details.Dock = DockStyle.Fill;
            maatschappijBeheer = frmMaatschappijBeheer.Instance;
            maatschappijBeheer.MdiParent = this;
            maatschappijBeheer.Dock = DockStyle.Fill;
            adresboekBeheer = frmAdresboek.Instance;
            adresboekBeheer.MdiParent = this;
            adresboekBeheer.Dock = DockStyle.Fill;
            prestatie = frmPrestatie.Instance;
            prestatie.MdiParent = this;
            prestatie.Dock = DockStyle.Fill;
            prijslijst = frmPrijslijst.Instance;
            prijslijst.MdiParent = this;
            prijslijst.Dock = DockStyle.Fill;
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            overview.Show();
        }

        private void mnuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild == null)
            {
                overview.Show();
            }
            else { this.ActiveMdiChild.Focus(); }
        }

        private void sluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void overzichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null && ActiveMdiChild.Text.Equals("Overzicht"))
            {
                this.ActiveMdiChild.Hide();
            }
            else
            {
                this.ActiveMdiChild.Close();
            }

            overview.Show();
        }

        private void maatschappijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null && ActiveMdiChild.Text.Equals("Overzicht"))
            {
                this.ActiveMdiChild.Hide();
            }
            else
            {
                this.ActiveMdiChild.Close();
            }

            maatschappijBeheer.Show();
        }

        private void adresboekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null && ActiveMdiChild.Text.Equals("Overzicht"))
            {
                this.ActiveMdiChild.Hide();
            }
            else
            {
                this.ActiveMdiChild.Close();
            }

            adresboekBeheer.Show();
        }

        private void zoekenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZoek.Instance.Show();
        }

        private void prestatiesPerExpertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayments.Instance.Show();
        }

        private void facturatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null && ActiveMdiChild.Text.Equals("Overzicht"))
            {
                this.ActiveMdiChild.Hide();
            }
            else
            {
                this.ActiveMdiChild.Close();
            }

            frmPrijslijst.Instance.Show();
        }

        private void factuurZoekenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOpenstaandePrestaties.Instance.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Visible == true)
                {
                    f.Close();
                }

            }

            Environment.Exit(0);
        }

        private void rapportageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting reporting = new Reporting();
            reporting.initializeData();
            reporting.generateReport();

        }
    }
}
