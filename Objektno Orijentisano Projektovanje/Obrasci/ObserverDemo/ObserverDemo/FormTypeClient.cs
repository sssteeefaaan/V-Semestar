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
    public partial class FormTypeClient : Form, IUpdate
    {
        public FormTypeClient()
        {
            InitializeComponent();
        }

        public void Update(string text)
        {
            this.textBox1.Text = text;
        }
        
    }
}
