using System;
using YashinLib;

/* Владимир Яшин
 * 2. Написать метод подсчета количества цифр числа.
 * */

namespace Quest2
{
    class Quest2
    {
        static void Main(string[] args)
        {
            int number = Con.AskForInt("Число");
            int count = 1;
            while (number / 10 > 0)
            {
                number /= 10;
                count++;
            }

            string str = String.Format($"\nЦифр в числе: {count}");
            Con.Print(str, ConsoleColor.Yellow);
            Con.Pause();
        }
    }
}
