using System;
using System.Collections.Generic;

namespace GenericRepository
{
    // Делегат для критеріїв
    public delegate bool Criteria<T>(T item);

    // Дженеричний клас Repository
    public class Repository<T>
    {
        private List<T> _items; // Список елементів у репозиторії

        public Repository()
        {
            _items = new List<T>();
        }

        // Метод для додавання елемента в репозиторій
        public void Add(T item)
        {
            _items.Add(item);
        }

        // Метод для видалення елемента
        public void Remove(T item)
        {
            _items.Remove(item);
        }

        // Метод для пошуку елементів за критерієм
        public List<T> Find(Criteria<T> criteria)
        {
            List<T> result = new List<T>();
            foreach (var item in _items)
            {
                if (criteria(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        // Метод для отримання всіх елементів
        public List<T> GetAll()
        {
            return _items;
        }
    }
}
