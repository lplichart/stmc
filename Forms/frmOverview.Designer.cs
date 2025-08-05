namespace Mertens.Forms
{
    partial class frmOverview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOverview));
            this.lvOverview = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNiewDossier = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBekijkDetail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReferentieAanpassen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVerwachtlijst = new System.Windows.Forms.ToolStripButton();
            this.txtReferenceToFind = new System.Windows.Forms.TextBox();
            this.btnFindDossierByReference = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvOverview
            // 
            this.lvOverview.Location = new System.Drawing.Point(12, 74);
            this.lvOverview.Name = "lvOverview";
            this.lvOverview.Size = new System.Drawing.Size(926, 791);
            this.lvOverview.TabIndex = 5;
            this.lvOverview.UseCompatibleStateImageBehavior = false;
            this.lvOverview.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOverview_ColumnClick);
            this.lvOverview.SelectedIndexChanged += new System.EventHandler(this.lvOverview_SelectedIndexChanged);
            this.lvOverview.DoubleClick += new System.EventHandler(this.lvOverview_DoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.btnNiewDossier,
            this.toolStripSeparator1,
            this.btnBekijkDetail,
            this.toolStripSeparator2,
            this.btnReferentieAanpassen,
            this.toolStripSeparator4,
            this.btnRefresh,
            this.toolStripSeparator5,
            this.btnVerwachtlijst});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1320, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNiewDossier
            // 
            this.btnNiewDossier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNiewDossier.Image = ((System.Drawing.Image)(resources.GetObject("btnNiewDossier.Image")));
            this.btnNiewDossier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNiewDossier.Name = "btnNiewDossier";
            this.btnNiewDossier.Size = new System.Drawing.Size(86, 22);
            this.btnNiewDossier.Text = "Nieuw Dossier";
            this.btnNiewDossier.Click += new System.EventHandler(this.btnNiewDossier_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBekijkDetail
            // 
            this.btnBekijkDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBekijkDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnBekijkDetail.Image")));
            this.btnBekijkDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBekijkDetail.Name = "btnBekijkDetail";
            this.btnBekijkDetail.Size = new System.Drawing.Size(75, 22);
            this.btnBekijkDetail.Text = "Bekijk Detail";
            this.btnBekijkDetail.Click += new System.EventHandler(this.btnBekijkDetail_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReferentieAanpassen
            // 
            this.btnReferentieAanpassen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReferentieAanpassen.Image = ((System.Drawing.Image)(resources.GetObject("btnReferentieAanpassen.Image")));
            this.btnReferentieAanpassen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReferentieAanpassen.Name = "btnReferentieAanpassen";
            this.btnReferentieAanpassen.Size = new System.Drawing.Size(124, 22);
            this.btnReferentieAanpassen.Text = "Referentie Aanpassen";
            this.btnReferentieAanpassen.Click += new System.EventHandler(this.btnReferentieAanpassen_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(50, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnVerwachtlijst
            // 
            this.btnVerwachtlijst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnVerwachtlijst.Image = ((System.Drawing.Image)(resources.GetObject("btnVerwachtlijst.Image")));
            this.btnVerwachtlijst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerwachtlijst.Name = "btnVerwachtlijst";
            this.btnVerwachtlijst.Size = new System.Drawing.Size(78, 22);
            this.btnVerwachtlijst.Text = "Verwachtlijst";
            this.btnVerwachtlijst.Click += new System.EventHandler(this.btnVerwachtlijst_Click);
            // 
            // txtReferenceToFind
            // 
            this.txtReferenceToFind.Location = new System.Drawing.Point(13, 41);
            this.txtReferenceToFind.Name = "txtReferenceToFind";
            this.txtReferenceToFind.Size = new System.Drawing.Size(160, 20);
            this.txtReferenceToFind.TabIndex = 7;
            this.txtReferenceToFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReferenceToFind_KeyDown);
            // 
            // btnFindDossierByReference
            // 
            this.btnFindDossierByReference.Location = new System.Drawing.Point(179, 41);
            this.btnFindDossierByReference.Name = "btnFindDossierByReference";
            this.btnFindDossierByReference.Size = new System.Drawing.Size(142, 23);
            this.btnFindDossierByReference.TabIndex = 8;
            this.btnFindDossierByReference.Text = "Vind Dossier";
            this.btnFindDossierByReference.UseVisualStyleBackColor = true;
            this.btnFindDossierByReference.Click += new System.EventHandler(this.btnFindDossierByReference_Click);
            // 
            // frmOverview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1320, 877);
            this.ControlBox = false;
            this.Controls.Add(this.btnFindDossierByReference);
            this.Controls.Add(this.txtReferenceToFind);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lvOverview);
            this.Name = "frmOverview";
            this.Text = "Overzicht";
            this.VisibleChanged += new System.EventHandler(this.frmOverview_VisibleChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvOverview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnBekijkDetail;
        private System.Windows.Forms.ToolStripButton btnNiewDossier;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnReferentieAanpassen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnVerwachtlijst;
        private System.Windows.Forms.TextBox txtReferenceToFind;
        private System.Windows.Forms.Button btnFindDossierByReference;
    }
}