using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core
{
    public class MemoryHandler
    {
        private CalculatorEngine calculatorEngine;
        private IMemory memory;

        public MemoryHandler(CalculatorEngine calculatorEngine, IMemory memory)
        {
            this.calculatorEngine = calculatorEngine;
            this.memory = memory;
        }

        public void Add()
        {
            double total = memory.Retrieve() + calculatorEngine.GetTotal();
            memory.Store(total);
        }

        public void Subtract()
        {
            var total = memory.Retrieve() - calculatorEngine.GetTotal();
            memory.Store(total);
        }

        public void Store()
        {
            var total = calculatorEngine.GetTotal();
            memory.Store(total);
        }

        public void Clear()
        {
            memory.Clear();
        }

        public void Retrieve()
        {
            var storedValue = memory.Retrieve();
            calculatorEngine.Set(storedValue);
        }
    }
}
