using System;
using YashinLib;

/* Владимир Яшин
 * 4. Реализовать метод проверки логина и пароля.На вход подается логин и пароль.
 * На выходе истина, если прошел авторизацию, и ложь, если не прошел(Логин:root, Password:GeekBrains). 
 * Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
 * программа пропускает его дальше или не пропускает.С помощью цикла do while ограничить ввод пароля тремя попытками.
 * */

namespace Quest4
{
    class Quest4
    {
        const string realLogin = "root";
        const string realPass = "GeekBrains";

        static bool TryToLogin(string login, string pass)
        {
            if (login == realLogin && pass == realPass)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            
            int count = 3;
            bool logged = false;

            do
            {
                string login = Con.AskFor("Login");
                string pass = Con.AskFor("Password");
                if (TryToLogin(login, pass) == true)
                {
                    logged = true;
                    Con.Print("\nВы вошли в систему", ConsoleColor.Yellow);
                }
                else
                {
                    count--;
                    string str = String.Format("Неверный логин или пароль. Осталось попыток: {0}", count);
                    Con.Print(str, ConsoleColor.Red);
                }                
            }
            while (logged == false && count > 0);
            
            Con.Pause();
        }
    }
}
