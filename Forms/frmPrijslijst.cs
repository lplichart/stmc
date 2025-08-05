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
    public partial class frmPrijslijst : Form
    {
        static frmPrijslijst instance = null;
        static readonly object padlock = new object();
        private ArrayList onkosten;
        private ArrayList erelonen;
        private Boolean pageload = true;

        public frmPrijslijst()
        {
            InitializeComponent();
        }

        public static frmPrijslijst Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmPrijslijst();
                    }
                    return instance;
                }
            }
        }

        private void dgvErelonen_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                fillErelonen();
                fillOnkosten();
                pageload = false;
            }

            if (this.Visible == false)
            {
                pageload = true;
            }
        }

        private void fillErelonen()
        {
            this.erelonen = PrijslijstDao.Instance.getPriceListErelonen();
            dgvErelonen.Rows.Clear();
            foreach (Object o in erelonen)
            {
                KostDetail detail = (KostDetail)o;
                dgvErelonen.Rows.Add(detail.Omschrijving, detail.Prijslaag.ToString(), detail.Prijsmedium.ToString(), detail.Prijshoog.ToString());
            }
        }

        private void fillOnkosten()
        {
            this.onkosten = PrijslijstDao.Instance.getPriceListOnkosten();
            dgvOnkosten.Rows.Clear();
            foreach (Object o in onkosten)
            {
                KostDetail detail = (KostDetail)o;
                dgvOnkosten.Rows.Add(detail.Omschrijving, detail.Prijslaag.ToString(), detail.Prijsmedium.ToString(), detail.Prijshoog.ToString());
            }
        }

        private void dgvErelonen_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!pageload)
            {
                int rij = e.RowIndex;
                int kolom = e.ColumnIndex;

                KostDetail oldDetail = (KostDetail)erelonen[rij];
                KostDetail newDetail = new KostDetail();
                newDetail.Id = oldDetail.Id;
                newDetail.Type = oldDetail.Type;
                newDetail.Omschrijving = dgvErelonen[0, rij].Value.ToString();
                float number;
                if (float.TryParse(dgvErelonen[1, rij].Value.ToString(), out number)) newDetail.Prijslaag = (float)Math.Round(number, 2);
                else
                {
                    MessageBox.Show("Gelieve een cijfer voor de prijs op te geven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fillErelonen();
                    return;
                }

                if (float.TryParse(dgvErelonen[2, rij].Value.ToString(), out number)) newDetail.Prijsmedium = (float)Math.Round(number, 2);
                else
                {
                    MessageBox.Show("Gelieve een cijfer voor de prijsmedium op te geven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fillErelonen();
                    return;
                }

                if (float.TryParse(dgvErelonen[3, rij].Value.ToString(), out number)) newDetail.Prijshoog = (float)Math.Round(number, 2);
                else
                {
                    MessageBox.Show("Gelieve een cijfer voor de prijshoog op te geven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fillErelonen();
                    return;
                }

                if (!newDetail.Equals(oldDetail))
                {
                    if (!oldDetail.Equals(PrijslijstDao.Instance.getKostDetailById(oldDetail.Id)))
                    {
                        MessageBox.Show("Kon de kost niet updaten in de databank omdat iemand anders ze al heeft aangepast.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fillErelonen();
                    }
                    else
                    {
                        PrijslijstDao.Instance.updateKostDetail(newDetail);
                        this.erelonen = PrijslijstDao.Instance.getPriceListErelonen();
                    }
                }
            }
        }

        private void frmPrijslijst_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                if (msg.WParam.ToInt32() == (int)Keys.Escape)
                {
                    this.Close();
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Key Overrided Events Error:" + Ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void dgvOnkosten_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!pageload)
            {
                int rij = e.RowIndex;
                int kolom = e.ColumnIndex;

                KostDetail oldDetail = (KostDetail)onkosten[rij];
                KostDetail newDetail = new KostDetail();
                newDetail.Id = oldDetail.Id;
                newDetail.Type = oldDetail.Type;
                newDetail.Omschrijving = dgvOnkosten[0, rij].Value.ToString();
                float number;
                if (float.TryParse(dgvOnkosten[1, rij].Value.ToString(), out number)) newDetail.Prijslaag = (float)Math.Round(number, 2);
                else
                {
                    MessageBox.Show("Gelieve een cijfer voor de prijs op te geven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fillOnkosten();
                    return;
                }

                if (float.TryParse(dgvOnkosten[2, rij].Value.ToString(), out number)) newDetail.Prijsmedium = (float)Math.Round(number, 2);
                else
                {
                    MessageBox.Show("Gelieve een cijfer voor de prijsmedium op te geven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fillOnkosten();
                    return;
                }

                if (float.TryParse(dgvOnkosten[3, rij].Value.ToString(), out number)) newDetail.Prijshoog = (float)Math.Round(number, 2);
                else
                {
                    MessageBox.Show("Gelieve een cijfer voor de prijshoog op te geven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fillOnkosten();
                    return;
                }

                if (!newDetail.Equals(oldDetail))
                {
                    if (!oldDetail.Equals(PrijslijstDao.Instance.getKostDetailById(oldDetail.Id)))
                    {
                        MessageBox.Show("Kon de kost niet updaten in de databank omdat iemand anders ze al heeft aangepast.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fillOnkosten();
                    }
                    else
                    {
                        PrijslijstDao.Instance.updateKostDetail(newDetail);
                        this.onkosten = PrijslijstDao.Instance.getPriceListOnkosten();
                    }
                }
            }

        }

    }
}
