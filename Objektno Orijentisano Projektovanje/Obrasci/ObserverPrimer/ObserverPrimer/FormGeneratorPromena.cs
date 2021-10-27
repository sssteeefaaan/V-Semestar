using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverPrimer
{
    public partial class FormGeneratorPromena : Form
    {
        public FormGeneratorPromena()
        {
            InitializeComponent();
        }

        public FormGeneratorPromena(FormGlavna glavna)
        {
            InitializeComponent();
            this.LocalParent = glavna;
        }

        public FormGlavna LocalParent { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            LocalParent.ProslediPromene(this.txtZaprosledjivanje.Text);
        }
    }
}
