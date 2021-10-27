using ObserverAdditionalForms;
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
    public partial class FormMain : Form, INotify
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void createFormTypeServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTypeServer fts = new FormTypeServer();
            fts.MdiParent = this;
            fts.Show();
        }

        private void createFormTypeClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTypeClient ftc = new FormTypeClient();
            ftc.MdiParent = this;
            ftc.Show();
        }

        

        private void createFormTypeClientBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientB ftc = new FormClientB();
            ftc.MdiParent = this;
            ftc.Show();
        }

        public void Notify(int valueToSend)
        {
            NotifyChildren(valueToSend);
            //foreach (IUpdate fc in this.MdiChildren)
            //{             
            //    fc.Update(valueToSend.ToString());
            //}
        }

        public void NotifyChildren(int number)
        {
            foreach (Form fc in this.MdiChildren)
            {
                IUpdate ftc = fc as IUpdate;
                if (ftc == null)
                {                    
                    continue;
                }

                ftc.Update(number.ToString());
            }
        }

        private void createKlijentIzDrugeBibliotekeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KlijentIzDrugeBiblioteke fdb = new KlijentIzDrugeBiblioteke();
            fdb.MdiParent = this;
            fdb.Show();
        }
    }
}
