using System;
using YashinLib;

/* Владимир Яшин
 * 7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b);
 * б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
*/

namespace Quest7
{
    class Quest7
    {
        static void ShowNumbersTo(int a, int b)
        {
            if (a <= b)
            {
                Console.WriteLine($"{a}");
                ShowNumbersTo(a + 1, b);
            }
        }

        static void SumTo(int a, int b, int sum = 0)
        {
            if (a <= b)
            {
                sum += a;
                SumTo(a + 1, b, sum);
            }
            else Console.WriteLine($"Сумма всех чисел от A до B: {sum}");
        }

        static void Main(string[] args)
        {
            int a = Con.AskForInt("A");
            Con.Print("Число B должно быть больше А для корректной работы программы", ConsoleColor.Gray);
            int b = Con.AskForInt("B");

            Con.Print("1 - Вывести на экран числа от A до B\n2 - Посчитать сумму чисел от A до B", ConsoleColor.Blue);
            int action = Con.AskForInt("Выполнить", ConsoleColor.Blue);

            if (action == 1) ShowNumbersTo(a, b);
            else if (action == 2) SumTo(a, b);

            Con.Pause();
        }
    }
}
