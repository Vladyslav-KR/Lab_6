using System;
using System.Collections.Generic;
using GenericRepository;

namespace RepositoryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Для підтримки кирилиці
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Репозиторій для зберігання чисел
            var numberRepository = new Repository<int>();
            numberRepository.Add(1);
            numberRepository.Add(2);
            numberRepository.Add(3);
            numberRepository.Add(4);
            numberRepository.Add(5);

            // Пошук чисел, які більше 3
            Criteria<int> greaterThanThree = x => x > 3;
            var filteredNumbers = numberRepository.Find(greaterThanThree);

            Console.WriteLine("Числа більше 3:");
            foreach (var number in filteredNumbers)
            {
                Console.WriteLine(number);
            }

            // Репозиторій для зберігання рядків
            var stringRepository = new Repository<string>();
            stringRepository.Add("Київ");
            stringRepository.Add("Львів");
            stringRepository.Add("Одеса");
            stringRepository.Add("Харків");

            // Пошук міст, назва яких починається з "Л"
            Criteria<string> startsWithL = s => s.StartsWith("Л");
            var filteredStrings = stringRepository.Find(startsWithL);

            Console.WriteLine("\nМіста, які починаються з 'Л':");
            foreach (var city in filteredStrings)
            {
                Console.WriteLine(city);
            }
        }
    }
}
