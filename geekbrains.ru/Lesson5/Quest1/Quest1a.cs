using System;
using YashinLib;

/* Владимир Яшин
 * 1. Создать программу, которая будет проверять корректность ввода логина. 
 * Корректным логином будет строка от 2-х до 10-ти символов, 
 * содержащая только буквы или цифры, и при этом цифра не может быть первой.
 * 
 * а) без использования регулярных выражений;
 * */

namespace Quest1
{
    class Quest1a
    {
        static void Main(string[] args)
        {
            bool allowLogin;
            do
            {
                string str = Con.AskFor("Придумайте логин");
                allowLogin = true;

                if (str.Length < 2 || str.Length > 10)
                {
                    Con.Print("Длина логина должна быть от 2 до 10 символов", ConsoleColor.Red);
                    allowLogin = false;
                }
                else if (char.IsDigit(str[0]))
                {
                    Con.Print("Логин не может начинаться с цифры", ConsoleColor.Red);
                    allowLogin = false;
                }
                else for (int i = 0; i < str.Length; i++) if (!char.IsLetterOrDigit(str[i]))
                {
                    Con.Print("Логин может содержать только буквы и цифры", ConsoleColor.Red);
                    allowLogin = false;
                }
            }
            while (allowLogin == false);

            Con.Print("Поздравляем! Вы ввели корректный логин", ConsoleColor.Blue);
            Con.Pause();
        }
    }
}
