using System;
using System.Text;
using YashinLib;

/* 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать.
 * а) с использованием методов C#
 * б) *разработав собственный алгоритм
 * Например: badc являются перестановкой abcd
 */

namespace Quest3
{
    class Quest3
    {
        public static bool IsReshuffle(string str1, string str2)
        {
            if (str1.Length != str2.Length || str1 == str2) return false; //это не перестановка если количество символов различается или если строки полностью идентичны

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str1.Length; i++)
            {
                bool founded = false;
                for (int j = 0; j < sb.Length; j++)
                {
                    if (sb[j] == str1[i])
                    {
                        founded = true;
                    }
                }
                if (!founded) sb.Append(str1[i]);
            }
            //Теперь sb у нас хранит список всех символов (если в str1 символ 'А' встречается 8 раз, то в sb - только один раз
            //Далее сравниваем две строки чтобы убедиться, что все символы (например 'А') встречаются равное количество раз
            for (int c = 0; c < sb.Length; c++)
            {
                int str1Count = 0, str2Count = 0;
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] == sb[c]) str1Count++;
                    if (str2[i] == sb[c]) str2Count++;
                }                
                if (str1Count != str2Count) return false; //Один и тотже символ встречается в двух строках разное кол-во раз - значит НЕ перестановка
            }
            return true;//все символы, хоть и находятся в разных местах, встречаются одинаковое число раз в обоих строках - значит ПЕРЕСТАНОВКА (длина у строк одинаковая)      
        }

        static void Main(string[] args)
        {
            while(true)
            {
                string str1 = Con.AskFor("Строка 1");
                string str2 = Con.AskFor("Строка 2");
                if (IsReshuffle(str1, str2)) Con.Print("Это перестановка!\n", ConsoleColor.Blue);
                else Con.Print("Это НЕ перестановка!\n", ConsoleColor.Red);
            }            
        }
    }
}
