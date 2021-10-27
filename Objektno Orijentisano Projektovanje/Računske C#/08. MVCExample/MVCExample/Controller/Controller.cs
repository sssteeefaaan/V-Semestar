using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCExample.Model;
using MVCExample.View;

namespace MVCExample.Controller
{
    public class Controller : IController
    {
        IModel model;
        IView  view;


        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view  = view;
            this.view.AddListener(this);
        }

        public void OnClick( int number )
        {
            view.Total = model.SetInput(number).ToString();
        }

        public void OnAdd()
        {
            model.ChangeToAddState();
        }

        public void OnSubstract()
        {
            model.ChangeToSubstractState();
        }


        public IModel GetModel()
        {
            return model;
        }
    }
}
