using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Threading;

namespace TestNIITKD
{
    class Server
    {
        int port;

        List<Socket> connections; 

        //конструктор
        public Server(int _port = 7777)
        {
            port = _port;

            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);
                connections = new List<Socket>();
                MessageBox.Show("Сервер запущен. Ожидание подключений...");
                //дальше слушаем новые подключения

                while (true)
                {
                    Socket newConnection = listenSocket.Accept();
                    if (newConnection != null)
                    {
                        connections.Add(newConnection);
                        IPEndPoint clientep = (IPEndPoint)newConnection.RemoteEndPoint;
                        OnPlayerConnect(newConnection, clientep.Address, clientep.Port);                        
                    }                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //метод для отправки сообщений клиентам (подключение, событие, аргументы)
        void SendMessage(Socket _conn, string _message, params int[] _args)
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
            sb.Append("|"); //обозначаем конец сообщения символом |
            //отправляем сообщение
            byte[] data = Encoding.Unicode.GetBytes(sb.ToString());
            _conn.Send(data);
        }

        //срабатывает при подключении игрока к серверу
        void OnPlayerConnect(Socket _conn, IPAddress _ip, int _port)
        {
            //MessageBox.Show("Новое подключение | IP: " + _ip);
            //отправляем игроку весь инвентарь в формате : тип предмета, количество
            SendInventoryCell(_conn, 0, 1, 12);
            SendInventoryCell(_conn, 1, 2, 5);
        }

        //отправляем клиенту ячейку инвентаря
        void SendInventoryCell(Socket _conn, int _cellID, int _type, int _count)
        {
            SendMessage(_conn, "InventoryCell", _cellID, _type, _count);
        }

    }
}
