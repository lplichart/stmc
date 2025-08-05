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
    public partial class frmZoek : Form
    {
        static frmZoek instance = null;
        static readonly object padlock = new object();
        public frmZoek()
        {
            InitializeComponent();
            foreach (var item in frmDetails.Instance.cmbPvdsPostcode.Items)
            {
                cmbPvdsPostcode.Items.Add((string)item);
                cmbPostcode.Items.Add((string)item);
            }

            foreach (var item in HoedanigheidDao.Instance.getHoedanigheden())
            {
                cmbHoedanigheid.Items.Add((string)item);
            }

        }

        public static frmZoek Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmZoek();
                    }
                    return instance;
                }
            }
        }

        private void frmZoek_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void cmbPvdsPostcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPvdsGemeente.SelectedIndex = -1;
            cmbPvdsGemeente.Text.Remove(0, cmbPvdsGemeente.Text.Length);
            cmbPvdsGemeente.Items.Clear();

            if (cmbPvdsPostcode.SelectedIndex != -1)
            {
                foreach (Object o in GemeenteDao.Instance.getGemeentenByPostcode(int.Parse(cmbPvdsPostcode.SelectedItem.ToString())))
                {
                    cmbPvdsGemeente.Items.Add((String)o);
                }

                if (cmbPvdsGemeente.Items.Count == 1)
                {
                    cmbPvdsGemeente.SelectedIndex = 0;
                }
                else
                {
                    string message = "Maak zelf een keuze uit:\n";
                    foreach (Object o in cmbPvdsGemeente.Items)
                    {
                        message += "\n";
                        message += "- " + (String)o;
                    }
                    MessageBox.Show(message, "Opgelet!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                }

            }
        }

        private void cmbPvdsPostcode_TextChanged(object sender, EventArgs e)
        {
            if (cmbPvdsPostcode.Text.Trim().Equals(""))
            {
                cmbPvdsPostcode.SelectedIndex = -1;
                cmbPvdsGemeente.SelectedIndex = -1;
                cmbPvdsGemeente.Text.Remove(0, cmbPvdsGemeente.Text.Length);
                cmbPvdsGemeente.Items.Clear();
            }
            if (cmbPvdsPostcode.Text.Length == 4)
            {
                cmbPvdsGemeente.SelectedIndex = -1;
                cmbPvdsGemeente.Text = "";
                cmbPvdsPostcode.SelectedIndex = cmbPvdsPostcode.Items.IndexOf(cmbPvdsPostcode.Text);
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

        private void cmbPostcode_TextChanged(object sender, EventArgs e)
        {
            if (cmbPostcode.Text.Trim().Equals(""))
            {
                cmbPostcode.SelectedIndex = -1;
                cmbPvdsGemeente.SelectedIndex = -1;
                cmbPvdsGemeente.Text.Remove(0, cmbPvdsGemeente.Text.Length);
                cmbPvdsGemeente.Items.Clear();
            }
            if (cmbPostcode.Text.Length == 4)
            {
                cmbPvdsGemeente.SelectedIndex = -1;
                cmbPvdsGemeente.Text = "";
                cmbPostcode.SelectedIndex = cmbPostcode.Items.IndexOf(cmbPostcode.Text);
            }

        }


        private void btnZoek_Click(object sender, EventArgs e)
        {
            string hoofdquery = "SELECT * FROM dossier WHERE ";
            string subquery = "";
            string x = txtPvdsDatum.Text.Trim();

            if (!txtReferentie.Text.Trim().Equals("")) hoofdquery += "referentie_maatschappij LIKE \'%" + txtReferentie.Text + "%\' "; else hoofdquery += "(referentie_maatschappij LIKE \'%\' OR referentie_maatschappij IS NULL) ";
            if (!txtPvdsDatum.Text.Trim().Equals("/  /")) hoofdquery += "AND pvds_datum LIKE \'%" + txtPvdsDatum.Text + "%\' "; else hoofdquery += "AND (pvds_datum LIKE \'%\' OR  pvds_datum IS NULL) ";
            if (!txtPvdsNaam.Text.Trim().Equals("")) hoofdquery += "AND pvds_naam LIKE \'%" + txtPvdsNaam.Text + "%\' "; else hoofdquery += "AND (pvds_naam LIKE \'%\' OR pvds_naam IS NULL) ";
            if (!txtPvdsStraat.Text.Trim().Equals("")) hoofdquery += "AND pvds_straat LIKE \'%" + txtPvdsStraat.Text + "%\' "; else hoofdquery += "AND (pvds_straat LIKE \'%\' OR pvds_straat IS NULL) ";
            if (!txtPvdsNr.Text.Trim().Equals("")) hoofdquery += "AND pvds_nr LIKE \'%" + txtPvdsNr.Text + "%\' "; else hoofdquery += "AND (pvds_nr LIKE \'%\' OR pvds_nr IS NULL) ";
            if (!cmbPvdsPostcode.Text.Trim().Equals("")) hoofdquery += "AND pvds_postcode LIKE \'%" + cmbPvdsPostcode.Text + "%\' "; else hoofdquery += "AND (pvds_postcode LIKE \'%\' OR pvds_postcode IS NULL) ";
            if (!cmbPvdsGemeente.Text.Trim().Equals("")) hoofdquery += "AND pvds_gemeente LIKE \'%" + cmbPvdsGemeente.Text + "%\' "; else hoofdquery += "AND (pvds_gemeente LIKE \'%\' OR pvds_gemeente IS NULL)  ";

            if (!txtNaam.Text.Trim().Equals("") || !txtAdres.Text.Trim().Equals("") || !cmbPostcode.Text.Trim().Equals("") || !cmbGemeente.Text.Trim().Equals("") || !txtContactpersoon.Text.Trim().Equals("") || !cmbHoedanigheid.Text.Trim().Equals(""))
            {
                hoofdquery += " AND id IN ";
                subquery = "Select dossier_id FROM partij WHERE ";
                if (!txtNaam.Text.Trim().Equals("")) subquery += "naam LIKE \'%" + txtNaam.Text + "%\' "; else subquery += "(naam LIKE \'%\' OR naam IS NULL) ";
                if (!txtAdres.Text.Trim().Equals("")) subquery += "AND adres LIKE \'%" + txtAdres.Text + "%\' "; else subquery += "AND (adres LIKE \'%\' OR adres IS NULL) ";
                if (!cmbPostcode.Text.Trim().Equals("")) subquery += "AND postcode LIKE \'%" + cmbPostcode.Text + "%\' "; else subquery += "AND (postcode LIKE \'%\' OR postcode IS NULL) ";
                if (!cmbGemeente.Text.Trim().Equals("")) subquery += "AND gemeente LIKE \'%" + cmbGemeente.Text + "%\' "; else subquery += "AND (gemeente LIKE \'%\' OR gemeente IS NULL) ";
                if (!txtContactpersoon.Text.Trim().Equals("")) subquery += "AND contact LIKE \'%" + txtContactpersoon.Text + "%\' "; else subquery += "AND (contact LIKE \'%\' OR contact IS NULL) ";
                if (!cmbHoedanigheid.Text.Trim().Equals("")) subquery += "AND hoedanigheid LIKE \'%" + cmbHoedanigheid.Text + "%\' "; else subquery += "AND (hoedanigheid LIKE \'%\' OR hoedanigheid IS NULL) ";
                hoofdquery += "(" + subquery + ") ";
            }

            if (!txtReferentie.Text.Trim().Equals("")) hoofdquery += "OR id in (select dossier_id from partij where referentie like \'%" + txtReferentie.Text + "%\');";

            //frmOverview.Instance.buildListView("select * from dossier where referentie_maatschappij like \'%" + txtReferentie.Text + "%\' OR id in (select dossier_id from partij where referentie like \'%" + txtReferentie.Text + "%\');");

            frmOverview.Instance.buildListView(hoofdquery);

            txtReferentie.Text = "";
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReferentie.Text = "";
            txtPvdsNaam.Text = ""; ;
            txtPvdsStraat.Text = "";
            txtPvdsNr.Text = "";
            cmbPvdsPostcode.Text = "";
            cmbPvdsGemeente.Text = "";
            txtPvdsDatum.Text = "";
            txtNaam.Text = "";
            txtAdres.Text = "";
            cmbPostcode.Text = "";
            cmbGemeente.Text = "";
            txtContactpersoon.Text = "";
            cmbHoedanigheid.Text = "";
        }
    }
}
