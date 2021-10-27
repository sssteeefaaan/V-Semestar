using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MVCExample.View;
using MVCExample.Controller;

namespace MVCExample
{
    public partial class FormCalc : Form, IView
    {
        public FormCalc()
        {
            InitializeComponent();
            
        }

        IController controller;        
        public void AddListener( IController controller )
        {
            this.controller = controller;
        }

        private void lbl_Click(object sender, EventArgs e)
        {   
            Label local = sender as Label;
            if (local == null) return;

           controller.OnClick(int.Parse(local.Text));
        }

        private void lblPlus_Click(object sender, EventArgs e)
        {
           controller.OnAdd();
        }

        private void lblMinus_Click(object sender, EventArgs e)
        {
            controller.OnSubstract();
        }

        #region ICalcView Members

        public string Total
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            controller = new Controller.Controller(controller.GetModel(), this);
        }

        

        
    }
}
