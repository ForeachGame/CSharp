using System;
using HomeWorkHelpers;

namespace HomeWork8._1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Helpers.PrintStudentInfo(8);
            /*
            * С помощью рефлексии выведите все свойства структуры DateTime.
            */
            Console.WriteLine("С помощью рефлексии выведите все свойства структуры DateTime");
            DateTime dateTimeNow = DateTime.Now;
            int i = 1;
            Type type = typeof(DateTime); 
            
            foreach (var propetryInfo in type.GetProperties())
            {
                Console.WriteLine($"{i}. " + propetryInfo.Name + ": " + propetryInfo.GetValue(dateTimeNow));
                i++;
            }
            Console.ReadLine();
        }
    }
}