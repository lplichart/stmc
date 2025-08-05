namespace Mertens.Forms
{
    partial class frmPrijslijst
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
            this.dgvErelonen = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvOnkosten = new System.Windows.Forms.DataGridView();
            this.clmErelonenOmschrijving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmErelonenPrijsLaag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmErelonenPrijsMedium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmErelonenPrijsHoog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErelonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnkosten)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvErelonen
            // 
            this.dgvErelonen.AllowUserToAddRows = false;
            this.dgvErelonen.AllowUserToDeleteRows = false;
            this.dgvErelonen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErelonen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmErelonenOmschrijving,
            this.clmErelonenPrijsLaag,
            this.clmErelonenPrijsMedium,
            this.clmErelonenPrijsHoog});
            this.dgvErelonen.Location = new System.Drawing.Point(12, 42);
            this.dgvErelonen.Name = "dgvErelonen";
            this.dgvErelonen.Size = new System.Drawing.Size(545, 483);
            this.dgvErelonen.TabIndex = 0;
            this.dgvErelonen.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvErelonen_CellValueChanged);
            this.dgvErelonen.VisibleChanged += new System.EventHandler(this.dgvErelonen_VisibleChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Erelonen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(578, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Onkosten";
            // 
            // dgvOnkosten
            // 
            this.dgvOnkosten.AllowUserToAddRows = false;
            this.dgvOnkosten.AllowUserToDeleteRows = false;
            this.dgvOnkosten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOnkosten.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvOnkosten.Location = new System.Drawing.Point(582, 42);
            this.dgvOnkosten.Name = "dgvOnkosten";
            this.dgvOnkosten.Size = new System.Drawing.Size(544, 483);
            this.dgvOnkosten.TabIndex = 3;
            this.dgvOnkosten.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOnkosten_CellValueChanged);
            // 
            // clmErelonenOmschrijving
            // 
            this.clmErelonenOmschrijving.HeaderText = "Omschrijving";
            this.clmErelonenOmschrijving.Name = "clmErelonenOmschrijving";
            this.clmErelonenOmschrijving.ReadOnly = true;
            this.clmErelonenOmschrijving.Width = 200;
            // 
            // clmErelonenPrijsLaag
            // 
            this.clmErelonenPrijsLaag.HeaderText = "Laag";
            this.clmErelonenPrijsLaag.Name = "clmErelonenPrijsLaag";
            // 
            // clmErelonenPrijsMedium
            // 
            this.clmErelonenPrijsMedium.HeaderText = "Medium";
            this.clmErelonenPrijsMedium.Name = "clmErelonenPrijsMedium";
            // 
            // clmErelonenPrijsHoog
            // 
            this.clmErelonenPrijsHoog.HeaderText = "Hoog";
            this.clmErelonenPrijsHoog.Name = "clmErelonenPrijsHoog";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Omschrijving";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Laag";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Medium";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Hoog";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // frmPrijslijst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 580);
            this.Controls.Add(this.dgvOnkosten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvErelonen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrijslijst";
            this.Text = "Prijslijst";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrijslijst_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErelonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnkosten)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvErelonen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvOnkosten;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmErelonenOmschrijving;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmErelonenPrijsLaag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmErelonenPrijsMedium;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmErelonenPrijsHoog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}