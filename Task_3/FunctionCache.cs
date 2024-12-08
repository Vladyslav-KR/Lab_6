using System;
using System.Collections.Generic;

namespace GenericCache
{
    public class FunctionCache<TKey, TResult>
    {
        
        private class CacheItem
        {
            public TResult Value { get; }
            public DateTime ExpirationTime { get; }

            public CacheItem(TResult value, DateTime expirationTime)
            {
                Value = value;
                ExpirationTime = expirationTime;
            }
        }

        private readonly Dictionary<TKey, CacheItem> _cache;
        private readonly TimeSpan _defaultExpiration;

        // Конструктор із можливістю встановлення часу дії кешу
        public FunctionCache(TimeSpan defaultExpiration)
        {
            _cache = new Dictionary<TKey, CacheItem>();
            _defaultExpiration = defaultExpiration;
        }

        // Метод для отримання значення
        public TResult GetOrAdd(TKey key, Func<TKey, TResult> function)
        {
            // Перевірка, чи є ключ у кеші та чи не закінчився термін дії
            if (_cache.TryGetValue(key, out var cacheItem) && cacheItem.ExpirationTime > DateTime.Now)
            {
                return cacheItem.Value;
            }

            // Виконання функції, якщо значення немає в кеші або термін дії закінчився
            var result = function(key);
            var expirationTime = DateTime.Now + _defaultExpiration;

            _cache[key] = new CacheItem(result, expirationTime);
            return result;
        }

        // Метод для очищення кешу від прострочених елементів
        public void CleanupExpiredItems()
        {
            var keysToRemove = new List<TKey>();

            foreach (var kvp in _cache)
            {
                if (kvp.Value.ExpirationTime <= DateTime.Now)
                {
                    keysToRemove.Add(kvp.Key);
                }
            }

            foreach (var key in keysToRemove)
            {
                _cache.Remove(key);
            }
        }

        // Метод для очищення всього кешу
        public void ClearCache()
        {
            _cache.Clear();
        }
    }
}