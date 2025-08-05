namespace Mertens.Forms
{
    partial class frmVerwacht
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
            this.lsbVerwachtlijst = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsbVerwachtlijst
            // 
            this.lsbVerwachtlijst.FormattingEnabled = true;
            this.lsbVerwachtlijst.Location = new System.Drawing.Point(13, 39);
            this.lsbVerwachtlijst.Name = "lsbVerwachtlijst";
            this.lsbVerwachtlijst.Size = new System.Drawing.Size(259, 212);
            this.lsbVerwachtlijst.TabIndex = 0;
            this.lsbVerwachtlijst.DoubleClick += new System.EventHandler(this.lsbVerwachtlijst_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Verwachtlijst";
            // 
            // frmVerwacht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsbVerwachtlijst);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVerwacht";
            this.Text = "frmVerwacht";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVerwacht_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.frmVerwacht_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbVerwachtlijst;
        private System.Windows.Forms.Label label1;
    }
}