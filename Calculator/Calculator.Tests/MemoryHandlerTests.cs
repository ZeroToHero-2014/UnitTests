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
    public class MemoryHandlerTests
    {

        [TestMethod]
        public void Store_StoreIsCalled()
        {
            CalculatorEngineDummy calculator = new CalculatorEngineDummy();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            
            var handler = new MemoryHandler(calculator, memoryMock.Object);

            handler.Store();

            memoryMock.Verify(memory => memory.Store(It.IsAny<double>()));
        }

        [TestMethod]
        public void Store_GetTotalIsCalled()
        {
            CalculatorEngineDummy calculator = new CalculatorEngineDummy();
            MemoryReplacement memory = new MemoryReplacement();
            calculator.Set(5);

            var handler = new MemoryHandler(calculator, memory);

            handler.Store();

            Assert.AreEqual(true, calculator.GetTotalCalled);
        }

        [TestMethod]
        public void Retrieve_RetrieveIsCalled()
        {
            CalculatorEngine calculator = new CalculatorEngine();
            MemoryReplacement memory = new MemoryReplacement();

            var handler = new MemoryHandler(calculator, memory);

            handler.Retrieve();

            Assert.IsTrue(memory.RetrieveCalled);
        }

        [TestMethod]
        public void Retrieve_ValueIsFed()
        {
            CalculatorEngine calculator = new CalculatorEngine();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            memoryMock.Setup(m => m.Retrieve()).Returns(6);

            var handler = new MemoryHandler(calculator, memoryMock.Object);

            handler.Retrieve();

            var actualTotal = calculator.GetTotal();
            Assert.AreEqual(6, actualTotal);
        }
        [TestMethod]
        public void Add_value()
        {
            CalculatorEngine calculator = new CalculatorEngine();
            MemoryReplacement memory = new MemoryReplacement();
            memory.StoredValue = 7;
            calculator.Set(9);
            var handler = new MemoryHandler(calculator, memory);

            handler.Add();

            Assert.AreEqual(16, memory.LastStoreArgument);
        }

        [TestMethod]
        public void Subtract_test()
        {
            CalculatorEngineDummy calculator = new CalculatorEngineDummy();
            MemoryReplacement memory = new MemoryReplacement();

            var handler = new MemoryHandler(calculator, memory);
            handler.Subtract();

            Assert.IsTrue(calculator.GetTotalCalled);
        }
        [TestMethod]
        public void Substract_RetriveIsCalled()
        {
            CalculatorEngineDummy calculator = new CalculatorEngineDummy();
            MemoryReplacement memory = new MemoryReplacement();
            
            var handler = new MemoryHandler(calculator, memory);
            handler.Subtract();
            Assert.IsTrue(memory.RetrieveCalled);
        }
        [TestMethod]
        public void Substract_StoreIsCalled()
        {
            CalculatorEngineDummy calculator = new CalculatorEngineDummy();
            MemoryReplacement memory = new MemoryReplacement();
            var handler = new MemoryHandler(calculator, memory);
            handler.Subtract();
            Assert.IsTrue(memory.StoreCalled);
        }

        [TestMethod]
        public void Substract_value()
        {   
            CalculatorEngineDummy calculator = new CalculatorEngineDummy();
            MemoryReplacement memory = new MemoryReplacement();
            var handler = new MemoryHandler(calculator, memory);
            calculator.Set(13);
            memory.StoredValue = 20;

            handler.Subtract();
          
            Assert.AreEqual(7, memory.LastStoreArgument);
        }

        [TestMethod]
        public void Add_GetTotalCalled()
        {
            CalculatorEngineDummy calculator = new CalculatorEngineDummy();
            MemoryReplacement memory = new MemoryReplacement();

            var handler = new MemoryHandler(calculator, memory);
            handler.Add();

            Assert.IsTrue(calculator.GetTotalCalled);
        }


        [TestMethod]
        public void Add_RetriveIsCalled()
        {
            CalculatorEngineDummy calculator = new CalculatorEngineDummy();
            MemoryReplacement memory = new MemoryReplacement();

            var handler = new MemoryHandler(calculator, memory);
            handler.Add();
            Assert.IsTrue(memory.RetrieveCalled);
        }
        [TestMethod]
        public void Add_StoreIsCalled()
        {
            CalculatorEngineDummy calculator = new CalculatorEngineDummy();
            MemoryReplacement memory = new MemoryReplacement();
            var handler = new MemoryHandler(calculator, memory);
            handler.Add();
            Assert.IsTrue(memory.StoreCalled);
        }

        [TestMethod]
        public void Clear_ClearIsCalled()
        {
            CalculatorEngineDummy calculator = new CalculatorEngineDummy();
            MemoryReplacement memory = new MemoryReplacement();
            var handler = new MemoryHandler(calculator, memory);
            handler.Clear();
            Assert.IsTrue(memory.ClearIsCalled);
        }

    }
}
