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

namespace Mertens.Forms
{
    public partial class frmHistorie : Form
    {
        static frmHistorie instance = null;
        static readonly object padlock = new object();

        public static frmHistorie Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmHistorie();
                    }
                    return instance;
                }
            }
        }

        public frmHistorie()
        {
            InitializeComponent();
        }

        private void frmHistorie_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void frmHistorie_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                Prestatie prestatie = PrestatieDao.Instance.getPrestatieByDossierReferentie(frmDetails.Instance.SelectedReference);
                txtHistorie.Text = prestatie.Historiek;
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
    }
}
