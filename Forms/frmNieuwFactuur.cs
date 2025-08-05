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
using System.Collections;

namespace Mertens.Forms
{
    public partial class frmNieuwFactuur : Form
    {
        static frmNieuwFactuur instance = null;
        static readonly object padlock = new object();
        private Factuur factuur = null;
        private string factuurnummer = "";
        private KostDetail index;
        private Prestatie prestatie;
        private Boolean pageLoad = true;
        ArrayList kosten;

        public string Factuurnummer
        {
            get { return factuurnummer; }
            set { factuurnummer = value; }
        }

        public frmNieuwFactuur()
        {
            InitializeComponent();
        }

        public static frmNieuwFactuur Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmNieuwFactuur();
                    }
                    return instance;
                }
            }
        }

        private void frmNieuwFactuur_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                pageLoad = true;
                this.WindowState = FormWindowState.Maximized;
                factuur = new Factuur();
                setFactuurnummer();
                txtDatum.Text = DateTime.Now.ToShortDateString();
                index = PrijslijstDao.Instance.getKostDetailByOmschrijving("administratie & secretariaat");
                txtIndex.Text = index.Prijsmedium.ToString();
                prestatie = frmPrestatie.Instance.PrestatieVoorForm;
                fillKosten();
            }
            if (this.Visible == false)
            {
                pageLoad = true;
            }
        }

        private void setFactuurnummer()
        {
            factuurnummer = FactuurDao.Instance.getLatestFactuurNummer();
            string reference = frmDetails.Instance.SelectedReference;
            if (factuurnummer.Equals(""))
            {
                Factuurnummer = DateTime.Now.Year.ToString() + "/0001";
                txtFactuurnummer.Text = factuurnummer;
                cmbExpert.SelectedIndex = cmbExpert.Items.IndexOf(reference.Substring(reference.Length - 1, 1));
            }
            else
            {
                string prefix = Factuurnummer.Substring(0, 5);
                int nr = +int.Parse(Factuurnummer.Substring(5, Factuurnummer.Length -5));
                nr++;
                string suffix = "";
                switch (nr.ToString().Length)
                {
                    case 1: suffix = "000" + nr.ToString(); break;
                    case 2: suffix = "00" + nr.ToString(); break;
                    case 3: suffix = "0" + nr.ToString(); break;
                    case 4: suffix = nr.ToString(); break; //The invoice number is already 1000 or more

                }

                Factuurnummer = prefix + "" + suffix;
                txtFactuurnummer.Text = factuurnummer;
                cmbExpert.SelectedIndex = cmbExpert.Items.IndexOf(reference.Substring(reference.Length - 1, 1));
            }
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bent u zeker dat u een factuur wilt maken gebaseerd op dit factuurdetail?\n\nOpgelet hierna wordt het prestatieblad vernieuwd en zijn verdere wijzigingen onmogelijk!", "Factuur maken?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result.ToString().Equals("Yes"))
            {

                if (txtFactuurnummer.Text.Length != 9)
                {
                    MessageBox.Show("Dit is geen geldig factuurnummer", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmbExpert.Text == "" && !cmbExpert.Items.Contains(cmbExpert.Text))
                {
                    MessageBox.Show("Dit is geen geldige expert", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // De kost: onvoorziene kost en indexering wordt gecreeerd. Deze moet aangepast kunnen worden per dossier. 
                    // Het percentage in de pagina is standaard het percentage dat in de databank staat maar de effectieve kost die 
                    // wordt toegevoegd is gebaseerd op het percentage uit de pagina.
                    float percent;
                    if (float.TryParse(txtIndex.Text.ToString(), out percent)) percent = (float)Math.Round(percent / 100, 3);
                    else
                    {
                        MessageBox.Show("U gaf een foutief percentage voor onvoorziene kost en indexering", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    KostDao.Instance.createKost(new Kost(prestatie.Id, 'E', DateTime.Now.ToShortDateString(), "administratie & secretariaat (erelonen)", "", prestatie.TotaalErelonen, percent, 0, "KOS"));
                    KostDao.Instance.createKost(new Kost(prestatie.Id, 'O', DateTime.Now.ToShortDateString(), "administratie & secretariaat (onkosten)", "", prestatie.TotaalOnkosten, percent, 0, "KOS"));
                    frmPrestatie.Instance.buildDgv("KOS");
                    frmPrestatie.Instance.setTotalen();
                    prestatie = frmPrestatie.Instance.PrestatieVoorForm;
                    Factuur factuur = new Factuur();
                    factuur.Datum = txtDatum.Text;
                    factuur.Factuurnummer = txtFactuurnummer.Text;
                    factuur.Referentie = frmDetails.Instance.SelectedReference;
                    factuur.Erelonen = prestatie.TotaalErelonen;
                    factuur.Onkosten = prestatie.TotaalOnkosten;
                    factuur.Btw = prestatie.TotaalBtw;
                    factuur.Totaal = factuur.Erelonen + factuur.Onkosten + factuur.Btw;
                    factuur.Prestatie_id = prestatie.Id;
                    factuur.Expert = cmbExpert.Text[0];
                    try
                    {
                        if (FactuurDao.Instance.factuurExists(factuur.Factuurnummer))
                        {
                            result = MessageBox.Show("Er bestaat al een factuur met EENZELFDE FACTUURNUMMER!\n\nWilt u toch het factuur maken? Dit wil zeggen dat er 2 facturen met eenzelfde factuurnummer zullen bestaan!", "Factuur maken?", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            if (result.ToString().Equals("Yes"))
                            {
                                FactuurDao.Instance.createFactuur(factuur);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            FactuurDao.Instance.createFactuur(factuur);
                        }
                        
                    }
                    catch { MessageBox.Show("Er liep iets mis bij het aanmaken van het factuur", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    ExcelBuilder builder = new ExcelBuilder();
                    string reference = factuur.Referentie;
                    Dossier dossier = DossierDao.Instance.getDossierByReference(reference);
                    int maatschappijId = DossierDao.Instance.getMaatschappijIdFromDossier(reference);
                    Maatschappij maatschappij = MaatschappijDao.Instance.getMaatschappijById(maatschappijId);
                    builder.buildFactuur(dossier, maatschappij, prestatie, factuur);

                    Prestatie newPrestatie = new Prestatie();
                    newPrestatie.DossierId = frmPrestatie.Instance.PrestatieVoorForm.DossierId;
                    newPrestatie.Werkdatum = DateTime.Now.ToString("dd/MM/yyyy"); ;
                    newPrestatie.Herinnerdatum = "";
                    newPrestatie.Btw = 21;
                    newPrestatie.TotaalErelonen = 0;
                    newPrestatie.TotaalOnkosten = 0;
                    newPrestatie.TotaalBtw = 0;
                    newPrestatie.Historiek = frmPrestatie.Instance.PrestatieVoorForm.Historiek + factuur.Datum + " " + "factuur" + "\t" + "Factuur " + factuur.Factuurnummer + " " + "\n"; ;
                    newPrestatie.Tariefniveau = "medium";
                    newPrestatie.Openstaand = true;

                    this.Hide();
                    frmPrestatie.Instance.Hide();

                    PrestatieDao.Instance.deletePrestatie(frmPrestatie.Instance.PrestatieVoorForm.Id);

                    PrestatieDao.Instance.createNewPrestatie(newPrestatie);
                    prestatie = PrestatieDao.Instance.getOpenstaandePrestatie(frmPrestatie.Instance.PrestatieVoorForm.DossierId);

                    Kost kost = new Kost();
                    kost.PrestatieId = PrestatieDao.Instance.getLatestPrestatie(frmPrestatie.Instance.PrestatieVoorForm.DossierId);
                    kost.Type = 'O';
                    kost.Datum = DateTime.Now.ToShortDateString();
                    kost.Omschrijving = "facturatiekosten + nazicht";
                    kost.Commentaar = "Nazicht Facturatie";
                    kost.Hoeveelheid = 1;
                    String tariefNiveau = frmPrestatie.Instance.PrestatieVoorForm.Tariefniveau;
                    if (tariefNiveau.Equals("laag")) kost.Eenheidsprijs = PrijslijstDao.Instance.getKostDetailByOmschrijving("facturatiekosten + nazicht").Prijslaag;
                    if (tariefNiveau.Equals("medium")) kost.Eenheidsprijs = PrijslijstDao.Instance.getKostDetailByOmschrijving("facturatiekosten + nazicht").Prijsmedium;
                    if (tariefNiveau.Equals("hoog")) kost.Eenheidsprijs = PrijslijstDao.Instance.getKostDetailByOmschrijving("facturatiekosten + nazicht").Prijshoog;
                    kost.setTotaal();
                    kost.HoofdKostId = 0;
                    kost.KostenPost = "KOS";
                    KostDao.Instance.createKost(kost);
                }
            }
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvKostenDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!pageLoad)
            {
                int rij = e.RowIndex;
                int kolom = e.ColumnIndex;

                Kost oldKost = (Kost)kosten[rij];
                Kost newKost = new Kost();
                newKost.Id = oldKost.Id;
                newKost.PrestatieId = oldKost.PrestatieId;
                newKost.Type = oldKost.Type;
                newKost.Datum = oldKost.Datum;
                newKost.Omschrijving = oldKost.Omschrijving;
                newKost.Commentaar = oldKost.Commentaar;
                newKost.HoofdKostId = oldKost.HoofdKostId;
                newKost.KostenPost = oldKost.KostenPost;

                float number;
                if (float.TryParse(dgvKostenDetail[2, rij].Value.ToString(), out number)) newKost.Hoeveelheid = (float)Math.Round(number, 2);
                else
                {
                    MessageBox.Show("Gelieve een cijfer voor de HOEVEELHEID op te geven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fillKosten();
                    return;
                }

                if (float.TryParse(dgvKostenDetail[3, rij].Value.ToString(), out number)) newKost.Eenheidsprijs = (float)Math.Round(number, 2);
                else
                {
                    MessageBox.Show("Gelieve een cijfer voor de EENHEIDSPRIJS op te geven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fillKosten();
                    return;
                }
                newKost.setTotaal();
                if (!newKost.Equals(oldKost))
                {
                    if (!oldKost.Equals(KostDao.Instance.getKostById(oldKost.Id)))
                    {
                        MessageBox.Show("Kon de kost niet updaten in de databank omdat iemand anders ze al heeft aangepast.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fillKosten();
                    }
                    else
                    {
                        KostDao.Instance.updateKost(newKost);
                        this.kosten = KostDao.Instance.getKostenByPrestatie(prestatie.Id);
                        pageLoad = true;
                        fillKosten();
                        frmPrestatie.Instance.buildDgv(newKost.KostenPost);
                        frmPrestatie.Instance.setTotalen();
                    }
                }
            }
        }

        private void fillKosten()
        {
            dgvKostenDetail.Rows.Clear();
            kosten = KostDao.Instance.getKostenByPrestatie(prestatie.Id);
            foreach (Object o in kosten)
            {
                Kost kost = (Kost)o;
                dgvKostenDetail.Rows.Add(kost.Datum, kost.Omschrijving, kost.Hoeveelheid.ToString(), kost.Eenheidsprijs.ToString(), kost.Totaal.ToString());
            }
            setTotalen();
            pageLoad = false;
        }

        private void setTotalen()
        {
            float totaalExclBtw =(float) Math.Round((prestatie.TotaalOnkosten + prestatie.TotaalErelonen)*(1+index.Prijsmedium/100),2);
            float btw = (float) Math.Round((totaalExclBtw/100)*21,2);
            float totaalInclBtw = (float) Math.Round(totaalExclBtw + btw,2);

            txtExclBtw.Text = totaalExclBtw.ToString();
            txtBtw.Text = btw.ToString();
            txtInclBtw.Text = totaalInclBtw.ToString();

        }

        private void txtIndex_TextChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                float number = 0;

                if (!float.TryParse(txtIndex.Text, out number))
                {
                    if (txtIndex.Text.Equals(""))
                    {
                        number = 0;
                    }
                    else
                    {
                        MessageBox.Show("Gelieve een cijfer voor de INDEX op te geven ", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtIndex.Text = index.Prijsmedium.ToString();
                        setTotalen();
                        return;
                    }
                }

                index.Prijsmedium = number;
                index.Prijslaag = number;
                index.Prijshoog = number;
                setTotalen();
            }
        }

        private void frmNieuwFactuur_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frmNieuwFactuur_Load(object sender, EventArgs e)
        {

        }
    }
}
