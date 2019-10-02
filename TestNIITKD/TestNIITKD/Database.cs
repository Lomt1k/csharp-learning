using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows; //для MessageBox

/* Как требует задание - работал с SQ Lite.
 * Впервые. До этого имел опыт работы только с MySQL (правда не в C# проектах)
 * Разбирался с SQLite, используя данное руководство:
 * https://devpractice.ru/sqlite-c/
 * Как я понял - это по своей сути тоже самое, по крайней мере формат запросов совпадает.
 * Разница только в том, что БД не запускается в качестве сервера.
 * 
 * В данном случае мы будем использовать БД в качестве файла сохранений.
 * Игрок сможет сохранить содержимое инвентаря и загрузить его при следующем запуске игры
 */

namespace TestNIITKD
{
    class Database
    {
        String dbFileName = "savefile.sqlite";
        SQLiteConnection m_dbConn;
        SQLiteCommand m_sqlCmd;

        //конструктор
        public Database()
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            //lbStatusText.Text = "Disconnected";
        }

        //метод для подключения к базе данных (и создания базы данных, если она не существует)
        public void Connect()
        {
            if (!File.Exists(dbFileName)) SQLiteConnection.CreateFile(dbFileName);

            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;

                //создаем таблицу инвентаря, если она не существует
                m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Inventory (cellid INTEGER PRIMARY KEY, itemtype INTEGER, count INTEGER)";
                m_sqlCmd.ExecuteNonQuery();

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка SQLite: " + ex.Message);
            }
        }

        //загрузить игру - загружает инвентарь из БД
        public void LoadGame(Inventory _inventory)
        {
            if (m_dbConn.State != ConnectionState.Open) //нет связи с БД
            {
                MessageBox.Show("Произошла ошибка при попытке загрузки сохранения. Попробуйте еще раз...");
                Connect(); //пробуем восстановить поключение с БД
                return;
            }

            DataTable dTable = new DataTable();
            String sqlQuery;

            try
            {
                sqlQuery = "SELECT * FROM Inventory";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    for (int i = 0; i < 9; i++) _inventory.ClearCell(i); //очищаем инвентарь
                    for (int i = 0; i < dTable.Rows.Count; i++) //пробегаемся по всем столбца таблицы
                    {
                        //-- дальше парсим данные из столбца таблицы в нормальные переменные
                        int cell = Int32.Parse(dTable.Rows[i].ItemArray[0].ToString());
                        int count = Int32.Parse(dTable.Rows[i].ItemArray[2].ToString());
                        Item.ItemType type = (Item.ItemType) Int32.Parse(dTable.Rows[i].ItemArray[1].ToString());
                        _inventory.TryAddItem(new Item(type), cell, count); //добавляем предмет 
                    }
                    MessageBox.Show("Игра загружена с сохранения");
                }
                else MessageBox.Show("Сохранения не найдены");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка SQLite: " + ex.Message);
            }
        }

        //сохранить игру - сохраняет инвентарь в БД
        public void SaveGame(Item[] _items, int[] _itemsCount)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Произошла ошибка при попытке сохранить игру. Попробуйте еще раз...");
                Connect(); //пробуем восстановить поключение с БД
                return;
            }

            try
            {
                //сначала удалим прошлое сохранение
                m_sqlCmd.CommandText = "DELETE FROM Inventory WHERE 1";
                m_sqlCmd.ExecuteNonQuery();
                //сохраняем инвентарь в таблицу
                for (int i = 0; i < _items.Length; i++)
                {
                    if (_items[i] == null || _itemsCount[i] < 1) continue;
                    m_sqlCmd.CommandText = $"INSERT INTO Inventory ('cellid', 'itemtype', 'count') values ('{i}' , '{(int)_items[i].Type}' , '{_itemsCount[i]}')";
                    m_sqlCmd.ExecuteNonQuery();
                }
                MessageBox.Show("Игра сохранена");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка SQLite: " + ex.Message);
            }
        }

    }
}
