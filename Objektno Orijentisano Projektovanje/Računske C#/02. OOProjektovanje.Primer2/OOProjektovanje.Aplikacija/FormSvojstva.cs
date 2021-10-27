using System;
using System.Windows.Forms;

namespace OOProjektovanje.Aplikacija
{
    public partial class FormSvojstva : Form
    {
        #region Atributes

        public Object SelectedObject
        {
            set
            {
                prgObject.SelectedObject = value;
            }
        }

        #endregion

        #region construcotrs

        public FormSvojstva()
        {
            InitializeComponent();
        }

        public FormSvojstva(Object o)
            : this()
        {
            prgObject.SelectedObject = o;
        }

        #endregion

        #region EventsHandler

        private void FormSvojstva_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Pokrenuta je forma sa listom svih svojstava koja se odnose na data grid view kontrolu.",
                            "Obavestenje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        #endregion
    }
}
