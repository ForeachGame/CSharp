using System;
using System.Linq;
using HomeWorkHelpers;

namespace HomeWorkHelpers
{
    public class ConsoleMenu
    {
        public static int Select(int x, int y, string[] menu)
        {
            int active = 0;
            bool isShow = true;
            menu = Helpers.AddStrToArray(menu, "Выход");
            Console.WriteLine("Меню");
            while (isShow)
            {
                Draw(x, y, menu, active);
                ConsoleKeyInfo info = Console.ReadKey(true);
                
                switch (info.Key)
                {
                    case ConsoleKey.Enter:
                        isShow = false;
                        break;
                    case ConsoleKey.UpArrow:
                        if (active > 0) active--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (active < menu.Length - 1) active++;
                        break;
                    default:
                        continue;
                }
                
            }
            return active;
        }
        
        static void Draw(int x, int y, string[] menu, int active)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(i + 1 + ". " + menu[i]);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y + active);
            Console.Write(active + 1 + ". " + menu[active]);
            Console.ResetColor();
        }
    }
}