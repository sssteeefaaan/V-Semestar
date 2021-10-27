using OOProjektovanje.Extensions;
using OOProjektovanje.Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OOProjektovanje1
{
    public partial class FormGlavna : Form
    {
        #region Atributes
        #endregion

        #region Consctructors

        public FormGlavna()
        {
            InitializeComponent();

            Init();
        }

        #endregion

        #region Methodes

        private void Init()
        {
            lblTacnoVreme.Text = String.Empty;
            btnObrisi.Enabled = false;

            ListaOsoba.Instance.SortListDelegate = new ListaOsoba.SortDelegate(this.SortList);
        }

        private bool ValidacijaKontrola()
        {
            if (String.IsNullOrEmpty(txtIme.Text))
            {
                MessageBox.Show("Ime ne sme biti prazno polje.",
                                "Obavestenje",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

                return false;
            }

            if (String.IsNullOrEmpty(txtPrezime.Text))
            {
                MessageBox.Show("Prezime ne sme biti prazno polje.",
                                "Obavestenje",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

                return false;
            }

            if (String.IsNullOrEmpty(txtJMBG.Text))
            {
                MessageBox.Show("JMBG ne sme biti prazno polje.",
                                "Obavestenje",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

                return false;
            }

            if (txtJMBG.Text.Length < 13)
            {
                MessageBox.Show("JMBG mora sadrzati 13 cifara.",
                                "Obavestenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return false;
            }

            return true;
        }

        void UcitajListBox()
        {
            lbxStudent.DisplayMember = "ZaPrikaz";
            lbxStudent.ValueMember = "Jmbg";
            lbxStudent.DataSource = ListaOsoba.Instance.ListaOsobaValues.ToList();
        }

        void SortList(List<Osoba> l)
        {
            for (int i = 0; i < l.Count - 1; i++)
            {
                long jmbg1 = long.Parse(l[i].Jmbg);

                for (int j = i + 1; j < l.Count; j++)
                {
                    long jmbg2 = long.Parse(l[j].Jmbg);

                    if (jmbg1 > jmbg2)
                    {
                        Osoba tmp = l[i];
                        l[i] = l[j];
                        l[j] = tmp;
                    }
                }
            }
        }

        #endregion

        #region EventsHandlers

        private void btnTacnoVreme_Click(object sender, EventArgs e)
        {
            var tacnoVreme = DateTime.Now.ToString("dd.MM.yyyy. HH:ss");
            lblTacnoVreme.Text = tacnoVreme;

            //lblTacnoVreme.Text = $"Tacno vreme je: {DateTime.Now.ToString("dd.MM.yyyy. HH:ss")}";

            MessageBox.Show(tacnoVreme, "Tacno vreme",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaKontrola())
                return;

            String ime = txtIme.Text.TrimEnd(' ').PostaviPrvoVelikoSlovo();
            String prezime = txtPrezime.Text.TrimEnd(' ').PostaviPrvoVelikoSlovo();
            String jmbg = txtJMBG.Text;

            Osoba o = new Osoba(ime, prezime, jmbg);

            bool resultat = ListaOsoba.Instance.DodajOsobu(o);

            if (!resultat)
            {
                MessageBox.Show("Osoba nije uspesno dodata u listu osoba. Mozda takva osoba vec postoji u listi.",
                                 "Obavestenje",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Osoba je uspesno dodata u listu osoba.",
                            "Obavestenje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);

            UcitajListBox();

            btnObrisi.Enabled = true;

            txtIme.Focus();
        }

        private void bntObrisi_Click(object sender, EventArgs e)
        {
            if (lbxStudent.SelectedValue == null)
                return;

            String jmbg = lbxStudent.SelectedValue as String;
            bool result = ListaOsoba.Instance.ObrisiOsobu(jmbg);

            if (!result)
            {
                MessageBox.Show("Akcija brisanja nije uspesno obavljena.",
                                "Obavestenje",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Akcija brisanja je uspesno obavljena.",
                            "Obavestenje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);

            UcitajListBox();

            if (ListaOsoba.Instance.ListaOsobaValues.Count == 0)
                btnObrisi.Enabled = false;
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtJMBG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsLetter(e.KeyChar))
                e.Handled = true;

        }

        private void txtPrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }


        private void lbxStudent_DoubleClick(object sender, EventArgs e)
        {
            if (lbxStudent.SelectedValue == null)
                return;

            String zaPrikaz = "Ime: {0}" + Environment.NewLine + "Prezime: {1}" + Environment.NewLine + "JMBG: {2}";

            String jmbg = lbxStudent.SelectedValue as String;
            Osoba o = ListaOsoba.Instance.GetOsoba(jmbg);

            MessageBox.Show(String.Format(zaPrikaz, o.Ime, o.Prezime, o.Jmbg),
                            "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // String proba = $"Ime: {o.Ime}\nPrezime: {o.Prezime}\nJmbg: {o.Jmbg}";
            //MessageBox.Show($"Ime: {o.Ime}\nPrezime: {o.Prezime}\nJMBG: {o.Jmbg}",
            //                "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {

            ListaOsoba.Instance.SortListValue();

            this.UcitajListBox();
        }

        private void FormGlavna_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult di = MessageBox.Show("Da li ste sigurni da zelite da ugasite program?",
                                            "Obavestenje",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (di == DialogResult.No)
                e.Cancel = true;

        }

        #endregion
    }
}
