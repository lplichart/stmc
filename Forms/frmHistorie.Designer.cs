namespace Mertens.Forms
{
    partial class frmHistorie
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
            this.txtHistorie = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtHistorie
            // 
            this.txtHistorie.Location = new System.Drawing.Point(29, 24);
            this.txtHistorie.Name = "txtHistorie";
            this.txtHistorie.Size = new System.Drawing.Size(754, 588);
            this.txtHistorie.TabIndex = 0;
            this.txtHistorie.Text = "";
            // 
            // frmHistorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 624);
            this.Controls.Add(this.txtHistorie);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHistorie";
            this.Text = "Historie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHistorie_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.frmHistorie_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtHistorie;
    }
}