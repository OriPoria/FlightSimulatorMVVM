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

        private SimulatorObject[] myFlightObjects;

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
                    for (i = 0; i < myFlightObjects.Length; i++)
                    {
                        builder.Append("get ").Append(myFlightObjects[i].Sim);
                        myTelnetClient.write(builder.ToString());
                        string s = myTelnetClient.read();
                        s = stringLexing(s);
                        myFlightObjects[i].Value = Double.Parse(s);
                        NotifyPropertyChanged(myFlightObjects[i].Name);
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

        public string stringLexing(string myString)
        {
            int l = myString.Length;

            int i = 0;
            int endIndex = 0;
            for (i = l - 1; i > 0; i--)
            {
                if (Char.IsNumber(myString[i]))
                {
                    endIndex = i + 1;
                    while (Char.IsNumber(myString[i]) || myString[i] == '.' || myString[i] == '-' || myString[i] == 'e')
                    {
                        i--;
                    }
                    i++;
                    break;
                }
            }
            myString = myString.Substring(i, endIndex - i);
            return myString;

        }
        private void initializeObjects()
        {
            myFlightObjects = new SimulatorObject[] 
                { new SimulatorObject("headingDeg","/instrumentation/heading-indicator/indicated-heading-deg"),
                new SimulatorObject("verticalSpeed", "/instrumentation/gps/indicated-vertical-speed"),
                new SimulatorObject("groundSpeed","/instrumentation/gps/indicated-ground-speed-kt"),
                new SimulatorObject("indicatedSpeed","/instrumentation/airspeed-indicator/indicated-speed-kt"),
                new SimulatorObject("altitude","/instrumentation/gps/indicated-altitude-ft"),
                new SimulatorObject("internalRoll","/instrumentation/attitude-indicator/internal-roll-deg"),
                new SimulatorObject("internalPitch","/instrumentation/attitude-indicator/internal-pitch-deg"),
                new SimulatorObject("altimeterIndicatedAltitude","/instrumentation/altimeter/indicated-altitude-ft") };
        }
    }
}
