using System;
using System.Net.Sockets;
using System.IO;

namespace FlightSimulator
{
    class MyTelnetClient : ITelnetClient
    {
        private TcpClient clientSocket;
        private StreamWriter writer;
        private StreamReader reader;
        
        string readdata = null;

        public void Connect(string ip, int port)
        {
            clientSocket = new TcpClient();
            clientSocket.Connect(ip, port);
            writer = new StreamWriter(clientSocket.GetStream());
            reader = new StreamReader(clientSocket.GetStream());
        }

        public void Write(string command)
        {
            try
            {
                writer.WriteLine(command);
                writer.Flush();
                readdata = reader.ReadLine();
            }
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
