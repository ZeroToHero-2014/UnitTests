using Calculator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorEngineTests
    {
        [TestMethod]
        public void GetTotal_Default_ReturnsZero()
        {
            //Arrange
            CalculatorEngine engine = new CalculatorEngine();

            //Act
            double total = engine.GetTotal();

            //Assert
            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void Set_With5_TotalReturns5()
        {
            //Arrange
            CalculatorEngine engine = new CalculatorEngine();
            engine.Set(5);

            //Act
            double total = engine.GetTotal();

            //Assert
            Assert.AreEqual(5, total);
        }

        [TestMethod]
        public void Add_10With5_TotalReturns15()
        {
            CalculatorEngine engine = new CalculatorEngine();
            engine.Set(10);

            engine.Add(5);
            double total = engine.GetTotal();

            Assert.AreEqual(15, total);
        }

        [TestMethod]
        public void Subtract_5From7_TotalReturns2()
        {
            CalculatorEngine engine = new CalculatorEngine();
            engine.Set(7);

            engine.Subtract(5);
            double total = engine.GetTotal();

            Assert.AreEqual(2, total);
        }

        [TestMethod]
        public void Multiply_6ByDefault_ReturnsZero()
        {
            CalculatorEngine engine = new CalculatorEngine();

            engine.Multiply(6);
            double total = engine.GetTotal();

            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void Multiply_2By20_TotalReturns40()
        {
            CalculatorEngine engine = new CalculatorEngine();
            engine.Set(20);

            engine.Multiply(2);
            double total = engine.GetTotal();

            Assert.AreEqual(40, total);
        }

        [TestMethod]
        public void Divide_20By10_TotalReturns2()
        {
            CalculatorEngine engine = new CalculatorEngine();
            engine.Set(20);

            engine.Divide(10);
            double total = engine.GetTotal();

            Assert.AreEqual(2, total);
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsDivideException()
        {
            CalculatorEngine engine = new CalculatorEngine();
            engine.Set(10);

            Exception thrownException = null;

            try
            {
                engine.Divide(0);
            }

            catch (DivideException ex)
            {
                thrownException = ex;
            }

            Assert.IsInstanceOfType(thrownException, typeof(DivideException));
        }

        [TestMethod]
        public void Clear_Exists114_TotalReturnsZero()
        {
            CalculatorEngine engine = new CalculatorEngine();
            engine.Set(114);

            engine.Clear();
            double total = engine.GetTotal();

            Assert.AreEqual(0, total);
        }
    }
}
