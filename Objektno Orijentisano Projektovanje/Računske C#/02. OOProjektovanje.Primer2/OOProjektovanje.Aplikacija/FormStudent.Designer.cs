namespace OOProjektovanje.Aplikacija
{
    partial class FormStudent
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
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblPol = new System.Windows.Forms.Label();
            this.cmbPol = new System.Windows.Forms.ComboBox();
            this.lblJmbg = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProsledi = new System.Windows.Forms.Button();
            this.btnZatvori = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(31, 41);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(27, 13);
            this.lblIme.TabIndex = 1;
            this.lblIme.Text = "Ime:";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(183, 41);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(47, 13);
            this.lblPrezime.TabIndex = 3;
            this.lblPrezime.Text = "Prezime:";
            // 
            // lblPol
            // 
            this.lblPol.AutoSize = true;
            this.lblPol.Location = new System.Drawing.Point(205, 70);
            this.lblPol.Name = "lblPol";
            this.lblPol.Size = new System.Drawing.Size(25, 13);
            this.lblPol.TabIndex = 7;
            this.lblPol.Text = "Pol:";
            // 
            // cmbPol
            // 
            this.cmbPol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPol.FormattingEnabled = true;
            this.cmbPol.Items.AddRange(new object[] {
            "",
            "M",
            "Z"});
            this.cmbPol.Location = new System.Drawing.Point(224, 52);
            this.cmbPol.Name = "cmbPol";
            this.cmbPol.Size = new System.Drawing.Size(100, 21);
            this.cmbPol.TabIndex = 8;
            // 
            // lblJmbg
            // 
            this.lblJmbg.AutoSize = true;
            this.lblJmbg.Location = new System.Drawing.Point(20, 67);
            this.lblJmbg.Name = "lblJmbg";
            this.lblJmbg.Size = new System.Drawing.Size(39, 13);
            this.lblJmbg.TabIndex = 5;
            this.lblJmbg.Text = "JMBG:";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(64, 38);
            this.txtIme.MaxLength = 20;
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(100, 20);
            this.txtIme.TabIndex = 2;
            this.txtIme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIme_KeyPress);
            this.txtIme.Leave += new System.EventHandler(this.txtIme_Leave);
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(236, 38);
            this.txtPrezime.MaxLength = 20;
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(100, 20);
            this.txtPrezime.TabIndex = 4;
            this.txtPrezime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrezime_KeyPress);
            this.txtPrezime.Leave += new System.EventHandler(this.txtPrezime_Leave);
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(64, 67);
            this.txtJMBG.MaxLength = 13;
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.Size = new System.Drawing.Size(100, 20);
            this.txtJMBG.TabIndex = 6;
            this.txtJMBG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJMBG_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPol);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o studentu";
            // 
            // btnProsledi
            // 
            this.btnProsledi.Location = new System.Drawing.Point(89, 103);
            this.btnProsledi.Name = "btnProsledi";
            this.btnProsledi.Size = new System.Drawing.Size(75, 23);
            this.btnProsledi.TabIndex = 9;
            this.btnProsledi.Text = "Prosledi";
            this.btnProsledi.UseVisualStyleBackColor = true;
            this.btnProsledi.Click += new System.EventHandler(this.btnProsledi_Click);
            // 
            // btnZatvori
            // 
            this.btnZatvori.Location = new System.Drawing.Point(208, 103);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(75, 23);
            this.btnZatvori.TabIndex = 10;
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.UseVisualStyleBackColor = true;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // FormStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 132);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.btnProsledi);
            this.Controls.Add(this.txtJMBG);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.lblJmbg);
            this.Controls.Add(this.lblPol);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(378, 171);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(378, 171);
            this.Name = "FormStudent";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student";
            this.Load += new System.EventHandler(this.FormStudent_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblPol;
        private System.Windows.Forms.ComboBox cmbPol;
        private System.Windows.Forms.Label lblJmbg;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtJMBG;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProsledi;
        private System.Windows.Forms.Button btnZatvori;
    }
}