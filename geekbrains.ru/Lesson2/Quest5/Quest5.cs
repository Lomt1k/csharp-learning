using System;
using YashinLib;

/* Владимир Яшин 5. 
 * а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;\
 * б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
*/

namespace Quest5
{
    class Quest5
    {
        const double minBMI = 18.5;
        const double maxBMI = 24.99;

        static void Main(string[] args)
        {
            double mass = Con.AskForDouble("Вес (кг)");
            double height = Con.AskForDouble("Рост (см)") / 100;
            double i = mass / (height * height);

            string str = String.Format($"\nВаш ИМТ: {i:F1}");
            Con.Print(str, ConsoleColor.Yellow);

            if (i < minBMI)
            {//дефицит
                double deltaBMI = minBMI - i;
                double needMass = deltaBMI * height * height;
                string bmiInfo = String.Format($"У вас дефицит массы тела. Рекомендуем набрать еще {needMass:F1} кг");
                Con.Print(bmiInfo, ConsoleColor.Yellow);
            }//дефицит
            else if (i > maxBMI)
            {//избыток
                double deltaBMI = i - maxBMI;
                double needMass = deltaBMI * height * height;
                string bmiInfo = String.Format($"У вас избыточная масса тела. Рекомендуем сбросить еще {needMass:F1} кг");
                Con.Print(bmiInfo, ConsoleColor.Yellow);
            }//избыток
            else Con.Print("Ваш вес в пределах нормы. Вы красавчик! ;)", ConsoleColor.Yellow);

            Con.Pause();
        }
    }
}
