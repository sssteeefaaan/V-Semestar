using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCExample.Model
{
    public interface IModel
    {        
        int SetInput(int number);
                
        int Add(int value1, int value2);

        int Subtract(int value1, int value2);
        
        void ChangeToAddState();

        void ChangeToSubstractState();
    }
}
