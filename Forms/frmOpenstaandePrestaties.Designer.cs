namespace Mertens.Forms
{
    partial class frmOpenstaandePrestaties
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnbtn = new System.Windows.Forms.Button();
            this.txtHoeveelheid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vind dossiers met openstaande prestaties groter dan:";
            // 
            // btnbtn
            // 
            this.btnbtn.Location = new System.Drawing.Point(30, 79);
            this.btnbtn.Name = "btnbtn";
            this.btnbtn.Size = new System.Drawing.Size(253, 23);
            this.btnbtn.TabIndex = 1;
            this.btnbtn.Text = "Zoek";
            this.btnbtn.UseVisualStyleBackColor = true;
            this.btnbtn.Click += new System.EventHandler(this.btnbtn_Click);
            // 
            // txtHoeveelheid
            // 
            this.txtHoeveelheid.Location = new System.Drawing.Point(75, 48);
            this.txtHoeveelheid.Name = "txtHoeveelheid";
            this.txtHoeveelheid.Size = new System.Drawing.Size(146, 20);
            this.txtHoeveelheid.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "EUR";
            // 
            // frmOpenstaandePrestaties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 120);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHoeveelheid);
            this.Controls.Add(this.btnbtn);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOpenstaandePrestaties";
            this.Text = "frmOpenstaandePrestaties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOpenstaandePrestaties_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbtn;
        private System.Windows.Forms.TextBox txtHoeveelheid;
        private System.Windows.Forms.Label label2;
    }
}