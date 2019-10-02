using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ColoredTableGenerator2
{
    static class Program
    {
        static Random rand;  

        public static int count; //счетчик слова - цвета (20 всего)
        public static int[] labelTextID;
        public static int[] labelColorID;

        public static string[] colorNames;
        public static Color[] colors;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            rand = new Random();
            labelTextID = new int[21];
            labelColorID = new int[21];

            colorNames = new string[]
            {
                "КРАСНЫЙ",
                "СИНИЙ",
                "ЗЕЛЕНЫЙ",
                "ЖЕЛТЫЙ",
                "ЧЕРНЫЙ"
            };
            colors = new Color[]
            {
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Gold,
                Color.Black
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //получаем случайное название цвета( "красный", "синий", "зеленый", "желтый", "черный")
        public static string GetRandomColorText()
        {
            count++;
              labelTextID[count] = labelTextID[count - 1];
            while (labelTextID[count] == labelTextID[count - 1] || (count > 4 && labelTextID[count] == labelTextID[count - 4]) ) labelTextID[count] = rand.Next(5); //исключаем появление одного и того же цвета два раза подряд

            int val = labelTextID[count];            
            return colorNames[val];
        }

        //получаем случайный цвет
        public static Color GetRandomColor()
        {
            labelColorID[count] = labelColorID[count - 1];
            while (labelColorID[count] == labelColorID[count - 1] || labelColorID[count] == labelTextID[count] || (count > 4 && labelColorID[count] == labelColorID[count - 4]) ) labelColorID[count] = rand.Next(5); //исключаем появление одного и того же цвета два раза подряд, а также исключаем чтобы название цвета совпадало с реальным цветом

            int val = labelColorID[count];
            return colors[val];
        }
    }
}
