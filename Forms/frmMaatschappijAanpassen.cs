using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mertens.BusinessLogic;
using System.Collections;
using Mertens.Dao;

namespace Mertens.Forms
{
    public partial class frmMaatschappijAanpassen : Form
    {

        private Boolean nieuweMaatschappij = false;
        private Maatschappij maatschappij;
        private Boolean firstLoad = true;
        static frmMaatschappijAanpassen instance = null;
        static readonly object padlock = new object();

        frmMaatschappijAanpassen()
        {
            InitializeComponent();
            setupCmbPostcode();

        }

        public static frmMaatschappijAanpassen Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmMaatschappijAanpassen();
                    }
                    return instance;
                }
            }
        }

        internal Maatschappij Maatschappij
        {
            get { return maatschappij; }
            set { maatschappij = value; }
        }
        public Boolean NieuweMaatschappij
        {
            get { return nieuweMaatschappij; }
            set { nieuweMaatschappij = value; }
        }

        private void frmMaatschappijAanpassen_Load(object sender, EventArgs e)
        {

        }

        private void frmMaatschappijAanpassen_VisibleChanged(object sender, EventArgs e)
        {
            if (nieuweMaatschappij == true)
            {
                Maatschappij = null;
                txtMaatschappij.Clear();
                txtMaatschappijAdres.Clear();
                cmbPostcode.SelectedIndex = -1;
                cmbGemeente.SelectedIndex = -1;
                txtMaatschappijTelefoon.Clear();
                txtMaatschappijFax.Clear();
                txtMaatschappijEmail.Clear();
                txtBtwNr.Clear();
            }
            else
            {
                Maatschappij = frmMaatschappijBeheer.Instance.Maatschappij;
                this.firstLoad = true;
                txtMaatschappij.Text = Maatschappij.Naam;
                txtMaatschappijAdres.Text = Maatschappij.Straat;
                cmbPostcode.Text = Maatschappij.Postcode;
                cmbGemeente.Text = Maatschappij.Gemeente;
                if (cmbPostcode.SelectedIndex == -1) firstLoad = false;
                txtMaatschappijTelefoon.Text = Maatschappij.Telefoon;
                txtMaatschappijFax.Text = Maatschappij.Fax;
                txtMaatschappijEmail.Text = Maatschappij.Email;
                txtBtwNr.Text = Maatschappij.Btw;
            }
        }

        private void setupCmbPostcode()
        {
            foreach (Object o in GemeenteDao.Instance.getAllPostCodes())
            {
                cmbPostcode.Items.Add((String)o);
            }
        }

        private void cmbPostcode_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbGemeente.SelectedIndex = -1;
            cmbGemeente.Items.Clear();

            if (cmbPostcode.SelectedIndex != -1)
            {
                foreach (Object o in GemeenteDao.Instance.getGemeentenByPostcode(int.Parse(cmbPostcode.SelectedItem.ToString())))
                {
                    cmbGemeente.Items.Add((String)o);
                }

                if (cmbGemeente.Items.Count == 1) { cmbGemeente.SelectedIndex = 0; }
                else
                {
                    if (Maatschappij != null && firstLoad == true)
                    {

                        cmbGemeente.SelectedIndex = cmbGemeente.Items.IndexOf(Maatschappij.Gemeente);
                        this.firstLoad = false;
                    }
                    else
                    {
                        string message = "Maak zelf een keuze uit:\n";
                        foreach (Object o in cmbGemeente.Items)
                        {
                            message += "\n";
                            message += "- " + (String)o;
                        }
                        MessageBox.Show(message, "Opgelet!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void frmMaatschappijAanpassen_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Annuleer_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (NieuweMaatschappij == true)
            {
                if (txtMaatschappij.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Er moet op zijn minst een naam worden opgegeven van de maatschappij!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                }
                else
                {
                    Maatschappij maatschappij = new Maatschappij(txtMaatschappij.Text, txtMaatschappijAdres.Text, cmbGemeente.Text, cmbPostcode.Text);
                    maatschappij.Telefoon = txtMaatschappijTelefoon.Text;
                    maatschappij.Fax = txtMaatschappijFax.Text;
                    maatschappij.Email = txtMaatschappijEmail.Text;
                    maatschappij.Btw = txtBtwNr.Text;
                    MaatschappijDao.Instance.AddMaatschappij(maatschappij);
                    frmMaatschappijBeheer.Instance.fillListBoxMaatschappij();
                    frmDetails.Instance.refresh();
                    this.Hide();
                }
            }
            else
            {
                Maatschappij maatschappijInDb = MaatschappijDao.Instance.getMaatschappij(Maatschappij);

                if (maatschappijInDb == null)
                {
                    MessageBox.Show("Kan de maatschappij niet opslaan om dat iemand anders de gegevens reeds aanpaste!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    frmMaatschappijBeheer.Instance.fillListBoxMaatschappij();
                    this.Hide();
                }
                else
                {
                    if (txtMaatschappij.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Er moet op zijn minst een naam worden opgegeven van de maatschappij!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                    }
                    else
                    {
                        Maatschappij maatschappij = new Maatschappij(txtMaatschappij.Text, txtMaatschappijAdres.Text, cmbGemeente.Text, cmbPostcode.Text);
                        maatschappij.Telefoon = txtMaatschappijTelefoon.Text;
                        maatschappij.Fax = txtMaatschappijFax.Text;
                        maatschappij.Email = txtMaatschappijEmail.Text;
                        maatschappij.Btw = txtBtwNr.Text;
                        MaatschappijDao.Instance.updateMaatschappij(Maatschappij, maatschappij);
                        frmMaatschappijBeheer.Instance.fillListBoxMaatschappij();
                        frmDetails.Instance.refresh();
                        this.Hide();
                    }
                }
            }
        }

        private void cmbPostcode_TextChanged(object sender, EventArgs e)
        {
            if (cmbPostcode.Text.Trim().Equals(""))
            {
                cmbPostcode.SelectedIndex = -1;
                cmbGemeente.SelectedIndex = -1;
                cmbGemeente.Text.Remove(0, cmbGemeente.Text.Length);
                cmbGemeente.Items.Clear();
            }

            if (cmbPostcode.Text.Length == 4)
            {
                cmbGemeente.SelectedIndex = -1;
                cmbGemeente.Text = "";
                cmbPostcode.SelectedIndex = cmbPostcode.Items.IndexOf(cmbPostcode.Text);
            }
        }

    }
}
