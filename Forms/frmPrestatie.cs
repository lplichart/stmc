using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mertens.Dao;
using System.Collections;
using Mertens.BusinessLogic;

namespace Mertens.Forms
{
    public partial class frmPrestatie : Form
    {

        static frmPrestatie instance = null;
        static readonly object padlock = new object();
        private Dictionary<string, float> tarieflijst;
        private ArrayList erelonen;
        private ArrayList onkosten;
        private ArrayList plaatsbezoekKosten;
        private ArrayList dactylografieKosten;
        private ArrayList inkomendeInformatieKosten;
        private ArrayList variabeleKosten;
        private Prestatie prestatie;
        private Prestatie prestatieOnLoad;


        public frmPrestatie()
        {
            InitializeComponent();
        }
        private void buildTarieflijst(string tariefplan)
        {
            tarieflijst = KostDao.Instance.getTarieven(tariefplan);
            erelonen = KostDao.Instance.getKostOmschrijving('E');
            onkosten = KostDao.Instance.getKostOmschrijving('O');
        }

        public static frmPrestatie Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmPrestatie();
                    }
                    return instance;
                }
            }
        }

        internal Prestatie PrestatieVoorForm
        {
            get { return prestatie; }
            set
            {
                prestatie = value;
                buildTarieflijst(prestatie.Tariefniveau);
                cmbTarief.SelectedIndex = cmbTarief.Items.IndexOf(prestatie.Tariefniveau);
            }
        }

        private void frmPrestatie_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                lblReferentie.Text = frmDetails.Instance.SelectedReference;
                prestatieOnLoad = PrestatieDao.Instance.getPrestatieById(PrestatieVoorForm.Id);
                resetInputFields();
                cmbTarief.SelectedIndex = cmbTarief.Items.IndexOf(prestatie.Tariefniveau);
                txtBtw.Text = PrestatieVoorForm.Btw.ToString();
                buildDgv("PBZ");
                buildDgv("DAC");
                buildDgv("INK");
                buildDgv("KOS");
                setTotalen();
                if (PrestatieVoorForm.Herinnerdatum == null || PrestatieVoorForm.Herinnerdatum.Trim().Equals(""))
                {
                    txtHerinnerDatum.Text = "";
                }
                else
                {
                    txtHerinnerDatum.Text = PrestatieVoorForm.Herinnerdatum;
                }
                if (PrestatieVoorForm.HerinnerCommentaar == null || PrestatieVoorForm.HerinnerCommentaar.Trim().Equals(""))
                {
                    txtHerinnerCommentaar.Text = "";
                }
                else
                {
                    txtHerinnerCommentaar.Text = PrestatieVoorForm.HerinnerCommentaar;
                }
            }
        }

        private void resetInputFields()
        {
            //PLAATSBEZOEK KOST
            txtPbDatum.Text = "";
            txtPbOmschrijving.Text = "";
            txtPbFotos.Text = "0";
            txtPbTijd.Text = "0";
            txtPbKm.Text = "0";
            txtPbReistijd.Text = "0";

            //DACTYLO KOST
            ckbDactStandaard.Checked = false;
            cmbDactSoort.SelectedIndex = 0;
            txtDactDatum.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDactOmschrijving.Text = "";
            txtDactBlz.Text = "0";
            txtDactDigitaal.Text = "0";
            txtDactPost.Text = "0"; ;
            txtDactKopie.Text = "0";
            txtDactAangetekend.Text = "0";
            txtDactVertaling.Text = "0";

            //INKOMENDE 
            cmbInSoort.SelectedIndex = 0;
            txtInDatum.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtInOmschrijving.Text = "";
            txtInHoeveelheid.Text = "1";

            //VARIABELE KOST
            cmbKostSoort.SelectedIndex = -1;
            cmbKostSoort.Text = "";
            txtKostDatum.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtKostCommentaar.Text = "";
            txtKostHoeveelheid.Text = "0";
            txtKostEenheidsprijs.Text = "0";

        }

        public void setTotalen()
        {
            this.PrestatieVoorForm.TotaalErelonen = KostDao.Instance.getTotaal(PrestatieVoorForm.Id, 'E');
            this.PrestatieVoorForm.TotaalOnkosten = KostDao.Instance.getTotaal(PrestatieVoorForm.Id, 'O');
            this.PrestatieVoorForm.TotaalBtw = (float)Math.Round((((this.PrestatieVoorForm.TotaalErelonen + this.PrestatieVoorForm.TotaalOnkosten) / 100) * PrestatieVoorForm.Btw), 2);
            txtTotaalErelonen.Text = PrestatieVoorForm.TotaalErelonen.ToString();
            txtTotaalOnkosten.Text = PrestatieVoorForm.TotaalOnkosten.ToString();
            txtTotaalBtw.Text = PrestatieVoorForm.TotaalBtw.ToString();
            txtTotaal.Text = (PrestatieVoorForm.TotaalErelonen + PrestatieVoorForm.TotaalOnkosten + PrestatieVoorForm.TotaalBtw).ToString();
            if (prestatieOnLoad.Equals(PrestatieDao.Instance.getPrestatieById(PrestatieVoorForm.Id)))
            {
                PrestatieDao.Instance.updatePrestatie(PrestatieVoorForm);
                prestatieOnLoad = PrestatieDao.Instance.getPrestatieById(PrestatieVoorForm.Id);
            }
            else
            {
                MessageBox.Show("Kon het prestatieblad niet updaten in de databank omdat iemand anders reeds aanpassingen maakte aan dit prestatieblad.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                this.Show();
            }

        }

        #region BUILD & FILL DGV
        public void buildDgv(string post)
        {
            switch (post)
            {
                case "PBZ": plaatsbezoekKosten = KostDao.Instance.getKostPerPost(this.PrestatieVoorForm.Id, "PBZ"); fillDgvPlaatsbezoek(); break;

                case "DAC": dactylografieKosten = KostDao.Instance.getKostPerPost(this.PrestatieVoorForm.Id, "DAC"); fillDgvDactylografie(); break;

                case "INK": inkomendeInformatieKosten = KostDao.Instance.getKostPerPost(this.PrestatieVoorForm.Id, "INK"); fillDgvIn(); break;

                case "KOS": variabeleKosten = KostDao.Instance.getKostPerPost(this.PrestatieVoorForm.Id, "KOS"); fillDgvKost(); break;

            }
        }

        private void fillDgvPlaatsbezoek()
        {
            dgvPlaatsbezoek.Rows.Clear();
            ArrayList hoofdKosten = new ArrayList();

            foreach (Object o in plaatsbezoekKosten)
            {
                Kost hoofdkost = (Kost)o;
                if (hoofdkost.HoofdKostId == 0)
                {
                    hoofdKosten.Add(hoofdkost);
                }
            }

            foreach (Object k in hoofdKosten)
            {
                Kost hoofdkost = (Kost)k;
                float fotos = 0;
                float reistijd = 0;
                float verplaatsingen = 0;

                foreach (Object o in plaatsbezoekKosten)
                {
                    Kost kost = (Kost)o;

                    if (kost.HoofdKostId == hoofdkost.Id)
                    {
                        switch (kost.Omschrijving)
                        {
                            case "foto": fotos = kost.Hoeveelheid; break;
                            case "verplaatsingen": verplaatsingen = kost.Hoeveelheid; break;
                            case "reistijd": reistijd = kost.Hoeveelheid; break;
                        }
                    }
                }
                dgvPlaatsbezoek.Rows.Add(hoofdkost.Datum, hoofdkost.Commentaar, fotos, hoofdkost.Hoeveelheid, verplaatsingen, reistijd);
            }
        }

        private void fillDgvDactylografie()
        {
            dgvDactylografie.Rows.Clear();
            ArrayList hoofdKosten = new ArrayList();

            foreach (Object o in dactylografieKosten)
            {
                Kost hoofdkost = (Kost)o;
                if (hoofdkost.HoofdKostId == 0)
                {
                    hoofdKosten.Add(hoofdkost);
                }
            }

            foreach (Object k in hoofdKosten)
            {
                Kost hoofdkost = (Kost)k;
                float digitaal = 0;
                float post = 0;
                float kopie = 0;
                float aangetekend = 0;
                float vertaling = 0;

                foreach (Object o in dactylografieKosten)
                {
                    Kost kost = (Kost)o;
                    if (kost.HoofdKostId == hoofdkost.Id)
                    {
                        switch (kost.Omschrijving)
                        {
                            case "digitaalverzending": digitaal = kost.Hoeveelheid; break;
                            case "postverzending": post = kost.Hoeveelheid; break;
                            case "kopie": kopie = kost.Hoeveelheid; break;
                            case "aangetekende verzending": aangetekend = kost.Hoeveelheid; break;
                            case "vertaling": vertaling = kost.Hoeveelheid; break;
                        }
                    }
                }
                switch (hoofdkost.Omschrijving)
                {
                    case "dactylografie": dgvDactylografie.Rows.Add(true, "BRIEF", hoofdkost.Datum, hoofdkost.Commentaar, hoofdkost.Hoeveelheid, digitaal, post, kopie, aangetekend, vertaling); break;
                    case "brief": dgvDactylografie.Rows.Add(false, "BRIEF", hoofdkost.Datum, hoofdkost.Commentaar, hoofdkost.Hoeveelheid, digitaal, post, kopie, aangetekend, vertaling); break;
                    case "deskundig verslag": dgvDactylografie.Rows.Add(false, "VERSLAG", hoofdkost.Datum, hoofdkost.Commentaar, hoofdkost.Hoeveelheid, digitaal, post, kopie, aangetekend, vertaling); break;
                    case "PV van MS": dgvDactylografie.Rows.Add(false, "PV van MS", hoofdkost.Datum, hoofdkost.Commentaar, hoofdkost.Hoeveelheid, digitaal, post, kopie, aangetekend, vertaling); break;
                }

            }
            return;
        }

        private void fillDgvIn()
        {
            dgvIn.Rows.Clear();

            foreach (Object o in inkomendeInformatieKosten)
            {
                Kost kost = (Kost)o;

                switch (kost.Omschrijving)
                {
                    case "telefoon":
                        dgvIn.Rows.Add("TELEFOON", kost.Datum, kost.Commentaar, kost.Hoeveelheid);
                        break;
                    case "digitaal in":
                        dgvIn.Rows.Add("POST", kost.Datum, kost.Commentaar, kost.Hoeveelheid);
                        break;
                }
            }
        }

        private void fillDgvKost()
        {
            dgvKost.Rows.Clear();

            foreach (Object o in variabeleKosten)
            {
                Kost k = (Kost)o;
                string type = "";
                if (k.Type.Equals('E')) type = "ERELOON";
                if (k.Type.Equals('O')) type = "ONKOST";
                dgvKost.Rows.Add(type, k.Datum, k.Omschrijving, k.Commentaar, k.Hoeveelheid, k.Eenheidsprijs);
            }
        }
        #endregion

        #region ADD KOST BUTTON_CLICK
        private void btnAddPlaatsbezoek_Click(object sender, EventArgs e)
        {
            float parsed = 0;

            if (txtPbDatum.Text.Trim().Equals("") || txtPbDatum.Text.Trim().Length != 10) { MessageBox.Show("Er werd geen geldige DATUM opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtPbTijd.Text.Trim().Equals("") || !float.TryParse(txtPbTijd.Text, out parsed) || txtPbTijd.Text.Trim().Equals("0")) { MessageBox.Show("Er werd geen geldige DUURTIJD van het PLAATSBEZOEK opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtPbFotos.Text.Trim().Equals("") || !float.TryParse(txtPbFotos.Text, out parsed)) { MessageBox.Show("Er werd geen geldige hoeveelheid voor het aantal FOTOS opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtPbKm.Text.Trim().Equals("") || !float.TryParse(txtPbKm.Text, out parsed)) { MessageBox.Show("Er werd geen geldige hoeveelheid voor het aantal AFGELEGDE KM opgegeven\'s", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtPbReistijd.Text.Trim().Equals("") || !float.TryParse(txtPbReistijd.Text, out parsed)) { MessageBox.Show("Er werd geen geldige hoeveelheid REISTIJD opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            float tariefpbz = tarieflijst["plaatsbezoek"];
            float tariefreistijd = tarieflijst["reistijd"];
            float tarieffotos = tarieflijst["foto"];
            float tariefverplaatsingen = tarieflijst["verplaatsingen"];
            Kost pbz = null; ;
            Kost fotos = null;
            Kost reistijd = null;
            Kost verplaatsingen = null;

            pbz = new Kost(this.PrestatieVoorForm.Id, 'E', txtPbDatum.Text, "plaatsbezoek", txtPbOmschrijving.Text, float.Parse(txtPbTijd.Text), tariefpbz, 0, "PBZ");
            KostDao.Instance.createKost(pbz);
            int hoofdKostId = KostDao.Instance.getLatestKostId(this.PrestatieVoorForm.Id);

            if (txtPbReistijd.Text != "0") { reistijd = new Kost(this.PrestatieVoorForm.Id, 'E', txtPbDatum.Text, "reistijd", "", float.Parse(txtPbReistijd.Text), tariefreistijd, hoofdKostId, "PBZ"); KostDao.Instance.createKost(reistijd); }
            if (txtPbFotos.Text != "0") { fotos = new Kost(this.PrestatieVoorForm.Id, 'O', txtPbDatum.Text, "foto", "", float.Parse(txtPbFotos.Text), tarieffotos, hoofdKostId, "PBZ"); KostDao.Instance.createKost(fotos); }
            if (txtPbKm.Text != "0") { verplaatsingen = new Kost(this.PrestatieVoorForm.Id, 'O', txtPbDatum.Text, "verplaatsingen", "", float.Parse(txtPbKm.Text), tariefverplaatsingen, hoofdKostId, "PBZ"); KostDao.Instance.createKost(verplaatsingen); }

            buildDgv("PBZ");
            setTotalen();
            resetInputFields();
            PrestatieVoorForm.Werkdatum = DateTime.Now.ToString("dd/MM/yyyy");
            PrestatieVoorForm.Historiek += txtPbDatum.Text + " " + "plaatsbezoek" + "\t" + txtPbOmschrijving.Text + "\n";
        }

        private void btnAddDactylo_Click(object sender, EventArgs e)
        {
            int hoofdId = 0;
            float parsed = 0;
            Kost dactylografie = null;
            Kost digitaal = null;
            Kost post = null;
            Kost kopie = null;
            Kost aangetekend = null;
            Kost vertaling = null;

            if (txtDactDatum.Text.Trim().Equals("") || txtDactDatum.Text.Trim().Length != 10) { MessageBox.Show("Er werd geen geldige DATUM opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtDactBlz.Text.Trim().Equals("") || !float.TryParse(txtDactBlz.Text, out parsed) || txtDactBlz.Text.Trim().Equals("0")) { MessageBox.Show("Er werd geen geldig aantal BLADZIJDEN opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtDactDigitaal.Text.Trim().Equals("") || !float.TryParse(txtDactDigitaal.Text, out parsed)) { MessageBox.Show("Er werd geen geldig aantal pagina\'s DIGITAAL opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtDactPost.Text.Trim().Equals("") || !float.TryParse(txtDactPost.Text, out parsed)) { MessageBox.Show("Er werd geen geldig aantal pagina\'s voor een POST verzending opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtDactKopie.Text.Trim().Equals("") || !float.TryParse(txtDactKopie.Text, out parsed)) { MessageBox.Show("Er werd geen geldig aantal KOPIE\'s opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtDactAangetekend.Text.Trim().Equals("") || !float.TryParse(txtDactAangetekend.Text, out parsed)) { MessageBox.Show("Er werd geen geldig aantal pagina\'s AANGETEKEND opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtDactVertaling.Text.Trim().Equals("") || !float.TryParse(txtDactVertaling.Text, out parsed)) { MessageBox.Show("Er werd geen geldig aantal pagina\'s voor VERTALING opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            switch (cmbDactSoort.SelectedItem.ToString())
            {
                case "BRIEF":
                    if (ckbDactStandaard.Checked == false)
                    {
                        Kost brief = new Kost(PrestatieVoorForm.Id, 'E', txtDactDatum.Text, "brief", txtDactOmschrijving.Text, float.Parse(txtDactBlz.Text), tarieflijst["brief"], 0, "DAC");
                        KostDao.Instance.createKost(brief);
                        hoofdId = KostDao.Instance.getLatestKostId(this.PrestatieVoorForm.Id);
                        dactylografie = new Kost(PrestatieVoorForm.Id, 'O', txtDactDatum.Text, "dactylografie", txtDactOmschrijving.Text, float.Parse(txtDactBlz.Text), tarieflijst["dactylografie"], hoofdId, "DAC");
                        KostDao.Instance.createKost(dactylografie);
                        PrestatieVoorForm.Historiek += txtDactDatum.Text + " " + "brief" + "\t" + txtDactOmschrijving.Text + "\n";
                    }
                    else
                    {
                        dactylografie = new Kost(PrestatieVoorForm.Id, 'O', txtDactDatum.Text, "dactylografie", txtDactOmschrijving.Text, float.Parse(txtDactBlz.Text), tarieflijst["dactylografie"], 0, "DAC");
                        KostDao.Instance.createKost(dactylografie);
                        hoofdId = KostDao.Instance.getLatestKostId(this.PrestatieVoorForm.Id);
                        PrestatieVoorForm.Historiek += txtDactDatum.Text + " " + "std. brief" + "\t" + txtDactOmschrijving.Text + "\n";
                    }
                    break;
                case "VERSLAG":
                    Kost verslag = new Kost(PrestatieVoorForm.Id, 'E', txtDactDatum.Text, "deskundig verslag", txtDactOmschrijving.Text, float.Parse(txtDactBlz.Text), tarieflijst["deskundig verslag"], 0, "DAC");
                    KostDao.Instance.createKost(verslag);
                    hoofdId = KostDao.Instance.getLatestKostId(this.PrestatieVoorForm.Id);
                    dactylografie = new Kost(PrestatieVoorForm.Id, 'O', txtDactDatum.Text, "dactylografie", txtDactOmschrijving.Text, float.Parse(txtDactBlz.Text), tarieflijst["dactylografie"], hoofdId, "DAC");
                    KostDao.Instance.createKost(dactylografie);
                    PrestatieVoorForm.Historiek += txtDactDatum.Text + " " + "verslag" + "\t" + txtDactOmschrijving.Text + "\n";
                    break;
                case "PV van MS":
                    Kost pv = new Kost(PrestatieVoorForm.Id, 'O', txtDactDatum.Text, "PV van MS", txtDactOmschrijving.Text, float.Parse(txtDactBlz.Text), tarieflijst["PV van MS"], 0, "DAC");
                    KostDao.Instance.createKost(pv);
                    hoofdId = KostDao.Instance.getLatestKostId(this.PrestatieVoorForm.Id);
                    PrestatieVoorForm.Historiek += txtDactDatum.Text + " " + "pv van ms" + "\t" + txtDactOmschrijving.Text + "\n";
                    break;
            }

            if (txtDactDigitaal.Text != "0") { digitaal = new Kost(PrestatieVoorForm.Id, 'O', txtDactDatum.Text, "digitaalverzending", "", float.Parse(txtDactDigitaal.Text), tarieflijst["digitaalverzending"], hoofdId, "DAC"); KostDao.Instance.createKost(digitaal); }
            if (txtDactPost.Text != "0") { post = new Kost(PrestatieVoorForm.Id, 'O', txtDactDatum.Text, "postverzending", "", float.Parse(txtDactPost.Text), tarieflijst["postverzending"], hoofdId, "DAC"); KostDao.Instance.createKost(post); }
            if (txtDactKopie.Text != "0") { kopie = new Kost(PrestatieVoorForm.Id, 'O', txtDactDatum.Text, "kopie", "", float.Parse(txtDactKopie.Text), tarieflijst["kopie"], hoofdId, "DAC"); KostDao.Instance.createKost(kopie); }
            if (txtDactAangetekend.Text != "0") { aangetekend = new Kost(PrestatieVoorForm.Id, 'O', txtDactDatum.Text, "aangetekende verzending", "", float.Parse(txtDactAangetekend.Text), tarieflijst["aangetekende verzending"], hoofdId, "DAC"); KostDao.Instance.createKost(aangetekend); }
            if (txtDactVertaling.Text != "0") { vertaling = new Kost(PrestatieVoorForm.Id, 'O', txtDactDatum.Text, "vertaling", "", float.Parse(txtDactVertaling.Text), tarieflijst["vertaling"], hoofdId, "DAC"); KostDao.Instance.createKost(vertaling); }

            resetInputFields();
            setTotalen();
            buildDgv("DAC");
            PrestatieVoorForm.Werkdatum = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnAddIn_Click(object sender, EventArgs e)
        {
            float parsed = 0;

            if (txtInDatum.Text.Trim().Equals("") || txtInDatum.Text.Trim().Length != 10) { MessageBox.Show("Er werd geen geldige DATUM opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtInHoeveelheid.Text.Trim().Equals("") || !float.TryParse(txtInHoeveelheid.Text, out parsed) || txtInHoeveelheid.Text.Trim().Equals("0")) { MessageBox.Show("Er werd geen geldige HOEVEELHEID opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            switch (cmbInSoort.SelectedItem.ToString())
            {
                case "TELEFOON":
                    Kost telefoon = new Kost(PrestatieVoorForm.Id, 'O', txtInDatum.Text, "telefoon", txtInOmschrijving.Text, float.Parse(txtInHoeveelheid.Text), tarieflijst["telefoon"], 0, "INK");
                    KostDao.Instance.createKost(telefoon);
                    PrestatieVoorForm.Historiek += txtInDatum.Text + " " + "telefoon" + "\t" + txtInOmschrijving.Text + "\n";
                    break;
                case "POST":
                    Kost post = new Kost(PrestatieVoorForm.Id, 'O', txtInDatum.Text, "digitaal in", txtInOmschrijving.Text, float.Parse(txtInHoeveelheid.Text), tarieflijst["digitaal in"], 0, "INK");
                    KostDao.Instance.createKost(post);
                    break;
            }

            resetInputFields();
            setTotalen();
            buildDgv("INK");
            PrestatieVoorForm.Werkdatum = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnAddKost_Click(object sender, EventArgs e)
        {
            float parsed = 0;

            if (cmbKostSoort.SelectedIndex == -1 || !cmbKostSoort.Items.Contains(cmbKostSoort.Text)) { MessageBox.Show("Er werd geen geldige KOSTENSOORT gekozen", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtKostDatum.Text.Trim().Equals("") || txtKostDatum.Text.Trim().Length != 10) { MessageBox.Show("Er werd geen geldige DATUM opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtKostHoeveelheid.Text.Trim().Equals("") || !float.TryParse(txtKostHoeveelheid.Text, out parsed) || txtKostHoeveelheid.Text.Trim().Equals("0")) { MessageBox.Show("Er werd geen geldige HOEVEELHEID opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtKostEenheidsprijs.Text.Trim().Equals("") || !float.TryParse(txtKostEenheidsprijs.Text, out parsed) || txtKostEenheidsprijs.Text.Trim().Equals("0")) { MessageBox.Show("Er werd geen geldige EENHEIDSPRIJS opgegeven", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            switch (cmbKostSoort.SelectedItem.ToString())
            {
                case "ERELOON":
                    Kost ereloon = new Kost(this.PrestatieVoorForm.Id, 'E', txtKostDatum.Text, cmbKostOmschrijving.Text, txtKostCommentaar.Text, float.Parse(txtKostHoeveelheid.Text), float.Parse(txtKostEenheidsprijs.Text), 0, "KOS");
                    KostDao.Instance.createKost(ereloon);
                    PrestatieVoorForm.Historiek += txtKostDatum.Text + " " + cmbKostOmschrijving.Text + "\t" + txtKostCommentaar.Text + "\n";
                    break;

                case "ONKOST":
                    Kost onkost = new Kost(this.PrestatieVoorForm.Id, 'O', txtKostDatum.Text, cmbKostOmschrijving.Text, txtKostCommentaar.Text, float.Parse(txtKostHoeveelheid.Text), float.Parse(txtKostEenheidsprijs.Text), 0, "KOS");
                    KostDao.Instance.createKost(onkost);
                    PrestatieVoorForm.Historiek += txtKostDatum.Text + " " + cmbKostOmschrijving.Text + "\t" + txtKostCommentaar.Text + "\n";
                    break;
            }

            resetInputFields();
            setTotalen();
            buildDgv("KOS");
            PrestatieVoorForm.Werkdatum = DateTime.Now.ToString("dd/MM/yyyy");

        }
        #endregion

        #region COMBOBOX ACTIONS
        private void cmbInSoort_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInHoeveelheid.Text = "1";
        }
        private void cmbKostSoort_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbKostOmschrijving.SelectedItem = -1;
            cmbKostOmschrijving.Text = "";
            txtKostEenheidsprijs.Text = "";
            if (cmbKostSoort.SelectedIndex != -1)
            {
                cmbKostOmschrijving.Items.Clear();
                switch (cmbKostSoort.SelectedItem.ToString())
                {
                    case "ERELOON":
                        foreach (Object o in erelonen)
                        {
                            cmbKostOmschrijving.Items.Add((string)o);
                        }
                        cmbKostOmschrijving.Enabled = true;
                        break;
                    case "ONKOST":
                        foreach (Object o in onkosten)
                        {
                            cmbKostOmschrijving.Items.Add((string)o);
                        }
                        cmbKostOmschrijving.Enabled = true;
                        break;
                }
            }
            else { cmbKostOmschrijving.Items.Clear(); cmbKostOmschrijving.Enabled = false; }
        }
        private void cmbKostSoort_TextChanged(object sender, EventArgs e)
        {
            if (cmbKostSoort.Text.Trim().Equals(""))
            {
                cmbKostSoort.SelectedIndex = -1;
                cmbKostOmschrijving.Items.Clear();
                cmbKostOmschrijving.Enabled = false;
            }
        }
        private void cmbKostOmschrijving_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKostOmschrijving.SelectedIndex != -1)
            {
                txtKostEenheidsprijs.Text = tarieflijst[cmbKostOmschrijving.SelectedItem.ToString()].ToString();
            }

        }
        private void cmbKostOmschrijving_TextChanged(object sender, EventArgs e)
        {
            if (cmbKostOmschrijving.Text.Trim().Equals(""))
            {
                txtKostEenheidsprijs.Text = "";
            }
        }
        #endregion

        #region PRESTATIE INSTELLINGEN
        private void dtpHerinnerDatum_ValueChanged(object sender, EventArgs e)
        {
            DateTime newDate;
            if (DateTime.TryParse(dtpHerinnerDatum.Value.ToString(), out newDate))
            {
                PrestatieVoorForm.Herinnerdatum = dtpHerinnerDatum.Value.ToString("dd/MM/yyyy");
                txtHerinnerDatum.Text = dtpHerinnerDatum.Value.ToString("dd/MM/yyyy");
            }
        }

        private void txtBtw_Leave(object sender, EventArgs e)
        {
            float parsed;
            if (float.TryParse(txtBtw.Text, out parsed))
            {
                PrestatieVoorForm.Btw = (float)Math.Round(parsed, 1);
            }
        }

        private void txtHerinnerDatum_TextChanged(object sender, EventArgs e)
        {
            if (txtHerinnerDatum.Text.Equals("") || txtHerinnerDatum.Text.Length == 10)
            {
                if (txtHerinnerDatum.Text.Equals(""))
                {
                    txtHerinnerCommentaar.Text = "";
                    txtHerinnerCommentaar.Enabled = false;
                }

                if (txtHerinnerDatum.Text.Length == 10)
                {
                    txtHerinnerCommentaar.Enabled = true;
                }

                PrestatieVoorForm.Herinnerdatum = txtHerinnerDatum.Text;
            }

        }

        private void txtHerinnerDatum_Leave(object sender, EventArgs e)
        {
            if (!txtHerinnerDatum.Text.Equals("") && txtHerinnerDatum.Text.Length != 10)
            {
                MessageBox.Show("Er werd geen geldige HERINNERDATUM gekozen", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHerinnerDatum.Text = "";
            }
        }

        private void cmbTarief_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTarief.SelectedIndex == -1)
            {
                cmbTarief.SelectedIndex = cmbTarief.Items.IndexOf(PrestatieVoorForm.Tariefniveau);
                return;
            }

            if (cmbTarief.Items.IndexOf(PrestatieVoorForm.Tariefniveau) != cmbTarief.SelectedIndex)
            {
                PrestatieVoorForm.Tariefniveau = cmbTarief.Items[int.Parse(cmbTarief.SelectedIndex.ToString())].ToString();
                buildTarieflijst(PrestatieVoorForm.Tariefniveau);
                buildDgv("PBZ");
                buildDgv("DAC");
                buildDgv("INK");
                buildDgv("KOS");
                updateTariefVoorKosten();
                setTotalen();
                buildDgv("KOS");
                return;
            }



        }

        private void cmbTarief_TextChanged(object sender, EventArgs e)
        {
            if (cmbTarief.Text.Equals(""))
            {
                cmbTarief.Text = PrestatieVoorForm.Tariefniveau;
                cmbTarief.SelectedIndex = cmbTarief.Items.IndexOf(PrestatieVoorForm.Tariefniveau);
            }

        }

        #endregion

        #region UPDATE KOSTEN

        private void dgvPlaatsbezoek_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (plaatsbezoekKosten != null)
            {
                int rij = e.RowIndex;
                int kolom = e.ColumnIndex;
                ArrayList hoofdKosten = new ArrayList();

                if (kolom != 1 && dgvPlaatsbezoek[kolom, rij].Value == null)
                {
                    MessageBox.Show("Je moet ALTIJD een waarde invullen", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); buildDgv("PBZ"); return;
                }

                foreach (Object o in plaatsbezoekKosten)
                {
                    Kost hoofdkost = (Kost)o;
                    if (hoofdkost.HoofdKostId == 0)
                    {
                        hoofdKosten.Add(hoofdkost);
                    }
                }

                Kost kostToUpdate = (Kost)hoofdKosten[rij];
                string kostomschrijving = "";

                switch (kolom)
                {
                    case 2: kostomschrijving = "foto"; break;
                    case 3: kostomschrijving = "plaatsbezoek"; break;
                    case 4: kostomschrijving = "verplaatsingen"; break;
                    case 5: kostomschrijving = "reistijd"; break;
                }

                if (kolom == 0)
                {
                    if (kostToUpdate.Equals(KostDao.Instance.getKostById(kostToUpdate.Id)))
                    {
                        kostToUpdate.Datum = dgvPlaatsbezoek[kolom, rij].Value.ToString();
                        KostDao.Instance.updateKost(kostToUpdate);

                        foreach (Object o in plaatsbezoekKosten)
                        {
                            Kost kost = (Kost)o;
                            if (kost.HoofdKostId.Equals(kostToUpdate.Id) && kost.Equals(KostDao.Instance.getKostById(kost.Id)))
                            {
                                kost.Datum = kostToUpdate.Datum;
                                KostDao.Instance.updateKost(kost);
                            }
                        }

                        return;
                    }
                    else
                    {
                        MessageBox.Show("Kon de gegevens niet aanpassen omdat iemand ze al heeft aangepast of verwijderd", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        buildDgv("PBZ");
                        return;
                    }
                }

                if (kolom == 1)
                {
                    if (kostToUpdate.Equals(KostDao.Instance.getKostById(kostToUpdate.Id)))
                    {
                        if (dgvPlaatsbezoek[kolom, rij].Value == null)
                        {
                            kostToUpdate.Commentaar = "";
                        }
                        else
                        {
                            kostToUpdate.Commentaar = dgvPlaatsbezoek[kolom, rij].Value.ToString();
                        }
                        KostDao.Instance.updateKost(kostToUpdate);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Kon de gegevens niet aanpassen omdat iemand ze al heeft aangepast of verwijderd", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        buildDgv("PBZ");
                        return;
                    }

                }

                if (kolom == 3)
                {
                    if (kostToUpdate.Equals(KostDao.Instance.getKostById(kostToUpdate.Id)))
                    {
                        kostToUpdate.Hoeveelheid = (float)Math.Round(float.Parse(dgvPlaatsbezoek[kolom, rij].Value.ToString()), 2);
                        kostToUpdate.setTotaal();
                        KostDao.Instance.updateKost(kostToUpdate);
                        setTotalen();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Kon de gegevens niet aanpassen omdat iemand ze al heeft aangepast of verwijderd", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        buildDgv("PBZ");
                        return;
                    }
                }

                if (kolom > 1 && kolom != 3)
                {
                    Kost subKostToUpdate = null;

                    foreach (Object o in plaatsbezoekKosten)
                    {
                        Kost kost = (Kost)o;

                        if (kost.HoofdKostId.Equals(kostToUpdate.Id) && kost.Omschrijving.Equals(kostomschrijving))
                        {
                            subKostToUpdate = kost;

                            if (kost.Equals(KostDao.Instance.getKostById(kost.Id)))
                            {
                                subKostToUpdate.Hoeveelheid = (float)Math.Round(float.Parse(dgvPlaatsbezoek[kolom, rij].Value.ToString()), 2);
                                subKostToUpdate.setTotaal();
                                KostDao.Instance.updateKost(subKostToUpdate);
                                setTotalen();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Kon de gegevens niet aanpassen omdat iemand ze al heeft aangepast of verwijderd", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                buildDgv("PBZ");
                                return;
                            }
                        }
                    }

                    if (subKostToUpdate == null)
                    {
                        char type = ' ';
                        switch (kostomschrijving)
                        {
                            case "foto": type = 'O'; break;
                            case "plaatsbezoek": type = 'E'; break;
                            case "verplaatsingen": type = 'O'; break;
                            case "reistijd": type = 'E'; break;
                        }
                        KostDao.Instance.createKost(new Kost(PrestatieVoorForm.Id, type, kostToUpdate.Datum, kostomschrijving, "", (float)Math.Round(float.Parse(dgvPlaatsbezoek[kolom, rij].Value.ToString()), 2), tarieflijst[kostomschrijving], kostToUpdate.Id, "PBZ"));
                    }
                }
            }

        }

        private void dgvDactylografie_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dactylografieKosten != null)
            {
                int rij = e.RowIndex;
                int kolom = e.ColumnIndex;
                ArrayList hoofdKosten = new ArrayList();
                if (kolom!= 3 && dgvDactylografie[kolom, rij].Value == null)
                {
                    MessageBox.Show("Je moet ALTIJD een waarde invullen", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); buildDgv("DAC"); return;
                }

                foreach (Object o in dactylografieKosten)
                {
                    Kost hoofdkost = (Kost)o;
                    if (hoofdkost.HoofdKostId == 0)
                    {
                        hoofdKosten.Add(hoofdkost);
                    }
                }

                Kost kostToUpdate = (Kost)hoofdKosten[rij];
                string kostomschrijving = "";

                switch (kolom)
                {
                    case 0: MessageBox.Show("U kan dit veld niet aanpassen, indien toch gewenst probeer de rij te verwijderen en een nieuwe toe te voegen", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); buildDgv("DAC"); return;
                    case 1: MessageBox.Show("U kan dit veld niet aanpassen, indien toch gewenst probeer de rij te verwijderen en een nieuwe toe te voegen", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); buildDgv("DAC"); return;
                    case 5: kostomschrijving = "digitaalverzending"; break;
                    case 6: kostomschrijving = "postverzending"; break;
                    case 7: kostomschrijving = "kopie"; break;
                    case 8: kostomschrijving = "aangetekende verzending"; break;
                    case 9: kostomschrijving = "vertaling"; break;
                }

                if (kolom == 2)
                {
                    if (kostToUpdate.Equals(KostDao.Instance.getKostById(kostToUpdate.Id)))
                    {
                        kostToUpdate.Datum = dgvDactylografie[kolom, rij].Value.ToString();
                        KostDao.Instance.updateKost(kostToUpdate);

                        foreach (Object o in dactylografieKosten)
                        {
                            Kost kost = (Kost)o;

                            if (kost.HoofdKostId.Equals(kostToUpdate.Id) && kost.Equals(KostDao.Instance.getKostById(kost.Id)))
                            {
                                kost.Datum = kostToUpdate.Datum;
                                KostDao.Instance.updateKost(kost);
                            }

                        }
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Kon de DATUMGEGEVENS niet aanpassen omdat iemand de kost reeds aanpaste of verwijderde", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        buildDgv("DAC");
                        return;
                    }
                }

                if (kolom > 4)
                {
                    Kost subKostToUpdate = null;
                    foreach (Object o in dactylografieKosten)
                    {
                        Kost kost = (Kost)o;
                        if (kost.Omschrijving.Equals(kostomschrijving) && kost.HoofdKostId == kostToUpdate.Id)
                        {
                            subKostToUpdate = kost;
                            break;
                        }
                    }

                    if (subKostToUpdate != null)
                    {
                        if (subKostToUpdate.Equals(KostDao.Instance.getKostById(subKostToUpdate.Id)))
                        {
                            subKostToUpdate.Hoeveelheid = (float)Math.Round(float.Parse(dgvDactylografie[kolom, rij].Value.ToString()), 2);
                            subKostToUpdate.setTotaal();
                            KostDao.Instance.updateKost(subKostToUpdate);
                            setTotalen();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Kon de kostgegevens niet aanpassen omdat iemand de gegevens al aangepast of verwijderd heeft.", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            buildDgv("DAC");
                            return;
                        }
                    }
                    else
                    {
                        subKostToUpdate = new Kost(PrestatieVoorForm.Id, 'E', kostToUpdate.Datum, kostomschrijving, "", (float)Math.Round(float.Parse(dgvDactylografie[kolom, rij].Value.ToString()), 2), tarieflijst[kostomschrijving], kostToUpdate.Id, "DAC");
                        KostDao.Instance.createKost(subKostToUpdate);
                        buildDgv("DAC");
                        setTotalen();
                        return;
                    }
                }
                else
                {
                    if (kostToUpdate.Equals(KostDao.Instance.getKostById(kostToUpdate.Id)))
                    {
                        Kost newKost = kostToUpdate;
                        newKost.Datum = dgvDactylografie[2, rij].Value.ToString();
                        if (dgvDactylografie[3, rij].Value == null) newKost.Commentaar = ""; else newKost.Commentaar = dgvDactylografie[3, rij].Value.ToString();
                        newKost.Hoeveelheid = (float)Math.Round(float.Parse(dgvDactylografie[4, rij].Value.ToString()), 2);
                        newKost.setTotaal();
                        KostDao.Instance.updateKost(newKost);
                        setTotalen();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Kon de kostgegevens niet aanpassen omdat iemand de gegevens al aangepast of verwijderd heeft.", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        buildDgv("DAC");
                        return;
                    }
                }
            }

        }

        private void dgvIn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (inkomendeInformatieKosten != null)
            {
                int rij = e.RowIndex;
                int kolom = e.ColumnIndex;

                if (kolom != 2 && dgvIn[kolom, rij].Value == null)
                {
                    MessageBox.Show("Je moet ALTIJD een waarde invullen", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); buildDgv("INK"); return;
                }

                if (kolom == 0)
                {
                    MessageBox.Show("U kan dit veld niet aanpassen, indien toch gewenst probeer de rij te verwijderen en een nieuwe toe te voegen", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buildDgv("INK");
                    return;
                }

                Kost kosToUpdate = (Kost)inkomendeInformatieKosten[rij];

                if (kosToUpdate.Equals(KostDao.Instance.getKostById(kosToUpdate.Id)))
                {
                    switch (kolom)
                    {
                        case 1: kosToUpdate.Datum = dgvIn[kolom, rij].Value.ToString(); break;
                        case 2: if (dgvIn[kolom, rij].Value == null) kosToUpdate.Commentaar = ""; else kosToUpdate.Commentaar = dgvIn[kolom, rij].Value.ToString(); break;
                        case 3: kosToUpdate.Hoeveelheid = (float)Math.Round(float.Parse(dgvIn[kolom, rij].Value.ToString()), 2); kosToUpdate.setTotaal(); break;
                    }

                    KostDao.Instance.updateKost(kosToUpdate);
                    setTotalen();
                    return;
                }
                else
                {
                    MessageBox.Show("Kon de gegevens niet aanpassen omdat iemand ze al heeft aangepast of verwijderd", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buildDgv("INK");
                    return;
                }
            }
        }

        private void dgvKost_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (variabeleKosten != null)
            {
                int rij = e.RowIndex;
                int kolom = e.ColumnIndex;

                if (kolom != 3 && dgvKost[kolom, rij].Value == null)
                {
                    MessageBox.Show("Je moet ALTIJD een waarde invullen", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error); buildDgv("KOS"); return;
                }

                if (kolom == 0)
                {
                    MessageBox.Show("U kan dit veld niet aanpassen, indien toch gewenst probeer de rij te verwijderen en een nieuwe toe te voegen", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buildDgv("KOS");
                    return;
                }

                Kost kosToUpdate = (Kost)variabeleKosten[rij];

                if (kosToUpdate.Equals(KostDao.Instance.getKostById(kosToUpdate.Id)))
                {
                    switch (kolom)
                    {
                        case 1: kosToUpdate.Datum = dgvKost[kolom, rij].Value.ToString(); break;
                        case 2: kosToUpdate.Omschrijving = dgvKost[kolom, rij].Value.ToString(); break;
                        case 3: if (dgvKost[kolom, rij].Value == null) kosToUpdate.Commentaar = ""; else kosToUpdate.Commentaar = dgvKost[kolom, rij].Value.ToString(); break;
                        case 4: kosToUpdate.Hoeveelheid = (float)Math.Round(float.Parse(dgvKost[kolom, rij].Value.ToString()), 2); kosToUpdate.setTotaal(); break;
                        case 5: kosToUpdate.Eenheidsprijs = (float)Math.Round(float.Parse(dgvKost[kolom, rij].Value.ToString()), 2); kosToUpdate.setTotaal(); break;
                    }

                    KostDao.Instance.updateKost(kosToUpdate);
                    setTotalen();
                    return;
                }
                else
                {
                    MessageBox.Show("Kon de gegevens niet aanpassen omdat iemand ze al heeft aangepast of verwijderd", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buildDgv("INK");
                    return;
                }
            }

        }

        private void updateTariefVoorKosten()
        {
            foreach (Object o in plaatsbezoekKosten)
            {
                Kost kost = (Kost)o;
                if (!kost.Equals(KostDao.Instance.getKostById(kost.Id)))
                {
                    MessageBox.Show("Er heeft iemand de kost(en) al aangepast, probeer het niveau opnieuw te wijzigen", "FOUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    this.Show();
                }
                else
                {
                    kost.Eenheidsprijs = tarieflijst[kost.Omschrijving];
                    kost.setTotaal();
                    KostDao.Instance.updateKost(kost);
                }
            }

            foreach (Object o in dactylografieKosten)
            {
                Kost kost = (Kost)o;
                if (!kost.Equals(KostDao.Instance.getKostById(kost.Id)))
                {
                    MessageBox.Show("Er heeft iemand de kost(en) al aangepast, probeer het niveau opnieuw te wijzigen", "FOUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    this.Show();
                }
                else
                {
                    kost.Eenheidsprijs = tarieflijst[kost.Omschrijving];
                    kost.setTotaal();
                    KostDao.Instance.updateKost(kost);
                }
            }

            foreach (Object o in inkomendeInformatieKosten)
            {
                Kost kost = (Kost)o;
                if (!kost.Equals(KostDao.Instance.getKostById(kost.Id)))
                {
                    MessageBox.Show("Er heeft iemand de kost(en) al aangepast, probeer het niveau opnieuw te wijzigen", "FOUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    this.Show();
                }
                else
                {
                    kost.Eenheidsprijs = tarieflijst[kost.Omschrijving];
                    kost.setTotaal();
                    KostDao.Instance.updateKost(kost);
                }
            }

            foreach (Object o in variabeleKosten)
            {
                Kost kost = (Kost)o;
                if (!kost.Equals(KostDao.Instance.getKostById(kost.Id)))
                {
                    MessageBox.Show("Er heeft iemand de kost(en) al aangepast, probeer het niveau opnieuw te wijzigen", "FOUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    this.Show();
                }
                else
                {
                    if (tarieflijst.ContainsKey(kost.Omschrijving))
                    {
                        kost.Eenheidsprijs = tarieflijst[kost.Omschrijving];
                        kost.setTotaal();
                        KostDao.Instance.updateKost(kost);
                    }
                }
            }
        }
        #endregion

        #region CLOSE EVENTS

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

        private void frmPrestatie_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            handleClosing();
        }

        private void handleClosing()
        {
            if (txtHerinnerCommentaar.Enabled == true)
            {
                PrestatieVoorForm.HerinnerCommentaar = txtHerinnerCommentaar.Text;
            }

            if (PrestatieVoorForm.Equals(prestatieOnLoad))
            {
                this.Hide();
            }
            else
            {
                if (prestatieOnLoad.Equals(PrestatieDao.Instance.getPrestatieById(PrestatieVoorForm.Id)))
                {
                    PrestatieDao.Instance.updatePrestatie(PrestatieVoorForm);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kon het prestatieblad niet updaten in de databank omdat iemand anders reeds aanpassingen maakte aan dit prestatieblad.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    this.Show();
                }
            }

        }
        #endregion

        private void btnPbzVerwijderen_Click(object sender, EventArgs e)
        {
            if (dgvPlaatsbezoek.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Bent u zeker dat u deze kost wilt verwijderen?", "Verwijderen Kost?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result.ToString().Equals("Yes"))
                {
                    ArrayList hoofdKosten = new ArrayList();

                    foreach (Object o in plaatsbezoekKosten)
                    {
                        Kost hoofdkost = (Kost)o;
                        if (hoofdkost.HoofdKostId == 0)
                        {
                            hoofdKosten.Add(hoofdkost);
                        }
                    }

                    Kost kostToRemove = (Kost)hoofdKosten[int.Parse(dgvPlaatsbezoek.SelectedRows[0].Index.ToString())];
                    KostDao.Instance.deleteKost(kostToRemove);
                    buildDgv("PBZ");
                    setTotalen();
                }
            }
            else
            {
                MessageBox.Show("Selecteer MAXIMAAL 1 kost per keer om te verwijderen", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnDactVerwijderen_Click_1(object sender, EventArgs e)
        {
            if (dgvDactylografie.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Bent u zeker dat u deze kost wilt verwijderen?", "Verwijderen Kost?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result.ToString().Equals("Yes"))
                {
                    ArrayList hoofdKosten = new ArrayList();

                    foreach (Object o in dactylografieKosten)
                    {
                        Kost hoofdkost = (Kost)o;
                        if (hoofdkost.HoofdKostId == 0)
                        {
                            hoofdKosten.Add(hoofdkost);
                        }
                    }

                    Kost kostToRemove = (Kost)hoofdKosten[int.Parse(dgvDactylografie.SelectedRows[0].Index.ToString())];
                    KostDao.Instance.deleteKost(kostToRemove);
                    buildDgv("DAC");
                    setTotalen();
                }
            }
            else
            {
                MessageBox.Show("Selecteer MAXIMAAL 1 kost per keer om te verwijderen", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnInVerwijderen_Click(object sender, EventArgs e)
        {
            if (dgvIn.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Bent u zeker dat u deze kost wilt verwijderen?", "Verwijderen Kost?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result.ToString().Equals("Yes"))
                {
                    ArrayList hoofdKosten = new ArrayList();

                    foreach (Object o in inkomendeInformatieKosten)
                    {
                        Kost hoofdkost = (Kost)o;
                        if (hoofdkost.HoofdKostId == 0)
                        {
                            hoofdKosten.Add(hoofdkost);
                        }
                    }

                    Kost kostToRemove = (Kost)hoofdKosten[int.Parse(dgvIn.SelectedRows[0].Index.ToString())];
                    KostDao.Instance.deleteKost(kostToRemove);
                    buildDgv("INK");
                    setTotalen();
                }
            }
            else
            {
                MessageBox.Show("Selecteer MAXIMAAL 1 kost per keer om te verwijderen", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnKosVerwijderen_Click(object sender, EventArgs e)
        {
            if (dgvKost.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Bent u zeker dat u deze kost wilt verwijderen?", "Verwijderen Kost?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result.ToString().Equals("Yes"))
                {
                    ArrayList hoofdKosten = new ArrayList();

                    foreach (Object o in variabeleKosten)
                    {
                        Kost hoofdkost = (Kost)o;
                        if (hoofdkost.HoofdKostId == 0)
                        {
                            hoofdKosten.Add(hoofdkost);
                        }
                    }

                    Kost kostToRemove = (Kost)hoofdKosten[int.Parse(dgvKost.SelectedRows[0].Index.ToString())];
                    KostDao.Instance.deleteKost(kostToRemove);
                    buildDgv("KOS");
                    setTotalen();
                }
            }
            else
            {
                MessageBox.Show("Selecteer MAXIMAAL 1 kost per keer om te verwijderen", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnAfdrukken_Click(object sender, EventArgs e)
        {
            /**
            if (FactuurDao.Instance.factuurExists(PrestatieVoorForm.Id, frmDetails.Instance.SelectedReference))
            {
                MessageBox.Show("Het factuur dat u wenst aan te maken bestaat al!", "Aanmaken geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
             * */

            frmNieuwFactuur.Instance.Show();
        }
    }
}
