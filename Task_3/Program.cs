using System;
using GenericCache;

namespace FunctionCacheExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Для підтримки кирилиці
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення кешу з часом дії 10 секунд
            var cache = new FunctionCache<int, int>(TimeSpan.FromSeconds(10));

            // Функція для обчислення квадрата числа
            Func<int, int> squareFunction = x =>
            {
                Console.WriteLine($"Обчислюю квадрат для {x}");
                return x * x;
            };

            // Використання кешу
            Console.WriteLine("Результат 1: " + cache.GetOrAdd(4, squareFunction));
            Console.WriteLine("Результат 2: " + cache.GetOrAdd(4, squareFunction)); // Повинно взяти з кешу

            // Чекаємо 11 секунд
            Console.WriteLine("Чекаємо 11 секунд...");
            System.Threading.Thread.Sleep(11000);

            Console.WriteLine("Результат 3: " + cache.GetOrAdd(4, squareFunction)); // Повторно виконає функцію

            // Очищення кешу
            cache.ClearCache();
            Console.WriteLine("Кеш очищено.");
            Console.WriteLine("Результат 4: " + cache.GetOrAdd(4, squareFunction));
        }
    }
}
