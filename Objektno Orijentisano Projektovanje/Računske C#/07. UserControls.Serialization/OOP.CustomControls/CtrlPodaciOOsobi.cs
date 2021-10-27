using OOP.Podaci;
using System;
using System.Windows.Forms;

namespace OOP.CustomControls
{
    public partial class CtrlPodaciOOsobi : UserControl
    {
        private Osoba _osobaValue;

        public Osoba OsobaValue
        {
            get { return _osobaValue; }
            set
            {
                _osobaValue = value;
                if (_osobaValue != null)
                {
                    lblImeValue.Text = _osobaValue.Ime;
                    lblPrezimeValue.Text = _osobaValue.Prezime;
                    txtTelefoni.Text = "";
                    foreach (var s in _osobaValue.ListaTelefona)
                    {
                        txtTelefoni.Text += s;
                        txtTelefoni.Text += Environment.NewLine;
                    }
                }
            }
        }

        public CtrlPodaciOOsobi()
        {
            InitializeComponent();

            lblImeValue.Text = "";
            lblPrezimeValue.Text = "";
        }

        private void txtTelefoni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTelefoni_Enter(object sender, EventArgs e)
        {
            lblIme.Focus();
        }
    }
}
