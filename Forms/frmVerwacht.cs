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
    public partial class frmVerwacht : Form
    {
        static frmVerwacht instance = null;
        static readonly object padlock = new object();

        public static frmVerwacht Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmVerwacht();
                    }
                    return instance;
                }
            }
        }

        public frmVerwacht()
        {
            InitializeComponent();
        }

        private void frmVerwacht_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void frmVerwacht_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                lsbVerwachtlijst.Items.Clear();
                foreach (Object o in PrestatieDao.Instance.getVerwachtlijst())
                {
                    string lijn = (string)o;
                    string date = lijn.Replace('\t', ' ');
                    date = date.Substring(12, 10);
                    DateTime parsed;
                    if(DateTime.TryParse(date, out parsed))
                    {
                        if (DateTime.Compare(parsed,DateTime.Today)<= 0)
                        {
                            lsbVerwachtlijst.Items.Add(lijn);
                        }
                    }
                }        
                  
            }
        }

        private void lsbVerwachtlijst_DoubleClick(object sender, EventArgs e)
        {
            String reference = lsbVerwachtlijst.SelectedItem.ToString().Substring(0,11);
            this.Hide();
            frmOverview.Instance.SelectedReference = reference;
            frmDetails.Instance.Show();
            this.Hide();
            frmOverview.Instance.Hide();
        }

        
    }
}
