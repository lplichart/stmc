namespace Mertens.Forms
{
    partial class frmPartij
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
            this.txtGsm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContactpersoon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbHoedanigheid = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHoedanigheid = new System.Windows.Forms.TextBox();
            this.txtReferentie = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ckbAdresboek = new System.Windows.Forms.CheckBox();
            this.cmbAdresboek = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbGemeente
            // 
            this.cmbGemeente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGemeente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGemeente.FormattingEnabled = true;
            this.cmbGemeente.Location = new System.Drawing.Point(126, 144);
            this.cmbGemeente.Name = "cmbGemeente";
            this.cmbGemeente.Size = new System.Drawing.Size(277, 21);
            this.cmbGemeente.TabIndex = 4;
            // 
            // cmbPostcode
            // 
            this.cmbPostcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPostcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPostcode.FormattingEnabled = true;
            this.cmbPostcode.Location = new System.Drawing.Point(126, 115);
            this.cmbPostcode.Name = "cmbPostcode";
            this.cmbPostcode.Size = new System.Drawing.Size(121, 21);
            this.cmbPostcode.TabIndex = 3;
            this.cmbPostcode.SelectedIndexChanged += new System.EventHandler(this.cmbPostcode_SelectedIndexChanged);
            this.cmbPostcode.TextChanged += new System.EventHandler(this.cmbPostcode_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(498, 145);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(290, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(498, 87);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(216, 20);
            this.txtFax.TabIndex = 8;
            // 
            // txtTelefoon
            // 
            this.txtTelefoon.Location = new System.Drawing.Point(498, 62);
            this.txtTelefoon.Name = "txtTelefoon";
            this.txtTelefoon.Size = new System.Drawing.Size(216, 20);
            this.txtTelefoon.TabIndex = 7;
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(126, 89);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(277, 20);
            this.txtAdres.TabIndex = 2;
            // 
            // txtNaam
            // 
            this.txtNaam.Location = new System.Drawing.Point(126, 63);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(277, 20);
            this.txtNaam.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(449, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "E-mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Fax:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Telefoon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Gemeente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Postcode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Adres:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Naam:";
            // 
            // txtGsm
            // 
            this.txtGsm.Location = new System.Drawing.Point(498, 116);
            this.txtGsm.Name = "txtGsm";
            this.txtGsm.Size = new System.Drawing.Size(216, 20);
            this.txtGsm.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Gsm:";
            // 
            // txtContactpersoon
            // 
            this.txtContactpersoon.Location = new System.Drawing.Point(126, 179);
            this.txtContactpersoon.Name = "txtContactpersoon";
            this.txtContactpersoon.Size = new System.Drawing.Size(277, 20);
            this.txtContactpersoon.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Contactpersoon:";
            // 
            // cmbHoedanigheid
            // 
            this.cmbHoedanigheid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbHoedanigheid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHoedanigheid.FormattingEnabled = true;
            this.cmbHoedanigheid.Location = new System.Drawing.Point(126, 208);
            this.cmbHoedanigheid.Name = "cmbHoedanigheid";
            this.cmbHoedanigheid.Size = new System.Drawing.Size(277, 21);
            this.cmbHoedanigheid.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Hoedanigheid:";
            // 
            // txtHoedanigheid
            // 
            this.txtHoedanigheid.Location = new System.Drawing.Point(126, 208);
            this.txtHoedanigheid.Name = "txtHoedanigheid";
            this.txtHoedanigheid.Size = new System.Drawing.Size(277, 20);
            this.txtHoedanigheid.TabIndex = 6;
            // 
            // txtReferentie
            // 
            this.txtReferentie.Location = new System.Drawing.Point(497, 179);
            this.txtReferentie.Name = "txtReferentie";
            this.txtReferentie.Size = new System.Drawing.Size(290, 20);
            this.txtReferentie.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(428, 182);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Referentie:";
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Location = new System.Drawing.Point(622, 257);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(166, 23);
            this.btnAnnuleren.TabIndex = 13;
            this.btnAnnuleren.Text = "Annuleren";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Location = new System.Drawing.Point(450, 257);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(166, 23);
            this.btnOpslaan.TabIndex = 12;
            this.btnOpslaan.Text = "Opslaan";
            this.btnOpslaan.UseVisualStyleBackColor = true;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 257);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(166, 23);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "Verwijderen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ckbAdresboek
            // 
            this.ckbAdresboek.AutoSize = true;
            this.ckbAdresboek.Location = new System.Drawing.Point(126, 24);
            this.ckbAdresboek.Name = "ckbAdresboek";
            this.ckbAdresboek.Size = new System.Drawing.Size(99, 17);
            this.ckbAdresboek.TabIndex = 0;
            this.ckbAdresboek.Text = "Adresboek Aan";
            this.ckbAdresboek.UseVisualStyleBackColor = true;
            this.ckbAdresboek.CheckedChanged += new System.EventHandler(this.ckbAdresboek_CheckedChanged);
            // 
            // cmbAdresboek
            // 
            this.cmbAdresboek.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAdresboek.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAdresboek.FormattingEnabled = true;
            this.cmbAdresboek.Location = new System.Drawing.Point(126, 63);
            this.cmbAdresboek.Name = "cmbAdresboek";
            this.cmbAdresboek.Size = new System.Drawing.Size(277, 21);
            this.cmbAdresboek.TabIndex = 1;
            this.cmbAdresboek.Visible = false;
            this.cmbAdresboek.SelectedIndexChanged += new System.EventHandler(this.cmbAdresboek_SelectedIndexChanged);
            // 
            // frmPartij
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 310);
            this.Controls.Add(this.cmbAdresboek);
            this.Controls.Add(this.ckbAdresboek);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOpslaan);
            this.Controls.Add(this.btnAnnuleren);
            this.Controls.Add(this.txtReferentie);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtHoedanigheid);
            this.Controls.Add(this.cmbHoedanigheid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtContactpersoon);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtGsm);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbGemeente);
            this.Controls.Add(this.cmbPostcode);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTelefoon);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtNaam);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPartij";
            this.Text = "Partij Detail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPartij_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.frmPartij_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbGemeente;
        private System.Windows.Forms.ComboBox cmbPostcode;
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
        private System.Windows.Forms.TextBox txtGsm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtContactpersoon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbHoedanigheid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHoedanigheid;
        private System.Windows.Forms.TextBox txtReferentie;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox ckbAdresboek;
        private System.Windows.Forms.ComboBox cmbAdresboek;
    }
}