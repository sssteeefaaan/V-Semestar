using OOProjektovanje.Extensions;
using OOProjektovanje.Podaci;
using System;
using System.Windows.Forms;

namespace OOProjektovanje.Aplikacija
{
    public partial class FormStudent : Form
    {
        #region Properties
        public Osoba Student
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public FormStudent()
        {
            InitializeComponent();
        }

        public FormStudent(Osoba o)
            : this()
        {           
            Student = o;
            btnProsledi.Text = "Izmeni";
        }

        #endregion

        #region Methodes

        bool Validacija()
        {
            if (String.IsNullOrEmpty(txtIme.Text))
            {
                MessageBox.Show("Polje Ime ne sme biti prazno.",
                                "Obavestenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }

            if (String.IsNullOrEmpty(txtPrezime.Text))
            {
                MessageBox.Show("Polje Prezime ne sme biti prazno.",
                                "Obavestenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }

            if (txtJMBG.Text.Length < 13)
            {
                MessageBox.Show("Polje JMBG mora sadrzati 13 cifara.",
                                "Obavestenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return false;
            }

            return true;
        }

        void UcitajPodatkeUKontrole()
        {
            txtIme.Text = Student.Ime;
            txtPrezime.Text = Student.Prezime;
            txtJMBG.Text = Student.Jmbg;
            cmbPol.Text = Student.Pol;

            // zabranjujemo izmenu maticnog broja pri editovanju
            txtJMBG.Enabled = false;
            btnProsledi.Text = "Izmeni";
        }

        bool Dodaj()
        {
            var o = new Osoba
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Jmbg = txtJMBG.Text,
                Pol = cmbPol.Text
            };

            return ListaOsoba.Instance.DodajOsobu(o);
        }

        bool Izmeni()
        {
            var o = new Osoba
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Jmbg = txtJMBG.Text,
                Pol = cmbPol.Text
            };

            return ListaOsoba.Instance.IzmeniOsobu(o);
        }

        #endregion

        #region EventsHandler

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnProsledi_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            if (Student == null) // ukoliko je Student null dodajemo novog studenta, u suprotnom vrsimo azuriranje prosledjenog studenta
            {
                if (!Dodaj())
                {
                    MessageBox.Show("Neuspesno dodavanje. Pokusajte ponovo.",
                                    "Greska", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIme.Focus();

                    return;
                }
            }
            else
            {

                if (!Izmeni())
                {
                    MessageBox.Show("Neuspesna izmena. Pokusajte ponovo.",
                                    "Greska", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIme.Focus();

                    return;
                }
            }

            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtPrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtJMBG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            if (Student != null)
                UcitajPodatkeUKontrole();
        }

        private void txtIme_Leave(object sender, EventArgs e)
        {
            txtIme.Text = txtIme.Text.PostaviPrvoVelikoSlovo();
        }

        private void txtPrezime_Leave(object sender, EventArgs e)
        {
            txtPrezime.Text = txtPrezime.Text.PostaviPrvoVelikoSlovo();
        }

        #endregion

    }
}
