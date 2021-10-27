namespace OOP.CustomControls
{
    partial class CtrlPodaciOOsobi
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblImeValue = new System.Windows.Forms.Label();
            this.lblPrezimeValue = new System.Windows.Forms.Label();
            this.txtTelefoni = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.73973F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.26028F));
            this.tableLayoutPanel1.Controls.Add(this.lblIme, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPrezime, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTelefon, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblImeValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPrezimeValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTelefoni, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblIme
            // 
            this.lblIme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIme.Location = new System.Drawing.Point(49, 0);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(31, 25);
            this.lblIme.TabIndex = 0;
            this.lblIme.Text = "Ime:";
            // 
            // lblPrezime
            // 
            this.lblPrezime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezime.Location = new System.Drawing.Point(25, 25);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(55, 25);
            this.lblPrezime.TabIndex = 2;
            this.lblPrezime.Text = "Prezime:";
            // 
            // lblTelefon
            // 
            this.lblTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefon.Location = new System.Drawing.Point(23, 50);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(57, 13);
            this.lblTelefon.TabIndex = 4;
            this.lblTelefon.Text = "Telefoni:";
            // 
            // lblImeValue
            // 
            this.lblImeValue.AutoSize = true;
            this.lblImeValue.Location = new System.Drawing.Point(86, 0);
            this.lblImeValue.Name = "lblImeValue";
            this.lblImeValue.Size = new System.Drawing.Size(35, 13);
            this.lblImeValue.TabIndex = 1;
            this.lblImeValue.Text = "label4";
            // 
            // lblPrezimeValue
            // 
            this.lblPrezimeValue.AutoSize = true;
            this.lblPrezimeValue.Location = new System.Drawing.Point(86, 25);
            this.lblPrezimeValue.Name = "lblPrezimeValue";
            this.lblPrezimeValue.Size = new System.Drawing.Size(35, 13);
            this.lblPrezimeValue.TabIndex = 3;
            this.lblPrezimeValue.Text = "label5";
            // 
            // txtTelefoni
            // 
            this.txtTelefoni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTelefoni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTelefoni.Location = new System.Drawing.Point(86, 53);
            this.txtTelefoni.Multiline = true;
            this.txtTelefoni.Name = "txtTelefoni";
            this.txtTelefoni.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTelefoni.Size = new System.Drawing.Size(276, 94);
            this.txtTelefoni.TabIndex = 5;
   
            this.txtTelefoni.Enter += new System.EventHandler(this.txtTelefoni_Enter);
            this.txtTelefoni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefoni_KeyPress);
            // 
            // CtrlPodaciOOsobi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CtrlPodaciOOsobi";
            this.Size = new System.Drawing.Size(365, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Label lblImeValue;
        private System.Windows.Forms.Label lblPrezimeValue;
        private System.Windows.Forms.TextBox txtTelefoni;
    }
}
