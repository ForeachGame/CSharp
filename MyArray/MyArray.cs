using System;
using System.IO;
using System.Linq;

namespace HomeWorkArray
{
    public class MyArray
    {
        private readonly int[] _array;

        public int this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }
        
        /// <summary>
        /// Создать свойство Sum, которое возвращает сумму элементов массива
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (int item in _array)
                {
                    sum += item;
                }

                return sum;
            }
        }
        
        /// <summary>
        /// Cвойство MaxCount, возвращающее количество максимальных элементов.
        /// </summary>
        public int MaxCount
        {
            get
            {
                return _array.Count(item => item == _array.Max());
            }
        }

        public int Max => _array.Max();

        public MyArray(int[] array)
        {
            _array = array;
        }

        public MyArray(int size)
        {
            Random random = new Random();
            _array = new int[size];
            for (int i = 0; i < size; i++)
            {
                _array[i] = random.Next(-99, 100);
            }
        }

        public MyArray(string fileName)
        {
            _array = LoadArrayFromFile(fileName);
        }
        
        /// <summary>
        /// Реализовать конструктор, создающий массив определенного размера
        /// и заполняющий массив числами от начального значения с заданным шагом.
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <param name="start">Стартовое значение</param>
        /// <param name="step">Шаг</param>
        public MyArray(int size, int start, int step)
        {
            _array = new int[size];
            for (int i = 0; i < _array.Length; i++)
            {
                if (i == 0) _array[i] = start;
                else _array[i] = start *= step;
            }
        }

        public void PrintArray()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write($"{_array[i]}\t");
            }
            Console.WriteLine();
        }

        private int[] LoadArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                //StreamWriter
                //    WriteLine
                StreamReader streamReader = new StreamReader(fileName);
                int[] buf = new int[1000];
                int count = 0;
                //streamReader.ReadLine();
                //streamReader.EndOfStream
                while (!streamReader.EndOfStream)
                {
                    buf[count] = int.Parse(streamReader.ReadLine() ?? throw new InvalidOperationException());
                    count++;
                }

                int[] arr = new int[count];
                Array.Copy(buf, arr, count);
                streamReader.Close();
                return arr;

            }
            throw new FileNotFoundException();
        }
        
        /// <summary>
        /// Метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива
        /// (старый массив, остается без изменений)
        /// </summary>
        /// <returns></returns>
        public int[] Inverse()
        {
            int[] newArray = new int[_array.Length];

            for (int i = 0; i < _array.Length; i++)
            {
                newArray[i] = -_array[i];
            }

            return newArray;
        }
        
        /// <summary>
        /// Метод Multi, умножающий каждый элемент массива на определённое число.
        /// </summary>
        /// <param name="number"></param>
        public void Multi(int number)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] *= number;
            }
        }
    }
}