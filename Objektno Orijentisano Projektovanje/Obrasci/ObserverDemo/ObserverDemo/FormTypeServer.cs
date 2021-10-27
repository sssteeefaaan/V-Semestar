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
    public partial class FormTypeServer : Form
    {
        int clickCount = 0;
        public FormTypeServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clickCount++;
            this.Text = clickCount.ToString();

            if (this.MdiParent == null)
                return;

            INotify fm = this.MdiParent as INotify;
            if (fm == null)
                return;

            fm.Notify(clickCount);
        }
    }
}
