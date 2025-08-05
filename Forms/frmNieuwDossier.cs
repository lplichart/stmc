using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mertens.Dao;

namespace Mertens.Forms
{
    public partial class frmNieuwDossier : Form
    {

        static frmNieuwDossier instance = null;
        static readonly object padlock = new object();
        private string referentie = "";

        public static frmNieuwDossier Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmNieuwDossier();
                    }
                    return instance;
                }
            }
        }

        frmNieuwDossier()
        {
            InitializeComponent();
        }

        public string Referentie
        {
            get { return referentie; }
            set { referentie = value; }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtReferentie.Text.Trim().Equals(""))
            {
                MessageBox.Show("Er werd geen dossiernummer ingegeven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (txtReferentie.Text.Trim().Length != 11)
            {
                MessageBox.Show("Er werd een foutief dossiernummer ingegeven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if (DossierDao.Instance.getDossiersByReferenceLike(txtReferentie.Text).Count != 0)
            {
                MessageBox.Show("Het dossiernummer dat u probeert toe te voegen bestaat al, probeer het opnieuw", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Hide();
                frmOverview.Instance.buildListView("SELECT * FROM dossier ORDER BY referentie DESC;");
            }
            else
            {
                if (!txtReferentie.Text.Trim().Equals("") && txtReferentie.Text.Trim().Length == 11)
                {

                    Referentie = txtReferentie.Text;
                    if (DossierDao.Instance.getDossiersByReferenceLike(Referentie.Substring(0, Referentie.Length -1)).Count == 0)
                    {
                        DossierDao.Instance.createDossier(Referentie);
                        frmOverview.Instance.SelectedReference = Referentie;
                        frmDetails.Instance.Show();
                        frmOverview.Instance.Hide();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Het referentienummer werd al gebruikt, probeer opnieuw.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Hide();
                        this.Show();
                    }
                }
            }
            
        }

        private void frmNieuwDossier_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                txtReferentie.Text = Referentie;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Referentie = "";
        }

        private void frmNieuwDossier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnNew_Click(sender, e);
            }

        }

        public void switchToUpdate()
        {
            btnNew.Visible = false;
            btnUpdate.Visible = true;
        }

        public void switchToNew()
        {
            btnUpdate.Visible = false;
            btnNew.Visible = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtReferentie.Text.Trim().Equals(""))
            {
                MessageBox.Show("Er werd geen dossiernummer ingegeven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (txtReferentie.Text.Trim().Length != 11)
            {
                MessageBox.Show("Er werd een foutief dossiernummer ingegeven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (!txtReferentie.Text.Substring(0, 10).Equals(frmOverview.Instance.SelectedReference.Substring(0, 10)))
                {
                    MessageBox.Show("Je mag enkel de laatste letter van de referentie aanpassen", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtReferentie.Text = frmOverview.Instance.SelectedReference.Substring(0, 10);
                }
                else
                {
                    if (!txtReferentie.Text.Trim().Equals(""))
                    {
                        DossierDao.Instance.updateReferentie(frmOverview.Instance.SelectedReference, txtReferentie.Text);
                        frmOverview.Instance.SelectedReference = txtReferentie.Text;
                        frmOverview.Instance.buildListView("SELECT * FROM dossier ORDER BY referentie DESC;");
                        this.Hide();
                    }
                }
            }
        }

        private void txtReferentie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnNew_Click(sender, e);
            }

        }
    }
}
