using System;

namespace GenericCalculator
{
    public class Calculator<T> where T : struct
    {
        public delegate T Operation(T a, T b);

        public Operation Add { get; set; }
        public Operation Subtract { get; set; }
        public Operation Multiply { get; set; }
        public Operation Divide { get; set; }

        public Calculator()
        {
            Add = (a, b) => (dynamic)a + (dynamic)b;
            Subtract = (a, b) => (dynamic)a - (dynamic)b;
            Multiply = (a, b) => (dynamic)a * (dynamic)b;
            Divide = (a, b) =>
            {
                if ((dynamic)b == 0) throw new DivideByZeroException("На нуль ділити не можна!");
                return (dynamic)a / (dynamic)b;
            };
        }

        public T ExecuteOperation(Operation operation, T a, T b)
        {
            return operation(a, b);
        }
    }
}
