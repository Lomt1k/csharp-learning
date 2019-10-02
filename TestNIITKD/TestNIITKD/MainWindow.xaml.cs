using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestNIITKD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow instance; //будет хранить в себе экземпляр окна "главное меню"
        static GameWindow gameWindow; 

        /// свойство, через которое можно будет открыть / закрыть главное меню во время игры
        public static MainWindow Instance
        {
            get { return instance; }
        }
        

        public MainWindow()
        {
            InitializeComponent();
            instance = this; //записываем ссылку на экземпляр окна в статическую переменную
        }

        private void ButtonNewGame_Click(object sender, RoutedEventArgs e)
        {            
            instance.Hide();
            if (gameWindow != null) gameWindow.Close(); //если игра уже была запущена - закрываем её перед стартом новой игры (игрок перезапустил игру из меню во время игры)
            gameWindow = new GameWindow();
            gameWindow.ShowDialog();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// когда игрок закрывает окно
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //если игрок закрывает главное меню, то оно пересоздается заново и скрывается (исправляет баг c вылетом приложения при попытке открыть меню после его первого закрытия)
            if (gameWindow != null && gameWindow.IsVisible) 
            {
                instance = new MainWindow();
                instance.Hide();
                return;
            }
            else Environment.Exit(0); //если игрового окна не было, то при закрытии главного меню произойдет закрытие приложения
        }

        //start server
        private void ButtonServer_Click(object sender, RoutedEventArgs e)
        {
            new Server();
        }

        //start client
        private void ButtonClient_Click(object sender, RoutedEventArgs e)
        {
            instance.Hide();
            if (gameWindow != null) gameWindow.Close(); //если игра уже была запущена - закрываем её перед стартом новой игры (игрок перезапустил игру из меню во время игры)
            gameWindow = new GameWindow();
            gameWindow.Show();
            new Client();                     
        }

    }
}
