using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    class Player
    {
        string nickname;
        int level;
        int xp;
        int cash;

        /// <summary>
        /// Ник игрока, нельзя изменить
        /// </summary>
        public string Name
        {
            get => nickname;
            private set => nickname = value;
        }

        /// <summary>
        /// Уровень игрока
        /// </summary>
        public int Level => level;

        /// <summary>
        /// Количество опыта, набранного на текущем уровне
        /// </summary>
        public int XP => xp;

        /// <summary>
        /// Сумма денег, которые имеются у игрока
        /// </summary>
        public int Cash => cash;

        /// <summary>
        /// Конструктор, ник игрока обязателен к указанию
        /// </summary>
        /// <param name="_name">Игровой ник</param>
        /// <param name="_level">Уровень</param>
        /// <param name="_xp">Опыт, набранный на этом уровне</param>
        /// <param name="_cash">Деньги</param>
        public Player(string _name, int _level = 1, int _xp = 0, int _cash = 0)
        {
            nickname = _name;
            level = _level;
            xp = _xp;
            cash = _cash;
        }

    }
}
