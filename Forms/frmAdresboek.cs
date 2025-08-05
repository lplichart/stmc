using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Mertens.Dao;
using Mertens.BusinessLogic;

namespace Mertens.Forms
{
    public partial class frmAdresboek : Form
    {
        private int aantal = 0;
        private int sortColumn = -1;
        private Boolean niewePartij = false;
        private Partij partij = null;
        private Partij partijToCompare = null;
        static frmAdresboek instance = null;
        static readonly object padlock = new object();

        frmAdresboek()
        {
            InitializeComponent();
            setupCmbPostcode();
        }

        internal Partij Partij
        {
            get { return partij; }
            set { partij = value; }
        }

        private void setupCmbPostcode()
        {
            foreach (Object o in GemeenteDao.Instance.getAllPostCodes())
            {
                cmbPostcode.Items.Add((String)o);
            }
        }

        public static frmAdresboek Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmAdresboek();
                    }
                    return instance;
                }
            }
        }

        public void buildListView()
        {
            lvPartijen.Clear();
            // Set the view to show details.
            lvPartijen.View = View.Details;
            // Allow the user to rearrange columns.
            lvPartijen.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            lvPartijen.FullRowSelect = true;
            // Display grid lines.
            lvPartijen.GridLines = true;
            // Sort the items in the list in ascending order.
            lvPartijen.Sorting = SortOrder.Ascending;

            string[,] partijen = findPartijen();
            ListViewItem[] items = new ListViewItem[aantal];


            for (int i = 0; i < aantal; i++)
            {
                ListViewItem item = new ListViewItem(partijen[i, 0], i);
                for (int j = 1; j < 7; j++)
                {
                    item.SubItems.Add(partijen[i, j]);
                    items[i] = item;
                }
            }

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            lvPartijen.Columns.Add("Naam", 150, HorizontalAlignment.Left);
            lvPartijen.Columns.Add("Adres", 200, HorizontalAlignment.Left);
            lvPartijen.Columns.Add("Postcode", 50, HorizontalAlignment.Left);
            lvPartijen.Columns.Add("Gemeente", 150, HorizontalAlignment.Left);
            lvPartijen.Columns.Add("Telefoon", 80, HorizontalAlignment.Left);
            lvPartijen.Columns.Add("Fax", 80, HorizontalAlignment.Left);
            lvPartijen.Columns.Add("E-mail", -2, HorizontalAlignment.Left);

            //Add the items to the ListView.
            lvPartijen.Items.AddRange(items);

            // Add the ListView to the control collection.
            this.Controls.Add(lvPartijen);
        }

        private string[,] findPartijen()
        {
            lvPartijen.Items.Clear();
            ArrayList beheerders = AdresboekDao.Instance.getPartijenFromAdresboek();
            string[,] lijst = new string[beheerders.Count, 7];
            aantal = 0;

            foreach (object o in beheerders)
            {
                Partij partij = (Partij)o;
                try
                {
                    lijst[aantal, 0] = partij.Naam;
                    lijst[aantal, 1] = partij.Adres;
                    lijst[aantal, 2] = partij.Postcode;
                    lijst[aantal, 3] = partij.Gemeente;
                    lijst[aantal, 4] = partij.Tel;
                    lijst[aantal, 5] = partij.Fax;
                    lijst[aantal, 6] = partij.Email;

                    aantal++;
                }
                catch (Exception e) { /*nothing to do yet*/}
            }
            return lijst;
        }

        private void frmAdresboek_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                buildListView();
            }
        }

        private void frmAdresboek_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            frmOverview.Instance.Show();
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

        private void lvPartijen_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lvPartijen.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lvPartijen.Sorting == SortOrder.Ascending)
                    lvPartijen.Sorting = SortOrder.Descending;
                else
                    lvPartijen.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            lvPartijen.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.lvPartijen.ListViewItemSorter = new ListViewItemComparer(e.Column, lvPartijen.Sorting);
        }

        private void lvPartijen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPartijen.SelectedItems.Count != 0)
            {
                Partij = new Partij();
                Partij.Naam = lvPartijen.SelectedItems[0].SubItems[0].Text.ToString();
                Partij.Adres = lvPartijen.SelectedItems[0].SubItems[1].Text.ToString();
                cmbPostcode.Text = lvPartijen.SelectedItems[0].SubItems[2].Text.ToString();
                Partij.Postcode = cmbPostcode.Text;

                cmbGemeente.Text = lvPartijen.SelectedItems[0].SubItems[3].Text.ToString();
                Partij.Gemeente = cmbGemeente.Text;
                
                Partij.Tel = lvPartijen.SelectedItems[0].SubItems[4].Text.ToString();
                Partij.Fax = lvPartijen.SelectedItems[0].SubItems[5].Text.ToString();
                Partij.Email = lvPartijen.SelectedItems[0].SubItems[6].Text.ToString();

                txtNaam.Text = Partij.Naam;
                txtAdres.Text = Partij.Adres;
                txtTelefoon.Text = Partij.Tel;
                txtFax.Text = Partij.Fax;
                txtEmail.Text = Partij.Email;
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

                if (cmbGemeente.Items.Count == 1)
                {
                    cmbGemeente.SelectedIndex = 0;
                    Partij.Gemeente = cmbGemeente.SelectedItem.ToString();
                }
                else
                {
                    if (Partij != null && cmbPostcode.SelectedItem.ToString().Equals(lvPartijen.SelectedItems[0].SubItems[2].Text))
                    {
                        cmbGemeente.SelectedIndex = cmbGemeente.Items.IndexOf(lvPartijen.SelectedItems[0].SubItems[3].Text);
                        Partij.Gemeente = cmbGemeente.SelectedItem.ToString();
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

        private void btnNiew_Click(object sender, EventArgs e)
        {
            clearPanel();
            Partij = new Partij();
            pnlPartijDetail.Enabled = true;
            btnOpslaan.Visible = true;
            btnAnnuleren.Visible = true;
            niewePartij = true;
        }

        private void btnBewerken_Click(object sender, EventArgs e)
        {
            niewePartij = false;

            if (lvPartijen.SelectedItems.Count == 0)
            {
                MessageBox.Show("Er werd geen partij geselecteerd!", "Opgelet!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {

                btnOpslaan.Visible = false;
                btnOpslaan.Visible = true;
                btnAnnuleren.Visible = true;
                partijToCompare = Partij;
                pnlPartijDetail.Enabled = true;
            }

        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            pnlPartijDetail.Enabled = false;
            btnOpslaan.Visible = false;
            btnAnnuleren.Visible = false;
            niewePartij = false;
            clearPanel();
            buildListView();
        }

        private void clearPanel()
        {

            txtNaam.Clear();
            txtAdres.Clear();
            lvPartijen.SelectedItems.Clear();
            cmbPostcode.SelectedIndex = -1;
            txtTelefoon.Clear();
            txtFax.Clear();
            txtEmail.Clear();
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (niewePartij == true)
            {
                if (txtNaam.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Er moet op zijn minst een naam worden opgegeven voor de partij!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    string postcode = "";
                    string gemeente = "";
                    if (cmbPostcode.SelectedIndex != -1) postcode = cmbPostcode.SelectedItem.ToString();
                    if (cmbGemeente.SelectedIndex != -1) gemeente = cmbGemeente.SelectedItem.ToString();
                    Partij = new Partij(txtNaam.Text, txtAdres.Text, postcode, gemeente, txtTelefoon.Text, txtFax.Text, txtEmail.Text);
                    AdresboekDao.Instance.addNewPartijInAdresboek(partij);
                    pnlPartijDetail.Enabled = false;
                    btnOpslaan.Visible = false;
                    btnAnnuleren.Visible = false;
                    niewePartij = false;
                    clearPanel();
                    buildListView();
                    frmPartij.Instance.findAdressen();
                }
            }
            else
            {
                Partij partijInDb = AdresboekDao.Instance.getPartijFromAdresboek(partijToCompare);
                if (partijInDb != null)
                {
                    string postcode = cmbPostcode.Text;
                    string gemeente = cmbGemeente.Text;
                    Partij = new Partij(txtNaam.Text, txtAdres.Text, postcode, gemeente, txtTelefoon.Text, txtFax.Text, txtEmail.Text);
                    AdresboekDao.Instance.updateAdresboek(partijToCompare, Partij);
                    pnlPartijDetail.Enabled = false;
                    btnOpslaan.Visible = false;
                    btnAnnuleren.Visible = false;
                    clearPanel();
                    buildListView();
                    frmPartij.Instance.findAdressen();
                }
                else
                {
                    {
                        MessageBox.Show("Kon de partij niet bewerken omdat iemand anders de partij reeds wijzigde of verwijderde!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        pnlPartijDetail.Enabled = false;
                        btnOpslaan.Visible = false;
                        btnAnnuleren.Visible = false;
                        clearPanel();
                        buildListView();
                    }
                }
            }

        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            if (lvPartijen.SelectedItems.Count == 0)
            {
                MessageBox.Show("Er werd geen partij geselecteerd!", "Opgelet!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                AdresboekDao.Instance.deletePartijFromAdresboek(Partij);
                clearPanel();
                buildListView();
                frmPartij.Instance.findAdressen();
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
