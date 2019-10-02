using System;
using YashinLib;

/* Владимир Яшин 6. 
 * *Написать программу подсчета количества “Хороших” чисел в диапазоне от 1 до 1 000 000 000. 
 * Хорошим называется число, которое делится на сумму своих цифр. Реализовать подсчет времени
 * выполнения программы, используя структуру DateTime.
 * */

namespace Quest6
{
    class Quest6
    {
        static void Main(string[] args)
        {
            const int finalnumber = 1000000000; //Число, на котором заканчивается выполнение программы
            int onePercent = finalnumber / 100;

            int goodNumbersCount = 0;
            Con.Print("Программа выполняется. Пожалуйста, подождите... 0%", ConsoleColor.Blue);
            DateTime dt1 = DateTime.Now;

            for (int i = 1; i <= finalnumber; i++)
            {
                string numb = Convert.ToString(i);
                int sumOfThisNumber = 0;
                for (int j = 0; j < numb.Length; j++)
                {
                    sumOfThisNumber += Convert.ToInt32(numb[j]);
                }
                if (i % sumOfThisNumber == 0) goodNumbersCount++;

                //Процент выполнения программы
                if (i % onePercent == 0)
                {
                    Console.Clear();
                    string progess = string.Format($"Программа выполняется. Пожалуйста, подождите... {i / onePercent}%");
                    Con.Print(progess, ConsoleColor.Blue);
                }
            }

            Console.Clear();
            string str = String.Format($"Хороших чисел от 1 до {finalnumber}: {goodNumbersCount}");
            Con.Print(str, ConsoleColor.Blue);

            DateTime dt2 = DateTime.Now;
            string str2 = String.Format($"Время выполнения программы {dt2-dt1}");
            Con.Print(str2, ConsoleColor.Blue);
            Con.Pause();
        }
    }
}
