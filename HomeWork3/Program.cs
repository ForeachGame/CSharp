using System;
using HomeWorkHelpers;

namespace HomeWork3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Helpers.MainScreen(3);

                string[] tasks =
                {
                    "Структура Complex",
                    "Класс ComplexClass",
                    "Числа TryParse"
                };
                
                int number = ConsoleMenu.Select(0, 3, tasks);
                if (number == tasks.Length) Helpers.CloseProgram();
                
                Console.CursorVisible = true;
                Helpers.Clear();
                switch (number)
                {
                    case 0:
                        Task1();
                        break;
                    case 1:
                        Task2();
                        break;
                    case 2:
                        Task3();
                        break;
                }
                Helpers.Pause();
            }
        }

        private static void Task1()
        {
            Helpers.Header("Демонстрация работы структуры");
            double number1, number2, number3, number4;
            Complex result = new Complex();
            string operation;

            Helpers.CheckParse(out number1,"Действительная часть первого комплексного числа: ");
            Helpers.CheckParse(out number2,"Мнимая часть первого комплексного числа: ");
            
            Helpers.CheckParse(out number3,"Действительная часть второго комплексного числа: ");
            Helpers.CheckParse(out number4,"Мнимая часть второго комплексного числа: ");

            Complex complex1 = new Complex();
            complex1.re = number1;
            complex1.im = number2;
            
            Complex complex2 = new Complex();
            complex2.re = number3;
            complex2.im = number4;

            string[] methods =
            {
                "Сложить",
                "Вычесть"
            };
            
            Console.CursorVisible = false;
            int menu = ConsoleMenu.Select(0, 7, methods);
            if (menu == methods.Length) Helpers.CloseProgram();
            
            Helpers.Clear();
            switch (menu)
            {
                case 0:
                    result = Complex.Plus(complex1, complex2);
                    operation = "сложения";
                    break;
                case 1:
                    result = Complex.Minus(complex1, complex2);
                    operation = "вычитания";
                    break;
                default:
                    result = Complex.Plus(complex1, complex2);
                    operation = "сложения";
                    break;
            }
            
            Console.WriteLine($"Результат {operation} комлексных чисел: {result}");
        }
        private static void Task2()
        {
            Helpers.Header("Демонстрация работы класса");
            double number1, number2, number3, number4;
            ComplexClass result = new ComplexClass();
            string operation;

            Helpers.CheckParse(out number1,"Действительная часть первого комплексного числа: ");
            Helpers.CheckParse(out number2,"Мнимая часть первого комплексного числа: ");
            
            Helpers.CheckParse(out number3,"Действительная часть второго комплексного числа: ");
            Helpers.CheckParse(out number4,"Мнимая часть второго комплексного числа: ");

            ComplexClass complex1 = new ComplexClass(number1, number2);
            ComplexClass complex2 = new ComplexClass(number3, number4);

            string[] methods =
            {
                "Сложить",
                "Вычесть",
                "Умножить"
            };
            
            Console.CursorVisible = false;
            int menu = ConsoleMenu.Select(0, 7, methods);
            if (menu == methods.Length) Helpers.CloseProgram();
            
            Helpers.Clear();
            switch (menu)
            {
                case 0:
                    result = ComplexClass.Plus(complex1, complex2);
                    operation = "сложения";
                    break;
                case 1:
                    result = ComplexClass.Minus(complex1, complex2);
                    operation = "вычитания";
                    break;
                case 2:
                    result = ComplexClass.Multiplication(complex1, complex2);
                    operation = "умножения";
                    break;
                default:
                    result = ComplexClass.Plus(complex1, complex2);
                    operation = "сложения";
                    break;
            }
            
            Console.WriteLine($"Результат {operation} комлексных чисел: {result}");
        }
        private static void Task3()
        {
            Helpers.Header("Числа TryParse");
            
            double sum = 0;
            
            while (true)
            {
                double number;
                Helpers.CheckParse(out number,"Введите число: ");
                if (number == 0) break;
                if (number % 2 != 0 && number > 0) sum += number;
            }
            
            Console.WriteLine($"Сумма введённых нечётных положительных чисел: {sum}");
        }
    }
}