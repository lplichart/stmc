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
    public partial class frmOverview : Form
    {
        private DossierDao dossierDao;
        private PartijDao partijDao;
        private int aantal = 0;
        private string selectedReference;
        private string nextReference;
        private int sortColumn = -1;
        static frmOverview instance = null;
        static readonly object padlock = new object();

        frmOverview()
        {
            InitializeComponent();
            dossierDao = DossierDao.Instance;
            partijDao = PartijDao.Instance;
            buildListView("SELECT * FROM dossier ORDER BY referentie DESC;");
            selectedReference = "";
        }

        public static frmOverview Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmOverview();
                    }
                    return instance;
                }
            }
        }

        public string SelectedReference
        {
            get { return selectedReference; }
            set { selectedReference = value; }
        }

        public void buildListView(string query)
        {
            lvOverview.Clear();
            //lvOverview.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

            // Set the view to show details.
            lvOverview.View = View.Details;
            // Allow the user to rearrange columns.
            lvOverview.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            lvOverview.FullRowSelect = true;
            // Display grid lines.
            lvOverview.GridLines = true;
            // Sort the items in the list in ascending order.
            lvOverview.Sorting = SortOrder.Descending;

            string[,] dossiers = findDossiers(query);
            ListViewItem[] items = new ListViewItem[aantal];


            for (int i = 0; i < aantal; i++)
            {
                ListViewItem item = new ListViewItem(dossiers[i, 0], i);
                for (int j = 1; j < 6; j++)
                {
                    item.SubItems.Add(dossiers[i, j]);
                }
                items[i] = item;
            }

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            lvOverview.Columns.Add("Referentie", 100, HorizontalAlignment.Left);
            lvOverview.Columns.Add("Date In", 100, HorizontalAlignment.Left);
            lvOverview.Columns.Add("Date Out ", 100, HorizontalAlignment.Left);
            lvOverview.Columns.Add("Opdrachtgever", 200, HorizontalAlignment.Left);
            lvOverview.Columns.Add("Verzekerde", 200, HorizontalAlignment.Left);
            lvOverview.Columns.Add("Tegenpartij", 200, HorizontalAlignment.Left);

            //Add the items to the ListView.
            lvOverview.Items.AddRange(items);

            // Add the ListView to the control collection.
            this.Controls.Add(lvOverview);
        }

        private string[,] findDossiers(string query)
        {
            ArrayList dossiers = dossierDao.getDossiers(query);
            string[,] lijst = new string[dossiers.Count, 6];
            
            aantal = 0;

            foreach (object o in dossiers)
            {

                Dossier dossier = (Dossier)o;
                string verzekerde = "";
                string tegenpartij = "";
                string date_in = "";
                string date_out = "";

                if (dossier.Date_in.Length != 0)
                {
                    date_in = dossier.Date_in;
                }


                if (dossier.Date_out.Length != 0)
                {
                    date_out = dossier.Date_out;
                }

                foreach (Object po in partijDao.getPartijenVoorDossier(dossier.Id))
                {
                    Partij partij = (Partij)po;

                    if (partij.Type == 2 && verzekerde.Equals(""))
                    {
                        verzekerde = partij.Naam;
                    }

                    if (partij.Type == 3 && tegenpartij.Equals(""))
                    {
                        tegenpartij = partij.Naam;
                    }
                }

                if (aantal == 0) { setNextReference(dossier.Referentie); }

                lijst[aantal, 0] = dossier.Referentie;
                lijst[aantal, 1] = date_in;
                lijst[aantal, 2] = date_out;
                lijst[aantal, 3] = dossier.Maatschappij;
                lijst[aantal, 4] = verzekerde;
                lijst[aantal, 5] = tegenpartij;

                aantal++;
            }

            return lijst;
        }

        private void setNextReference(string p)
        {
            if (p.Length == 11)
            {
                string prefix = p.Substring(0, 5);
                string root = p.Substring(5, 4);
                string suffix = p.Substring(9, 1);

                int nextnumber = int.Parse(root);
                nextnumber += 1;
                if (nextnumber < 10) { root = "000" + nextnumber.ToString(); }
                if (nextnumber < 100 && nextnumber >= 10) { root = "00" + nextnumber.ToString(); }
                if (nextnumber < 1000 && nextnumber >= 100) { root = "0" + nextnumber.ToString(); }
                if (nextnumber >= 1000) { root = nextnumber.ToString(); }
                this.nextReference = prefix + root + suffix;
            }
            else
            {
                this.nextReference = "";
            }
        }

        private void lvOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvOverview.SelectedItems.Count != 0)
            {
                this.selectedReference = lvOverview.SelectedItems[0].Text;
            }
        }

        private void btnBekijkDetail_Click(object sender, EventArgs e)
        {
            if (selectedReference != "")
            {
                frmDetails.Instance.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Er werd geen dossier geselecteerd", "Opgelet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void frmOverview_VisibleChanged(object sender, EventArgs e)
        {
            if (frmOverview.Instance.Visible == true)
            {
                //buildListView("SELECT * FROM dossier ORDER BY referentie DESC;");

                if (selectedReference != "")
                {
                    int i = 0;

                    foreach (Object o in lvOverview.Items)
                    {
                        ListViewItem item = (ListViewItem)o;

                        if (item.Text == SelectedReference)
                        {
                            lvOverview.Items[i].Selected = true;
                        }
                        i++;
                    }
                }
            }
        }

        private void lvOverview_DoubleClick(object sender, EventArgs e)
        {
            btnBekijkDetail_Click(sender, e);
        }

        private void lvOverview_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lvOverview.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lvOverview.Sorting == SortOrder.Ascending)
                    lvOverview.Sorting = SortOrder.Descending;
                else
                    lvOverview.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            lvOverview.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.lvOverview.ListViewItemSorter = new ListViewItemComparer(e.Column, lvOverview.Sorting);

        }

        private void btnNiewDossier_Click(object sender, EventArgs e)
        {
            frmNieuwDossier.Instance.switchToNew();
            frmNieuwDossier.Instance.Referentie = nextReference;
            frmNieuwDossier.Instance.Show();
        }

        private void btnReferentieAanpassen_Click(object sender, EventArgs e)
        {


            if (selectedReference != "")
            {
                frmNieuwDossier.Instance.switchToUpdate();
                frmNieuwDossier.Instance.Referentie = selectedReference;
                frmNieuwDossier.Instance.Show();
            }
            else
            {
                MessageBox.Show("Er werd geen dossier geselecteerd", "Opgelet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            buildListView("SELECT * FROM dossier ORDER BY referentie DESC;");
        }

        private void btnVerwachtlijst_Click(object sender, EventArgs e)
        {
            frmVerwacht.Instance.Show();
        }

        private void btnFindDossierByReference_Click(object sender, EventArgs e)
        {
            buildListView("SELECT * FROM dossier WHERE referentie LIKE \'%"+txtReferenceToFind.Text+"%\' ORDER BY referentie DESC;");
            txtReferenceToFind.Text = "";
        }

        private void txtReferenceToFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnFindDossierByReference_Click(sender, e);
            }
        }
    }
}
