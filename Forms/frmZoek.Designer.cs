namespace Mertens.Forms
{
    partial class frmZoek
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
            this.pnlDossierInfo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPvdsDatum = new System.Windows.Forms.MaskedTextBox();
            this.txtPvdsNr = new System.Windows.Forms.TextBox();
            this.cmbPvdsGemeente = new System.Windows.Forms.ComboBox();
            this.cmbPvdsPostcode = new System.Windows.Forms.ComboBox();
            this.txtPvdsStraat = new System.Windows.Forms.TextBox();
            this.txtPvdsNaam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReferentie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnZoekOpReferentie = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbHoedanigheid = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtContactpersoon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbGemeente = new System.Windows.Forms.ComboBox();
            this.cmbPostcode = new System.Windows.Forms.ComboBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtNaam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlDossierInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDossierInfo
            // 
            this.pnlDossierInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDossierInfo.Controls.Add(this.label6);
            this.pnlDossierInfo.Controls.Add(this.txtPvdsDatum);
            this.pnlDossierInfo.Controls.Add(this.txtPvdsNr);
            this.pnlDossierInfo.Controls.Add(this.cmbPvdsGemeente);
            this.pnlDossierInfo.Controls.Add(this.cmbPvdsPostcode);
            this.pnlDossierInfo.Controls.Add(this.txtPvdsStraat);
            this.pnlDossierInfo.Controls.Add(this.txtPvdsNaam);
            this.pnlDossierInfo.Controls.Add(this.label2);
            this.pnlDossierInfo.Location = new System.Drawing.Point(33, 122);
            this.pnlDossierInfo.Name = "pnlDossierInfo";
            this.pnlDossierInfo.Size = new System.Drawing.Size(493, 116);
            this.pnlDossierInfo.TabIndex = 0;
            this.pnlDossierInfo.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Datum van de schade:";
            // 
            // txtPvdsDatum
            // 
            this.txtPvdsDatum.BeepOnError = true;
            this.txtPvdsDatum.Location = new System.Drawing.Point(374, 25);
            this.txtPvdsDatum.Mask = "00/00/0000";
            this.txtPvdsDatum.Name = "txtPvdsDatum";
            this.txtPvdsDatum.Size = new System.Drawing.Size(100, 20);
            this.txtPvdsDatum.TabIndex = 11;
            // 
            // txtPvdsNr
            // 
            this.txtPvdsNr.Location = new System.Drawing.Point(289, 52);
            this.txtPvdsNr.Name = "txtPvdsNr";
            this.txtPvdsNr.Size = new System.Drawing.Size(61, 20);
            this.txtPvdsNr.TabIndex = 8;
            // 
            // cmbPvdsGemeente
            // 
            this.cmbPvdsGemeente.FormattingEnabled = true;
            this.cmbPvdsGemeente.Location = new System.Drawing.Point(138, 79);
            this.cmbPvdsGemeente.Name = "cmbPvdsGemeente";
            this.cmbPvdsGemeente.Size = new System.Drawing.Size(212, 21);
            this.cmbPvdsGemeente.TabIndex = 10;
            // 
            // cmbPvdsPostcode
            // 
            this.cmbPvdsPostcode.Location = new System.Drawing.Point(10, 79);
            this.cmbPvdsPostcode.Name = "cmbPvdsPostcode";
            this.cmbPvdsPostcode.Size = new System.Drawing.Size(121, 21);
            this.cmbPvdsPostcode.TabIndex = 9;
            this.cmbPvdsPostcode.SelectedIndexChanged += new System.EventHandler(this.cmbPvdsPostcode_SelectedIndexChanged);
            this.cmbPvdsPostcode.TextChanged += new System.EventHandler(this.cmbPvdsPostcode_TextChanged);
            // 
            // txtPvdsStraat
            // 
            this.txtPvdsStraat.Location = new System.Drawing.Point(10, 52);
            this.txtPvdsStraat.Name = "txtPvdsStraat";
            this.txtPvdsStraat.Size = new System.Drawing.Size(263, 20);
            this.txtPvdsStraat.TabIndex = 7;
            // 
            // txtPvdsNaam
            // 
            this.txtPvdsNaam.Location = new System.Drawing.Point(10, 26);
            this.txtPvdsNaam.Name = "txtPvdsNaam";
            this.txtPvdsNaam.Size = new System.Drawing.Size(340, 20);
            this.txtPvdsNaam.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Naam en Plaats van de schade:";
            // 
            // txtReferentie
            // 
            this.txtReferentie.Location = new System.Drawing.Point(10, 27);
            this.txtReferentie.Name = "txtReferentie";
            this.txtReferentie.Size = new System.Drawing.Size(356, 20);
            this.txtReferentie.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Referentie maatschappij en andere partijen";
            // 
            // btnZoekOpReferentie
            // 
            this.btnZoekOpReferentie.Location = new System.Drawing.Point(33, 453);
            this.btnZoekOpReferentie.Name = "btnZoekOpReferentie";
            this.btnZoekOpReferentie.Size = new System.Drawing.Size(232, 23);
            this.btnZoekOpReferentie.TabIndex = 10;
            this.btnZoekOpReferentie.Text = "Zoek";
            this.btnZoekOpReferentie.UseVisualStyleBackColor = true;
            this.btnZoekOpReferentie.Click += new System.EventHandler(this.btnZoek_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtReferentie);
            this.panel1.Location = new System.Drawing.Point(33, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 64);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmbHoedanigheid);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtContactpersoon);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cmbGemeente);
            this.panel2.Controls.Add(this.cmbPostcode);
            this.panel2.Controls.Add(this.txtAdres);
            this.panel2.Controls.Add(this.txtNaam);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(33, 244);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 200);
            this.panel2.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Partij informatie";
            // 
            // cmbHoedanigheid
            // 
            this.cmbHoedanigheid.FormattingEnabled = true;
            this.cmbHoedanigheid.Location = new System.Drawing.Point(112, 165);
            this.cmbHoedanigheid.Name = "cmbHoedanigheid";
            this.cmbHoedanigheid.Size = new System.Drawing.Size(277, 21);
            this.cmbHoedanigheid.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Hoedanigheid:";
            // 
            // txtContactpersoon
            // 
            this.txtContactpersoon.Location = new System.Drawing.Point(112, 136);
            this.txtContactpersoon.Name = "txtContactpersoon";
            this.txtContactpersoon.Size = new System.Drawing.Size(277, 20);
            this.txtContactpersoon.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Contactpersoon:";
            // 
            // cmbGemeente
            // 
            this.cmbGemeente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGemeente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGemeente.FormattingEnabled = true;
            this.cmbGemeente.Location = new System.Drawing.Point(112, 109);
            this.cmbGemeente.Name = "cmbGemeente";
            this.cmbGemeente.Size = new System.Drawing.Size(277, 21);
            this.cmbGemeente.TabIndex = 43;
            // 
            // cmbPostcode
            // 
            this.cmbPostcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPostcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPostcode.FormattingEnabled = true;
            this.cmbPostcode.Location = new System.Drawing.Point(112, 80);
            this.cmbPostcode.Name = "cmbPostcode";
            this.cmbPostcode.Size = new System.Drawing.Size(121, 21);
            this.cmbPostcode.TabIndex = 42;
            this.cmbPostcode.SelectedIndexChanged += new System.EventHandler(this.cmbPostcode_SelectedIndexChanged);
            this.cmbPostcode.TextChanged += new System.EventHandler(this.cmbPostcode_TextChanged);
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(112, 54);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(277, 20);
            this.txtAdres.TabIndex = 41;
            // 
            // txtNaam
            // 
            this.txtNaam.Location = new System.Drawing.Point(112, 28);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(277, 20);
            this.txtNaam.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Gemeente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Postcode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Adres:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Naam:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(463, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(161, 26);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 25);
            this.label11.TabIndex = 14;
            this.label11.Text = "Dossier Zoeken";
            // 
            // frmZoek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 479);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnZoekOpReferentie);
            this.Controls.Add(this.pnlDossierInfo);
            this.Name = "frmZoek";
            this.Text = "frmZoek";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmZoek_FormClosing);
            this.pnlDossierInfo.ResumeLayout(false);
            this.pnlDossierInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDossierInfo;
        private System.Windows.Forms.TextBox txtReferentie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnZoekOpReferentie;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPvdsNr;
        private System.Windows.Forms.ComboBox cmbPvdsGemeente;
        private System.Windows.Forms.ComboBox cmbPvdsPostcode;
        private System.Windows.Forms.TextBox txtPvdsStraat;
        private System.Windows.Forms.TextBox txtPvdsNaam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtPvdsDatum;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbHoedanigheid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtContactpersoon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbGemeente;
        private System.Windows.Forms.ComboBox cmbPostcode;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.TextBox txtNaam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
    }
}