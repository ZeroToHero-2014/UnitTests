using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core
{
    public class CalculatorEngine
    {
        private double total;
                
        public void Set(double value)
        {
            total = value;
        }

        public void Add(double value)
        {
            total += value;
        }

        public void Subtract(double value)
        {
            total -= value;
        }

        public void Multiply(double value)
        {
            total *= value;
        }

        public void Divide(double value)
        {
            if (value == 0)
            {
                throw new DivideException();
            }
         
            total /= value;            
        }

        public void Clear()
        {
            total = 0;
        }

        public virtual double GetTotal()
        {
            return  total;
        }
    }
}
