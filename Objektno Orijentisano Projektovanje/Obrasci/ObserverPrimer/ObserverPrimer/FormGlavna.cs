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
    public partial class FormGlavna : Form
    {
        public FormGlavna()
        {
            InitializeComponent();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            FormChild fc = new FormChild();
            fc.MdiParent = this;
            fc.Show();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            FormGeneratorPromena fgp = new FormGeneratorPromena();
            fgp.LocalParent = this;
            fgp.MdiParent = this;
            fgp.Show();
        }

        internal void ProslediPromene(string p)
        {
            foreach(Form f in this.MdiChildren)
            {
                IUpdate upd = f as IUpdate;
                if (upd != null)
                    upd.Update(p);

                //FormChild fc = f as FormChild;
                //if (fc != null)
                //    fc.PrihvatiPromenu(p);
                //else
                //{
                //    FormLog fl = f as FormLog;
                //    if (fl!= null)
                //    {
                //        fl.listBox1.Items.Add(p);
                //    }
                //    else
                //    {
                //        FormJosjedna fjj = f as FormJosjedna;
                //        if (fjj != null)
                //            fjj.Upisitext(p);
                //    }
                //}
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            FormLog fc = new FormLog();
            fc.MdiParent = this;
            fc.Show();
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            FormJosjedna fc = new FormJosjedna();
            fc.MdiParent = this;
            fc.Show();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            NapraviFormPoslednja(new NumericEvaluator());
        }

        private void NapraviFormPoslednja(IEvaluate evaluator)
        {
            FormPoslednja fc = new FormPoslednja(evaluator);            
            fc.MdiParent = this;
            fc.Show();
        }

        private void NapraviFormPoslednja(int mode)
        {
            FormPoslednja fc = new FormPoslednja();
            fc.Mode = mode;
            fc.MdiParent = this;
            fc.Show();
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            NapraviFormPoslednja(new BoolEvaluator());
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            NapraviFormPoslednja(new StringEvaluator());
        }
    }
}
