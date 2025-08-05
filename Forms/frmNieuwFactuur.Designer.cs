namespace Mertens.Forms
{
    partial class frmNieuwFactuur
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
            this.cmbExpert = new System.Windows.Forms.ComboBox();
            this.txtFactuurnummer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnToevoegen = new System.Windows.Forms.Button();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.txtDatum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvKostenDetail = new System.Windows.Forms.DataGridView();
            this.clmDatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOmschrijving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHoeveelheid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEenheidsprijs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotaal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExclBtw = new System.Windows.Forms.TextBox();
            this.txtBtw = new System.Windows.Forms.TextBox();
            this.txtInclBtw = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKostenDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbExpert
            // 
            this.cmbExpert.FormattingEnabled = true;
            this.cmbExpert.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cmbExpert.Location = new System.Drawing.Point(159, 44);
            this.cmbExpert.Name = "cmbExpert";
            this.cmbExpert.Size = new System.Drawing.Size(58, 21);
            this.cmbExpert.TabIndex = 0;
            // 
            // txtFactuurnummer
            // 
            this.txtFactuurnummer.Location = new System.Drawing.Point(12, 44);
            this.txtFactuurnummer.Name = "txtFactuurnummer";
            this.txtFactuurnummer.Size = new System.Drawing.Size(141, 20);
            this.txtFactuurnummer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Factuurnummer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Expert";
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Location = new System.Drawing.Point(466, 819);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(93, 22);
            this.btnToevoegen.TabIndex = 4;
            this.btnToevoegen.Text = "Afdrukken";
            this.btnToevoegen.UseVisualStyleBackColor = true;
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Location = new System.Drawing.Point(565, 819);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(93, 22);
            this.btnAnnuleren.TabIndex = 5;
            this.btnAnnuleren.Text = "Annuleren";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(233, 44);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Size = new System.Drawing.Size(100, 20);
            this.txtDatum.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "FactuurDatum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 685);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Onvoorziene kosten en indexering";
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(588, 682);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(56, 20);
            this.txtIndex.TabIndex = 10;
            this.txtIndex.TextChanged += new System.EventHandler(this.txtIndex_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(642, 685);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "%";
            // 
            // dgvKostenDetail
            // 
            this.dgvKostenDetail.AllowUserToAddRows = false;
            this.dgvKostenDetail.AllowUserToDeleteRows = false;
            this.dgvKostenDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKostenDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDatum,
            this.clmOmschrijving,
            this.clmHoeveelheid,
            this.clmEenheidsprijs,
            this.clmTotaal});
            this.dgvKostenDetail.Location = new System.Drawing.Point(15, 97);
            this.dgvKostenDetail.Name = "dgvKostenDetail";
            this.dgvKostenDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvKostenDetail.Size = new System.Drawing.Size(644, 575);
            this.dgvKostenDetail.TabIndex = 12;
            this.dgvKostenDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKostenDetail_CellValueChanged);
            // 
            // clmDatum
            // 
            this.clmDatum.HeaderText = "datum";
            this.clmDatum.Name = "clmDatum";
            this.clmDatum.ReadOnly = true;
            // 
            // clmOmschrijving
            // 
            this.clmOmschrijving.HeaderText = "omschrijving";
            this.clmOmschrijving.Name = "clmOmschrijving";
            this.clmOmschrijving.ReadOnly = true;
            this.clmOmschrijving.Width = 200;
            // 
            // clmHoeveelheid
            // 
            this.clmHoeveelheid.HeaderText = "hoeveelheid";
            this.clmHoeveelheid.Name = "clmHoeveelheid";
            // 
            // clmEenheidsprijs
            // 
            this.clmEenheidsprijs.HeaderText = "eenheidsprijs";
            this.clmEenheidsprijs.Name = "clmEenheidsprijs";
            // 
            // clmTotaal
            // 
            this.clmTotaal.HeaderText = "totaal";
            this.clmTotaal.Name = "clmTotaal";
            this.clmTotaal.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 715);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Totaal excl. Btw";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(421, 739);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Btw";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 764);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Totaal incl. Btw";
            // 
            // txtExclBtw
            // 
            this.txtExclBtw.Enabled = false;
            this.txtExclBtw.Location = new System.Drawing.Point(449, 712);
            this.txtExclBtw.Name = "txtExclBtw";
            this.txtExclBtw.Size = new System.Drawing.Size(195, 20);
            this.txtExclBtw.TabIndex = 16;
            // 
            // txtBtw
            // 
            this.txtBtw.Enabled = false;
            this.txtBtw.Location = new System.Drawing.Point(449, 739);
            this.txtBtw.Name = "txtBtw";
            this.txtBtw.Size = new System.Drawing.Size(195, 20);
            this.txtBtw.TabIndex = 17;
            // 
            // txtInclBtw
            // 
            this.txtInclBtw.Enabled = false;
            this.txtInclBtw.Location = new System.Drawing.Point(449, 765);
            this.txtInclBtw.Name = "txtInclBtw";
            this.txtInclBtw.Size = new System.Drawing.Size(195, 20);
            this.txtInclBtw.TabIndex = 18;
            // 
            // frmNieuwFactuur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1225, 853);
            this.Controls.Add(this.txtInclBtw);
            this.Controls.Add(this.txtBtw);
            this.Controls.Add(this.txtExclBtw);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvKostenDetail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDatum);
            this.Controls.Add(this.btnAnnuleren);
            this.Controls.Add(this.btnToevoegen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFactuurnummer);
            this.Controls.Add(this.cmbExpert);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNieuwFactuur";
            this.Text = "Nieuw Factuur";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNieuwFactuur_FormClosing);
            this.Load += new System.EventHandler(this.frmNieuwFactuur_Load);
            this.VisibleChanged += new System.EventHandler(this.frmNieuwFactuur_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKostenDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbExpert;
        private System.Windows.Forms.TextBox txtFactuurnummer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnToevoegen;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.TextBox txtDatum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvKostenDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOmschrijving;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoeveelheid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEenheidsprijs;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotaal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtExclBtw;
        private System.Windows.Forms.TextBox txtBtw;
        private System.Windows.Forms.TextBox txtInclBtw;
    }
}