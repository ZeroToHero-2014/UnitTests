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
        public void Store_GetTotalFromCalculatorIsCalled()
        {
            Mock<CalculatorEngine> calculatorMock = new Mock<CalculatorEngine>();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            var handler = new MemoryHandler(calculatorMock.Object, memoryMock.Object);
            calculatorMock.Object.Set(5);

            handler.Store();

            calculatorMock.Verify(c => c.GetTotal());
        }

        [TestMethod]
        public void Store_StoreToMemoryIsCalledWithExactArgument()
        {
            CalculatorEngine calculator = new CalculatorEngine();
            Mock<IMemory> memoryMock = new Mock<IMemory>();            
            var handler = new MemoryHandler(calculator, memoryMock.Object);
            calculator.Set(5);

            handler.Store();

            //Aici am verificat ca s-a apelat cu un argument concret. 
            //Framework-ul imi spune daca s-a apelat cu un alt argument in loc de cel asteptat
            memoryMock.Verify(memory => memory.Store(5));
        }
        
        [TestMethod]
        public void Retrieve_RetrieveFromMemoryIsCalled()
        {
            CalculatorEngine calculator = new CalculatorEngine();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            var handler = new MemoryHandler(calculator, memoryMock.Object);

            handler.Retrieve();

            memoryMock.Verify(m => m.Retrieve());
        }

        [TestMethod]
        public void Retrieve_StoredValueISetInCalcualtor()
        {
            CalculatorEngine calculator = new CalculatorEngine();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            var handler = new MemoryHandler(calculator, memoryMock.Object);
            memoryMock.Setup(m => m.Retrieve()).Returns(6);

            handler.Retrieve();
            var actualTotal = calculator.GetTotal();

            Assert.AreEqual(6, actualTotal);        
        }

        [TestMethod]
        public void Add_GetTotalFromCalculatorIsCalled()
        {
            Mock<CalculatorEngine> calculatorMock = new Mock<CalculatorEngine>();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            var handler = new MemoryHandler(calculatorMock.Object, memoryMock.Object);

            handler.Add();

            calculatorMock.Verify(c => c.GetTotal());
        }

        [TestMethod]
        public void Add_RetriveFromMemoryIsCalled()
        {
            CalculatorEngine calculator = new CalculatorEngine();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            var handler = new MemoryHandler(calculator, memoryMock.Object);
            
            handler.Add();

            memoryMock.Verify(m => m.Retrieve());
        }

        [TestMethod]
        public void Add_StoreToMemoryIsCalledWithExactArguments()
        {
            CalculatorEngine calculator = new CalculatorEngine();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            var handler = new MemoryHandler(calculator, memoryMock.Object);
            calculator.Set(9);
            memoryMock.Setup(m=>m.Retrieve()).Returns(7);

            handler.Add();
            
            memoryMock.Verify(m=>m.Store(16));
        }

        [TestMethod]
        public void Subtract_GetTotalFromCalculatorIsCalled()
        {
            Mock<CalculatorEngine> calculatorMock = new Mock<CalculatorEngine>();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            var handler = new MemoryHandler(calculatorMock.Object, memoryMock.Object);
            
            handler.Subtract();

            calculatorMock.Verify(c => c.GetTotal());
        }

        [TestMethod]
        public void Substract_RetriveFromMemoryIsCalled()
        {
            CalculatorEngine calculatorEngine = new CalculatorEngine();
            Mock<IMemory> memoryMock = new Mock<IMemory>();            
            var handler = new MemoryHandler(calculatorEngine, memoryMock.Object);
            
            handler.Subtract();

            memoryMock.Verify(m => m.Retrieve());
        }

        [TestMethod]
        public void Substract_StoreToMemoryIsCalledWithExactsArguments()
        {
            CalculatorEngine calculatorEngine = new CalculatorEngine();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            var handler = new MemoryHandler(calculatorEngine, memoryMock.Object);
            calculatorEngine.Set(13);
            memoryMock.Setup(m => m.Retrieve()).Returns(20);

            handler.Subtract();

            memoryMock.Verify(m => m.Store(7));
        }

        

        [TestMethod]
        public void Clear_ClearIsCalled()
        {
            CalculatorEngine calculator = new CalculatorEngine();
            Mock<IMemory> memoryMock = new Mock<IMemory>();
            var handler = new MemoryHandler(calculator, memoryMock.Object);
            
            handler.Clear();

            memoryMock.Verify(m => m.Clear());
        }

    }
}
