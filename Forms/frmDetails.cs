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
    public partial class frmDetails : Form
    {
        static frmDetails instance = null;
        static readonly object padlock = new object();
        private string selectedReference = "";
        private int selectedPartijTypeId = 2;
        private int selectedHoofdpartijId = 0;
        private int selectedDossierId = 0;
        private Dictionary<string, int> maatschappijen;
        private ArrayList contracten;
        private Dictionary<string, Dictionary<string, int>> beheerders;
        private Dossier dossierOnLoad = new Dossier();
        private Dossier newDossier = null;
        private ArrayList partijen;
        private Partij selectedPartij;

        #region Constructor & Instance
        frmDetails()
        {
            InitializeComponent();
            initialiseerDossierInfo();
        }
        public void initialiseerPartijInfo()
        {
            SelectedDossierId = dossierOnLoad.Id;
            partijen = PartijDao.Instance.getPartijenVoorDossier(SelectedDossierId);
            buildTabPage("verzekerde");
            buildTabPage("tegenpartij");
            buildTabPage("andere");

        }

        public static frmDetails Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmDetails();
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        internal Partij SelectedPartij
        {
            get { return selectedPartij; }
            set { selectedPartij = value; }
        }

        public int SelectedDossierId
        {
            get { return selectedDossierId; }
            set { selectedDossierId = value; }
        }

        public int SelectedPartijTypeId
        {
            get { return selectedPartijTypeId; }
            set { selectedPartijTypeId = value; }
        }

        public int SelectedHoofdpartijId
        {
            get { return selectedHoofdpartijId; }
            set { selectedHoofdpartijId = value; }
        }

        public string SelectedReference
        {
            get { return selectedReference; }
            set { selectedReference = value; }
        }
        #endregion

        #region FormEvents
        private void frmDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            handleClosing();

        }
        private void handleClosing()
        {
            newDossier = new Dossier();
            newDossier.Id = dossierOnLoad.Id;
            newDossier.Referentie = SelectedReference;
            newDossier.Date_in = txtDateIn.Text;
            newDossier.Date_out = txtDateOut.Text;
            newDossier.Pvds_datum = txtPvdsDatum.Text;
            if (cmbMaatschappij.SelectedItem != null) newDossier.Maatschappij = cmbMaatschappij.SelectedItem.ToString(); else newDossier.Maatschappij = "";
            if (cmbBeheerder.SelectedItem != null) newDossier.Beheerder = cmbBeheerder.SelectedItem.ToString(); else newDossier.Beheerder = "";
            newDossier.Referentie_Maatschappij = txtReferentieMaatschappij.Text;
            newDossier.Polis = txtPolisnr.Text;
            if (cmbContract.SelectedItem != null) newDossier.Contract = cmbContract.SelectedItem.ToString(); else newDossier.Contract = "";
            newDossier.Pvds_naam = txtPvdsNaam.Text;
            newDossier.Pvds_straat = txtPvdsStraat.Text;
            newDossier.Pvds_nr = txtPvdsNr.Text;
            newDossier.Pvds_postcode = cmbPvdsPostcode.Text; 
            newDossier.Pvds_gemeente = cmbPvdsGemeente.Text;
            newDossier.Pvds_omvang =txtPvdsOmvang.Text;
            newDossier.Plaatsbezoek = "dd. " + txtPbDd1.Text.Trim() + " om " + txtPbOm1.Text.Trim() + ";" + "dd. " + txtPbDd2.Text.Trim() + " om " + txtPbOm2.Text.Trim() + ";" +
                "dd. " + txtPbDd3.Text.Trim() + " om " + txtPbOm3.Text.Trim() + ";" + "dd. " + txtPbDd4.Text.Trim() + " om " + txtPbOm4.Text.Trim() + ";" +
                "dd. " + txtPbDd5.Text.Trim() + " om " + txtPbOm5.Text.Trim() + ";" + "dd. " + txtPbDd6.Text.Trim() + " om " + txtPbOm6.Text.Trim() + ";";
            newDossier.Opdracht = txtOpdracht.Text;
            newDossier.Opmerking = txtOpmerking.Text;

            if (!newDossier.Equals(dossierOnLoad))
            {
                handleUpdating();
                frmOverview.Instance.Show();
                tabPartijen.SelectedIndex = 0;
                this.Hide();
            }

            else
            {
                frmOverview.Instance.Show();
                tabPartijen.SelectedIndex = 0;
                this.Hide();
            }
        }

        private void handleUpdating()
        {
            int maatschappijId = -1;
            int beheerdersId = -1;
            Dictionary<string, int> beheerdersToFind = null;
            if (maatschappijen.Keys.Contains(dossierOnLoad.Maatschappij))
            {
                maatschappijId = maatschappijen[dossierOnLoad.Maatschappij];
                if (beheerders.ContainsKey(dossierOnLoad.Maatschappij)) { beheerdersToFind = beheerders[dossierOnLoad.Maatschappij]; } else { beheerdersToFind = null; }
            }

            if (beheerdersToFind != null && beheerdersToFind.Keys.Contains(dossierOnLoad.Beheerder))
            {
                beheerdersId = beheerdersToFind[dossierOnLoad.Beheerder];
            }

            if (DossierDao.Instance.getDossier(dossierOnLoad, maatschappijId, beheerdersId) != null)
            {
                maatschappijId = -1;
                beheerdersId = -1;

                if (maatschappijen.Keys.Contains(newDossier.Maatschappij))
                {
                    maatschappijId = maatschappijen[newDossier.Maatschappij];
                    if (beheerders.ContainsKey(newDossier.Maatschappij)) { beheerdersToFind = beheerders[newDossier.Maatschappij]; } else { beheerdersToFind = null; }
                }

                if (beheerdersToFind != null && beheerdersToFind.Keys.Contains(newDossier.Beheerder))
                {
                    beheerdersId = beheerdersToFind[newDossier.Beheerder];
                }

                if (DossierDao.Instance.getDossiersBySchadeAdres(newDossier.Pvds_straat, newDossier.Pvds_nr, newDossier.Pvds_postcode, newDossier.Pvds_gemeente).Count != 0)
                {
                    ArrayList list = DossierDao.Instance.getDossiersBySchadeAdres(newDossier.Pvds_straat, newDossier.Pvds_nr, newDossier.Pvds_postcode, newDossier.Pvds_gemeente);

                    string melding = "Opgelet er werd één of meerdere dossiers gevonden op hetzelfde schadeadres : \n \n";
                    string dossiers = "";

                    foreach (Object dossierobj in list)
                    {
                        Dossier dossier = (Dossier)dossierobj;
                        if (dossier.Referentie != this.SelectedReference) dossiers += dossier.Referentie + "\n";

                    }

                    if (!dossiers.Trim().Equals(""))
                    {
                        MessageBox.Show(melding + " " + dossiers, "Melding", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }

                }

                DossierDao.Instance.updateDossier(maatschappijId, beheerdersId, newDossier);
                //MessageBox.Show("Gegevens werden opgeslagen", "Melding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dossierOnLoad = newDossier;
            }
            else
            {
                MessageBox.Show("Kon de gegevens van het dossier niet aanpassen omdat iemand de gegevens al gewijzigd of verwijderd heeft!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                frmOverview.Instance.buildListView("SELECT * FROM dossier ORDER BY referentie DESC;");
                frmOverview.Instance.SelectedReference = SelectedReference;
                frmDetails.Instance.Show();
            }
        }
        private void frmDetails_VisibleChanged(object sender, EventArgs e)
        {
            if (frmDetails.Instance.Visible == true)
            {
                //if (!this.SelectedReference.Equals(frmOverview.Instance.SelectedReference))
                //{
                    cmbMaatschappij.Items.Clear();
                    cmbMaatschappij.Text = "";
                    cmbMaatschappij.SelectedItem = null;
                    cmbBeheerder.Items.Clear();
                    cmbBeheerder.Text = "";
                    cmbMaatschappij.SelectedItem = null;

                    cmbPvdsPostcode.SelectedItem = null;
                    cmbPvdsPostcode.SelectedIndex = -1;
                    cmbPvdsPostcode.Text = "";
                    cmbPvdsGemeente.Text = "";
                    txtPvdsOmvang.Text = "";
                    txtPbDd1.Text = "";
                    txtPbDd2.Text = "";
                    txtPbDd3.Text = "";
                    txtPbDd4.Text = "";
                    txtPbDd5.Text = "";
                    txtPbDd6.Text = "";
                    txtPbOm1.Text = "";
                    txtPbOm2.Text = "";
                    txtPbOm3.Text = "";
                    txtPbOm4.Text = "";
                    txtPbOm5.Text = "";
                    txtPbOm6.Text = "";
                    dossierOnLoad = new Dossier();
                    refresh();
                    setDetails();
                    initialiseerPartijInfo();
                //}
            }
        }

        public void refresh()
        {
            fillComboboxMaatschappijen();
            prepareComboboxBeheerders();
        }
        #endregion

        #region Initializing Methods
        private void initialiseerDossierInfo()
        {
            fillComboboxMaatschappijen();
            fillComboBoxContracten();
            fillComboBoxPostcode();
            prepareComboboxBeheerders();
        }
        public void fillComboboxMaatschappijen()
        {
            maatschappijen = MaatschappijDao.Instance.getMaatschappijen();
            cmbMaatschappij.Items.Clear();
            foreach (string naam in maatschappijen.Keys)
            {
                cmbMaatschappij.Items.Add(naam);
            }
        }
        public void prepareComboboxBeheerders()
        {
            Dictionary<string, Dictionary<string, int>> temp = BeheerderDao.Instance.getBeheerders();
            this.beheerders = temp;
        }
        public void fillComboBoxContracten()
        {
            this.contracten = ContractDao.Instance.getContracten();
            foreach (Object o in contracten)
            {
                cmbContract.Items.Add((string)o);
            }
        }
        private void fillComboBoxPostcode()
        {
            foreach (Object o in GemeenteDao.Instance.getAllPostCodes())
            {
                cmbPvdsPostcode.Items.Add((String)o);
            }
        }
        private void setDetails()
        {
            setReferentieDetails();
            setMaatschappijDetails();
            if (cmbMaatschappij.SelectedItem != null) dossierOnLoad.Maatschappij = cmbMaatschappij.Text; else dossierOnLoad.Maatschappij = "";
            if (cmbBeheerder.SelectedItem != null) dossierOnLoad.Beheerder = cmbBeheerder.Text; else dossierOnLoad.Beheerder = "";
            setContractDetails();
            setGemeenteDetails();
            txtDateIn.Text = dossierOnLoad.Date_in;
            txtDateOut.Text = dossierOnLoad.Date_out;
            txtReferentieMaatschappij.Text = dossierOnLoad.Referentie_Maatschappij;
            txtPolisnr.Text = dossierOnLoad.Polis;
            txtPvdsNaam.Text = dossierOnLoad.Pvds_naam;
            txtPvdsDatum.Text = dossierOnLoad.Pvds_datum;
            txtPvdsStraat.Text = dossierOnLoad.Pvds_straat;
            txtPvdsNr.Text = dossierOnLoad.Pvds_nr;
            if (dossierOnLoad.Plaatsbezoek != null && !dossierOnLoad.Plaatsbezoek.Equals(""))
            {
                String[] temp = dossierOnLoad.Plaatsbezoek.Split(';');
                txtPbDd1.Text = temp[0].Substring(3,temp[0].IndexOf("om")-3);
                txtPbDd2.Text = temp[1].Substring(3, temp[1].IndexOf("om")-3);
                txtPbDd3.Text = temp[2].Substring(3, temp[2].IndexOf("om")-3);
                txtPbDd4.Text = temp[3].Substring(3, temp[3].IndexOf("om")-3);
                txtPbDd5.Text = temp[4].Substring(3, temp[4].IndexOf("om")-3);
                txtPbDd6.Text = temp[5].Substring(3, temp[5].IndexOf("om")-3);
                txtPbOm1.Text = temp[0].Substring(temp[0].IndexOf("om")+3);
                txtPbOm2.Text = temp[1].Substring(temp[1].IndexOf("om")+3);
                txtPbOm3.Text = temp[2].Substring(temp[2].IndexOf("om")+3);
                txtPbOm4.Text = temp[3].Substring(temp[3].IndexOf("om")+3);
                txtPbOm5.Text = temp[4].Substring(temp[4].IndexOf("om")+3);
                txtPbOm6.Text = temp[5].Substring(temp[5].IndexOf("om")+3);
            }
            if (dossierOnLoad.Pvds_omvang == null) txtPvdsOmvang.Text = ""; else txtPvdsOmvang.Text = dossierOnLoad.Pvds_omvang;
            if (dossierOnLoad.Opdracht.Equals("SCHADEVASTSTELLING")) { ckbSchadevaststelling.Checked = true; ckbGerechtsexpertise.Checked = false; txtOpdracht.Text = "SCHADEVASTSTELLING"; txtOpdracht.Enabled = false; }
            if (dossierOnLoad.Opdracht.Equals("GERECHTSEXPERTISE")) { ckbGerechtsexpertise.Checked = true; ckbSchadevaststelling.Checked = false; txtOpdracht.Text = "GERECHTSEXPERTISE"; txtOpdracht.Enabled = false; }
            if (!dossierOnLoad.Opdracht.Equals("SCHADEVASTSTELLING") && !dossierOnLoad.Opdracht.Equals("GERECHTSEXPERTISE")) { ckbGerechtsexpertise.Checked = false; ckbSchadevaststelling.Checked = false; txtOpdracht.Text = dossierOnLoad.Opdracht; }
            txtOpmerking.Text = dossierOnLoad.Opmerking;

        }
        private void setReferentieDetails()
        {
            SelectedReference = frmOverview.Instance.SelectedReference;
            lblReferentie.Text = SelectedReference;
            dossierOnLoad = DossierDao.Instance.getDossierByReference(SelectedReference);
        }
        private void setMaatschappijDetails()
        {
            int idMaatschappij = DossierDao.Instance.getMaatschappijIdFromDossier(SelectedReference);
            string maatschappij = "";

            if (idMaatschappij != -1)
            {
                int i = 0;

                foreach (string maatschappijNaam in maatschappijen.Keys)
                {
                    if (maatschappijen[maatschappijNaam] == idMaatschappij)
                    {
                        maatschappij = maatschappijNaam;
                        break;
                    }
                }

                foreach (Object o in cmbMaatschappij.Items)
                {
                    string selectedMaatschappij = (string)o;

                    if (selectedMaatschappij.Equals(maatschappij.ToUpper()))
                    {
                        cmbMaatschappij.SelectedIndex = i;
                        setBeheerderDetails(selectedMaatschappij);
                        break;
                    }

                    i++;
                }
            }
            else
            {
                cmbMaatschappij.SelectedIndex = -1;
                cmbContract.SelectedText = "";
                dossierOnLoad.Maatschappij = "";
                cmbBeheerder.Items.Clear();
                dossierOnLoad.Beheerder = "";
            }
        }
        private void setContractDetails()
        {
            if (!dossierOnLoad.Contract.Trim().Equals(""))
            {
                int i = 0;
                foreach (Object o in cmbContract.Items)
                {
                    string selectedContract = (string)o;

                    if (selectedContract.ToUpper().Equals(dossierOnLoad.Contract.ToUpper()))
                    {
                        cmbContract.SelectedIndex = i;
                        break;
                    }

                    i++;
                }
            }
            else
            {
                cmbContract.SelectedIndex = -1;
                cmbContract.Text = "";
            }
        }
        private void setGemeenteDetails()
        {
            cmbPvdsPostcode.Text = dossierOnLoad.Pvds_postcode;
            cmbPvdsGemeente.Text = dossierOnLoad.Pvds_gemeente;
        }
        private void setBeheerderDetails(string maatschappij)
        {
            cmbBeheerder.Items.Clear();
            cmbBeheerder.SelectedIndex = -1;

            if (!maatschappij.Equals(""))
            {
                int selectedBeheerder = DossierDao.Instance.getBeheerderIdFromDossier(SelectedReference);
                cmbBeheerder.Sorted = true;
                try
                {
                    Dictionary<string, int> lookupDictionary = beheerders[maatschappij];
                    foreach (string beheerder in lookupDictionary.Keys)
                    {
                        cmbBeheerder.Items.Add(beheerder);
                        if (lookupDictionary[beheerder] == selectedBeheerder)
                        {
                            cmbBeheerder.SelectedIndex = cmbBeheerder.Items.IndexOf(beheerder);
                        }
                    }
                }
                catch (KeyNotFoundException knfe) { /*do nothing*/ }
    
            }
        }
        #endregion

        #region DossierInfoHandlers
        private void cmbMaatschappij_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaatschappij.SelectedIndex != -1)
            {
                string selectedMaatschappij = cmbMaatschappij.SelectedItem.ToString();
                cmbBeheerder.Text = "";
                setBeheerderDetails(selectedMaatschappij);
            }
            else
            {
                cmbBeheerder.Text = "";
                setBeheerderDetails("");
            }
        }
        private void cmbMaatschappij_TextChanged(object sender, EventArgs e)
        {
            if (cmbMaatschappij.Text.Equals(""))
            {
                cmbMaatschappij.SelectedIndex = -1;
                cmbBeheerder.Text = "";
                setBeheerderDetails("");
            }
        }
        private void ckbGerechtsexpertise_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbGerechtsexpertise.Checked == true)
            {
                ckbSchadevaststelling.Enabled = false;
                ckbGerechtsexpertise.Enabled = true;
                txtOpdracht.Text = "GERECHTSEXPERTISE";
                txtOpdracht.Enabled = false;
            }
            if (ckbGerechtsexpertise.Checked == false)
            {
                ckbSchadevaststelling.Enabled = true;
                ckbGerechtsexpertise.Enabled = true;
                txtOpdracht.Clear();
                txtOpdracht.Enabled = true;
            }
        }
        private void ckbSchadevaststelling_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSchadevaststelling.Checked == true)
            {
                ckbGerechtsexpertise.Enabled = false;
                ckbSchadevaststelling.Enabled = true;
                txtOpdracht.Text = "SCHADEVASTSTELLING";
                txtOpdracht.Enabled = false;
            }
            if (ckbSchadevaststelling.Checked == false)
            {
                ckbGerechtsexpertise.Enabled = true;
                ckbSchadevaststelling.Enabled = true;
                txtOpdracht.Clear();
                txtOpdracht.Enabled = true;
            }
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
                    if (dossierOnLoad != null && dossierOnLoad.Pvds_gemeente != null && !dossierOnLoad.Pvds_gemeente.Trim().Equals("") && dossierOnLoad.Pvds_postcode.Equals(cmbPvdsPostcode.SelectedItem.ToString()))
                    {

                        cmbPvdsGemeente.SelectedIndex = cmbPvdsGemeente.Items.IndexOf(dossierOnLoad.Pvds_gemeente);

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
        #endregion

        public void buildTabPage(string p)
        {
            TabPage control = null;

            foreach (TabPage tab in tabPartijen.Controls)
            {
                if (tab.Text.ToLower().Equals(p))
                {
                    control = tab;
                    break;
                }
            }

            control.Controls.Clear();

            TabControl tabcontrol = new TabControl();
            tabcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            ArrayList verzekerden = getPartijenPerSoort(p);
            int i = 1;
            foreach (Object o in verzekerden)
            {
                ArrayList groep = (ArrayList)o;
                Partij hoofdpartij = (Partij)groep[0];
                TabPage page = new TabPage(hoofdpartij.Naam.ToUpper());
                page.Controls.Add(buildListview(prepareArrayListForListView(groep)));
                tabcontrol.TabPages.Add(page);
                i++;
            }
            tabcontrol.SelectedIndexChanged += new System.EventHandler(SubTabPartijen_SelectedIndexChanged);
            control.Controls.Add(tabcontrol);


        }

        public ListView buildListview(string[,] partij)
        {
            ListView lv = new ListView();
            int aantal = 0;

            lv.Clear();
            //lvOverview.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200
            // Set the view to show details.
            lv.View = View.Details;
            // Allow the user to rearrange columns.
            lv.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            lv.FullRowSelect = true;
            // Display grid lines.
            lv.GridLines = true;
            // Sort the items in the list in ascending order.
            //lv.Sorting = SortOrder.Descending;

            string[,] partijen = partij;
            aantal = partijen.Length / 7;
            ListViewItem[] items = new ListViewItem[aantal];

            for (int i = 0; i < aantal; i++)
            {
                ListViewItem item = new ListViewItem(partijen[i, 0], i);

                for (int j = 1; j < 7; j++)
                {
                    item.SubItems.Add(partijen[i, j]);
                }
                items[i] = item;
            }

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            lv.Columns.Add("Hoedanigheid", 80, HorizontalAlignment.Left);
            lv.Columns.Add("Naam", 200, HorizontalAlignment.Left);
            lv.Columns.Add("Referentie", 200, HorizontalAlignment.Left);
            lv.Columns.Add("Email", 200, HorizontalAlignment.Left);
            lv.Columns.Add("Tel", 80, HorizontalAlignment.Left);
            lv.Columns.Add("Fax", 80, HorizontalAlignment.Left);
            lv.Columns.Add("GSM", 100, HorizontalAlignment.Left);

            //Add the items to the ListView.
            lv.Items.AddRange(items);
            lv.Dock = DockStyle.Fill;
            lv.SelectedIndexChanged += new System.EventHandler(this.listview_SelectedIndexChanged);
            lv.DoubleClick += new System.EventHandler(this.btnDetail_Click);
            return lv;
        }

        private string[,] prepareArrayListForListView(ArrayList partijen)
        {
            ArrayList partijenPerSoort = partijen;
            string[,] lijst = new string[partijenPerSoort.Count, 7];
            int aantal = 0;

            foreach (object o in partijenPerSoort)
            {

                Partij partij = (Partij)o;

                if (partij.Hoedanigheid != null) lijst[aantal, 0] = partij.Hoedanigheid; else lijst[aantal, 0] = "";
                if (partij.Naam != null) lijst[aantal, 1] = partij.Naam; else lijst[aantal, 1] = "";
                if (partij.Referentie != null) lijst[aantal, 2] = partij.Referentie; else lijst[aantal, 2] = "";
                if (partij.Email != null) lijst[aantal, 3] = partij.Email; else lijst[aantal, 3] = "";
                if (partij.Tel != null) lijst[aantal, 4] = partij.Tel; else lijst[aantal, 4] = "";
                if (partij.Fax != null) lijst[aantal, 5] = partij.Fax; else lijst[aantal, 5] = "";
                if (partij.Gsm != null) lijst[aantal, 6] = partij.Gsm; else lijst[aantal, 6] = "";

                aantal++;
            }

            return lijst;
        }
        private ArrayList getPartijenPerSoort(string partijSoort)
        {
            ArrayList hoofdverzekerden = new ArrayList();
            ArrayList lijst = new ArrayList();
            int type = 0;
            switch (partijSoort.ToLower())
            {
                case "verzekerde": type = 2; break;
                case "tegenpartij": type = 3; break;
                case "andere": type = 4; break;
            }

            foreach (Object o in partijen)
            {
                Partij partij = (Partij)o;
                if (partij.Type == type) hoofdverzekerden.Add(partij);
            }

            foreach (Object o in hoofdverzekerden)
            {
                ArrayList temp = new ArrayList();
                Partij hoofdverzekerde = (Partij)o;
                temp.Add(hoofdverzekerde);

                foreach (Object obj in partijen)
                {
                    Partij partij = (Partij)obj;
                    if (partij.Type == type + 3 && partij.Hoofdpartij_id == hoofdverzekerde.Id) temp.Add(partij);
                }

                lijst.Add(temp);
            }

            return lijst;
        }

        private void listview_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count == 1)
            {
                if (lv.SelectedIndices[0] == 0)
                {
                    switch (tabPartijen.SelectedTab.Text.ToLower())
                    {
                        case "verzekerde": this.SelectedPartijTypeId = 2; break;
                        case "tegenpartij": this.SelectedPartijTypeId = 3; break;
                        case "andere": this.SelectedPartijTypeId = 4; break;

                    }
                }
                if (lv.SelectedIndices[0] != 0 && SelectedPartijTypeId < 5)
                {
                    this.SelectedPartijTypeId += 3;
                }
                ListViewItem item = lv.SelectedItems[0];
                setSelectedPartij(item.Text, item.SubItems[1].Text.ToString(), item.SubItems[2].Text.ToString(), item.SubItems[3].Text.ToString(), item.SubItems[4].Text.ToString(), item.SubItems[5].Text.ToString(), item.SubItems[6].Text.ToString());
            }
            else
            {
                this.SelectedPartij = null;
            }
        }

        private void setSelectedPartij(string p, string p_2, string p_3, string p_4, string p_5, string p_6, string p_7)
        {
            foreach (Object o in partijen)
            {
                Partij partij = (Partij)o;

                if (partij.Hoedanigheid.ToLower().Equals(p.ToLower()) && partij.Naam.ToLower().Equals(p_2.ToLower()) && partij.Referentie.ToLower().Equals(p_3.ToLower()) && partij.Email.ToLower().Equals(p_4.ToLower()) && partij.Tel.ToLower().Equals(p_5.ToLower()) && partij.Fax.ToLower().Equals(p_6.ToLower()) && partij.Gsm.ToLower().Equals(p_7.ToLower()))
                {
                    this.SelectedPartij = partij;
                    break;
                }
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (selectedPartij != null) frmPartij.Instance.Show();
            else MessageBox.Show("Er werd geen partij geselecteerd", "Opgelet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tabPartijen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPartijen.Controls.Count != 0)
            {
                switch (tabPartijen.SelectedTab.Text.ToLower())
                {
                    case "verzekerde": this.SelectedPartijTypeId = 2; break;
                    case "tegenpartij": this.SelectedPartijTypeId = 3; break;
                    case "andere": this.SelectedPartijTypeId = 4; break;

                }
                btnNieuwePartij.Text = "Nieuwe " + tabPartijen.SelectedTab.Text;
                selectedPartij = null;

            }
        }

        private void SubTabPartijen_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl subcontrol = (TabControl)sender;
            string partij = subcontrol.SelectedTab.Text;

            selectedPartij = null;

        }

        private void btnNieuwePartij_Click(object sender, EventArgs e)
        {
            selectedPartij = null;
            if (SelectedPartijTypeId > 4)
            {
                SelectedPartijTypeId -= 3;
            }
            frmPartij.Instance.switchToHoofdPartij();
            frmPartij.Instance.Show();
        }

        private void btnNewRelated_Click(object sender, EventArgs e)
        {

            Object o = tabPartijen.SelectedTab.Controls[0];
            SelectedPartij = null;

            TabControl subcontrol = (TabControl)o;
            if (subcontrol.TabPages.Count != 0)
            {
                string hoofdpartijnaam = subcontrol.SelectedTab.Text;

                ArrayList partijen = getPartijenPerSoort(tabPartijen.SelectedTab.Text.ToLower());

                foreach (Object o2 in partijen)
                {
                    ArrayList partijgroep = (ArrayList)o2;
                    Partij hoofdpartij = (Partij)partijgroep[0];
                    if (hoofdpartij.Naam.ToUpper().Equals(hoofdpartijnaam.ToUpper()))
                    {
                        SelectedHoofdpartijId = hoofdpartij.Id;
                        break;
                    }
                }

                frmPartij.Instance.switchToRelated();
                frmPartij.Instance.Show();
            }
        }

        private void btnToonPrestatie_Click(object sender, EventArgs e)
        {
            Object prestatie = PrestatieDao.Instance.getOpenstaandePrestatie(this.SelectedDossierId);

            if (prestatie != null)
            {
                frmPrestatie.Instance.PrestatieVoorForm = (Prestatie)prestatie;
                frmPrestatie.Instance.Show();
            }
            else
            {
                Prestatie newPrestatie = new Prestatie();
                newPrestatie.DossierId = this.SelectedDossierId;
                newPrestatie.Werkdatum = DateTime.Now.ToString("dd/MM/yyyy"); ;
                newPrestatie.Herinnerdatum = "";
                newPrestatie.Btw = 21;
                newPrestatie.TotaalErelonen = 0;
                newPrestatie.TotaalOnkosten = 0;
                newPrestatie.TotaalBtw = 0;
                newPrestatie.Historiek = "";
                newPrestatie.Tariefniveau = "medium";
                newPrestatie.Openstaand = true;
                PrestatieDao.Instance.createNewPrestatie(newPrestatie);
                prestatie = PrestatieDao.Instance.getOpenstaandePrestatie(this.SelectedDossierId);

                Kost kost = new Kost();
                kost.PrestatieId = PrestatieDao.Instance.getLatestPrestatie(selectedDossierId);
                kost.Type = 'O';
                kost.Datum = txtDateIn.Text;
                kost.Omschrijving = "openen dossier";
                kost.Commentaar = "Openen nieuw Dossier + Nazicht Facturatie";
                kost.Hoeveelheid = 1;
                kost.Eenheidsprijs = PrijslijstDao.Instance.getKostDetailByOmschrijving("openen dossier").Prijsmedium;
                kost.setTotaal();
                kost.HoofdKostId = 0;
                kost.KostenPost = "KOS";

                KostDao.Instance.createKost(kost);
                frmPrestatie.Instance.PrestatieVoorForm = (Prestatie)prestatie;
                frmPrestatie.Instance.Show();
            }

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

        private void btnAfdrukken_Click(object sender, EventArgs e)
        {
            prgrsBar.Visible = true;
            prgrsBar.Value = 5;
            newDossier = new Dossier();
            newDossier.Id = dossierOnLoad.Id;
            newDossier.Referentie = SelectedReference;
            newDossier.Date_in = txtDateIn.Text;
            newDossier.Date_out = txtDateOut.Text;
            if (cmbMaatschappij.SelectedItem != null) newDossier.Maatschappij = cmbMaatschappij.SelectedItem.ToString(); else newDossier.Maatschappij = "";
            if (cmbBeheerder.SelectedItem != null) newDossier.Beheerder = cmbBeheerder.SelectedItem.ToString(); else newDossier.Beheerder = "";
            newDossier.Referentie_Maatschappij = txtReferentieMaatschappij.Text;
            newDossier.Polis = txtPolisnr.Text;
            if (cmbContract.SelectedItem != null) newDossier.Contract = cmbContract.SelectedItem.ToString(); else newDossier.Contract = "";
            newDossier.Pvds_datum = txtPvdsDatum.Text;
            newDossier.Pvds_naam = txtPvdsNaam.Text;
            newDossier.Pvds_straat = txtPvdsStraat.Text;
            newDossier.Pvds_nr = txtPvdsNr.Text;
            newDossier.Pvds_omvang = txtPvdsOmvang.Text;
            newDossier.Pvds_postcode = cmbPvdsPostcode.Text;
            newDossier.Pvds_gemeente = cmbPvdsGemeente.Text;
            newDossier.Plaatsbezoek = "dd. " + txtPbDd1.Text.Trim() + " om " + txtPbOm1.Text.Trim() + ";" + "dd. " + txtPbDd2.Text.Trim() + " om " + txtPbOm2.Text.Trim() + ";" +
               "dd. " + txtPbDd3.Text.Trim() + " om " + txtPbOm3.Text.Trim() + ";" + "dd. " + txtPbDd4.Text.Trim() + " om " + txtPbOm4.Text.Trim() + ";" +
               "dd. " + txtPbDd5.Text.Trim() + " om " + txtPbOm5.Text.Trim() + ";" + "dd. " + txtPbDd6.Text.Trim() + " om " + txtPbOm6.Text.Trim() + ";";
            newDossier.Opdracht = txtOpdracht.Text;
            newDossier.Opdracht = txtOpdracht.Text;
            newDossier.Opmerking = txtOpmerking.Text;
            prgrsBar.Value = 10;
            if (!newDossier.Equals(dossierOnLoad))
            {
                handleUpdating();
                ExcelBuilder builder = new ExcelBuilder();
                builder.buildVoorblad(newDossier, partijen);
            }
            else
            {
                ExcelBuilder builder = new ExcelBuilder();
                builder.buildVoorblad(newDossier, partijen);
            }

            
        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            frmHistorie.Instance.Show();
        }
    }
}
