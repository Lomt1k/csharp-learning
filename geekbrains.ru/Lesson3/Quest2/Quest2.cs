using System;
using System.Collections.Generic;
using YashinLib;

/* Владимир Яшин
 * 2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечетных положительных чисел. 
 * Сами числа и сумму вывести на экран; Используя tryParse;
б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные. При возникновении ошибки вывести сообщение.

    ВАЖНО: Касательно tryParse и пункта б - я доработал метод Con.AskForInt в библиотеке YashinLib, теперь он соответствует условиям задачи
*/

namespace Quest2
{
    class Quest2
    {
        static void Main(string[] args)
        {
            int entered = -1, sum = 0;
            List<int> goodNumbers = new List<int>();
            Con.Print("Подсказка: Чтобы завершить работу программы, введите '0'");

            while (entered != 0)
            {
                entered = Con.AskForInt("Введите число");
                if (entered % 2 == 1) //нечетное положительное число
                {
                    sum += entered;
                    goodNumbers.Add(entered);
                }
            }

            Con.Print("Нечетные положительные числа: ", ConsoleColor.Yellow);
            for (int i = 0; i < goodNumbers.Count; i++)
            {
                  if (i != goodNumbers.Count - 1) Console.Write(goodNumbers[i] + ", ");
                else Console.WriteLine(goodNumbers[i]);
            }
            string str = String.Format("Сумма всех нечетных положительных чисел: {0}", sum);
            Con.Print(str, ConsoleColor.Yellow);

            Con.Pause();
        }
    }
}
