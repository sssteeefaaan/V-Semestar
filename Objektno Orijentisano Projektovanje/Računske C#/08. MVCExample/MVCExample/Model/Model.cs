using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCExample.Model
{
    public class Model : IModel
    {
        public enum States { NoOperation, Add, Subtract };

        States state;
        int currentValue;

        

        public int SetInput(int number)
        {
            if (state == States.NoOperation)
            {
                currentValue = number;
            }
            else if (state == States.Add)
            {
                currentValue = Add(currentValue, number);
            }
            else if (state == States.Subtract)
            {
                currentValue = Subtract(currentValue, number);
            }

            return currentValue;
        }

        public void ChangeToAddState()
        {
            this.state = States.Add;
        }

        public void ChangeToSubstractState()
        {
            this.state = States.Subtract;
        }

        public States State
        {
            set { state = value; }
        }

        public void ChangeToState(States newState)
        {
            this.State = newState;
        }

        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }

        public int Subtract(int value1, int value2)
        {
            return value1 - value2;
        }
    }
}
