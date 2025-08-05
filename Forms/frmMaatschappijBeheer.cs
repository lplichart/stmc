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
    public partial class frmMaatschappijBeheer : Form
    {
        private int aantal = 0;
        private Dictionary<string, int> maatschappijen;
        private string selectedMaatschappij = "";
        private int sortColumn = -1;
        private int selectedMaatschappijId;
        private Maatschappij maatschappij;
        static frmMaatschappijBeheer instance = null;
        static readonly object padlock = new object();


        public frmMaatschappijBeheer()
        {
            InitializeComponent();
        }

        public static frmMaatschappijBeheer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmMaatschappijBeheer();
                    }
                    return instance;
                }
            }
        }

        public void fillListBoxMaatschappij()
        {
            lsbMaatschappij.Items.Clear();
            maatschappijen = MaatschappijDao.Instance.getMaatschappijen();
            foreach (string naam in maatschappijen.Keys)
            {
                lsbMaatschappij.Items.Add(naam);
            }

            lsbMaatschappij.SelectedIndex = 0;
        }

        public void buildListView()
        {
            lvBeheerders.Clear();
            // Set the view to show details.
            lvBeheerders.View = View.Details;
            // Allow the user to rearrange columns.
            lvBeheerders.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            lvBeheerders.FullRowSelect = true;
            // Display grid lines.
            lvBeheerders.GridLines = true;
            // Sort the items in the list in ascending order.
            lvBeheerders.Sorting = SortOrder.Ascending;

            string[,] beheerders = findBeheerders();
            ListViewItem[] items = new ListViewItem[aantal];


            for (int i = 0; i < aantal; i++)
            {
                ListViewItem item = new ListViewItem(beheerders[i, 0], i);
                for (int j = 1; j < 6; j++)
                {
                    item.SubItems.Add(beheerders[i, j]);
                    items[i] = item;
                }
            }

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            lvBeheerders.Columns.Add("Titel", 40, HorizontalAlignment.Left);
            lvBeheerders.Columns.Add("Naam", 200, HorizontalAlignment.Left);
            lvBeheerders.Columns.Add("Voornaam", 150, HorizontalAlignment.Left);
            lvBeheerders.Columns.Add("Telefoon", 80, HorizontalAlignment.Left);
            lvBeheerders.Columns.Add("Fax", 80, HorizontalAlignment.Left);
            lvBeheerders.Columns.Add("E-mail", -2, HorizontalAlignment.Left);

            //Add the items to the ListView.
            lvBeheerders.Items.AddRange(items);

            // Add the ListView to the control collection.
            this.Controls.Add(lvBeheerders);
        }

        private string[,] findBeheerders()
        {
            lvBeheerders.Items.Clear();
            ArrayList beheerders = BeheerderDao.Instance.getBeheerdersDetailByMaatschappij(selectedMaatschappij);
            string[,] lijst = new string[beheerders.Count, 6];
            aantal = 0;

            foreach (object o in beheerders)
            {

                Beheerder beheerder = (Beheerder)o;


                try
                {
                    lijst[aantal, 0] = beheerder.Aanspreektitel;
                    lijst[aantal, 1] = beheerder.Naam;
                    lijst[aantal, 2] = beheerder.Voornaam;
                    lijst[aantal, 3] = beheerder.Telefoon;
                    lijst[aantal, 4] = beheerder.Fax;
                    lijst[aantal, 5] = beheerder.Email;

                    aantal++;

                }
                catch (Exception e) { /*nothing to do yet*/}

            }

            return lijst;
        }

        private void lsbMaatschappij_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMaatschappij = lsbMaatschappij.SelectedItem.ToString();
            setMaatschappijInfo();
            buildListView();
        }

        private void setMaatschappijInfo()
        {
            Maatschappij = MaatschappijDao.Instance.getMaatschappijByNaam(selectedMaatschappij);
            selectedMaatschappijId = Maatschappij.Id;
            txtMaatschappij.Text = Maatschappij.Naam;
            txtMaatschappijAdres.Text = Maatschappij.Straat;
            txtMaatschappijGemeente.Text = Maatschappij.Postcode + " " + Maatschappij.Gemeente;
            txtBtwNr.Text = Maatschappij.Btw;
            txtMaatschappijTelefoon.Text = Maatschappij.Telefoon;
            txtMaatschappijFax.Text = Maatschappij.Fax;
            txtMaatschappijEmail.Text = Maatschappij.Email;
        }

        private void btnAddBeheerder_Click(object sender, EventArgs e)
        {
            if (txtBeheerderNaam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Gelieve ten minste de naam op te geven van de dossierbeheerder",
                    "Fout!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                Beheerder beheerder = new Beheerder(selectedMaatschappij, txtBeheerderNaam.Text);
                beheerder.Aanspreektitel = txtBeheerderTitel.Text;
                beheerder.Voornaam = txtBeheerderVoornaam.Text;
                beheerder.Telefoon = txtBeheerderTelefoon.Text;
                beheerder.Fax = txtBeheerderFax.Text;
                beheerder.Email = txtBeheerderEmail.Text;

                BeheerderDao.Instance.AddBeheerder(beheerder);
                buildListView();
                clearToevoegenbeheerder();
                frmDetails.Instance.refresh();
            }

        }

        private void clearToevoegenbeheerder()
        {
            txtBeheerderTitel.Clear();
            txtBeheerderNaam.Clear();
            txtBeheerderVoornaam.Clear();
            txtBeheerderTelefoon.Clear();
            txtBeheerderFax.Clear();
            txtBeheerderEmail.Clear();
        }

        private void frmMaatschappijBeheer_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frmMaatschappijBeheer_Load(object sender, EventArgs e)
        {

        }

        private void btnBeheerderVerwijderen_Click(object sender, EventArgs e)
        {
            if (lvBeheerders.SelectedItems.Count == 0)
            {
                MessageBox.Show("Geen beheerder geselecteerd", "Opgelet!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bent u zeker dat u deze beheerder wilt verwijderen?", "Verwijderen Beheerder?", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result.ToString().Equals("Yes"))
                {
                    Beheerder beheerderInDatabase = BeheerderDao.Instance.getBeheerder(selectedMaatschappijId, getSelectedBeheerder());
                    if (beheerderInDatabase == null)
                    {
                        MessageBox.Show("Kan de beheerder niet verwijderen om dat iemand zijn gegevens reeds aanpaste of de beheerder al verwijderd heeft!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        buildListView();
                    }
                    else
                    {
                        BeheerderDao.Instance.deleteBeheerder(beheerderInDatabase);
                        buildListView();
                        frmDetails.Instance.refresh();
                    }
                    

                }
            }
        }

        private Beheerder getSelectedBeheerder()
        {
            if (lvBeheerders.SelectedItems.Count != 0)
            {
                string titel = lvBeheerders.SelectedItems[0].SubItems[0].Text;
                string naam = lvBeheerders.SelectedItems[0].SubItems[1].Text;
                string voornaam = lvBeheerders.SelectedItems[0].SubItems[2].Text;
                string telefoon = lvBeheerders.SelectedItems[0].SubItems[3].Text;
                string fax = lvBeheerders.SelectedItems[0].SubItems[4].Text;
                string email = lvBeheerders.SelectedItems[0].SubItems[5].Text;

                Beheerder selectedBeheerder = new Beheerder(selectedMaatschappij, naam);
                selectedBeheerder.Aanspreektitel = titel;
                selectedBeheerder.Naam = naam;
                selectedBeheerder.Voornaam = voornaam;
                selectedBeheerder.Telefoon = telefoon;
                selectedBeheerder.Fax = fax;
                selectedBeheerder.Email = email;
                return selectedBeheerder;
            }

            return null;
        }

        internal Maatschappij Maatschappij
        {
            get { return maatschappij; }
            set { maatschappij = value; }
        }

        private void btnBeheerderAanpassen_Click(object sender, EventArgs e)
        {
            if (lvBeheerders.SelectedItems.Count == 0)
            {
                MessageBox.Show("Geen beheerder geselecteerd", "Opgelet!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                frmBeheerderAanpassen.Instance.OldBeheerder = getSelectedBeheerder();
                frmBeheerderAanpassen.Instance.SelectedMaatschappijId = this.selectedMaatschappijId;
                frmBeheerderAanpassen.Instance.SelectedMaatschappij = this.selectedMaatschappij;
                frmBeheerderAanpassen.Instance.Dock = DockStyle.Top;
                frmBeheerderAanpassen.Instance.Show();
            }

        }

        private void lvBeheerders_DoubleClick(object sender, EventArgs e)
        {
            btnBeheerderAanpassen_Click(sender, e);
        }

        private void lvBeheerders_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lvBeheerders.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lvBeheerders.Sorting == SortOrder.Ascending)
                    lvBeheerders.Sorting = SortOrder.Descending;
                else
                    lvBeheerders.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            lvBeheerders.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.lvBeheerders.ListViewItemSorter = new ListViewItemComparer(e.Column, lvBeheerders.Sorting);
            
        }

        private void frmMaatschappijBeheer_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                fillListBoxMaatschappij();
                lvBeheerders.Sorting = SortOrder.Ascending;
                lvBeheerders.Sort();
                this.lvBeheerders.ListViewItemSorter = new ListViewItemComparer(1, lvBeheerders.Sorting);
            }

        }

        private void btnNewMaatschappij_Click(object sender, EventArgs e)
        {
            frmMaatschappijAanpassen.Instance.NieuweMaatschappij = true;
            frmMaatschappijAanpassen.Instance.Dock = DockStyle.Top;
            frmMaatschappijAanpassen.Instance.Show();
        }

        private void btnBewerken_Click(object sender, EventArgs e)
        {
            frmMaatschappijAanpassen.Instance.NieuweMaatschappij = false;
            frmMaatschappijAanpassen.Instance.Dock = DockStyle.Top;
            frmMaatschappijAanpassen.Instance.Show();
        }

    }
}
