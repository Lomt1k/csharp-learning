using System;
using YashinLib;

/* Владимир Яшин
 * Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. 
 * Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, 
 * демонстрирующую все разработанные элементы класса. * Добавить упрощение дробей.
 */


namespace Quest3
{
    class Fraction //класс дробей
    {
        public int Uper = 0, Lower = 0;
        public Fraction(int up, int low) //объявление дроби
        {
            Uper = up;
            Lower = low;
        }
        public Fraction() { } //объявление дроби без присваивания значений

        public string ShowString() //для отображения дроби в консоли
        {
            if (Uper % Lower == 0)
            {
                string str = string.Format("{0}", Uper / Lower);
                return str;
            }
            else
            {
                string str = string.Format("{0} / {1}", Uper, Lower);
                return str;
            }

        }

        public void Simplify() //упрощение дроби
        {
            int nod = 1;
            do //Находим НОД между числителем и знаменателем и пока он больше 1 - сокращаем дробь на НОД
            {
                int imax = Uper; if (imax < 0) imax = -imax;
                for (int i = 1; i <= imax; i++)
                {
                    if (Uper % i == 0 && Lower % i == 0) nod = i;
                }
                Uper /= nod; Lower /= nod;
            }
            while (nod > 1);
        }

        public void Plus(Fraction f2) //прибавить к этой дроби другую дробь
        {
            if (Lower != f2.Lower)
            {//приводим к общему знаменателю
                int f1mult = f2.Lower, f2mult = Lower; //находим множители для дробей
                Uper *= f1mult; Lower *= f1mult;
                f2.Uper *= f2mult; f2.Lower *= f2mult;
            }//приводим к общему знаменателю
            Uper += f2.Uper;
            Simplify();
        }

        public void Minus(Fraction f2) //отнять от этой дроби другую дробь
        {
            if (Lower != f2.Lower)
            {//приводим к общему знаменателю
                int f1mult = f2.Lower, f2mult = Lower; //находим множители для дробей
                Uper *= f1mult; Lower *= f1mult;
                f2.Uper *= f2mult; f2.Lower *= f2mult;
            }//приводим к общему знаменателю
            Uper -= f2.Uper;
            Simplify();
        }

        public void Mult(Fraction f2) //умножить эту дробь на другую
        {
            Uper *= f2.Uper;
            Lower *= f2.Lower;
            Simplify();
        }

        public void Divide(Fraction f2) //поделить эту дробь на другую
        {
            int delUper = f2.Lower, delLower = f2.Uper; //переворачиваем вторую дробь, затем перемножаем дроби
            Uper *= delUper;
            Lower *= delLower;
            Simplify();
        }
    }

    class Quest3
    {
        static void Main(string[] args)
        {
            int val1 = Con.AskForInt("Введите числитель: ");
            int val2 = Con.AskForInt("Введите знаменатель: ");
            Fraction f1 = new Fraction(val1, val2);

            Console.Clear();
            Console.WriteLine("Вы ввели Дробь 1: {0} \nВведите еще одну и программа отобразит результаты", f1.ShowString());
            val1 = Con.AskForInt("Введите числитель: ");
            val2 = Con.AskForInt("Введите знаменатель: ");
            Fraction f2 = new Fraction(val1, val2);

            Console.Clear();
            Console.WriteLine("Дробь 1: {0}", f1.ShowString());
            Console.WriteLine("Дробь 2: {0}\n", f2.ShowString());

            Fraction fPlus = new Fraction(f1.Uper, f1.Lower);
            fPlus.Plus(f2);
            Console.WriteLine("Дробь 1 + Дробь 2: {0}", fPlus.ShowString());

             Fraction fMinus = new Fraction(f1.Uper, f1.Lower);
            fMinus.Minus(f2);
            Console.WriteLine("Дробь 1 - Дробь 2: {0}", fMinus.ShowString());

             Fraction fMult = new Fraction(f1.Uper, f1.Lower);
            fMult.Mult(f2);
            Console.WriteLine("Дробь 1 * Дробь 2: {0}", fMult.ShowString());

            Fraction fDivide = new Fraction(f1.Uper, f1.Lower);
            fDivide.Divide(f2);
            Console.WriteLine("Дробь 1 / Дробь 2: {0}", fDivide.ShowString());



            Con.Print("\nPS: После каждого арифметического действия итоговая дробь была автомически упрощена", ConsoleColor.Blue);
            Con.Print("Если дробь является челым числом, то она отображается в виде числа (8 / 2 отобразится как число 4)", ConsoleColor.Blue);
            Console.ReadKey();
        }

    }
}
