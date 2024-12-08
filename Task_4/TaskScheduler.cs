using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericTaskScheduler
{
    public delegate void TaskExecution<TTask>(TTask task);

    public class TaskScheduler<TTask, TPriority> where TPriority : IComparable<TPriority>
    {
        private readonly SortedDictionary<TPriority, Queue<TTask>> _tasks;

        public TaskScheduler()
        {
            _tasks = new SortedDictionary<TPriority, Queue<TTask>>();
        }

        // Додавання завдання до планувальника
        public void AddTask(TTask task, TPriority priority)
        {
            if (!_tasks.ContainsKey(priority))
            {
                _tasks[priority] = new Queue<TTask>();
            }
            _tasks[priority].Enqueue(task);
        }

        // Виконання наступного завдання з найвищим пріоритетом
        public void ExecuteNext(TaskExecution<TTask> taskExecution)
        {
            if (_tasks.Count == 0)
            {
                Console.WriteLine("Немає завдань для виконання.");
                return;
            }

            // Отримання найвищого пріоритету
            var highestPriority = _tasks.Keys.First();
            var task = _tasks[highestPriority].Dequeue();

            // Видалення черги, якщо вона порожня
            if (_tasks[highestPriority].Count == 0)
            {
                _tasks.Remove(highestPriority);
            }

            // Виконання завдання
            taskExecution(task);
        }

        // Показ всіх завдань у черзі
        public void DisplayTasks()
        {
            if (_tasks.Count == 0)
            {
                Console.WriteLine("Черга завдань порожня.");
                return;
            }

            Console.WriteLine("Поточна черга завдань:");
            foreach (var kvp in _tasks)
            {
                Console.WriteLine($"Пріоритет {kvp.Key}: {string.Join(", ", kvp.Value)}");
            }
        }
    }
}

