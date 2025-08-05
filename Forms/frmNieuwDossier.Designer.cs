namespace Mertens.Forms
{
    partial class frmNieuwDossier
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReferentie = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(54, 88);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Nieuw dossier";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(179, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Annuleer";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Geef een nieuw dossiernummer in!";
            // 
            // txtReferentie
            // 
            this.txtReferentie.Location = new System.Drawing.Point(51, 51);
            this.txtReferentie.Name = "txtReferentie";
            this.txtReferentie.Size = new System.Drawing.Size(233, 20);
            this.txtReferentie.TabIndex = 0;
            this.txtReferentie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReferentie_KeyDown);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(54, 88);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Opslaan";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmNieuwDossier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 161);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtReferentie);
            this.Controls.Add(this.label1);
            this.Name = "frmNieuwDossier";
            this.Text = "Nieuw Dossier";
            this.VisibleChanged += new System.EventHandler(this.frmNieuwDossier_VisibleChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmNieuwDossier_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReferentie;
        private System.Windows.Forms.Button btnUpdate;
    }
}