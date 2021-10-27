using OOProjektovanje.Podaci;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OOProjektovanje.Aplikacija
{
    public partial class FormGlavna : Form
    {

        #region Constructors

        public FormGlavna()
        {
            InitializeComponent();
        }

        #endregion

        #region Methodes

        DialogResult ZatvoriFormu()
        {
            return MessageBox.Show("Da li ste sigurni da izvrsite izabranu akciju?",
                                   "Obavestenje",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);
        }

        void UcitajPodatke()
        {
            dgvListaStudenata.DataSource = ListaOsoba.Instance.ListaOsobaValues.ToList();
           // dgvListaStudenata.Columns["ZaPrikaz"].Visible = false;

            if (dgvListaStudenata.RowCount > 0)
            {
                btnObrisi.Visible = true;
                btnIzmeni.Visible = true;
            }
            else
            {
                btnObrisi.Visible = false;
                btnIzmeni.Visible = false;
            }
        }

        #endregion

        #region EventHandlers

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGlavna_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ZatvoriFormu() == DialogResult.No)
                e.Cancel = true;
        }

        private void FormGlavna_Load(object sender, EventArgs e)
        {
            btnObrisi.Visible = false;
            btnIzmeni.Visible = false;
            lblTacnoVreme.Text = String.Empty;

            tmrTacnoVReme.Start();

            UcitajPodatke();
        }

        private void tmrTacnoVReme_Tick(object sender, EventArgs e)
        {
            String str = DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy.");
            lblTacnoVreme.Text = str;
        }


        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var frm = new FormStudent();
            //frm.Show();
            DialogResult dlg = frm.ShowDialog();

            if (dlg == System.Windows.Forms.DialogResult.OK)
                UcitajPodatke();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvListaStudenata.SelectedRows.Count == 0)
                return;

            int selectedRow = dgvListaStudenata.SelectedRows[0].Index;
            String jmbg = (String)dgvListaStudenata["Jmbg", selectedRow].Value;

            var o = ListaOsoba.Instance.GetOsoba(jmbg);

            var frm = new FormStudent();
            frm.Student = o;

            DialogResult dlg = frm.ShowDialog();

            if (dlg == System.Windows.Forms.DialogResult.OK)
                UcitajPodatke();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvListaStudenata.SelectedRows.Count == 0)
                return;

            DialogResult dlg = MessageBox.Show("Da li ste sigurni da zelite da obrisete izabranu stavku?",
                                               "Obavestenje",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (dlg == System.Windows.Forms.DialogResult.No)
                return;

            int selectedRow = dgvListaStudenata.SelectedRows[0].Index;
            String jmbg = (String)dgvListaStudenata["Jmbg", selectedRow].Value;

            var o = ListaOsoba.Instance.GetOsoba(jmbg);

            if (ListaOsoba.Instance.ObrisiOsobu(o))
            {
                MessageBox.Show("Izabrana akcija je uspesno obavljena.",
                                "Obavestenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Izabrana akcija nije uspesno obavljena. Pokusajte ponovo.",
                                "Obavestenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            UcitajPodatke();
        }

        private void btnPrikaziSvojstvaZaDataGridVies_Click(object sender, EventArgs e)
        {
            var frm = new FormSvojstva(dgvListaStudenata);
            frm.Show();
        }

        #endregion

    }
}
