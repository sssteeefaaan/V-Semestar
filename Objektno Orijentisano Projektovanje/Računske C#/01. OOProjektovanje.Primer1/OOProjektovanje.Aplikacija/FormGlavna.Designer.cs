namespace OOProjektovanje1
{
    partial class FormGlavna
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
            this.btnDodaj = new System.Windows.Forms.Button();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblJmbg = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.lbxStudent = new System.Windows.Forms.ListBox();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnTacnoVreme = new System.Windows.Forms.Button();
            this.lblTacnoVreme = new System.Windows.Forms.Label();
            this.btnZatvori = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(15, 77);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 6;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(12, 24);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(27, 13);
            this.lblIme.TabIndex = 0;
            this.lblIme.Text = "Ime:";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(172, 24);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(47, 13);
            this.lblPrezime.TabIndex = 2;
            this.lblPrezime.Text = "Prezime:";
            // 
            // lblJmbg
            // 
            this.lblJmbg.AutoSize = true;
            this.lblJmbg.Location = new System.Drawing.Point(12, 54);
            this.lblJmbg.Name = "lblJmbg";
            this.lblJmbg.Size = new System.Drawing.Size(39, 13);
            this.lblJmbg.TabIndex = 4;
            this.lblJmbg.Text = "JMBG:";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(45, 21);
            this.txtIme.MaxLength = 20;
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(100, 20);
            this.txtIme.TabIndex = 1;
            this.txtIme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIme_KeyPress);
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(227, 21);
            this.txtPrezime.MaxLength = 20;
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(100, 20);
            this.txtPrezime.TabIndex = 3;
            this.txtPrezime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrezime_KeyPress);
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(55, 51);
            this.txtJMBG.MaxLength = 13;
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.Size = new System.Drawing.Size(270, 20);
            this.txtJMBG.TabIndex = 5;
            this.txtJMBG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJMBG_KeyPress);
            // 
            // lbxStudent
            // 
            this.lbxStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxStudent.FormattingEnabled = true;
            this.lbxStudent.HorizontalScrollbar = true;
            this.lbxStudent.Location = new System.Drawing.Point(15, 125);
            this.lbxStudent.Name = "lbxStudent";
            this.lbxStudent.ScrollAlwaysVisible = true;
            this.lbxStudent.Size = new System.Drawing.Size(312, 121);
            this.lbxStudent.TabIndex = 8;
            this.lbxStudent.DoubleClick += new System.EventHandler(this.lbxStudent_DoubleClick);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(144, 77);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(75, 23);
            this.btnObrisi.TabIndex = 7;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.bntObrisi_Click);
            // 
            // btnTacnoVreme
            // 
            this.btnTacnoVreme.Location = new System.Drawing.Point(13, 252);
            this.btnTacnoVreme.Name = "btnTacnoVreme";
            this.btnTacnoVreme.Size = new System.Drawing.Size(95, 23);
            this.btnTacnoVreme.TabIndex = 9;
            this.btnTacnoVreme.Text = "Tacno vreme";
            this.btnTacnoVreme.UseVisualStyleBackColor = true;
            this.btnTacnoVreme.Click += new System.EventHandler(this.btnTacnoVreme_Click);
            // 
            // lblTacnoVreme
            // 
            this.lblTacnoVreme.AutoSize = true;
            this.lblTacnoVreme.Location = new System.Drawing.Point(114, 257);
            this.lblTacnoVreme.Name = "lblTacnoVreme";
            this.lblTacnoVreme.Size = new System.Drawing.Size(66, 13);
            this.lblTacnoVreme.TabIndex = 10;
            this.lblTacnoVreme.Text = "tacno vreme";
            // 
            // btnZatvori
            // 
            this.btnZatvori.Location = new System.Drawing.Point(232, 252);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(95, 23);
            this.btnZatvori.TabIndex = 11;
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.UseVisualStyleBackColor = true;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(252, 77);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 12;
            this.btnSort.Text = "Sortiraj";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // FormGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 285);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.lblTacnoVreme);
            this.Controls.Add(this.btnTacnoVreme);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.lbxStudent);
            this.Controls.Add(this.txtJMBG);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.lblJmbg);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.btnDodaj);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(355, 324);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(355, 324);
            this.Name = "FormGlavna";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OOProjektovanje :)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGlavna_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblJmbg;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtJMBG;
        private System.Windows.Forms.ListBox lbxStudent;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnTacnoVreme;
        private System.Windows.Forms.Label lblTacnoVreme;
        private System.Windows.Forms.Button btnZatvori;
        private System.Windows.Forms.Button btnSort;
    }
}

