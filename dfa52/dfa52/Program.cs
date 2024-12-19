using System;
using System.Collections.Generic;

namespace ConsoleApp13
{
    class MyHashTable<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _hashTable;

        public MyHashTable()
        {
            _hashTable = new Dictionary<TKey, TValue>();
        }

        // 1. Метод возвращает все ключи из хеш-таблицы
        public IEnumerable<TKey> GetAllKeys()
        {
            return _hashTable.Keys;
        }

        // 2. Метод возвращает количество элементов в хеш-таблице
        public int GetCount()
        {
            return _hashTable.Count;
        }

        // 3. Метод проверяет, существует ли ключ в хеш-таблице
        public bool ContainsKey(TKey key)
        {
            return _hashTable.ContainsKey(key);
        }

        // 4. Метод очищает все элементы из хеш-таблицы
        public void ClearTable()
        {
            _hashTable.Clear();
        }

        // 5. Метод возвращает все значения из хеш-таблицы
        public IEnumerable<TValue> GetAllValues()
        {
            return _hashTable.Values;
        }

        // Дополнительный метод: Добавление элементов
        public void Add(TKey key, TValue value)
        {
            if (!_hashTable.ContainsKey(key))
            {
                _hashTable.Add(key, value);
            }
            else
            {
                Console.WriteLine("Key already exists.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyHashTable<string, int> myHashTable = new MyHashTable<string, int>();
            myHashTable.Add("One", 1);
            myHashTable.Add("Two", 2);
            myHashTable.Add("Three", 3);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nВыберите задание:");
                Console.WriteLine("1 - Получить все ключи");
                Console.WriteLine("2 - Получить количество элементов");
                Console.WriteLine("3 - Проверить существование ключа");
                Console.WriteLine("4 - Очистить хеш-таблицу");
                Console.WriteLine("5 - Получить все значения");
                Console.WriteLine("0 - Выйти");

                Console.Write("\nВведите номер задания: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Все ключи:");
                        foreach (var key in myHashTable.GetAllKeys())
                        {
                            Console.WriteLine(key);
                        }
                        break;

                    case "2":
                        Console.WriteLine($"Количество элементов: {myHashTable.GetCount()}");
                        break;

                    case "3":
                        Console.Write("Введите ключ для проверки: ");
                        string keyToCheck = Console.ReadLine();
                        Console.WriteLine(myHashTable.ContainsKey(keyToCheck)
                            ? "Ключ существует в хеш-таблице."
                            : "Ключ не найден.");
                        break;

                    case "4":
                        myHashTable.ClearTable();
                        Console.WriteLine("Хеш-таблица очищена.");
                        break;

                    case "5":
                        Console.WriteLine("Все значения:");
                        foreach (var value in myHashTable.GetAllValues())
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine("Выход из программы.");
                        break;

                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
