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
    public partial class FormChild : Form, IUpdate
    {
        public FormChild()
        {
            InitializeComponent();
        }

        public void PrihvatiPromenu(string s)
        {
            this.Text = s;
        }

        public void Update(string s)
        {
            this.PrihvatiPromenu(s);
        }
    }
}
