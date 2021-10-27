using System;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class FormReplace : Form
    {
        TextBox _editor;

        public FormReplace()
        {
            InitializeComponent();
        }

        public FormReplace(TextBox txb)
        {
            InitializeComponent();

            _editor = txb;
        }

        private void btnZameni_Click(object sender, EventArgs e)
        {
            if (txtStr1.Text == "" || txtStr2.Text == "")
            {
                MessageBox.Show("Sva polja moraju biti popunjena.",
                                "Obavestenje",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                return;
            }


            if (MessageBox.Show("Da li ste sigurni?",
                                "Obavestenje",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _editor.Text = _editor.Text.Replace(txtStr1.Text, txtStr2.Text);
                this.Close();
            }
        }
    }
}