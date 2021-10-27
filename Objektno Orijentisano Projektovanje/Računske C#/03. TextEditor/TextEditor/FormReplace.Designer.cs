namespace TextEditor
{
    partial class FormReplace
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
            this.txtStr1 = new System.Windows.Forms.TextBox();
            this.btnZameni = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStr2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtStr1
            // 
            this.txtStr1.Location = new System.Drawing.Point(87, 23);
            this.txtStr1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStr1.Name = "txtStr1";
            this.txtStr1.Size = new System.Drawing.Size(118, 20);
            this.txtStr1.TabIndex = 1;
            // 
            // btnZameni
            // 
            this.btnZameni.Location = new System.Drawing.Point(147, 62);
            this.btnZameni.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnZameni.Name = "btnZameni";
            this.btnZameni.Size = new System.Drawing.Size(118, 25);
            this.btnZameni.TabIndex = 4;
            this.btnZameni.Text = "Zameni";
            this.btnZameni.UseVisualStyleBackColor = true;
            this.btnZameni.Click += new System.EventHandler(this.btnZameni_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ovaj tekst";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "menjam sa";
            // 
            // txtStr2
            // 
            this.txtStr2.Location = new System.Drawing.Point(287, 23);
            this.txtStr2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStr2.Name = "txtStr2";
            this.txtStr2.Size = new System.Drawing.Size(118, 20);
            this.txtStr2.TabIndex = 3;
            // 
            // FormReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 105);
            this.Controls.Add(this.txtStr2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnZameni);
            this.Controls.Add(this.txtStr1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 144);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(435, 144);
            this.Name = "FormReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStr1;
        private System.Windows.Forms.Button btnZameni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStr2;
    }
}