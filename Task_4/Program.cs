using System;
using GenericTaskScheduler;

namespace TaskSchedulerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення планувальника
            var scheduler = new TaskScheduler<string, int>();

            // Делегат для виконання завдань
            TaskExecution<string> executeTask = task =>
            {
                Console.WriteLine($"Виконую завдання: {task}");
            };

            // Основне меню
            while (true)
            {
                Console.WriteLine("\nВиберіть опцію:");
                Console.WriteLine("1. Додати завдання");
                Console.WriteLine("2. Виконати наступне завдання");
                Console.WriteLine("3. Показати всі завдання");
                Console.WriteLine("4. Вийти");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть назву завдання: ");
                        var taskName = Console.ReadLine();

                        Console.Write("Введіть пріоритет завдання (число): ");
                        if (int.TryParse(Console.ReadLine(), out int priority))
                        {
                            scheduler.AddTask(taskName, priority);
                            Console.WriteLine($"Додано завдання '{taskName}' з пріоритетом {priority}.");
                        }
                        else
                        {
                            Console.WriteLine("Невірний формат пріоритету.");
                        }
                        break;

                    case "2":
                        scheduler.ExecuteNext(executeTask);
                        break;

                    case "3":
                        scheduler.DisplayTasks();
                        break;

                    case "4":
                        Console.WriteLine("Вихід із програми.");
                        return;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
