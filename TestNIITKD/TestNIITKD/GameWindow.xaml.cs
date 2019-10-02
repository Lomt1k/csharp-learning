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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TestNIITKD
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        static GameWindow instance; //хранит экземпляр игрового окна
        static Inventory inventory; //предполается, что у игрока будет только 1 инвентарь, поэтому также храним ссылку на него в статической переменной

        //XAML элементы инвентаря
        Button[] cell_Buttons;
        Image[] cell_Images;
        Label[] cell_labels;

        Database db; //для работы с SQLite

        //конструктор (выполняется при запуске новой игры)
        public GameWindow()
        {
            InitializeComponent();
            instance = this;

            //--- для удобной работы с инвентарем записываем ссылки на XAML элементы инвентаря в виде массива
            // кнопки
            cell_Buttons = new Button[9];
            cell_Buttons[0] = cell0;
            cell_Buttons[1] = cell1;
            cell_Buttons[2] = cell2;
            cell_Buttons[3] = cell3;
            cell_Buttons[4] = cell4;
            cell_Buttons[5] = cell5;
            cell_Buttons[6] = cell6;
            cell_Buttons[7] = cell7;
            cell_Buttons[8] = cell8;
            // картинки
            cell_Images = new Image[9];
            cell_Images[0] = cell0img;
            cell_Images[1] = cell1img;
            cell_Images[2] = cell2img;
            cell_Images[3] = cell3img;
            cell_Images[4] = cell4img;
            cell_Images[5] = cell5img;
            cell_Images[6] = cell6img;
            cell_Images[7] = cell7img;
            cell_Images[8] = cell8img;
            // текст
            cell_labels = new Label[9];
            cell_labels[0] = cell0label;
            cell_labels[1] = cell1label;
            cell_labels[2] = cell2label;
            cell_labels[3] = cell3label;
            cell_labels[4] = cell4label;
            cell_labels[5] = cell5label;
            cell_labels[6] = cell6label;
            cell_labels[7] = cell7label;
            cell_labels[8] = cell8label;

            // отрисовываем инвентарь пустым по умолнчанию
            for (int i = 0; i < cell_Buttons.Length; i++)
            {
                DrawInventoryCell(i, 0); //0 предметов в ячейке - отображает ячейку пустой
            }

            inventory = new Inventory(); //создаем объект инвентаря
            db = new Database(); //создаем экземляр класса для работы с БД
            db.Connect(); //подключаемся к БД
        }

        #region Свойства

        public static GameWindow Instance
        {
            get { return instance; }
        }

        public Inventory Inventory
        {
            get { return inventory; }
        }

        #endregion

        #region Методы

        //метод для отрисовки ячейки инвентаря (после того, как произвели какие-то изменения в ячейке - вызываем этот метод)
        public void DrawInventoryCell(int cellID, int count, string imageSource = "")
        {
            if (cellID < 0 || cellID > 8) return;
            //количество предметов равно 0 или некорректное значение - нужно отобразить пустую ячейку инвентаря
            if (count < 1)
            {
                cell_Images[cellID].Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, new
                 Action(() =>
                 {
                     cell_Images[cellID].Visibility = Visibility.Hidden;
                     cell_labels[cellID].Visibility = Visibility.Hidden;
                     var bc = new BrushConverter();
                     cell_Buttons[cellID].Background = (Brush)bc.ConvertFrom("#FF1E1E1E");
                     ;
                 }));
            }
            else //корректное количество предметов - нужно отрисовать ячейку инвентаря
            {
                cell_Images[cellID].Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, new
                 Action(() =>
                 {
                     if (imageSource.Length > 0) cell_Images[cellID].Source = new BitmapImage(new Uri(imageSource)); //если был путь к картинке - обновляем её
                    cell_labels[cellID].Content = count.ToString();
                    cell_Images[cellID].Visibility = Visibility.Visible;
                    cell_labels[cellID].Visibility = Visibility.Visible;
                    cell_Buttons[cellID].Background = Brushes.DarkGray;
                     ;
                 }));
            }
        }

        public delegate void DelegateDrawInventoryCell(int cellID, int count, string imageSource = "");


        #endregion

        //нажатие на кнопку "главное меню"
        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Show();
            MainWindow.Instance.Activate();
        }

        //при закрытии игрового окна
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ButtonMenu_Click(null, null);
        }

        //Ячейка инвентаря 0 - нажатие ПКМ
        private void Button_Cell0_RMB(object sender, RoutedEventArgs e)
        {
            inventory.UseItem(0);
        }
        //Ячейка инвентаря 1 - нажатие ПКМ
        private void Button_Cell1_RMB(object sender, RoutedEventArgs e)
        {
            inventory.UseItem(1);
        }
        //Ячейка инвентаря 2 - нажатие ПКМ
        private void Button_Cell2_RMB(object sender, RoutedEventArgs e)
        {
            inventory.UseItem(2);
        }
        //Ячейка инвентаря 3 - нажатие ПКМ
        private void Button_Cell3_RMB(object sender, RoutedEventArgs e)
        {
            inventory.UseItem(3);
        }
        //Ячейка инвентаря 4 - нажатие ПКМ
        private void Button_Cell4_RMB(object sender, RoutedEventArgs e)
        {
            inventory.UseItem(4);
        }
        //Ячейка инвентаря 5 - нажатие ПКМ
        private void Button_Cell5_RMB(object sender, RoutedEventArgs e)
        {
            inventory.UseItem(5);
        }
        //Ячейка инвентаря 6 - нажатие ПКМ
        private void Button_Cell6_RMB(object sender, RoutedEventArgs e)
        {
            inventory.UseItem(6);
        }
        //Ячейка инвентаря 7 - нажатие ПКМ
        private void Button_Cell7_RMB(object sender, RoutedEventArgs e)
        {
            inventory.UseItem(7);
        }
        //Ячейка инвентаря 8 - нажатие ПКМ
        private void Button_Cell8_RMB(object sender, RoutedEventArgs e)
        {
            inventory.UseItem(8);
        }

        //Ячейка инвентаря 0 - нажатие ЛКМ (Перетаскивание предмета | Drag)
        private void cell0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inventory.CellIsEmpty(0)) return; //не запускаем перетаскивание предмета, если ячейка пуста
            DataObject data = new DataObject(typeof(int?), 0); //в качестве данных DragAndDrop передаем ID ячейки инвентаря, из которой начался перенос предмета
            DragDrop.DoDragDrop(cell_Images[0], data, DragDropEffects.All);
        }
        //Ячейка инвентаря 1 - нажатие ЛКМ (Перетаскивание предмета | Drag)
        private void cell1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inventory.CellIsEmpty(1)) return; //не запускаем перетаскивание предмета, если ячейка пуста
            DataObject data = new DataObject(typeof(int?), 1); //в качестве данных DragAndDrop передаем ID ячейки инвентаря, из которой начался перенос предмета
            DragDrop.DoDragDrop(cell_Images[1], data, DragDropEffects.All);
        }
        //Ячейка инвентаря 2 - нажатие ЛКМ (Перетаскивание предмета | Drag)
        private void cell2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inventory.CellIsEmpty(2)) return; //не запускаем перетаскивание предмета, если ячейка пуста
            DataObject data = new DataObject(typeof(int?), 2); //в качестве данных DragAndDrop передаем ID ячейки инвентаря, из которой начался перенос предмета
            DragDrop.DoDragDrop(cell_Images[2], data, DragDropEffects.All);
        }
        //Ячейка инвентаря 3 - нажатие ЛКМ (Перетаскивание предмета | Drag)
        private void cell3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inventory.CellIsEmpty(3)) return; //не запускаем перетаскивание предмета, если ячейка пуста
            DataObject data = new DataObject(typeof(int?), 3); //в качестве данных DragAndDrop передаем ID ячейки инвентаря, из которой начался перенос предмета
            DragDrop.DoDragDrop(cell_Images[3], data, DragDropEffects.All);
        }
        //Ячейка инвентаря 4 - нажатие ЛКМ (Перетаскивание предмета | Drag)
        private void cell4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inventory.CellIsEmpty(4)) return; //не запускаем перетаскивание предмета, если ячейка пуста
            DataObject data = new DataObject(typeof(int?), 4); //в качестве данных DragAndDrop передаем ID ячейки инвентаря, из которой начался перенос предмета
            DragDrop.DoDragDrop(cell_Images[4], data, DragDropEffects.All);
        }
        //Ячейка инвентаря 5 - нажатие ЛКМ (Перетаскивание предмета | Drag)
        private void cell5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inventory.CellIsEmpty(5)) return; //не запускаем перетаскивание предмета, если ячейка пуста
            DataObject data = new DataObject(typeof(int?), 5); //в качестве данных DragAndDrop передаем ID ячейки инвентаря, из которой начался перенос предмета
            DragDrop.DoDragDrop(cell_Images[5], data, DragDropEffects.All);
        }
        //Ячейка инвентаря 6 - нажатие ЛКМ (Перетаскивание предмета | Drag)
        private void cell6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inventory.CellIsEmpty(6)) return; //не запускаем перетаскивание предмета, если ячейка пуста
            DataObject data = new DataObject(typeof(int?), 6); //в качестве данных DragAndDrop передаем ID ячейки инвентаря, из которой начался перенос предмета
            DragDrop.DoDragDrop(cell_Images[6], data, DragDropEffects.All);
        }
        //Ячейка инвентаря 7 - нажатие ЛКМ (Перетаскивание предмета | Drag)
        private void cell7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inventory.CellIsEmpty(7)) return; //не запускаем перетаскивание предмета, если ячейка пуста
            DataObject data = new DataObject(typeof(int?), 7); //в качестве данных DragAndDrop передаем ID ячейки инвентаря, из которой начался перенос предмета
            DragDrop.DoDragDrop(cell_Images[7], data, DragDropEffects.All);
        }
        //Ячейка инвентаря 8 - нажатие ЛКМ (Перетаскивание предмета | Drag)
        private void cell8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inventory.CellIsEmpty(8)) return; //не запускаем перетаскивание предмета, если ячейка пуста
            DataObject data = new DataObject(typeof(int?), 8); //в качестве данных DragAndDrop передаем ID ячейки инвентаря, из которой начался перенос предмета
            DragDrop.DoDragDrop(cell_Images[8], data, DragDropEffects.All);
        }


        //Ячейка инвентаря 0 - Drop (попытка перенести предмет в эту ячейку)
        private void cell0_Drop(object sender, DragEventArgs e)
        {
            //перетаскивание из другой ячейки инвентаря
            if ((e.Data.GetData(typeof(int?)) != null))
            {
                int cellFrom = (int)e.Data.GetData(typeof(int?));
                inventory.TryMoveItem(cellFrom, 0);
            }
            //перетаскивание из источника
            else if ((e.Data.GetData(typeof(Item)) != null)) 
            {
                inventory.TryAddItem( (Item)e.Data.GetData(typeof(Item)), 0 );
            }
        }
        //Ячейка инвентаря 1 - Drop (попытка перенести предмет в эту ячейку)
        private void cell1_Drop(object sender, DragEventArgs e)
        {
            //перетаскивание из другой ячейки инвентаря
            if ((e.Data.GetData(typeof(int?)) != null))
            {
                int cellFrom = (int)e.Data.GetData(typeof(int?));
                inventory.TryMoveItem(cellFrom, 1);
            }
            //перетаскивание из источника
            else if ((e.Data.GetData(typeof(Item)) != null)) 
            {
                inventory.TryAddItem((Item)e.Data.GetData(typeof(Item)), 1);
            }
        }
        //Ячейка инвентаря 2 - Drop (попытка перенести предмет в эту ячейку)
        private void cell2_Drop(object sender, DragEventArgs e)
        {
            //перетаскивание из другой ячейки инвентаря
            if ((e.Data.GetData(typeof(int?)) != null))
            {
                int cellFrom = (int)e.Data.GetData(typeof(int?));
                inventory.TryMoveItem(cellFrom, 2);
            }
            //перетаскивание из источника
            else if ((e.Data.GetData(typeof(Item)) != null)) 
            {
                inventory.TryAddItem((Item)e.Data.GetData(typeof(Item)), 2);
            }
        }
        //Ячейка инвентаря 3 - Drop (попытка перенести предмет в эту ячейку)
        private void cell3_Drop(object sender, DragEventArgs e)
        {
            //перетаскивание из другой ячейки инвентаря
            if ((e.Data.GetData(typeof(int?)) != null))
            {
                int cellFrom = (int)e.Data.GetData(typeof(int?));
                inventory.TryMoveItem(cellFrom, 3);
            }
            //перетаскивание из источника
            else if ((e.Data.GetData(typeof(Item)) != null))
            {
                inventory.TryAddItem((Item)e.Data.GetData(typeof(Item)), 3);
            }
        }
        //Ячейка инвентаря 4 - Drop (попытка перенести предмет в эту ячейку)
        private void cell4_Drop(object sender, DragEventArgs e)
        {
            //перетаскивание из другой ячейки инвентаря
            if ((e.Data.GetData(typeof(int?)) != null))
            {
                int cellFrom = (int)e.Data.GetData(typeof(int?));
                inventory.TryMoveItem(cellFrom, 4);
            }
            //перетаскивание из источника
            else if ((e.Data.GetData(typeof(Item)) != null))
            {
                inventory.TryAddItem((Item)e.Data.GetData(typeof(Item)), 4);
            }
        }
        //Ячейка инвентаря 5 - Drop (попытка перенести предмет в эту ячейку)
        private void cell5_Drop(object sender, DragEventArgs e)
        {
            //перетаскивание из другой ячейки инвентаря
            if ((e.Data.GetData(typeof(int?)) != null))
            {
                int cellFrom = (int)e.Data.GetData(typeof(int?));
                inventory.TryMoveItem(cellFrom, 5);
            }
            //перетаскивание из источника
            else if ((e.Data.GetData(typeof(Item)) != null))
            {
                inventory.TryAddItem((Item)e.Data.GetData(typeof(Item)), 5);
            }
        }
        //Ячейка инвентаря 6 - Drop (попытка перенести предмет в эту ячейку)
        private void cell6_Drop(object sender, DragEventArgs e)
        {
            //перетаскивание из другой ячейки инвентаря
            if ((e.Data.GetData(typeof(int?)) != null))
            {
                int cellFrom = (int)e.Data.GetData(typeof(int?));
                inventory.TryMoveItem(cellFrom, 6);
            }
            //перетаскивание из источника
            else if ((e.Data.GetData(typeof(Item)) != null))
            {
                inventory.TryAddItem((Item)e.Data.GetData(typeof(Item)), 6);
            }
        }
        //Ячейка инвентаря 7 - Drop (попытка перенести предмет в эту ячейку)
        private void cell7_Drop(object sender, DragEventArgs e)
        {
            //перетаскивание из другой ячейки инвентаря
            if ((e.Data.GetData(typeof(int?)) != null))
            {
                int cellFrom = (int)e.Data.GetData(typeof(int?));
                inventory.TryMoveItem(cellFrom, 7);
            }
            //перетаскивание из источника
            else if ((e.Data.GetData(typeof(Item)) != null))
            {
                inventory.TryAddItem((Item)e.Data.GetData(typeof(Item)), 7);
            }
        }
        //Ячейка инвентаря 8 - Drop (попытка перенести предмет в эту ячейку)
        private void cell8_Drop(object sender, DragEventArgs e)
        {
            //перетаскивание из другой ячейки инвентаря
            if ((e.Data.GetData(typeof(int?)) != null))
            {
                int cellFrom = (int)e.Data.GetData(typeof(int?));
                inventory.TryMoveItem(cellFrom, 8);
            }
            //перетаскивание из источника
            else if ((e.Data.GetData(typeof(Item)) != null))
            {
                inventory.TryAddItem((Item)e.Data.GetData(typeof(Item)), 8);
            }
        }

        //источник яблок
        private void itemSource_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject(typeof(Item), new Item(Item.ItemType.Apple)); //в качестве данных DragAndDrop передаем новый предмет типа Apple
            DragDrop.DoDragDrop(cell_Images[0], data, DragDropEffects.All);
        }

        //кнопка "Сохранить игру"
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            db.SaveGame(inventory.Cells, inventory.ItemCount);
        }
        //кнопка "Загрузить игру"
        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            db.LoadGame(inventory);
        }
    }
}
