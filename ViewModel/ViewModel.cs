using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace flightSimulator
{   
    abstract public class ViewModel : INotifyPropertyChanged
        {
            protected IFlightModel myModel;
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }

            }
        }
}
