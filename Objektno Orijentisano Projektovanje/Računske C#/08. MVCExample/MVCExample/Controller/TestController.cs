using MVCExample.Model;
using MVCExample.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCExample.Controller
{
    public class TestController : IController
    {
        IView myView;
        IModel myModel;
        int localCount = 0;

        public TestController(IModel m, IView v)
        {
            myView = v;
            myModel = m;
            v.AddListener(this);
        }

        public void OnClick(int number)
        {
            if (localCount > 1000000000)
                return;

            localCount = 10 * localCount + number;
            SetTotal();
        }

        private void SetTotal()
        {
            myView.Total = localCount.ToString();
        }

        public void OnAdd()
        {
            localCount++;
            SetTotal();
        }

        public void OnSubstract()
        {
            localCount--;
            SetTotal();
        }


        public IModel GetModel()
        {
            return myModel;
        }
    }
}
