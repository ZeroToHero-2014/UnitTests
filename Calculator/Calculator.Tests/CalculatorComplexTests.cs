using Calculator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorComplexTests
    {
        [TestMethod]
        public void DivideisCorect_beforeAdd()
        {
            CalculatorEngine smart = new CalculatorEngine();
            smart.Add(7);
            smart.Add(4);
            smart.Divide(2);
            smart.Add(10);
            Assert.AreEqual(19, smart.GetTotal());

        }

        [TestMethod]
        public void Multiply_WhenTwoAddingBefore_MultiplyIsDoneFirst()
        {
            CalculatorEngine calculator = new CalculatorEngine();

            calculator.Set(5);
            calculator.Add(5);
            calculator.Multiply(5);

            double total = calculator.GetTotal();
            Assert.AreEqual(30, total);
        }

        [TestMethod]
        public void Multiply_WhenTwoAddingBeforeAndOneAfter_MultiplyIsDoneFirst()
        {
            CalculatorEngine calculator = new CalculatorEngine();

            calculator.Set(5);
            calculator.Add(5);
            calculator.Multiply(5);
            calculator.Add(5);

            double total = calculator.GetTotal();
            Assert.AreEqual(35, total);
        }

        [TestMethod]
        public void MultiplyAndDivide_Mixed_TotalIsAsExpected()
        {
            CalculatorEngine calculator = new CalculatorEngine();

            calculator.Set(6);
            calculator.Divide(3);
            calculator.Add(7);
            calculator.Multiply(2);

            double total = calculator.GetTotal();
            Assert.AreEqual(16, total);
        }
    }
}
