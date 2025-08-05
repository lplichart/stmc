namespace Mertens.Forms
{
    partial class frmMaatschappijAanpassen
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
            this.pnlMaatschappij = new System.Windows.Forms.Panel();
            this.cmbGemeente = new System.Windows.Forms.ComboBox();
            this.cmbPostcode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaatschappijFax = new System.Windows.Forms.MaskedTextBox();
            this.txtMaatschappijTelefoon = new System.Windows.Forms.MaskedTextBox();
            this.txtMaatschappijEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBtwNr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaatschappijAdres = new System.Windows.Forms.TextBox();
            this.txtMaatschappij = new System.Windows.Forms.TextBox();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.Annuleer = new System.Windows.Forms.Button();
            this.pnlMaatschappij.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMaatschappij
            // 
            this.pnlMaatschappij.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMaatschappij.Controls.Add(this.cmbGemeente);
            this.pnlMaatschappij.Controls.Add(this.cmbPostcode);
            this.pnlMaatschappij.Controls.Add(this.label1);
            this.pnlMaatschappij.Controls.Add(this.txtMaatschappijFax);
            this.pnlMaatschappij.Controls.Add(this.txtMaatschappijTelefoon);
            this.pnlMaatschappij.Controls.Add(this.txtMaatschappijEmail);
            this.pnlMaatschappij.Controls.Add(this.label13);
            this.pnlMaatschappij.Controls.Add(this.label12);
            this.pnlMaatschappij.Controls.Add(this.label11);
            this.pnlMaatschappij.Controls.Add(this.txtBtwNr);
            this.pnlMaatschappij.Controls.Add(this.label10);
            this.pnlMaatschappij.Controls.Add(this.label9);
            this.pnlMaatschappij.Controls.Add(this.label8);
            this.pnlMaatschappij.Controls.Add(this.label7);
            this.pnlMaatschappij.Controls.Add(this.txtMaatschappijAdres);
            this.pnlMaatschappij.Controls.Add(this.txtMaatschappij);
            this.pnlMaatschappij.Location = new System.Drawing.Point(12, 39);
            this.pnlMaatschappij.Name = "pnlMaatschappij";
            this.pnlMaatschappij.Size = new System.Drawing.Size(790, 116);
            this.pnlMaatschappij.TabIndex = 10;
            // 
            // cmbGemeente
            // 
            this.cmbGemeente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGemeente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGemeente.FormattingEnabled = true;
            this.cmbGemeente.Location = new System.Drawing.Point(110, 83);
            this.cmbGemeente.Name = "cmbGemeente";
            this.cmbGemeente.Size = new System.Drawing.Size(308, 21);
            this.cmbGemeente.TabIndex = 3;
            // 
            // cmbPostcode
            // 
            this.cmbPostcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPostcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPostcode.FormattingEnabled = true;
            this.cmbPostcode.Location = new System.Drawing.Point(110, 56);
            this.cmbPostcode.Name = "cmbPostcode";
            this.cmbPostcode.Size = new System.Drawing.Size(121, 21);
            this.cmbPostcode.TabIndex = 2;
            this.cmbPostcode.SelectedIndexChanged += new System.EventHandler(this.cmbPostcode_SelectedIndexChanged);
            this.cmbPostcode.TextChanged += new System.EventHandler(this.cmbPostcode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Postcode:";
            // 
            // txtMaatschappijFax
            // 
            this.txtMaatschappijFax.Location = new System.Drawing.Point(539, 32);
            this.txtMaatschappijFax.Name = "txtMaatschappijFax";
            this.txtMaatschappijFax.Size = new System.Drawing.Size(80, 20);
            this.txtMaatschappijFax.TabIndex = 5;
            // 
            // txtMaatschappijTelefoon
            // 
            this.txtMaatschappijTelefoon.Location = new System.Drawing.Point(539, 6);
            this.txtMaatschappijTelefoon.Name = "txtMaatschappijTelefoon";
            this.txtMaatschappijTelefoon.Size = new System.Drawing.Size(80, 20);
            this.txtMaatschappijTelefoon.TabIndex = 4;
            // 
            // txtMaatschappijEmail
            // 
            this.txtMaatschappijEmail.Location = new System.Drawing.Point(539, 58);
            this.txtMaatschappijEmail.Name = "txtMaatschappijEmail";
            this.txtMaatschappijEmail.Size = new System.Drawing.Size(229, 20);
            this.txtMaatschappijEmail.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(493, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "E-mail:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(504, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Fax:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(479, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Telefoon:";
            // 
            // txtBtwNr
            // 
            this.txtBtwNr.Location = new System.Drawing.Point(539, 89);
            this.txtBtwNr.Name = "txtBtwNr";
            this.txtBtwNr.Size = new System.Drawing.Size(229, 20);
            this.txtBtwNr.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(463, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Btw nummer:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Gemeente:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Adres:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Maatschappij:";
            // 
            // txtMaatschappijAdres
            // 
            this.txtMaatschappijAdres.Location = new System.Drawing.Point(110, 32);
            this.txtMaatschappijAdres.Name = "txtMaatschappijAdres";
            this.txtMaatschappijAdres.Size = new System.Drawing.Size(308, 20);
            this.txtMaatschappijAdres.TabIndex = 1;
            // 
            // txtMaatschappij
            // 
            this.txtMaatschappij.Location = new System.Drawing.Point(110, 6);
            this.txtMaatschappij.Name = "txtMaatschappij";
            this.txtMaatschappij.Size = new System.Drawing.Size(308, 20);
            this.txtMaatschappij.TabIndex = 0;
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Location = new System.Drawing.Point(212, 161);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(126, 31);
            this.btnOpslaan.TabIndex = 11;
            this.btnOpslaan.Text = "Opslaan";
            this.btnOpslaan.UseVisualStyleBackColor = true;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // Annuleer
            // 
            this.Annuleer.Location = new System.Drawing.Point(452, 161);
            this.Annuleer.Name = "Annuleer";
            this.Annuleer.Size = new System.Drawing.Size(126, 31);
            this.Annuleer.TabIndex = 12;
            this.Annuleer.Text = "Annuleer";
            this.Annuleer.UseVisualStyleBackColor = true;
            this.Annuleer.Click += new System.EventHandler(this.Annuleer_Click);
            // 
            // frmMaatschappijAanpassen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 223);
            this.Controls.Add(this.Annuleer);
            this.Controls.Add(this.btnOpslaan);
            this.Controls.Add(this.pnlMaatschappij);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaatschappijAanpassen";
            this.Text = "Maatschappij";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMaatschappijAanpassen_FormClosing);
            this.Load += new System.EventHandler(this.frmMaatschappijAanpassen_Load);
            this.VisibleChanged += new System.EventHandler(this.frmMaatschappijAanpassen_VisibleChanged);
            this.pnlMaatschappij.ResumeLayout(false);
            this.pnlMaatschappij.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMaatschappij;
        private System.Windows.Forms.MaskedTextBox txtMaatschappijFax;
        private System.Windows.Forms.MaskedTextBox txtMaatschappijTelefoon;
        private System.Windows.Forms.TextBox txtMaatschappijEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBtwNr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaatschappijAdres;
        private System.Windows.Forms.TextBox txtMaatschappij;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.Button Annuleer;
        private System.Windows.Forms.ComboBox cmbPostcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGemeente;
    }
}