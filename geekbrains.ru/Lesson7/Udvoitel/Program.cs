using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Udvoitel
{
	//Владимир Яшин
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Game.Launch();
        }
    }
}
