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
    public partial class FormPoslednja : Form, IUpdate
    {
        int mode = 0;

        public int Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public FormPoslednja()
        {
            InitializeComponent();
        }

        public FormPoslednja(IEvaluate eval)
        {
            InitializeComponent();
            this.Evaluator = eval;
        }

        public void Update(string s)
        {
            Evaluate(s);
        }

        private void Evaluate(string s)
        {
            if (this.Evaluator != null)
            {
                this.label1.Text = "Ok";
                this.textBox1.Text = s;

                string errormessage = string.Empty;
                bool result = this.Evaluator.Evaluate(s, 
                    out errormessage);

                if (!result)
                {
                    this.label1.Text = errormessage;
                    this.textBox1.Clear();
                }
            }
            //this.label1.Text = "Ok";
            //this.textBox1.Text = s;

            //if (mode == 0)
            //{                

            //    try
            //    {
            //        decimal res = decimal.Parse(s);
            //    }
            //    catch (Exception ex)
            //    {
            //        this.label1.Text = ex.Message;
            //        this.textBox1.Clear();
            //    }
            //}
            //else if (mode == 1)
            //{
            //    bool evaluated = false;
            //    if (!bool.TryParse(s, out evaluated))
            //    {
            //        this.label1.Text = "Not evaluated";
            //        this.textBox1.Clear();
            //    }
                
            //}
            //else if (mode == 2)
            //{                
            //    if (s.Length > 10)
            //    {
            //        this.label1.Text = "(s.Length > 10)";
            //        this.textBox1.Clear();
            //    }

            //}
        }

        public IEvaluate Evaluator { get; set; }
    }
}
