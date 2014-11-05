using Calculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    public class MemoryReplacement : IMemory
    {
        public bool StoreCalled { get; set; }
        public double LastStoreArgument { get; set; }

        public void Store(double value)
        {
            StoreCalled = true;
            LastStoreArgument = value;
        }

        public void Clear()
        {
            ClearIsCalled = true;
        }

        public double StoredValue { get; set; }
        public bool RetrieveCalled { get; set; }

        public double Retrieve()
        {
            RetrieveCalled = true;
            return StoredValue;
        }

        public bool ClearIsCalled { get; set; }
    }

    public class CalculatorEngineDummy : CalculatorEngine
    {
        public bool GetTotalCalled { get; set; }

        public override double GetTotal()
        {
            GetTotalCalled = true;
            return base.GetTotal();
        }
    }
}
