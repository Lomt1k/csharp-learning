using System;
using YashinLib;

/* Владимир Яшин
 * 1. Написать метод возвращающий минимальное из трех чисел.
 * */

namespace Quest1
{
    class Quest1
    {
        static void Main(string[] args)
        {
            int a = Con.AskForInt("А");
            int b = Con.AskForInt("B");
            int c = Con.AskForInt("C");

            int min = a;
            if (b < min) min = b;
            if (c < min) min = c;
            string str = String.Format($"\nНаименьшее число: {min}");
            Con.Print(str, ConsoleColor.Yellow);
            Con.Pause();
        }
    }
}
