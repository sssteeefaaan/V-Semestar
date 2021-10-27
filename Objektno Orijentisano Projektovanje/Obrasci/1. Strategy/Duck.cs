using System;
using System.Windows.Forms;
using System.Collections;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for Duck.
	/// </summary>
	public class Duck
	{
		protected FlyBehaviour flyBehaviour;
		protected QuackBehaviour quackBehaviour;
		public Duck()
		{
			
		}

		public virtual void PerformQuack()
		{
			quackBehaviour.Quack();
		}

		public virtual void PerformFly()
		{
			flyBehaviour.Fly();
		}

		public virtual void Swim()
		{
			MessageBox.Show("Duck swims");
		}

		public virtual void Display()
		{
			MessageBox.Show("Duck!");
		}

		/// <summary>
		/// Omogucuje promenu nacina letenja u run-timeu
		/// </summary>
		/// <param name="fb"></param>
		public void SetFlyBehaviour(FlyBehaviour fb)
		{
			flyBehaviour = fb;
		}

		/// <summary>
		/// Omogucuje promenu nacina kvakanja u ran tajmu
		/// </summary>
		/// <param name="qb"></param>
		public void SetQuackBehaviour(QuackBehaviour qb)
		{
			quackBehaviour = qb;
		}
	}

	#region Ducks
	
	public class MallardDuck : Duck
	{
		public MallardDuck()
		{
			this.flyBehaviour = new FlyWithWings();
			this.quackBehaviour = new Quacking();
		}

		public override void Display()
		{
			MessageBox.Show("Mallard duck");
		}

	}


	public class RedHeadDuck : Duck
	{
		public RedHeadDuck()
		{
			this.flyBehaviour = new FlyWithWings();
			this.quackBehaviour = new Quacking();
		}

		public override void Display()
		{
			MessageBox.Show("Red Head duck");
		}

	}


	public class RubberDuck : Duck
	{
		public RubberDuck()
		{
			this.flyBehaviour = new FlyNoWay();
			this.quackBehaviour = new Squeek();
		}

		public override void Display()
		{
			MessageBox.Show("Rubber duck");
		}

	}

	public class DecoyDuck : Duck
	{
		public DecoyDuck()
		{
			this.flyBehaviour = new FlyNoWay();
			this.quackBehaviour = new MuteQuack();
		}

		public override void Display()
		{
			MessageBox.Show("Decoy duck");
		}

	}


	#endregion

	public interface FlyBehaviour
	{
		void Fly();
	}

	public class FlyWithWings : FlyBehaviour
	{
		#region FlyBehaviour Members

		public void Fly()
		{
			// TODO:  Add FlyWithWings.Fly implementation
			MessageBox.Show("Flies with wings");
		}

		#endregion
	}

	public class FlyWithRocketPropulsion : FlyBehaviour
	{
		#region FlyBehaviour Members

		public void Fly()
		{
			// TODO:  Add FlyWithRocketPropulsion.Fly implementation
			MessageBox.Show("Flies with rocket propulsion");
		}

		#endregion

	}

	public class FlyNoWay : FlyBehaviour
	{
		#region FlyBehaviour Members

		public void Fly()
		{
			// TODO:  Add FlyNoWay.Fly implementation
			return;
		}

		#endregion

	}



	public interface QuackBehaviour
	{
		void Quack();
	}

	public class Quacking : QuackBehaviour
	{
		#region QuackBehaviour Members

		public void Quack()
		{
			// TODO:  Add Quack.Quack implementation
			MessageBox.Show("Quack!");
		}

		#endregion

	}

	public class Squeek : QuackBehaviour
	{
		#region QuackBehaviour Members

		public void Quack()
		{
			// TODO:  Add Squeek.Quack implementation
			MessageBox.Show("Squeek!");
		}

		#endregion

	}

	public class MuteQuack : QuackBehaviour
	{
		#region QuackBehaviour Members

		public void Quack()
		{
			// TODO:  Add MuteQuack.Quack implementation
			return;
		}

		#endregion

	}

    public class Ducks
    {
        public static void Use()
        {
            MallardDuck md = new MallardDuck();
            RubberDuck rd = new RubberDuck();
            rd.SetFlyBehaviour(new FlyWithRocketPropulsion());
            Duck td = new TurkeyAdapter(new Turkey());

            ArrayList ducks = new ArrayList();

            ducks.Add(md);
            ducks.Add(rd);
            ducks.Add(td);

            foreach (Duck d in ducks)
            {
                d.Display();
                d.Swim();
                d.PerformFly();
                d.PerformQuack();
            }
        }

    }


    



}
