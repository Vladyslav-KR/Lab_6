using System;
using GenericCalculator;

namespace GenericCalculatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Дженеричний калькулятор:");

            // Калькулятор для int
            var intCalculator = new Calculator<int>();
            Console.WriteLine($"Сума (int): {intCalculator.ExecuteOperation(intCalculator.Add, 5, 10)}");
            Console.WriteLine($"Різниця (int): {intCalculator.ExecuteOperation(intCalculator.Subtract, 15, 5)}");
            Console.WriteLine($"Добуток (int): {intCalculator.ExecuteOperation(intCalculator.Multiply, 3, 4)}");
            Console.WriteLine($"Частка (int): {intCalculator.ExecuteOperation(intCalculator.Divide, 20, 4)}");

            // Калькулятор для double
            var doubleCalculator = new Calculator<double>();
            Console.WriteLine($"Сума (double): {doubleCalculator.ExecuteOperation(doubleCalculator.Add, 5.5, 10.2)}");
            Console.WriteLine($"Різниця (double): {doubleCalculator.ExecuteOperation(doubleCalculator.Subtract, 15.5, 5.3)}");
            Console.WriteLine($"Добуток (double): {doubleCalculator.ExecuteOperation(doubleCalculator.Multiply, 3.3, 4.1)}");
            Console.WriteLine($"Частка (double): {doubleCalculator.ExecuteOperation(doubleCalculator.Divide, 20.5, 4.5)}");

            // Калькулятор для float
            var floatCalculator = new Calculator<float>();
            Console.WriteLine($"Сума (float): {floatCalculator.ExecuteOperation(floatCalculator.Add, 2.5f, 3.5f)}");
            Console.WriteLine($"Різниця (float): {floatCalculator.ExecuteOperation(floatCalculator.Subtract, 5.5f, 2.2f)}");
            Console.WriteLine($"Добуток (float): {floatCalculator.ExecuteOperation(floatCalculator.Multiply, 1.5f, 3.0f)}");
            Console.WriteLine($"Частка (float): {floatCalculator.ExecuteOperation(floatCalculator.Divide, 6.0f, 2.0f)}");
        }
    }
}
