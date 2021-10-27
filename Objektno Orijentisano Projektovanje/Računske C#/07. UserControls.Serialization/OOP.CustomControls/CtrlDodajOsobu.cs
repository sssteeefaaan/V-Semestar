using OOP.Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OOP.CustomControls
{
    public partial class CtrlDodajOsobu : UserControl
    {

        public delegate void RefreshDelegate();
        private RefreshDelegate _refreshDlg = delegate { };

        public RefreshDelegate RefreshDlg
        {
            get { return _refreshDlg; }
            set { _refreshDlg = value; }
        }

        public Imenik ImenikValue
        {
            set;
            get;
        }

        public CtrlDodajOsobu()
        {
            InitializeComponent();
        }

        private bool Validacija()
        {
            if (String.IsNullOrEmpty(txtIme.Text))
                return false;

            if (String.IsNullOrEmpty(txtPrezime.Text))
                return false;

            if (String.IsNullOrEmpty(txtBrTelefona.Text))
                return false;

            return true;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
            {
                MessageBox.Show("Niste uneli sve potrebne podatke", "Obavestenje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<String> telefoni;
            GetTelefoni(out telefoni);
            Osoba o = new Osoba(txtIme.Text, txtPrezime.Text, telefoni);

            ImenikValue.AddOsoba(o);

            Clear();

            _refreshDlg();
        }

        private void GetTelefoni(out List<String> lista)
        {
            String str = txtBrTelefona.Text;
            String[] strs = str.Split(new Char[] { '\r', '\n' });

            lista = strs.Where(x => x != String.Empty).ToList();

        }

        private void Clear()
        {
            txtIme.Text = txtPrezime.Text = txtBrTelefona.Text = String.Empty;
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
