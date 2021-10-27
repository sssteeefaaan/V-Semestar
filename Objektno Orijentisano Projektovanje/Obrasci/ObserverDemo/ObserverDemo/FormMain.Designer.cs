namespace ObserverDemo
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFormTypeServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFormTypeClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFormTypeClientBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createKlijentIzDrugeBibliotekeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFormTypeServerToolStripMenuItem,
            this.createFormTypeClientToolStripMenuItem,
            this.createFormTypeClientBToolStripMenuItem,
            this.createKlijentIzDrugeBibliotekeToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // createFormTypeServerToolStripMenuItem
            // 
            this.createFormTypeServerToolStripMenuItem.Name = "createFormTypeServerToolStripMenuItem";
            this.createFormTypeServerToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.createFormTypeServerToolStripMenuItem.Text = "Create FormTypeServer";
            this.createFormTypeServerToolStripMenuItem.Click += new System.EventHandler(this.createFormTypeServerToolStripMenuItem_Click);
            // 
            // createFormTypeClientToolStripMenuItem
            // 
            this.createFormTypeClientToolStripMenuItem.Name = "createFormTypeClientToolStripMenuItem";
            this.createFormTypeClientToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.createFormTypeClientToolStripMenuItem.Text = "Create FormTypeClient";
            this.createFormTypeClientToolStripMenuItem.Click += new System.EventHandler(this.createFormTypeClientToolStripMenuItem_Click);
            // 
            // createFormTypeClientBToolStripMenuItem
            // 
            this.createFormTypeClientBToolStripMenuItem.Name = "createFormTypeClientBToolStripMenuItem";
            this.createFormTypeClientBToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.createFormTypeClientBToolStripMenuItem.Text = "Create FormTypeClient B";
            this.createFormTypeClientBToolStripMenuItem.Click += new System.EventHandler(this.createFormTypeClientBToolStripMenuItem_Click);
            // 
            // createKlijentIzDrugeBibliotekeToolStripMenuItem
            // 
            this.createKlijentIzDrugeBibliotekeToolStripMenuItem.Name = "createKlijentIzDrugeBibliotekeToolStripMenuItem";
            this.createKlijentIzDrugeBibliotekeToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.createKlijentIzDrugeBibliotekeToolStripMenuItem.Text = "Create KlijentIzDrugeBiblioteke";
            this.createKlijentIzDrugeBibliotekeToolStripMenuItem.Click += new System.EventHandler(this.createKlijentIzDrugeBibliotekeToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 316);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFormTypeServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFormTypeClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFormTypeClientBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createKlijentIzDrugeBibliotekeToolStripMenuItem;
    }
}

