namespace Mertens.Forms
{
    partial class frmAdresboek
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPartijDetail = new System.Windows.Forms.Panel();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.cmbGemeente = new System.Windows.Forms.ComboBox();
            this.cmbPostcode = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtTelefoon = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtNaam = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvPartijen = new System.Windows.Forms.ListView();
            this.btnNiew = new System.Windows.Forms.Button();
            this.btnBewerken = new System.Windows.Forms.Button();
            this.btnVerwijderen = new System.Windows.Forms.Button();
            this.pnlPartijDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPartijDetail
            // 
            this.pnlPartijDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPartijDetail.Controls.Add(this.btnAnnuleren);
            this.pnlPartijDetail.Controls.Add(this.btnOpslaan);
            this.pnlPartijDetail.Controls.Add(this.cmbGemeente);
            this.pnlPartijDetail.Controls.Add(this.cmbPostcode);
            this.pnlPartijDetail.Controls.Add(this.txtEmail);
            this.pnlPartijDetail.Controls.Add(this.txtFax);
            this.pnlPartijDetail.Controls.Add(this.txtTelefoon);
            this.pnlPartijDetail.Controls.Add(this.txtAdres);
            this.pnlPartijDetail.Controls.Add(this.txtNaam);
            this.pnlPartijDetail.Controls.Add(this.label7);
            this.pnlPartijDetail.Controls.Add(this.label6);
            this.pnlPartijDetail.Controls.Add(this.label5);
            this.pnlPartijDetail.Controls.Add(this.label4);
            this.pnlPartijDetail.Controls.Add(this.label3);
            this.pnlPartijDetail.Controls.Add(this.label2);
            this.pnlPartijDetail.Controls.Add(this.label1);
            this.pnlPartijDetail.Enabled = false;
            this.pnlPartijDetail.Location = new System.Drawing.Point(70, 28);
            this.pnlPartijDetail.Name = "pnlPartijDetail";
            this.pnlPartijDetail.Size = new System.Drawing.Size(790, 144);
            this.pnlPartijDetail.TabIndex = 0;
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Location = new System.Drawing.Point(588, 94);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(121, 23);
            this.btnAnnuleren.TabIndex = 8;
            this.btnAnnuleren.Text = "Annuleren";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Visible = false;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Location = new System.Drawing.Point(423, 94);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(142, 23);
            this.btnOpslaan.TabIndex = 7;
            this.btnOpslaan.Text = "Opslaan";
            this.btnOpslaan.UseVisualStyleBackColor = true;
            this.btnOpslaan.Visible = false;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // cmbGemeente
            // 
            this.cmbGemeente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGemeente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGemeente.FormattingEnabled = true;
            this.cmbGemeente.Location = new System.Drawing.Point(103, 94);
            this.cmbGemeente.Name = "cmbGemeente";
            this.cmbGemeente.Size = new System.Drawing.Size(277, 21);
            this.cmbGemeente.TabIndex = 3;
            // 
            // cmbPostcode
            // 
            this.cmbPostcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPostcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPostcode.FormattingEnabled = true;
            this.cmbPostcode.Location = new System.Drawing.Point(103, 65);
            this.cmbPostcode.Name = "cmbPostcode";
            this.cmbPostcode.Size = new System.Drawing.Size(121, 21);
            this.cmbPostcode.TabIndex = 2;
            this.cmbPostcode.SelectedIndexChanged += new System.EventHandler(this.cmbPostcode_SelectedIndexChanged);
            this.cmbPostcode.TextChanged += new System.EventHandler(this.cmbPostcode_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(483, 64);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(216, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(483, 37);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(216, 20);
            this.txtFax.TabIndex = 5;
            // 
            // txtTelefoon
            // 
            this.txtTelefoon.Location = new System.Drawing.Point(483, 12);
            this.txtTelefoon.Name = "txtTelefoon";
            this.txtTelefoon.Size = new System.Drawing.Size(216, 20);
            this.txtTelefoon.TabIndex = 4;
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(103, 39);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(277, 20);
            this.txtAdres.TabIndex = 1;
            // 
            // txtNaam
            // 
            this.txtNaam.Location = new System.Drawing.Point(103, 13);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(277, 20);
            this.txtNaam.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(434, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "E-mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fax:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Telefoon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gemeente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Postcode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adres:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naam:";
            // 
            // lvPartijen
            // 
            this.lvPartijen.Location = new System.Drawing.Point(69, 178);
            this.lvPartijen.Name = "lvPartijen";
            this.lvPartijen.Size = new System.Drawing.Size(1108, 621);
            this.lvPartijen.TabIndex = 7;
            this.lvPartijen.UseCompatibleStateImageBehavior = false;
            this.lvPartijen.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvPartijen_ColumnClick);
            this.lvPartijen.SelectedIndexChanged += new System.EventHandler(this.lvPartijen_SelectedIndexChanged);
            // 
            // btnNiew
            // 
            this.btnNiew.Location = new System.Drawing.Point(70, 826);
            this.btnNiew.Name = "btnNiew";
            this.btnNiew.Size = new System.Drawing.Size(75, 23);
            this.btnNiew.TabIndex = 8;
            this.btnNiew.Text = "Nieuw";
            this.btnNiew.UseVisualStyleBackColor = true;
            this.btnNiew.Click += new System.EventHandler(this.btnNiew_Click);
            // 
            // btnBewerken
            // 
            this.btnBewerken.Location = new System.Drawing.Point(164, 826);
            this.btnBewerken.Name = "btnBewerken";
            this.btnBewerken.Size = new System.Drawing.Size(75, 23);
            this.btnBewerken.TabIndex = 9;
            this.btnBewerken.Text = "Bewerken";
            this.btnBewerken.UseVisualStyleBackColor = true;
            this.btnBewerken.Click += new System.EventHandler(this.btnBewerken_Click);
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.Location = new System.Drawing.Point(257, 826);
            this.btnVerwijderen.Name = "btnVerwijderen";
            this.btnVerwijderen.Size = new System.Drawing.Size(75, 23);
            this.btnVerwijderen.TabIndex = 10;
            this.btnVerwijderen.Text = "Verwijderen";
            this.btnVerwijderen.UseVisualStyleBackColor = true;
            this.btnVerwijderen.Click += new System.EventHandler(this.btnVerwijderen_Click);
            // 
            // frmAdresboek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 873);
            this.Controls.Add(this.btnVerwijderen);
            this.Controls.Add(this.btnBewerken);
            this.Controls.Add(this.btnNiew);
            this.Controls.Add(this.lvPartijen);
            this.Controls.Add(this.pnlPartijDetail);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdresboek";
            this.Text = "Adresboek";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdresboek_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.frmAdresboek_VisibleChanged);
            this.pnlPartijDetail.ResumeLayout(false);
            this.pnlPartijDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPartijDetail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtTelefoon;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.TextBox txtNaam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvPartijen;
        private System.Windows.Forms.Button btnNiew;
        private System.Windows.Forms.Button btnBewerken;
        private System.Windows.Forms.Button btnVerwijderen;
        private System.Windows.Forms.ComboBox cmbPostcode;
        private System.Windows.Forms.ComboBox cmbGemeente;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.Button btnAnnuleren;
    }
}