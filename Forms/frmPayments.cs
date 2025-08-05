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
    public partial class frmPayments : Form
    {

        static frmPayments instance = null;
        static readonly object padlock = new object();

        public static frmPayments Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new frmPayments();
                    }
                    return instance;
                }
            }
        }

        public frmPayments()
        {
            InitializeComponent();
        }

        private void btnAfdrukken_Click(object sender, EventArgs e)
        {
            ArrayList facturen;
            string maand = "";
            String expert = cmbExpert.Text; 
            switch (cmbMaand.Text)
            {
                case "januari": maand = "01"; break;
                case "februari": maand = "02"; break;
                case "maart": maand = "03"; break;
                case "april": maand = "04"; break;
                case "mei": maand = "05"; break;
                case "juni": maand = "06"; break;
                case "juli": maand = "07"; break;
                case "augustus": maand = "08"; break;
                case "september": maand = "09"; break;
                case "oktober": maand = "10"; break;
                case "november": maand = "11"; break;
                case "december": maand = "12"; break;
            }

            if (expert.Equals("ALL"))
            {
                facturen = FactuurDao.Instance.getAllFacturenPerMonthAndYear(maand, cmbJaar.Text);
            }
            else
            {
                facturen = FactuurDao.Instance.getFactuurPerExpert(maand, cmbJaar.Text, expert);
            }
            ExcelBuilder builder = new ExcelBuilder();
            builder.buildPayment(facturen, expert, cmbMaand.Text + " "+cmbJaar.Text);
            
        }

        private void frmPayments_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
