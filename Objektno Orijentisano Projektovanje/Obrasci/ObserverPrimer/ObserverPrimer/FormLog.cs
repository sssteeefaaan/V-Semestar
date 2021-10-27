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
    public partial class FormLog : Form, IUpdate
    {
        public FormLog()
        {
            InitializeComponent();
        }
        
        public void Update(string s)
        {
            this.listBox1.Items.Add(s);
        }
    }
}
