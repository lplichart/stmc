namespace Mertens.Forms
{
    partial class frmMain
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beeldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overzichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoekenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.factuurZoekenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestatiesPerExpertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rapportageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beheerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maatschappijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adresboekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem,
            this.beeldToolStripMenuItem,
            this.extraToolStripMenuItem,
            this.beheerToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(921, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            this.mnuMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuMain_ItemClicked);
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sluitenToolStripMenuItem});
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.bestandToolStripMenuItem.Text = "Bestand";
            // 
            // sluitenToolStripMenuItem
            // 
            this.sluitenToolStripMenuItem.Name = "sluitenToolStripMenuItem";
            this.sluitenToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.sluitenToolStripMenuItem.Text = "Sluiten";
            this.sluitenToolStripMenuItem.Click += new System.EventHandler(this.sluitenToolStripMenuItem_Click);
            // 
            // beeldToolStripMenuItem
            // 
            this.beeldToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overzichtToolStripMenuItem});
            this.beeldToolStripMenuItem.Name = "beeldToolStripMenuItem";
            this.beeldToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.beeldToolStripMenuItem.Text = "Beeld";
            // 
            // overzichtToolStripMenuItem
            // 
            this.overzichtToolStripMenuItem.Name = "overzichtToolStripMenuItem";
            this.overzichtToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.overzichtToolStripMenuItem.Text = "Overzicht";
            this.overzichtToolStripMenuItem.Click += new System.EventHandler(this.overzichtToolStripMenuItem_Click);
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoekenToolStripMenuItem,
            this.factuurZoekenToolStripMenuItem,
            this.prestatiesPerExpertToolStripMenuItem,
            this.rapportageToolStripMenuItem});
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // zoekenToolStripMenuItem
            // 
            this.zoekenToolStripMenuItem.Name = "zoekenToolStripMenuItem";
            this.zoekenToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.zoekenToolStripMenuItem.Text = "Dossier Zoeken";
            this.zoekenToolStripMenuItem.Click += new System.EventHandler(this.zoekenToolStripMenuItem_Click);
            // 
            // factuurZoekenToolStripMenuItem
            // 
            this.factuurZoekenToolStripMenuItem.Name = "factuurZoekenToolStripMenuItem";
            this.factuurZoekenToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.factuurZoekenToolStripMenuItem.Text = "Openstaande Prestaties Zoeken";
            this.factuurZoekenToolStripMenuItem.Click += new System.EventHandler(this.factuurZoekenToolStripMenuItem_Click);
            // 
            // prestatiesPerExpertToolStripMenuItem
            // 
            this.prestatiesPerExpertToolStripMenuItem.Name = "prestatiesPerExpertToolStripMenuItem";
            this.prestatiesPerExpertToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.prestatiesPerExpertToolStripMenuItem.Text = "Prestaties per expert";
            this.prestatiesPerExpertToolStripMenuItem.Click += new System.EventHandler(this.prestatiesPerExpertToolStripMenuItem_Click);
            // 
            // rapportageToolStripMenuItem
            // 
            this.rapportageToolStripMenuItem.Name = "rapportageToolStripMenuItem";
            this.rapportageToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.rapportageToolStripMenuItem.Text = "Rapportage";
            this.rapportageToolStripMenuItem.Visible = false;
            this.rapportageToolStripMenuItem.Click += new System.EventHandler(this.rapportageToolStripMenuItem_Click);
            // 
            // beheerToolStripMenuItem
            // 
            this.beheerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maatschappijToolStripMenuItem,
            this.adresboekToolStripMenuItem,
            this.facturatieToolStripMenuItem});
            this.beheerToolStripMenuItem.Name = "beheerToolStripMenuItem";
            this.beheerToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.beheerToolStripMenuItem.Text = "Beheer";
            // 
            // maatschappijToolStripMenuItem
            // 
            this.maatschappijToolStripMenuItem.Name = "maatschappijToolStripMenuItem";
            this.maatschappijToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.maatschappijToolStripMenuItem.Text = "Maatschappij";
            this.maatschappijToolStripMenuItem.Click += new System.EventHandler(this.maatschappijToolStripMenuItem_Click);
            // 
            // adresboekToolStripMenuItem
            // 
            this.adresboekToolStripMenuItem.Name = "adresboekToolStripMenuItem";
            this.adresboekToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.adresboekToolStripMenuItem.Text = "Adresboek";
            this.adresboekToolStripMenuItem.Click += new System.EventHandler(this.adresboekToolStripMenuItem_Click);
            // 
            // facturatieToolStripMenuItem
            // 
            this.facturatieToolStripMenuItem.Name = "facturatieToolStripMenuItem";
            this.facturatieToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.facturatieToolStripMenuItem.Text = "Facturatie";
            this.facturatieToolStripMenuItem.Click += new System.EventHandler(this.facturatieToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 530);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "Mertens IT Beheersysteem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sluitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoekenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beheerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maatschappijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beeldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overzichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adresboekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem factuurZoekenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestatiesPerExpertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturatieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rapportageToolStripMenuItem;
    }
}