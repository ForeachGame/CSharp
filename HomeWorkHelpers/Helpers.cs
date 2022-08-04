﻿using System;
using System.Diagnostics;

namespace HomeWorkHelpers
{
    public class Helpers
    {
        public static void PrintStudentInfo(int homeworkNumber)
        {
            Console.WriteLine($"Домашняя работа. Урок: {homeworkNumber}");
            Console.WriteLine("Автор: Черемисинов Александр");
            Console.WriteLine("=======================================");
        }

        public static void CloseProgram()
        {
            Process.GetCurrentProcess().Kill();
        }
        
        public static string[] AddStrToArray(string[] array, string str)
        {
            string[] newArray = new string[array.Length + 1];
            for(int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[array.Length] = str;
            return newArray;
        }
        
        public static string ConsoleDataInput(string title)
        {
            Console.Write(title);
            return Console.ReadLine();
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void Pause()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadLine();
        }

        public static void Spacer()
        {
            Console.WriteLine("================================");
        }
    }
}