using OOP.CustomControls;
using OOP.Extension;
using OOP.Podaci;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OOP.CustonControl
{
    public partial class FormGlavna : Form
    {
        #region Atributes

        Imenik _imenik = new Imenik();

        #endregion

        #region Constructors

        public FormGlavna()
        {
            InitializeComponent();
        }


        #endregion

        #region Methodes

        private void LoadPodaci()
        {
            lbxListaOsoba.DisplayMember = "ZaPrikaz";

            lbxListaOsoba.DataSource = _imenik.ListaOsoba.ToList();
        }

        private void RefreshImenik()
        {
            LoadPodaci();
        }

        #endregion

        #region EventsHandlers

        private void lbxListaOsoba_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxListaOsoba.SelectedIndex == -1)
                return;

            Osoba o = lbxListaOsoba.SelectedValue as Osoba;
            ctrlPodaciOOsobi.OsobaValue = o;
        }


        private void FormGlavna_Load(object sender, EventArgs e)
        {
            ctrlDodajOsobu.ImenikValue = _imenik;
            ctrlDodajOsobu.RefreshDlg = new CtrlDodajOsobu.RefreshDelegate(this.RefreshImenik);
        }

        private void btnSnimiXml_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "xml files (*.xml)|*.xml";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _imenik.Serialize(sfd.FileName);
            }
        }

        private void btnUcitajXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml files (*.xml)|*.xml";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _imenik = _imenik.DeSerialize(ofd.FileName);
                LoadPodaci();
            }
        }

        #endregion

    }
}
