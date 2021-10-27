using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPrimer
{
    public interface IEvaluate
    {
        bool Evaluate(string toEvaluate, out string errormessage);
    }

    public class NumericEvaluator : IEvaluate
    {
        public bool Evaluate(string toEvaluate, 
            out string errormessage)
        {
            errormessage = string.Empty;
            try
            {
                decimal res = decimal.Parse(toEvaluate);
                return true;
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return false;
            }
        }
    }

    public class BoolEvaluator : IEvaluate
    {
        public bool Evaluate(string toEvaluate, out string errormessage)
        {   bool evaluatedValue;
            errormessage = string.Empty;
            bool evaluated = bool.TryParse(toEvaluate, out evaluatedValue);
            if (!evaluated)
            {
                errormessage = "Not evaluated";         
            }
            return evaluated;
        }
    }

    public class StringEvaluator : IEvaluate
    {
        public bool Evaluate(string toEvaluate, out string errormessage)
        {
            if (toEvaluate.Length > 10)
            {
                errormessage = "(s.Length > 10)";
                return false;
            }
            errormessage = string.Empty;
            return true;
        }
    }



}
