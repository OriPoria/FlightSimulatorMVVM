using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace flightSimulator
{
    class MyFlight : IFlightModel
    {
        private SimulatorObject[] readFlightObjects;
        private SimulatorObject[] writeFlightObjects;
        private Dictionary<string, int> hash = new Dictionary<string, int>();


        private ITelnetClient myTelnetClient;
        private volatile Boolean stop;
        
        public event PropertyChangedEventHandler PropertyChanged;
        public MyFlight(ITelnetClient tc)
        {
            this.myTelnetClient = tc;
            initializeObjects();
        }
        public void connect(string ip, int port)
        {
            myTelnetClient.connect(ip, port);
        }

        public void disconnect()
        {
            myTelnetClient.disconnect();
            stop = false;
        }
        public void start()
        {
                while (!stop)
                {
                    var builder = new StringBuilder();
                    int i = 0;
                    for (i = 0; i < readFlightObjects.Length; i++)
                    {
                        builder.Append("get ").Append(readFlightObjects[i].Sim);
                        myTelnetClient.write(builder.ToString());
                        string s = myTelnetClient.read();
                        readFlightObjects[i].Value = Double.Parse(s);
                        NotifyPropertyChanged(readFlightObjects[i].Name);
                        builder.Clear();
                        

                    }



                    Thread.Sleep(250);
                }
                    

        }


        public void NotifyPropertyChanged(string proName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(proName));
            }
        }
        public double getData(string str)
        {
            return readFlightObjects[hash[str]].Value;
        }


        private void initializeObjects()
        {
            readFlightObjects = new SimulatorObject[] {
                new SimulatorObject("heading","/instrumentation/heading-indicator/indicated-heading-deg"),
                new SimulatorObject("verticalSpeed", "/instrumentation/gps/indicated-vertical-speed"),
                new SimulatorObject("groundSpeed","/instrumentation/gps/indicated-ground-speed-kt"),
                new SimulatorObject("airSpeed","/instrumentation/airspeed-indicator/indicated-speed-kt"),
                new SimulatorObject("altitude","/instrumentation/gps/indicated-altitude-ft"),
                new SimulatorObject("roll","/instrumentation/attitude-indicator/internal-roll-deg"),
                new SimulatorObject("pitch","/instrumentation/attitude-indicator/internal-pitch-deg"),
                new SimulatorObject("altimeter", "/instrumentation/altimeter/indicated-altitude-ft"),
                
                new SimulatorObject("latitude","/position/latitude-deg"),
                new SimulatorObject("longitude","/position/longitude-deg") };
            int i = 0;
            for (i = 0; i < readFlightObjects.Length; i++)
            {
                hash.Add(readFlightObjects[i].Name, i);
            }
            
            
            writeFlightObjects = new SimulatorObject[] {
                new SimulatorObject("throttle","/controls/engines/current-engine/throttle"),
                new SimulatorObject("aileron","/controls/flight/aileron"),
                new SimulatorObject("elevator","/controls/flight/elevator"),
                new SimulatorObject("rudder","/controls/flight/rudder") };
        }
    }
}
