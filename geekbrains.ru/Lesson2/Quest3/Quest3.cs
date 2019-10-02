using System;
using YashinLib;

/* Владимир Яшин
 * С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
 * */

namespace Quest3
{
    class Quest3
    {
        static void Main(string[] args)
        {
            int sum = 0, entered = -1; //че-то не люблю do .. while, решил сделать entered = -1 по умолчанию
            while (entered != 0)
            {
                entered = Con.AskForInt("Введите число");
                if (entered % 2 == 1) sum += entered;
            }            

            string str = String.Format("\nСумма всех нечетных положительных чисел: {0}", sum);
            Con.Print(str, ConsoleColor.Yellow);
            Con.Pause();
        }
    }
}
