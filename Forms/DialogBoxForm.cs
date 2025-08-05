using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mertens.Forms
{
    public partial class DialogBoxForm : Form
    {
       
        public DialogBoxForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            frmMain.Instance.DialogText = txtPassword.Text;
            this.Close();
        }
    }
}
