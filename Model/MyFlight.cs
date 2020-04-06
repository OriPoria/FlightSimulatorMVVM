using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace flightSimulator
{
    class MyFlight : IFlightModel
    {
        private SimulatorObject[] readFlightObjects;
        private SimulatorObject[] writeFlightObjects;
        private Dictionary<string, int> hash = new Dictionary<string, int>();
        private Queue<string> queueCommands = new Queue<string>();

        private double throttle;    
        private double rudder;
        private double elevator;
        private double aileron;

        private ITelnetClient myTelnetClient;
        private volatile Boolean stop;
        
        public event PropertyChangedEventHandler PropertyChanged;
        public MyFlight(ITelnetClient tc)
        {
            this.myTelnetClient = tc;
            stop = false;
            initializeObjects();
        }
        public void Connect(string ip, int port)
        {
            myTelnetClient.Connect(ip, port);
        }

        public void Disconnect()
        {
            stop = true;
            myTelnetClient.Disconnect();
        }
        public void Start()
        {
                while (!stop)
                {
                    var builder = new StringBuilder();
                    int i = 0;
                    for (i = 0; i < readFlightObjects.Length; i++)
                    {
                        builder.Append("get ").Append(readFlightObjects[i].Sim);
                        myTelnetClient.Write(builder.ToString());
                        string s = myTelnetClient.Read();
                        readFlightObjects[i].Value = Double.Parse(s);
                        NotifyPropertyChanged(readFlightObjects[i].Name);
                        builder.Clear();
                        

                    }
                    //send all the commands from the queue to the simulator and remove the item from the queue
                    while (queueCommands.Count > 0)
                    {
                    myTelnetClient.Write(queueCommands.Dequeue());
                    }



                    Thread.Sleep(250);
                }
                    

        }
        public double Throttle
        {
            get{ return throttle; }
            set{ AddCommand("set /controls/engines/current-engine/throttle " + value);
                this.throttle = value;
                NotifyPropertyChanged("throttle");
            }
        }
        public double Rudder
        {
            get { return rudder; }
            set {
                AddCommand("set /controls/flight/rudder " + value);
                this.rudder = value;
                NotifyPropertyChanged("rudder");

            }
        }
        public double Elevator
        {
            get
            { return elevator;
            }
            set
            {   AddCommand("set /controls/flight/elevator " + value);
                this.elevator = value;
                NotifyPropertyChanged("elevator");

            }
        }
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                AddCommand("set /controls/flight/aileron " + value);
                this.aileron = value;
                NotifyPropertyChanged("aileron");

            }
        }

        public void NotifyPropertyChanged(string proName)
        {
            if (this.PropertyChanged != null)
            {   
                this.PropertyChanged(this, new PropertyChangedEventArgs(proName));
            }
        }
        public double GetData(string str)
        {
            return readFlightObjects[hash[str]].Value;
        }
        public void AddCommand(string command)
        {
            queueCommands.Enqueue(command);
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
