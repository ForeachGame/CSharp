using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using HomeWorkHelpers;

namespace HomeWork6
{
    internal class Program
    {
        
        // Описываем делегат. В делегате описывается сигнатура методов, на
        // которые он сможет ссылаться в дальнейшем (хранить в себе)
        public delegate double Fun(double x);
        public delegate double Fun2(double x, double b);

        public static void Main(string[] args)
        {
            while (true)
            {
                string[] tasks =
                {
                    "Задание 1",
                    "Задание 2"
                };
                
                int number = Helpers.StartProgram(5, tasks);
                
                switch (number)
                {
                    case 0:
                        Task1();
                        break;
                    case 1:
                        Task2();
                        break;
                }
                Helpers.Pause();
            }
        }

        #region Task1

        private static void Task1()
        {
            /*
             * 1. Изменить программу вывода таблицы функции так,
             * чтобы можно было передавать функции типа double (double, double).
             * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
             */
            
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc),-2,2);
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.
            
            Table(MyFunc, -2, 2);
            Console.WriteLine("Таблица функции Sin:");
            Table(Math.Sin, -2, 2); // Можно передавать уже созданные методы
            Console.WriteLine("Таблица функции x^2:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(delegate (double x) { return x * x; }, 0, 3);
            
            // Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
            Console.WriteLine("Таблица функции a*x^2:");
            Table((x, b) => b * (x * x), 1, 4);
            
            Console.WriteLine("Таблица функции a*sin(x):");
            Table((x, b) => b * Math.Sin(x), 1, 4);

        }
        
        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        public static void Table(Fun2 F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, b));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x)
        {
            return x * x * x;
        }

        #endregion

        #region Task2

        public delegate double Task2Delegate(double x);
        
        private static void Task2()
        {
            /*
             * 2. Модифицировать программу нахождения минимума функции так, чтобы можно было
             * передавать функцию в виде делегата.
             * а) Сделать меню с различными функциями и представить пользователю выбор,
             * для какой функции и на каком отрезке находить минимум. Использовать массив (или список) делегатов,
             * в котором хранятся различные функции.
             * б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.
             * Пусть она возвращает минимум через параметр (с использованием модификатора out).
             */
            
            Helpers.Header("Выберите функцию: ");
            string[] func =
            {
                "f(x)=y^2",
                "f(x)=y^3",
                "f(x)=y^1/2",
                "f(x)=Sin(y)",
                "f(x)=Cos(y)"
            };
            
            Console.CursorVisible = false;
            int menu = ConsoleMenu.Select(0, 3, func);
            if (menu == func.Length) Helpers.CloseProgram();
            List<Task2Delegate> functions = new List<Task2Delegate>
            {
                new Task2Delegate(Squaring),
                new Task2Delegate(Cube), 
                new Task2Delegate(ExtractingSquareRoot), 
                new Task2Delegate(Sin), 
                new Task2Delegate(Cos)
            };
            Helpers.Clear();

            Console.WriteLine("Поиск минимума на отрезке");

            double a, b, h;
            
            Helpers.CheckParse(out a,"Начало отрезка: ");
            Helpers.CheckParse(out b,"Конец отрезка: ");
            Helpers.CheckParse(out h,"Величина шага: ");

            SaveFunc("data.bin", a, b, h, functions[menu]);
            double min = double.MaxValue;

            Console.WriteLine("Результат работы функции: ");
            PrintTable(a, b, h, Load("data.bin", out min));
            Console.WriteLine("Минимальное значение функции: {0:0.00}", min );
        }
        
        public static void SaveFunc(string fileName, double a, double b, double h, Task2Delegate F)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            
            while (a <= b)
            {
                bw.Write(F(a));
                a += h;
            }
            bw.Close();
            fs.Close();
        }
        
        static void PrintTable(double a, double b, double h, double[] values)
        {
            Console.WriteLine("------- A -------- B -------- H --------");
            int index = 0;
            while (a <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000}", a, b, values[index]);
                a += h;
                index++;
            }
            Console.WriteLine("------------------------------------");
        }
        
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double[] array = new double[fs.Length / sizeof(double)];
            min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                array[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return array;
        }
        
        static double Squaring(double x)
        {
            return x * x;
        }
        
        static double Cube(double x)
        {
            return x * x * x;
         
        }

        static double ExtractingSquareRoot(double x)
        {
            return Math.Sqrt(x);
        }

        static double Sin(double x)
        {
            return Math.Sin(x);
        }

        static double Cos(double x)
        {
            return Math.Cos(x);
        }

        #endregion
        
    }
}