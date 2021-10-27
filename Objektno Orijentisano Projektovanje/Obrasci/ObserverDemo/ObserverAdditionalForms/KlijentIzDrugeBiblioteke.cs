using ObserverDemoApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverAdditionalForms
{
    public partial class KlijentIzDrugeBiblioteke : Form, IUpdate
    {
        int t = 0;
        public KlijentIzDrugeBiblioteke()
        {
            InitializeComponent();
        }

        public void Update(string text)
        {
            this.Text = text;
            t++;
            if (t % 2 == 0)
                this.BackColor = Color.Red;
            else
                this.BackColor = Color.Green;
        }
    }
}
