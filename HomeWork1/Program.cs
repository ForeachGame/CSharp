using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Task1();
            // Task2();
            // Task3();
            Task4();
            Task5();
            Console.ReadLine();
        }

        private static void Task1()
        {
            /*
             1. Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
             В результате вся информация выводится в одну строчку:
                а) используя склеивание;
                б) используя форматированный вывод;
                в) используя вывод со знаком $.
             */
            StartTask("Программа \"Анкета\"");

            string name = ConsoleDataInput("Введите имя:");
            string lastname = ConsoleDataInput("Введите фамилию:");
            int age = int.Parse(ConsoleDataInput("Введите возраст:"));
            int height = int.Parse(ConsoleDataInput("Введите рост:"));
            int weight = int.Parse(ConsoleDataInput("Введите вес:"));

            Console.WriteLine("Имя: " + name + "; Фамилия: " + lastname + "; Возраст: " + age + "; Рост: " + 
                              height + "; Вес: " + weight + ";");
            Console.WriteLine("Имя: {0}; Фамилия: {1}; Возраст: {2}; Рост: {3}; Вес: {4};", 
                name, lastname, age, height, weight);
            Console.WriteLine($"Имя: {name}; Фамилия: {lastname}; Возраст: {age}; Рост: {height}; Вес: {weight};");
        }

        private static void Task2()
        {
            /*
             2. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
             где m — масса тела в килограммах, h — рост в метрах.
             */

            StartTask("Программа \"Индекс Массы Тела\"");

            float weight = float.Parse(ConsoleDataInput("Введите массу тела в килограммах:"));
            float height = float.Parse(ConsoleDataInput("Введите рост в метрах:"));

            float result = weight / (height * height);
            Console.WriteLine($"Индекс массы тела: {Math.Round(result, 2)};");
        }

        private static void Task3()
        {
            /*
             3.
                а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
                по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор 
                формата .2f (с двумя знаками после запятой);
                б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
             */
            
            StartTask("Программа \"Расстояние между точками координат\"");

            double x1 = Double.Parse(ConsoleDataInput("Введите координату x1:"));
            double y1 = Double.Parse(ConsoleDataInput("Введите координату y1:"));
            double x2 = Double.Parse(ConsoleDataInput("Введите координату x2:"));
            double y2 = Double.Parse(ConsoleDataInput("Введите координату y2:"));
            
            Double result = CoordResult(x1, y1, x2, y2);
            Console.WriteLine($"Расстояние между точками координат: {result:f2}");
        }

        private static void Task4()
        {
            /*
             4. Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
                а) с использованием третьей переменной;
                б) *без использования третьей переменной.
             */

            int a = 1;
            int b = 2;
            Console.WriteLine($"Значение переменных: a: {a}, b: {b}");

            int c = a; 
            a = b;
            b = c;
            Console.WriteLine($"Изменённое значение переменных: a: {a}, b: {b}");
            
            (a, b) = (b, a);
            Console.WriteLine($"Изменённое значение переменных: a: {a}, b: {b}");
        }

        private static void Task5()
        {
            /*
             5.
                а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
                б) Сделать задание, только вывод организовать в центре экрана.
                в) *Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).
             */
        }

        private static void StartTask(string taskTitle)
        {
            Console.WriteLine(taskTitle);
        }

        private static string ConsoleDataInput(string title)
        {
            Console.WriteLine(title);
            return Console.ReadLine();
        }

        private static double CoordResult(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
