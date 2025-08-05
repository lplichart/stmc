namespace Mertens.Forms
{
    partial class frmMaatschappijBeheer
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
            this.lsbMaatschappij = new System.Windows.Forms.ListBox();
            this.lvBeheerders = new System.Windows.Forms.ListView();
            this.btnNewMaatschappij = new System.Windows.Forms.Button();
            this.btnBewerken = new System.Windows.Forms.Button();
            this.pnlMaatschappij = new System.Windows.Forms.Panel();
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
            this.txtMaatschappijGemeente = new System.Windows.Forms.TextBox();
            this.txtMaatschappijAdres = new System.Windows.Forms.TextBox();
            this.txtMaatschappij = new System.Windows.Forms.TextBox();
            this.txtBeheerderTitel = new System.Windows.Forms.TextBox();
            this.txtBeheerderNaam = new System.Windows.Forms.TextBox();
            this.txtBeheerderVoornaam = new System.Windows.Forms.TextBox();
            this.txtBeheerderTelefoon = new System.Windows.Forms.MaskedTextBox();
            this.txtBeheerderFax = new System.Windows.Forms.MaskedTextBox();
            this.txtBeheerderEmail = new System.Windows.Forms.MaskedTextBox();
            this.pnlNewBeheerder = new System.Windows.Forms.Panel();
            this.btnAddBeheerder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBeheerderAanpassen = new System.Windows.Forms.Button();
            this.btnBeheerderVerwijderen = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlMaatschappij.SuspendLayout();
            this.pnlNewBeheerder.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbMaatschappij
            // 
            this.lsbMaatschappij.FormattingEnabled = true;
            this.lsbMaatschappij.Location = new System.Drawing.Point(21, 44);
            this.lsbMaatschappij.Name = "lsbMaatschappij";
            this.lsbMaatschappij.Size = new System.Drawing.Size(275, 537);
            this.lsbMaatschappij.TabIndex = 0;
            this.lsbMaatschappij.SelectedIndexChanged += new System.EventHandler(this.lsbMaatschappij_SelectedIndexChanged);
            // 
            // lvBeheerders
            // 
            this.lvBeheerders.Location = new System.Drawing.Point(302, 166);
            this.lvBeheerders.Name = "lvBeheerders";
            this.lvBeheerders.Size = new System.Drawing.Size(791, 278);
            this.lvBeheerders.TabIndex = 6;
            this.lvBeheerders.UseCompatibleStateImageBehavior = false;
            this.lvBeheerders.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvBeheerders_ColumnClick);
            this.lvBeheerders.DoubleClick += new System.EventHandler(this.lvBeheerders_DoubleClick);
            // 
            // btnNewMaatschappij
            // 
            this.btnNewMaatschappij.Location = new System.Drawing.Point(21, 591);
            this.btnNewMaatschappij.Name = "btnNewMaatschappij";
            this.btnNewMaatschappij.Size = new System.Drawing.Size(118, 23);
            this.btnNewMaatschappij.TabIndex = 7;
            this.btnNewMaatschappij.Text = "Nieuw";
            this.btnNewMaatschappij.UseVisualStyleBackColor = true;
            this.btnNewMaatschappij.Click += new System.EventHandler(this.btnNewMaatschappij_Click);
            // 
            // btnBewerken
            // 
            this.btnBewerken.Location = new System.Drawing.Point(154, 591);
            this.btnBewerken.Name = "btnBewerken";
            this.btnBewerken.Size = new System.Drawing.Size(118, 23);
            this.btnBewerken.TabIndex = 8;
            this.btnBewerken.Text = "Bewerken";
            this.btnBewerken.UseVisualStyleBackColor = true;
            this.btnBewerken.Click += new System.EventHandler(this.btnBewerken_Click);
            // 
            // pnlMaatschappij
            // 
            this.pnlMaatschappij.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.pnlMaatschappij.Controls.Add(this.txtMaatschappijGemeente);
            this.pnlMaatschappij.Controls.Add(this.txtMaatschappijAdres);
            this.pnlMaatschappij.Controls.Add(this.txtMaatschappij);
            this.pnlMaatschappij.Location = new System.Drawing.Point(303, 44);
            this.pnlMaatschappij.Name = "pnlMaatschappij";
            this.pnlMaatschappij.Size = new System.Drawing.Size(790, 116);
            this.pnlMaatschappij.TabIndex = 9;
            // 
            // txtMaatschappijFax
            // 
            this.txtMaatschappijFax.Enabled = false;
            this.txtMaatschappijFax.Location = new System.Drawing.Point(539, 32);
            this.txtMaatschappijFax.Name = "txtMaatschappijFax";
            this.txtMaatschappijFax.Size = new System.Drawing.Size(80, 20);
            this.txtMaatschappijFax.TabIndex = 17;
            // 
            // txtMaatschappijTelefoon
            // 
            this.txtMaatschappijTelefoon.Enabled = false;
            this.txtMaatschappijTelefoon.Location = new System.Drawing.Point(539, 6);
            this.txtMaatschappijTelefoon.Name = "txtMaatschappijTelefoon";
            this.txtMaatschappijTelefoon.Size = new System.Drawing.Size(80, 20);
            this.txtMaatschappijTelefoon.TabIndex = 16;
            // 
            // txtMaatschappijEmail
            // 
            this.txtMaatschappijEmail.Enabled = false;
            this.txtMaatschappijEmail.Location = new System.Drawing.Point(539, 58);
            this.txtMaatschappijEmail.Name = "txtMaatschappijEmail";
            this.txtMaatschappijEmail.Size = new System.Drawing.Size(229, 20);
            this.txtMaatschappijEmail.TabIndex = 13;
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
            this.txtBtwNr.Enabled = false;
            this.txtBtwNr.Location = new System.Drawing.Point(110, 86);
            this.txtBtwNr.Name = "txtBtwNr";
            this.txtBtwNr.Size = new System.Drawing.Size(308, 20);
            this.txtBtwNr.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Btw nummer:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 58);
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
            // txtMaatschappijGemeente
            // 
            this.txtMaatschappijGemeente.Enabled = false;
            this.txtMaatschappijGemeente.Location = new System.Drawing.Point(110, 58);
            this.txtMaatschappijGemeente.Name = "txtMaatschappijGemeente";
            this.txtMaatschappijGemeente.Size = new System.Drawing.Size(308, 20);
            this.txtMaatschappijGemeente.TabIndex = 2;
            // 
            // txtMaatschappijAdres
            // 
            this.txtMaatschappijAdres.Enabled = false;
            this.txtMaatschappijAdres.Location = new System.Drawing.Point(110, 32);
            this.txtMaatschappijAdres.Name = "txtMaatschappijAdres";
            this.txtMaatschappijAdres.Size = new System.Drawing.Size(308, 20);
            this.txtMaatschappijAdres.TabIndex = 1;
            // 
            // txtMaatschappij
            // 
            this.txtMaatschappij.Enabled = false;
            this.txtMaatschappij.Location = new System.Drawing.Point(110, 6);
            this.txtMaatschappij.Name = "txtMaatschappij";
            this.txtMaatschappij.Size = new System.Drawing.Size(308, 20);
            this.txtMaatschappij.TabIndex = 0;
            // 
            // txtBeheerderTitel
            // 
            this.txtBeheerderTitel.Location = new System.Drawing.Point(16, 24);
            this.txtBeheerderTitel.Name = "txtBeheerderTitel";
            this.txtBeheerderTitel.Size = new System.Drawing.Size(40, 20);
            this.txtBeheerderTitel.TabIndex = 0;
            // 
            // txtBeheerderNaam
            // 
            this.txtBeheerderNaam.Location = new System.Drawing.Point(62, 24);
            this.txtBeheerderNaam.Name = "txtBeheerderNaam";
            this.txtBeheerderNaam.Size = new System.Drawing.Size(200, 20);
            this.txtBeheerderNaam.TabIndex = 1;
            // 
            // txtBeheerderVoornaam
            // 
            this.txtBeheerderVoornaam.Location = new System.Drawing.Point(268, 24);
            this.txtBeheerderVoornaam.Name = "txtBeheerderVoornaam";
            this.txtBeheerderVoornaam.Size = new System.Drawing.Size(150, 20);
            this.txtBeheerderVoornaam.TabIndex = 2;
            // 
            // txtBeheerderTelefoon
            // 
            this.txtBeheerderTelefoon.Location = new System.Drawing.Point(423, 24);
            this.txtBeheerderTelefoon.Name = "txtBeheerderTelefoon";
            this.txtBeheerderTelefoon.Size = new System.Drawing.Size(80, 20);
            this.txtBeheerderTelefoon.TabIndex = 3;
            // 
            // txtBeheerderFax
            // 
            this.txtBeheerderFax.Location = new System.Drawing.Point(510, 24);
            this.txtBeheerderFax.Name = "txtBeheerderFax";
            this.txtBeheerderFax.Size = new System.Drawing.Size(80, 20);
            this.txtBeheerderFax.TabIndex = 4;
            // 
            // txtBeheerderEmail
            // 
            this.txtBeheerderEmail.Location = new System.Drawing.Point(597, 24);
            this.txtBeheerderEmail.Name = "txtBeheerderEmail";
            this.txtBeheerderEmail.Size = new System.Drawing.Size(200, 20);
            this.txtBeheerderEmail.TabIndex = 5;
            // 
            // pnlNewBeheerder
            // 
            this.pnlNewBeheerder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNewBeheerder.Controls.Add(this.btnAddBeheerder);
            this.pnlNewBeheerder.Controls.Add(this.label6);
            this.pnlNewBeheerder.Controls.Add(this.label5);
            this.pnlNewBeheerder.Controls.Add(this.label4);
            this.pnlNewBeheerder.Controls.Add(this.label3);
            this.pnlNewBeheerder.Controls.Add(this.label2);
            this.pnlNewBeheerder.Controls.Add(this.label1);
            this.pnlNewBeheerder.Controls.Add(this.txtBeheerderTitel);
            this.pnlNewBeheerder.Controls.Add(this.txtBeheerderEmail);
            this.pnlNewBeheerder.Controls.Add(this.txtBeheerderNaam);
            this.pnlNewBeheerder.Controls.Add(this.txtBeheerderFax);
            this.pnlNewBeheerder.Controls.Add(this.txtBeheerderVoornaam);
            this.pnlNewBeheerder.Controls.Add(this.txtBeheerderTelefoon);
            this.pnlNewBeheerder.Location = new System.Drawing.Point(303, 499);
            this.pnlNewBeheerder.Name = "pnlNewBeheerder";
            this.pnlNewBeheerder.Size = new System.Drawing.Size(814, 79);
            this.pnlNewBeheerder.TabIndex = 18;
            // 
            // btnAddBeheerder
            // 
            this.btnAddBeheerder.Location = new System.Drawing.Point(268, 50);
            this.btnAddBeheerder.Name = "btnAddBeheerder";
            this.btnAddBeheerder.Size = new System.Drawing.Size(276, 23);
            this.btnAddBeheerder.TabIndex = 6;
            this.btnAddBeheerder.Text = "Nieuwe beheerder toevoegen aan maatschappij";
            this.btnAddBeheerder.UseVisualStyleBackColor = true;
            this.btnAddBeheerder.Click += new System.EventHandler(this.btnAddBeheerder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(594, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Fax";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Telefoon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Voornaam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Naam";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Titel";
            // 
            // btnBeheerderAanpassen
            // 
            this.btnBeheerderAanpassen.Location = new System.Drawing.Point(477, 461);
            this.btnBeheerderAanpassen.Name = "btnBeheerderAanpassen";
            this.btnBeheerderAanpassen.Size = new System.Drawing.Size(212, 23);
            this.btnBeheerderAanpassen.TabIndex = 19;
            this.btnBeheerderAanpassen.Text = "Beheerder aanpassen";
            this.btnBeheerderAanpassen.UseVisualStyleBackColor = true;
            this.btnBeheerderAanpassen.Click += new System.EventHandler(this.btnBeheerderAanpassen_Click);
            // 
            // btnBeheerderVerwijderen
            // 
            this.btnBeheerderVerwijderen.Location = new System.Drawing.Point(723, 461);
            this.btnBeheerderVerwijderen.Name = "btnBeheerderVerwijderen";
            this.btnBeheerderVerwijderen.Size = new System.Drawing.Size(212, 23);
            this.btnBeheerderVerwijderen.TabIndex = 20;
            this.btnBeheerderVerwijderen.Text = "Beheerder verwijderen";
            this.btnBeheerderVerwijderen.UseVisualStyleBackColor = true;
            this.btnBeheerderVerwijderen.Click += new System.EventHandler(this.btnBeheerderVerwijderen_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(276, 31);
            this.label14.TabIndex = 21;
            this.label14.Text = "Maatschappijbeheer";
            // 
            // frmMaatschappijBeheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1152, 620);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnBeheerderVerwijderen);
            this.Controls.Add(this.btnBeheerderAanpassen);
            this.Controls.Add(this.pnlNewBeheerder);
            this.Controls.Add(this.pnlMaatschappij);
            this.Controls.Add(this.btnBewerken);
            this.Controls.Add(this.btnNewMaatschappij);
            this.Controls.Add(this.lvBeheerders);
            this.Controls.Add(this.lsbMaatschappij);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaatschappijBeheer";
            this.Text = "Maatschappij Beheer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMaatschappijBeheer_FormClosing);
            this.Load += new System.EventHandler(this.frmMaatschappijBeheer_Load);
            this.VisibleChanged += new System.EventHandler(this.frmMaatschappijBeheer_VisibleChanged);
            this.pnlMaatschappij.ResumeLayout(false);
            this.pnlMaatschappij.PerformLayout();
            this.pnlNewBeheerder.ResumeLayout(false);
            this.pnlNewBeheerder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbMaatschappij;
        private System.Windows.Forms.ListView lvBeheerders;
        private System.Windows.Forms.Button btnNewMaatschappij;
        private System.Windows.Forms.Button btnBewerken;
        private System.Windows.Forms.Panel pnlMaatschappij;
        private System.Windows.Forms.TextBox txtBeheerderTitel;
        private System.Windows.Forms.TextBox txtBeheerderNaam;
        private System.Windows.Forms.TextBox txtBeheerderVoornaam;
        private System.Windows.Forms.MaskedTextBox txtBeheerderTelefoon;
        private System.Windows.Forms.MaskedTextBox txtBeheerderFax;
        private System.Windows.Forms.MaskedTextBox txtBeheerderEmail;
        private System.Windows.Forms.Panel pnlNewBeheerder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBtwNr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaatschappijGemeente;
        private System.Windows.Forms.TextBox txtMaatschappijAdres;
        private System.Windows.Forms.TextBox txtMaatschappij;
        private System.Windows.Forms.MaskedTextBox txtMaatschappijFax;
        private System.Windows.Forms.MaskedTextBox txtMaatschappijTelefoon;
        private System.Windows.Forms.TextBox txtMaatschappijEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddBeheerder;
        private System.Windows.Forms.Button btnBeheerderAanpassen;
        private System.Windows.Forms.Button btnBeheerderVerwijderen;
        private System.Windows.Forms.Label label14;
    }
}