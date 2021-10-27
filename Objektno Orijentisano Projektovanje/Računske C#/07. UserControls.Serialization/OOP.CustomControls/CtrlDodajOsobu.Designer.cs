namespace OOP.CustomControls
{
    partial class CtrlDodajOsobu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrTelefona = new System.Windows.Forms.TextBox();
            this.grpPodaciOOsobi = new System.Windows.Forms.GroupBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnPonisti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(7, 20);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(27, 13);
            this.lblIme.TabIndex = 1;
            this.lblIme.Text = "Ime:";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(7, 45);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(47, 13);
            this.lblPrezime.TabIndex = 3;
            this.lblPrezime.Text = "Prezime:";
            // 
            // txtIme
            // 
            this.txtIme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIme.Location = new System.Drawing.Point(70, 20);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(207, 20);
            this.txtIme.TabIndex = 2;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrezime.Location = new System.Drawing.Point(70, 47);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(207, 20);
            this.txtPrezime.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Telefon:";
            // 
            // txtBrTelefona
            // 
            this.txtBrTelefona.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBrTelefona.Location = new System.Drawing.Point(70, 79);
            this.txtBrTelefona.Multiline = true;
            this.txtBrTelefona.Name = "txtBrTelefona";
            this.txtBrTelefona.Size = new System.Drawing.Size(207, 147);
            this.txtBrTelefona.TabIndex = 6;
            // 
            // grpPodaciOOsobi
            // 
            this.grpPodaciOOsobi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPodaciOOsobi.Location = new System.Drawing.Point(4, 0);
            this.grpPodaciOOsobi.Name = "grpPodaciOOsobi";
            this.grpPodaciOOsobi.Size = new System.Drawing.Size(279, 236);
            this.grpPodaciOOsobi.TabIndex = 0;
            this.grpPodaciOOsobi.TabStop = false;
            this.grpPodaciOOsobi.Text = "Podaci o osobi";
            // 
            // btnDodaj
            // 
            this.btnDodaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDodaj.Location = new System.Drawing.Point(4, 242);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 7;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnPonisti
            // 
            this.btnPonisti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPonisti.Location = new System.Drawing.Point(202, 242);
            this.btnPonisti.Name = "btnPonisti";
            this.btnPonisti.Size = new System.Drawing.Size(75, 23);
            this.btnPonisti.TabIndex = 8;
            this.btnPonisti.Text = "Ponisti";
            this.btnPonisti.UseVisualStyleBackColor = true;
            this.btnPonisti.Click += new System.EventHandler(this.btnPonisti_Click);
            // 
            // CtrlDodajOsobu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPonisti);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.txtBrTelefona);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.grpPodaciOOsobi);
            this.Name = "CtrlDodajOsobu";
            this.Size = new System.Drawing.Size(286, 268);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrTelefona;
        private System.Windows.Forms.GroupBox grpPodaciOOsobi;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnPonisti;
    }
}
