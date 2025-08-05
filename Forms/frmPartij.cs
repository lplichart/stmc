using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mertens.Dao;
using Mertens.BusinessLogic;
using System.Collections;

namespace Mertens.Forms
{
    public partial class frmPartij : Form
    {
        private string partijSoort;
        private Partij partijOnload = null;
        private Partij newPartij = null;
        private ArrayList adresboek = null;
        static frmPartij instance = null;
        static readonly object padlock = new object();

        internal Partij NewPartij
        {
            get { return newPartij; }
            set { newPartij = value; }
        }

        public frmPartij()
        {
            InitializeComponent();
            setupCmbPostcode();
            setupcmbHoedanigheid();
        }

        public static frmPartij Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmPartij();
                    }
                    return instance;
                }
            }
        }

        public string PartijSoort
        {
            get { return partijSoort; }
            set { partijSoort = value; }
        }

        private void setupCmbPostcode()
        {
            foreach (Object o in frmDetails.Instance.cmbPvdsPostcode.Items)
            {
                cmbPostcode.Items.Add((String)o);
            }
        }
        private void setupcmbHoedanigheid()
        {
            foreach (Object o in HoedanigheidDao.Instance.getHoedanigheden())
            {
                cmbHoedanigheid.Items.Add((String)o);
            }
        }
        private void frmPartij_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            handleClosing();
        }

        private void handleClosing()
        {
            NewPartij = new Partij();
            NewPartij.Naam = txtNaam.Text;
            NewPartij.Adres = txtAdres.Text;
            if (cmbPostcode.SelectedItem != null) NewPartij.Postcode = cmbPostcode.SelectedItem.ToString(); else NewPartij.Postcode = "";
            if (cmbGemeente.SelectedItem != null) NewPartij.Gemeente = cmbGemeente.SelectedItem.ToString(); else NewPartij.Gemeente = "";
            if (cmbHoedanigheid.Visible == true)
            {
                NewPartij.Hoedanigheid = cmbHoedanigheid.Text;
            }
            else
            {
                if (txtHoedanigheid.Visible == true) NewPartij.Hoedanigheid = txtHoedanigheid.Text;
            }

            NewPartij.ContactPersoon = txtContactpersoon.Text;
            NewPartij.Email = txtEmail.Text;
            NewPartij.Tel = txtTelefoon.Text;
            NewPartij.Fax = txtFax.Text;
            NewPartij.Gsm = txtGsm.Text;
            NewPartij.Referentie = txtReferentie.Text;

            if (partijOnload != null)
            {
                NewPartij.Id = partijOnload.Id;
                NewPartij.Type = partijOnload.Type;
                NewPartij.Hoofdpartij_id = partijOnload.Hoofdpartij_id;

                if (!partijOnload.Equals(NewPartij))
                {
                    if (PartijDao.Instance.getPartij(partijOnload) != null)
                    {
                        PartijDao.Instance.updatePartij(NewPartij);
                        frmDetails.Instance.initialiseerPartijInfo();
                        MessageBox.Show("Gegevens werden opgeslagen", "Melding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kon de gegevens van de partij niet aanpassen omdat iemand de gegevens al gewijzigd of verwijderd heeft!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        this.Hide();
                        frmDetails.Instance.initialiseerPartijInfo();
                    }
                }
                this.Hide();
            }
            else
            {
                if (cmbHoedanigheid.Visible == false)
                {
                    if (newPartij.Naam.Trim().Equals("")) MessageBox.Show("Geef ten minste de naam van de partij!", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    else
                    {
                        DialogResult result = MessageBox.Show("Wilt u de nieuwe partij toevoegen", "Partij Toevoegen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result.ToString().Equals("Yes"))
                        {
                            newPartij.Type = frmDetails.Instance.SelectedPartijTypeId;
                            PartijDao.Instance.createPartij(frmDetails.Instance.SelectedDossierId, NewPartij);
                            frmDetails.Instance.initialiseerPartijInfo();
                            MessageBox.Show("Gegevens werden opgeslagen", "Melding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        else
                        {
                            this.Hide();
                        }
                    }
                }
                else
                {
                    if (newPartij.Naam.Trim().Equals("")) MessageBox.Show("Geef ten minste de naam van de gerelateerde partij!", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    else
                    {
                        DialogResult result = MessageBox.Show("Wilt u de gerelateerde partij toevoegen", "Partij Toevoegen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result.ToString().Equals("Yes"))
                        {
                            newPartij.Type = frmDetails.Instance.SelectedPartijTypeId;
                            if (newPartij.Type < 5)
                            {
                                newPartij.Type += 3;
                            }
                            newPartij.Hoofdpartij_id = frmDetails.Instance.SelectedHoofdpartijId;
                            PartijDao.Instance.createPartij(frmDetails.Instance.SelectedDossierId, NewPartij);
                            frmDetails.Instance.initialiseerPartijInfo();
                            MessageBox.Show("Gegevens werden opgeslagen", "Melding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        else
                        {
                            this.Hide();
                        }
                    }
                }
            }

        }
        private void cmbPostcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGemeente.SelectedIndex = -1;
            cmbGemeente.Text.Remove(0, cmbGemeente.Text.Length);
            cmbGemeente.Items.Clear();

            if (cmbPostcode.SelectedIndex != -1)
            {
                foreach (Object o in GemeenteDao.Instance.getGemeentenByPostcode(int.Parse(cmbPostcode.SelectedItem.ToString())))
                {
                    cmbGemeente.Items.Add((String)o);
                }

                if (cmbGemeente.Items.Count == 1)
                {
                    cmbGemeente.SelectedIndex = 0;
                }
                else
                {
                    if (partijOnload != null && !partijOnload.Gemeente.Trim().Equals("") && partijOnload.Postcode.Equals(cmbPostcode.SelectedItem.ToString()))
                    {
                        cmbGemeente.SelectedIndex = cmbGemeente.Items.IndexOf(partijOnload.Gemeente);
                    }
                    else
                    {
                        if (ckbAdresboek.Checked == false)
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

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (partijOnload == null)
            {
                NewPartij = new Partij();
                NewPartij.Naam = txtNaam.Text;
                NewPartij.Adres = txtAdres.Text;
                if (cmbPostcode.SelectedItem != null) NewPartij.Postcode = cmbPostcode.SelectedItem.ToString(); else NewPartij.Postcode = "";
                if (cmbGemeente.SelectedItem != null) NewPartij.Gemeente = cmbGemeente.SelectedItem.ToString(); else NewPartij.Gemeente = "";
                NewPartij.ContactPersoon = txtContactpersoon.Text;
                if (cmbHoedanigheid.SelectedItem != null) NewPartij.Hoedanigheid = cmbHoedanigheid.SelectedItem.ToString(); else NewPartij.Hoedanigheid = "";
                NewPartij.Tel = txtTelefoon.Text;
                NewPartij.Fax = txtFax.Text;
                NewPartij.Gsm = txtGsm.Text;
                NewPartij.Email = txtEmail.Text;
            }
        }

        private void frmPartij_VisibleChanged(object sender, EventArgs e)
        {
            if (frmPartij.Instance.Visible == true)
            {
                if (frmDetails.Instance.SelectedPartij != null)
                {
                    partijOnload = frmDetails.Instance.SelectedPartij;
                    ckbAdresboek.Checked = false;
                    setFields();
                    Partij x = PartijDao.Instance.getPartij(partijOnload);
                }
                else clearfields();
                ckbAdresboek.Checked = false;
            }
        }

        private void clearfields()
        {
            txtNaam.Text = "";
            txtAdres.Text = "";
            cmbPostcode.SelectedIndex = -1;
            cmbPostcode.Text = "";
            cmbGemeente.SelectedIndex = -1;
            cmbGemeente.Text = "";
            cmbHoedanigheid.SelectedIndex = -1;
            cmbHoedanigheid.Text = "";
            txtHoedanigheid.Text = "";
            txtContactpersoon.Text = "";
            txtTelefoon.Text = "";
            txtFax.Text = "";
            txtGsm.Text = "";
            txtEmail.Text = "";
            txtReferentie.Text = "";
            partijOnload = null;
        }

        private void setFields()
        {
            txtNaam.Text = partijOnload.Naam;
            txtAdres.Text = partijOnload.Adres;
            cmbPostcode.SelectedIndex = cmbPostcode.Items.IndexOf(partijOnload.Postcode);
            txtContactpersoon.Text = partijOnload.ContactPersoon;
            txtEmail.Text = partijOnload.Email;
            txtTelefoon.Text = partijOnload.Tel;
            txtFax.Text = partijOnload.Fax;
            txtGsm.Text = partijOnload.Gsm;

            if (partijOnload.Hoofdpartij_id == 0)
            {
                switchToHoofdPartij();
                txtHoedanigheid.Text = partijOnload.Hoedanigheid;
            }
            else
            {
                switchToRelated();

                for (int i = 0; i < cmbHoedanigheid.Items.Count; i++)
                {
                    if (cmbHoedanigheid.Items[i].ToString().ToLower().Equals(partijOnload.Hoedanigheid.ToLower())) cmbHoedanigheid.SelectedIndex = i;
                }
            }

            txtReferentie.Text = partijOnload.Referentie;
        }

        public void switchToHoofdPartij()
        {
            cmbHoedanigheid.Visible = false;
            txtHoedanigheid.Visible = true;

        }
        public void switchToRelated()
        {
            cmbHoedanigheid.Visible = true;
            txtHoedanigheid.Visible = false;
        }

        private void btnOpslaan_Click_1(object sender, EventArgs e)
        {
            handleClosing();
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bent u zeker dat u de partij wilt verwijderen", "Partij Verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.ToString().Equals("Yes"))
            {
                if (PartijDao.Instance.getPartij(partijOnload) != null)
                {
                    PartijDao.Instance.deletePartij(partijOnload);
                    frmDetails.Instance.initialiseerPartijInfo();
                    //MessageBox.Show("Partij werd verwijderd", "Melding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    partijOnload = null;
                    frmDetails.Instance.SelectedPartij = null;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kon de partij niet verwijderen omdat iemand de gegevens al gewijzigd of verwijderd heeft!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    this.Hide();
                    frmDetails.Instance.initialiseerPartijInfo();
                }
            }
        }

        private void ckbAdresboek_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAdresboek.Checked == true)
            {
                cmbAdresboek.Visible = true;
                findAdressen();
            }

            if (ckbAdresboek.Checked == false)
            {
                cmbAdresboek.Visible = false;
                cmbAdresboek.SelectedIndex = -1;
                cmbAdresboek.SelectedItem = null;
                cmbAdresboek.Text = "";
                cmbAdresboek.Items.Clear();
            }
        }

        public void findAdressen()
        {
            adresboek = AdresboekDao.Instance.getPartijenFromAdresboek();
            cmbAdresboek.Items.Clear();
            foreach (Object o in adresboek)
            {
                Partij adres = (Partij)o;
                cmbAdresboek.Items.Add(adres.Naam);
            }
        }

        private void cmbAdresboek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAdresboek.SelectedIndex != -1)
            {
                foreach (Object o in adresboek)
                {
                    Partij p = (Partij)o;
                    if (cmbAdresboek.SelectedItem.ToString().ToLower().Equals(p.Naam.ToLower()))
                    {
                        txtNaam.Text = p.Naam;
                        txtAdres.Text = p.Adres;
                        for (int i = 0; i < cmbPostcode.Items.Count; i++)
                        {
                            if (cmbPostcode.Items[i].Equals(p.Postcode)) cmbPostcode.SelectedIndex = i;
                        }
                        for (int i = 0; i < cmbGemeente.Items.Count; i++)
                        {
                            if (cmbGemeente.Items[i].Equals(p.Gemeente)) cmbGemeente.SelectedIndex = i;
                        }
                        txtTelefoon.Text = p.Tel;
                        txtFax.Text = p.Fax;
                        txtEmail.Text = p.Email;
                    }
                }
            }
        }
    }
}
