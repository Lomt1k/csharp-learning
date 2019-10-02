using System;
using Yashin;

namespace Yashin
{
    class Con
    {
        public static void Print(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White; //возвращаем консоли изначальный белый цвет
        }

        public static void Pause()
        {
            Console.ReadKey();
        }

        public static string AskFor(string text, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.Write(text + ": ");
            Console.ForegroundColor = ConsoleColor.White; //возвращаем консоли изначальный белый цвет
            return Console.ReadLine();
        }
        public static int AskForInt(string text, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.Write(text + ": ");
            Console.ForegroundColor = ConsoleColor.White; //возвращаем консоли изначальный белый цвет
            return Convert.ToInt32(Console.ReadLine());
        }
        public static double AskForDouble(string text, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.Write(text + ": ");
            Console.ForegroundColor = ConsoleColor.White; //возвращаем консоли изначальный белый цвет
            return Convert.ToDouble(Console.ReadLine());
        }
    }
}

/* 5. 
а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
б) Сделать задание, только вывод организуйте в центре экрана
в) *Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y) 

PS: Задание 6 было выполненио в первую очередь и методы используются во всех заданиях
6. *Создать класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).
*/

namespace Quest5
{
    class Quest5
    {
        static void Main(string[] args)
        {
            Con.Print("Владимир Яшин, г. Омск", ConsoleColor.Blue);
            Con.Pause();
        }
    }
}
