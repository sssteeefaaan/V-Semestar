using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    /// <summary>
    /// Osnovni proizvodi
    /// </summary>
    abstract public class Beverage
    {
        protected string description = "";

        public virtual string GetDescription()
        {
            return this.description;
        }

        public abstract float Cost();
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            this.description = "House Blend";
        }

        public override float Cost()
        {
            return 1.99f;            
        }
    }

    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            this.description = "Dark Roast";
        }

        public override float Cost()
        {
            return 1.49f;
        }
    }

    public class Espresso : Beverage
    {
        public Espresso()
        {
            this.description = "Espresso";
        }

        public override float Cost()
        {
            return 2.49f;
        }
    }

    public class Decaf : Beverage
    {
        public Decaf()
        {
            this.description = "Decaf";
        }

        public override float Cost()
        {
            return 1.09f;
        }
    }

    /// <summary>
    /// Dekoratori
    /// </summary>
    public abstract class CondimentDecorator : Beverage
    {       
		protected Beverage beverage;
    }

    public class Mocha : CondimentDecorator
    {      

        public Mocha(Beverage bev)
        {
            this.beverage = bev;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Mocha";
        }

        public override float Cost()
        {
            return .2f + beverage.Cost();
        }
    }

    public class Whip : CondimentDecorator
    {
        public Whip(Beverage bev)
        {
            this.beverage = bev;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Whip";
        }

        public override float Cost()
        {
            return .09f + beverage.Cost();
        }
    }

    public class Soy : CondimentDecorator
    {

        public Soy(Beverage bev)
        {
            this.beverage = bev;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Soy";
        }

        public override float Cost()
        {
            return .12f + beverage.Cost();
        }
    }

    public class Milk : CondimentDecorator
    {
        

        public Milk(Beverage bev)
        {
            this.beverage = bev;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Milk";
        }

        public override float Cost()
        {
            return .1f + beverage.Cost();
        }
    }

    /// <summary>
    /// Kako se koriste kreirane klase
    /// </summary>
    public class CoffeShop
    {
        public static void Use()
        {
            Beverage bev1 = new Milk(new Whip(new DarkRoast()));
            MessageBox.Show(bev1.GetDescription() + " " + bev1.Cost().ToString());

            bev1 = new Soy(new Milk(new Milk(new Decaf())));
            MessageBox.Show(bev1.GetDescription() + " " + bev1.Cost().ToString());

        }
    }
}
