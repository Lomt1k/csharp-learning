using System;
using System.Collections.Generic;
using System.Text;

namespace Tzolkin
{
    public static class Converter
    {
        /* Метод для получения кина из даты
         * 11 декабря 2018 = Кин 1 ( _numberOfDay = 737054 )  
         * _numberOfDay 214 также равен Кину 1
         * Ведем отсчет от этой даты
         * */
        public static int GetKin(int _day, int _month, int _year)
        {
            int number = GetNumberOfDay(_day, _month, _year);
            if (number != 260) number %= 260;

            //number 214 = кину 1
            number -= 213; //например, 214 - 213 вернет 1
            if (number < 1) number += 260;

            return number;
        }

        //переводим дату формата dd.mm.yyyy в номер дня формата int
        public static int GetNumberOfDay(int _day, int _month, int _year)
        {
            int value = _day;
            //прибавляем дни за ПОЛНОСТЬЮ ЗАКОНЧЕННЫЕ МЕСЯЦЫ этого года
            switch ( _month - 1 ) 
            {
                case 1: value += 31; break;
                case 2: value += 59; break;
                case 3: value += 90; break;
                case 4: value += 120; break;
                case 5: value += 151; break;
                case 6: value += 181; break;
                case 7: value += 212; break;
                case 8: value += 243; break;
                case 9: value += 273; break;
                case 10: value += 304; break;
                case 11: value += 334; break;
            }
            if (_year % 4 == 0 && _month > 2) value++; //если сейчас високосный год и уже прошел февраль - добавляем високосный день этого года

            int prevYear = _year - 1;
            value += prevYear * 365; //за каждый прошедший год даем по 365 дней
            value += prevYear / 4; //прибавляем дни за прошедшие високосные года

            return value;
        }

    }
}
