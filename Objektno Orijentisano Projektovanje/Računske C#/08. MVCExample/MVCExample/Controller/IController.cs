using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCExample.Controller
{
    public interface IController
    {
        void OnClick(int number);
        void OnAdd();
        void OnSubstract();

        Model.IModel GetModel();
    }
}
