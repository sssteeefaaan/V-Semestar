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
    public partial class FormJosjedna : Form, IUpdate 
    {
        public FormJosjedna()
        {
            InitializeComponent();
        }

        public void Upisitext(string s)
        {
            this.textBox1.Text = s;
        }

        public void Update(string s)
        {
            Upisitext(s);
        }
    }
}
