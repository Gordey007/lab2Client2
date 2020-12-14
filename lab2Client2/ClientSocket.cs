using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lab2Client2 {
    class ClientSocket {

        Socket sender;
	    // Буфер для входящих данных
	    byte[] bytes = new byte[1024];
	    public ClientSocket(int port) {

            try {

	            // Соединяемся с удаленным устройством

	            // Устанавливаем удаленную точку для сокета
	            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
	            IPAddress ipAddr = ipHost.AddressList[0];
	            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

	            sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

	            // Соединяем сокет с удаленной точкой
	            sender.Connect(ipEndPoint);

	        }
	        catch (Exception ex) {
	            Console.WriteLine(ex.ToString());
	        }
	        finally {
	            Console.ReadLine();
	        }
        }

        // функция отправки данных на сервер
	    public void SendMessage(string message) {

            byte[] discipline = Encoding.UTF8.GetBytes(message);

	        // Отправляем данные через сокет
	        int bytesSent = sender.Send(discipline);
	    }

        // функция получения ответа от сервера
	    public string response()
	    {
	        // Получаем ответ от сервера
	        int bytesRec = sender.Receive(bytes);
	        string text = Encoding.UTF8.GetString(bytes, 0, bytesRec);
	        return text;
	    }

        // функция отключениыя
	    public void Disconnect()
	    {
	        // Освобождаем сокет
	        sender.Shutdown(SocketShutdown.Both);
	        sender.Close();
	    }
	}
}
