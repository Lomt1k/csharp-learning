using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Данная работа - результат первичного знакомства с Linq
 * Есть несколько игроков - сортируем их по количеству игровых денег, по уровню прокачки и тд
 * Обучался по видеоролику https://youtu.be/gF4X3yr0nsA
 */

namespace LinqExample
{
    class Program
    {
        static List<Player> players;
        static List<Player> showedPlayers;

        static void Main(string[] args)
        {
            players = new List<Player>();
            //Создаем список игроков и заполняем его данными
            players.Add(new Player("Vladimir Yashin", 2236, 0, 100500));
            players.Add(new Player("Newbie"));
            players.Add(new Player("Professional", 100, 8540, 32800));
            players.Add(new Player("Kojima", 40, 7340, 8745370));
            players.Add(new Player("Todd Howard", 100, 12400, 74500));
            players.Add(new Player("Sid Meier", 75, 220, 16500));
            players.Add(new Player("Eric Barone", 28, 7770, 500000));

            showedPlayers = players;
            while (true)
            {
                ShowPlayers(showedPlayers);
                ShowMenu();
            }
            
        }

        /// <summary>
        /// Метод для вывода списка игроков на экран
        /// </summary>
        /// <param name="_players"></param>
        static void ShowPlayers(List<Player> _players)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{"Игрок", -24} {"Уровень", -12} {"XP", -12} {"Деньги", -12}");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var e in _players)
            {
                Console.WriteLine($"{e.Name, -24} {e.Level, -12} {e.XP, -12} {e.Cash + "$", -12}");
            }            
        }

        /// <summary>
        /// Отображает меню и вызывает действие, выбранное игроком
        /// </summary>
        static void ShowMenu()
        {
            //отображаем меню
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\nВыберите действие: \n");
            Console.WriteLine("1 - Отобразить всех игроков по алфавиту");
            Console.WriteLine("2 - Отобразить всех игроков по рейтингу богатства");
            Console.WriteLine("3 - Отобразить всех игроков уровню прокачки (уровень + xp)");
            Console.WriteLine("4 - Отобразить TOP 5 самых богатых игроков");
            Console.WriteLine("5 - Отобразить только игроков 50+ уровня");
            Console.WriteLine();

            //получаем ответ от игрока
            int entered;
            do
            {
                Console.Write("Введите число: ");
                int.TryParse(Console.ReadLine(), out entered);
            } while (entered < 1 || entered > 5);

            //выполняем нужное действие
            Console.Clear();
            switch (entered)
            {
                case 1: //отобразить по алфавиту
                    showedPlayers = players.OrderBy(x => x.Name).ToList();
                    break;
                case 2: //сортировать по богатству
                    showedPlayers = players.OrderByDescending(x => x.Cash).ToList();
                    break;
                case 3: //сортировать по уровню прокачки
                    showedPlayers = players.OrderByDescending(x => x.Level).ThenByDescending(x => x.XP).ToList();
                    break;
                case 4: //TOP 5 самых богатых игроков
                    showedPlayers = players.OrderByDescending(x => x.Cash).Take(5).ToList();
                    break;
                case 5: //Игроки 50+ уровня
                    showedPlayers = players.Where(x => x.Level >= 50).ToList();
                    break;
            }
            
        }
    }
}
