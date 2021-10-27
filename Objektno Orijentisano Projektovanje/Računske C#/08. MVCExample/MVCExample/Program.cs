using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace MVCExample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            FormCalc view = new FormCalc();

            MVCExample.Model.Model model = new MVCExample.Model.Model();

            MVCExample.Controller.IController controller 
                = new MVCExample.Controller.TestController(model, 
                    view);

            Application.Run(view);
        }
    }
}
