using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public abstract class WakeUpBeverage
    {
        public void PrepareRecipe()
        {
            boilWater();
            brew();
            pourInCup();
            addCondiments();
        }

        public abstract void addCondiments();
        public abstract void brew();
        public void boilWater()
        {
            MessageBox.Show("Boil water");
        }
        public void pourInCup()
        {
            MessageBox.Show("Pour coffee in the cup");
        }
    }

    public class Coffee: WakeUpBeverage
    {        
        public void addSugarAndMilk()
        {
            MessageBox.Show("Add sugar & milk");
        }        

        public void brewCoffeeGrinds()
        {
            MessageBox.Show("Brew coffee grinds");
        }

        public override void addCondiments()
        {
            this.addSugarAndMilk();
        }

        public override void brew()
        {
            this.addCondiments();
        }
    }

    public class Tea : WakeUpBeverage
    {        
        public void stepTeaBag()
        {
            MessageBox.Show("AStep tea bag");
        }        

        public void addLemon()
        {
            MessageBox.Show("Add lemon");
        }

        public override void addCondiments()
        {
            this.stepTeaBag();
        }

        public override void brew()
        {
            this.addLemon();
        }
    }
}
