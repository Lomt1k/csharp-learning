using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Tzolkin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //при запуске приложения
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            inputYear.Text = DateTime.Now.Year.ToString();
            inputMonth.Text = DateTime.Now.Month.ToString();
            inputDay.Text = DateTime.Now.Day.ToString();
            ButtonConvert_Click(null, null);
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            Help helpWindow = new Help();
            helpWindow.ShowDialog();
            helpWindow.Activate();
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            int year, month, day; 
            Int32.TryParse(inputDay.Text, out day);
            Int32.TryParse(inputMonth.Text, out month);
            Int32.TryParse(inputYear.Text, out year);

            //InfoKIN.Content = $"{day}.{month}.{year}";

            int kin = Converter.GetKin(day, month, year);
            int symID = kin % 20; //номер знака
            if (symID == 0) symID = 20;
            string symName = ""; //название знака
            int tone = kin % 13;
            if (tone == 0) tone = 13;
            
            switch (symID)
            {
                case 1: symName = "ИМИШ"; break;
                case 2: symName = "ИК"; break;
                case 3: symName = "АКБАЛЬ"; break;
                case 4: symName = "КАН"; break;
                case 5: symName = "ЧИКЧАН"; break;
                case 6: symName = "КИМИ"; break;
                case 7: symName = "МАНИК"; break;
                case 8: symName = "ЛАМАТ"; break;
                case 9: symName = "МУЛУК"; break;
                case 10: symName = "ОК"; break;
                case 11: symName = "ЧУЭН"; break;
                case 12: symName = "ЭБ"; break;
                case 13: symName = "БЕН"; break;
                case 14: symName = "ИШ"; break;
                case 15: symName = "МЕН"; break;
                case 16: symName = "КИБ"; break;
                case 17: symName = "КАБАН"; break;
                case 18: symName = "ЭЦНАБ"; break;
                case 19: symName = "КАВАК"; break;
                default: symName = "АХАУ"; break;
            }
            ImageSourceConverter iscon = new ImageSourceConverter();
            InfoImage.Source = (ImageSource)iscon.ConvertFromString($"pack://siteoforigin:,,,/Resources/sym/{symID}.png");
            InfoImageTone.Source = (ImageSource)iscon.ConvertFromString($"pack://siteoforigin:,,,/Resources/tones/{tone}.gif");
            InfoKIN.Content = $"Кин {kin}, {symName} {tone}";

            StreamReader sr = new StreamReader($"Resources/kins/{kin}.txt");
            textBlock.Text = sr.ReadToEnd();
        }


    }
}
