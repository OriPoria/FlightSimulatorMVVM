using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Timers;
using System.IO;


namespace FlightSimulator
{
    class MyFlight : IFlightModel
    {
        private SimulatorObject[] readFlightObjects;
        private readonly Dictionary<string, int> hashFlightObjects = new Dictionary<string, int>();
        private readonly Queue<string> queueCommands = new Queue<string>();

        private double throttle;    
        private double rudder;
        private double elevator;
        private double aileron;

        private readonly ITelnetClient myTelnetClient;
        private volatile Boolean stop;

        private string mdlErr;
        private readonly System.Timers.Timer timer;
        
        public event PropertyChangedEventHandler PropertyChanged;
        public MyFlight(ITelnetClient tc)
        {
            this.myTelnetClient = tc;
            stop = false;
            
            timer = new System.Timers.Timer(10000);
            timer.Elapsed += HandleTimer;
            timer.AutoReset = false;
            timer.Enabled = true;

            InitializeObjects();            
        }


        public void Connect(string ip, int port)
        {
            myTelnetClient.Connect(ip, port);
        }

        public void Disconnect()
        {
            stop = true;
            timer.Enabled = false;

            Thread.Sleep(2000);
            myTelnetClient.Disconnect();
        }


        public void Start()
        {
            double val;
            string serverStr;

            while (!stop)
            {
                try
                {
                    var builder = new StringBuilder();
                    for (int i = 0; i < readFlightObjects.Length; i++)
                    {
                        Reset(timer);
                        builder.Append("get ").Append(readFlightObjects[i].Sim);
                        myTelnetClient.Write(builder.ToString());

                        serverStr = myTelnetClient.Read();
                        val = Double.Parse(serverStr);

                        //8 and 9 are the indexs of the longitude and latitude thus we check their values
                        try
                        {
                            if (i == 8 && ((val > 85) || (val < -85)))
                            {
                                throw new InvalidOperationException();
                            }
                            if (i == 9 && ((val > 180) || (val < -180)))
                            {
                                throw new InvalidOperationException();
                            }
                        } 
                        catch (InvalidOperationException)
                        {
                            CallErrorAsync("ERR: Invalid map values");
                            builder.Clear();
                            continue;
                        }

                        readFlightObjects[i].Value = val;

                        NotifyPropertyChanged(readFlightObjects[i].Name);
                        builder.Clear();

                    }
                    Reset(timer);
                    //send all the commands from the queue to the simulator and remove the item from the queue
                    //resetting timer to check dealay, with the server, in the set commands 
                    while (queueCommands.Count > 0)
                    {
                        myTelnetClient.Write(queueCommands.Dequeue());
                        serverStr = myTelnetClient.Read();
                        val = Double.Parse(serverStr);
                    }
                }
                catch (FormatException)
                {
                    CallErrorAsync("ERR: Invalid value");
                }
                catch (IOException)
                {
                    CallErrorAsync("ERR: Server is not available");
                }
                Thread.Sleep(250);
            }
        }
        public string Error
        {
            get { return this.mdlErr; }
  
            set { this.mdlErr = value;
                  NotifyPropertyChanged("error"); }
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
            get 
            { 
                return rudder; 
            }
            set 
            {
                AddCommand("set /controls/flight/rudder " + value);
                this.rudder = value;
                NotifyPropertyChanged("rudder");
            }
        }
        public double Elevator
        {
            get
            { 
                return elevator;
            }
            set
            {   
                AddCommand("set /controls/flight/elevator " + value);
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
                PropertyChanged(this, new PropertyChangedEventArgs(proName));
            }
        }
        public double GetData(string str)
        {
            return readFlightObjects[hashFlightObjects[str]].Value;
        }
        public void AddCommand(string command)
        {
            queueCommands.Enqueue(command);
        }

        private void InitializeObjects()
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
                
                //map variables
                new SimulatorObject("latitude","/position/latitude-deg"),
                new SimulatorObject("longitude","/position/longitude-deg") };
            for (int i = 0; i < readFlightObjects.Length; i++)
            {
                hashFlightObjects.Add(readFlightObjects[i].Name, i);
            }
        }
        private void HandleTimer(Object source, ElapsedEventArgs e)
        {
            CallErrorAsync("ERR: Server is too slow...");
        }
        private async void CallErrorAsync(string s)
        {
            await Task.Run(() => Error = s);
        }

        public void Reset(System.Timers.Timer timer)
        {
            timer.Stop();
            timer.Start();
        }
    }
}
