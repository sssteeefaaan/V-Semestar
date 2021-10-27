using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public class Turkey
    {
        public void Gooble()
        {
            MessageBox.Show("Gooble");
        }

        public void ShortFly()
        {
            MessageBox.Show("fly-dly-fly");
        }

        public void Draw()
        {
            MessageBox.Show("Turkey");
        }
    }

    public class TurkeyAdapter : Duck
    {
        Turkey tk;
        public TurkeyAdapter(Turkey turkey)
        {
            this.tk = turkey;
        }

        public override void Display()
        {
            this.tk.Draw();
        }

        public override void Swim()
        {
            return;
        }

        public override void PerformQuack()
        {
            tk.Gooble();
        }

        public override void PerformFly()
        {
            tk.ShortFly();
        }
    }
}
