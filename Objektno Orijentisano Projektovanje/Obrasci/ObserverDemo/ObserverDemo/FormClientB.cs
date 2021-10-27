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

namespace ObserverDemo
{
    public partial class FormClientB : Form, IUpdate
    {
        public FormClientB()
        {
            InitializeComponent();
        }

        public void Update(string s)
        {
            this.listBox1.Items.Add(s);
        }
    }
}
