

namespace FlightSimulator
{
    public interface ITelnetClient
    {
        void Connect(string ip, int port);
        void Write(string command);
        string Read();
        void Disconnect();
    }

}
