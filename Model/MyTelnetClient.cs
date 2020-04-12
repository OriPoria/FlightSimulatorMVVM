using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace flightSimulator
{
    class MyTelnetClient : ITelnetClient
    {
        private TcpClient clientSocket;
        private StreamWriter sw;
        private StreamReader sr;
        
        string readdata = null;// the returned string

        public void Connect(string ip, int port)
        {
            clientSocket = new TcpClient();
            clientSocket.Connect(ip, port);
            sw = new StreamWriter(clientSocket.GetStream());
            sr = new StreamReader(clientSocket.GetStream());


        }

        public void Write(string command)
        {
            try
            {
                sw.WriteLine(command);
                sw.Flush();
                readdata = sr.ReadLine();
            }
            catch (IOException) { }
            catch (ObjectDisposedException) { }

        }
        public string Read()
        {
                return readdata;

        }
        public void Disconnect()
        {
            clientSocket.Close();
        }

    }
}
