using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core
{
    public class CalculatorEngine
    {
        private Queue<OrderPriorityValue> operations;
        private double initialValue;

        public CalculatorEngine()
        {
            operations = new Queue<OrderPriorityValue>();
        }

        public virtual void Set(double value)
        {
            if (operations.Count != 0) throw new InvalidOperationException();

            operations.Enqueue(new OrderPriorityValue(AddOperation, 0, value));
        }

        private double SetOperation(double value, double totalSoFar)
        {
            return value;
        }

        public virtual void Add(double value)
        {
            if (operations.Count == 0) Set(0);
            operations.Enqueue(new OrderPriorityValue(AddOperation, 0, value));
        }

        private double AddOperation(double value, double totalSoFar)
        {
            return totalSoFar + value;
        }

        public virtual void Subtract(double value)
        {
            if (operations.Count == 0) Set(0);
            operations.Enqueue(new OrderPriorityValue(SubtractOperation, 0, value));
        }

        private double SubtractOperation(double value, double totalSoFar)
        {
            return totalSoFar - value;
        }

        public virtual void Multiply(double value)
        {
            if (operations.Count == 0) Set(0);
            operations.Enqueue(new OrderPriorityValue(MultiplyOperation, 1, value));
        }

        private double MultiplyOperation(double value, double totalSoFar)
        {
            return totalSoFar * value;
        }

        public virtual void Divide(double value)
        {
            if (operations.Count == 0) Set(0);
            operations.Enqueue(new OrderPriorityValue(DivideOperation, 1, value));
        }

        public double DivideOperation(double value, double totalSoFar)
        {
            if (value == 0)
            {
                DivideException e = new DivideException();
                throw e;
            }
            else
            {
                return totalSoFar / value;
            }
        }

        public virtual void Clear()
        {
            operations.Clear();
        }

        public virtual double GetTotal()
        {
            var maxPriority = operations.Max(m => m.Prioritate);

            return GetTotalInternal(maxPriority, new Queue<OrderPriorityValue>(operations));
        }

        private virtual double GetTotalInternal(double currentPriority, Queue<OrderPriorityValue> operations)
        {

            Queue<OrderPriorityValue> newQueue = new Queue<OrderPriorityValue>();

            OrderPriorityValue previousOperation = null;
            OrderPriorityValue currentOperation = null;
            while (operations.Count > 0)
            {
                if (previousOperation == null)
                {
                    previousOperation = operations.Dequeue();
                }
                else
                {
                    currentOperation = operations.Dequeue();
                    if (currentOperation.Prioritate == currentPriority)
                    {
                        var currentTotal = currentOperation.Run(previousOperation.Valoare);
                        previousOperation = new OrderPriorityValue(previousOperation.Operatie, previousOperation.Prioritate, currentTotal);
                    }
                    else
                    {
                        newQueue.Enqueue(previousOperation);
                        previousOperation = currentOperation;
                    }
                }
            }

            if (newQueue.Count == 1)
            {
                var uniqueOperation = newQueue.Dequeue();
                return uniqueOperation.Run(0);
            }
            else
            {
                var maxPriority = newQueue.Max(m => m.Prioritate);

                return GetTotalInternal(maxPriority, newQueue);
            }
        }
    }

    public class OrderPriorityValue
    {
        public double Valoare { get; set; }
        public Func<double, double, double> Operatie { get; private set; }

        public OrderPriorityValue(Func<double, double, double> operatie, int prioritate, double valoare)
        {
            this.Operatie = operatie;
            this.Prioritate = prioritate;
            this.Valoare = valoare;
        }

        public int Prioritate { get; set; }

        public double Run(double totalSoFar)
        {
            return Operatie(Valoare, totalSoFar);
        }
    }
}
