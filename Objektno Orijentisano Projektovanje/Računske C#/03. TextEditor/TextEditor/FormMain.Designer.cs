namespace TextEditor
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
            this.txtTekst = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msbNew = new System.Windows.Forms.ToolStripMenuItem();
            this.msbOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.msbSave = new System.Windows.Forms.ToolStripMenuItem();
            this.msbExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msbReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTekst
            // 
            this.txtTekst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTekst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTekst.Location = new System.Drawing.Point(0, 24);
            this.txtTekst.Margin = new System.Windows.Forms.Padding(2);
            this.txtTekst.Multiline = true;
            this.txtTekst.Name = "txtTekst";
            this.txtTekst.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTekst.Size = new System.Drawing.Size(546, 269);
            this.txtTekst.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.btnExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(546, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msbNew,
            this.msbOpen,
            this.msbSave,
            this.msbExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "F&ile";
            // 
            // msbNew
            // 
            this.msbNew.Name = "msbNew";
            this.msbNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.msbNew.Size = new System.Drawing.Size(180, 22);
            this.msbNew.Text = "New";
            this.msbNew.Click += new System.EventHandler(this.msbNew_Click);
            // 
            // msbOpen
            // 
            this.msbOpen.Name = "msbOpen";
            this.msbOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.msbOpen.Size = new System.Drawing.Size(180, 22);
            this.msbOpen.Text = "Open";
            this.msbOpen.Click += new System.EventHandler(this.msbOpen_Click);
            // 
            // msbSave
            // 
            this.msbSave.Name = "msbSave";
            this.msbSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.msbSave.Size = new System.Drawing.Size(180, 22);
            this.msbSave.Text = "Save";
            this.msbSave.Click += new System.EventHandler(this.msbSave_Click);
            // 
            // msbExit
            // 
            this.msbExit.Name = "msbExit";
            this.msbExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.msbExit.Size = new System.Drawing.Size(180, 22);
            this.msbExit.Text = "Exit";
            this.msbExit.Click += new System.EventHandler(this.msbExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msbReplace});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // msbReplace
            // 
            this.msbReplace.Name = "msbReplace";
            this.msbReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.msbReplace.Size = new System.Drawing.Size(156, 22);
            this.msbReplace.Text = "Replace";
            this.msbReplace.Click += new System.EventHandler(this.msbReplace_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(38, 22);
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 293);
            this.Controls.Add(this.txtTekst);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTekst;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msbOpen;
        private System.Windows.Forms.ToolStripMenuItem msbSave;
        private System.Windows.Forms.ToolStripMenuItem msbExit;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem msbNew;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msbReplace;
    }
}

