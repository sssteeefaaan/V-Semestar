using System;
using System.IO;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void msbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void msbOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String fileName = ofd.FileName;
                txtTekst.Text = File.ReadAllText(fileName);
            }
        }

        private void msbSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                String fileName = sfd.FileName;
                File.WriteAllText(fileName, txtTekst.Text);
            }
        }

        private void msbNew_Click(object sender, EventArgs e)
        {
            txtTekst.Text = String.Empty;
        }

        private void msbReplace_Click(object sender, EventArgs e)
        {
            FormReplace frm = new FormReplace(txtTekst);
            frm.ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgr = MessageBox.Show("Da li ste sigurni",
                                                "Obavestenje",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (dlgr == DialogResult.No)
                e.Cancel = true;
        }
    }
}