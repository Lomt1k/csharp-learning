using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows;

namespace TestNIITKD
{
    class Client
    {
        string serverIP;
        int serverPort;
        Socket socket;

        Thread socketListener; //поток, который будет слушать сообщения от сервера

        //конструктор (запуск клиента)
        public Client(string _ip = "127.0.0.1", int _port = 7777)
        {
            serverIP = _ip;
            serverPort = _port;

            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
                socketListener = new Thread(SocketListener); //слушаем сообщения от сервера в отдельном потоке
                socketListener.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //метод, который слушает сообщения от сервера в отдельном потоке
        void SocketListener()
        {
            byte[] data = new byte[256]; // буфер для ответа
            StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байт

            while (socket.Connected)
            {
                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                //MessageBox.Show("Ответ сервера: " + builder.ToString());

                string[] messages = builder.ToString().Split('|'); //разделяем сообщения
                //дальше в цикле обрабатываем каждое сообщение
                foreach (string _mes in messages)
                {
                    string[] args = _mes.ToString().Split(';'); //разделяем аргументы

                    switch (args[0]) //нувевой аргумент - это название метода
                    {
                        case "InventoryCell": OnRecieve_InventoryCell(args[1], args[2], args[3]); break; //обновление ячейки инвентаря
                    }
                }

                
            }
            //при потере соединения
            socket = null;
            socketListener = null;
        }

        //метод для отправки сообщений на сервер (событие, аргументы)
        void SendMessage(string _message, string[] _args)
        {
            StringBuilder sb = new StringBuilder(_message + ";");
            //если указаны аргументы - добавляем их через точку с запятой
            if (_args.Length > 0)
            {
                for (int i = 0; i < _args.Length; i++)
                {
                    sb.Append(_args[i] + ";");
                }                
            }
            //отправляем сообщение
            byte[] data = Encoding.Unicode.GetBytes(sb.ToString());
            socket.Send(data);
        }

        //когда от сервера приходит информация об обновлении ячейки инвентаря
        void OnRecieve_InventoryCell(string _cellID, string _itemType, string _itemCount)
        {
            //парсим данные
            int cellID = Int32.Parse(_cellID);
            Item.ItemType type = (Item.ItemType) Int32.Parse(_itemType);
            int itemCount = Int32.Parse(_itemCount);
            //обновляем ячейку ивентаря
            GameWindow.Instance.Inventory.ClearCell(cellID);
            GameWindow.Instance.Inventory.TryAddItem(new Item(type), cellID, itemCount);
        }

    }
}
