using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mertens.BusinessLogic;
using Mertens.Dao;

namespace Mertens.Forms
{
    public partial class frmBeheerderAanpassen : Form
    {

        private Beheerder oldBeheerder;
        private int selectedMaatschappijId;
        private string selectedMaatschappij;
        static frmBeheerderAanpassen instance = null;
        static readonly object padlock = new object();

        internal Beheerder OldBeheerder
        {
            get { return oldBeheerder; }
            set { oldBeheerder = value; }
        }
        public int SelectedMaatschappijId
        {
            set { selectedMaatschappijId = value; }
        }

        public string SelectedMaatschappij
        {
            set { selectedMaatschappij = value; }
        }

        frmBeheerderAanpassen()
        {
            InitializeComponent();
        }

        public static frmBeheerderAanpassen Instance
        { 
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmBeheerderAanpassen();
                    }
                    return instance;
                }
            }
        }

        private void frmBeheerderAanpassen_Load(object sender, EventArgs e)
        {

        }

        private void frmBeheerderAanpassen_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                txtBeheerderTitel.Text = OldBeheerder.Aanspreektitel;
                txtBeheerderNaam.Text = OldBeheerder.Naam;
                txtBeheerderVoornaam.Text = OldBeheerder.Voornaam;
                txtBeheerderTelefoon.Text = OldBeheerder.Telefoon;
                txtBeheerderFax.Text = OldBeheerder.Fax;
                txtBeheerderEmail.Text = OldBeheerder.Email;
            }
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            Beheerder beheerderInDatabase = BeheerderDao.Instance.getBeheerder(selectedMaatschappijId, this.OldBeheerder);
            if (beheerderInDatabase == null)
            {
                MessageBox.Show("Kan de beheerder niet opslaan om dat iemand zijn gegevens reeds aanpaste of de beheerder al verwijderd heeft!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                this.Hide();
                frmMaatschappijBeheer.Instance.buildListView();
            }
            else
            {
                Beheerder newBeheerder = new Beheerder(this.selectedMaatschappij, txtBeheerderNaam.Text);
                newBeheerder.Aanspreektitel = txtBeheerderTitel.Text;
                newBeheerder.Voornaam = txtBeheerderVoornaam.Text;
                newBeheerder.Telefoon = txtBeheerderTelefoon.Text;
                newBeheerder.Fax = txtBeheerderFax.Text;
                newBeheerder.Email = txtBeheerderEmail.Text;
                BeheerderDao.Instance.updateBeheerder(OldBeheerder,newBeheerder);
                this.Hide();
                frmMaatschappijBeheer.Instance.buildListView();
                frmDetails.Instance.refresh();
            }
        }
    }
}
