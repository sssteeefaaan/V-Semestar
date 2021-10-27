using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCExample.Controller;

namespace MVCExample.View
{
    public interface IView
    {
        void AddListener(IController controller);

        string Total
        {
            get;
            set;
        }
    }
}
