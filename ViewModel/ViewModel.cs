using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace flightSimulator
{   
    public class ViewModel : INotifyPropertyChanged
        {
            protected IFlightModel myModel;
            public event PropertyChangedEventHandler PropertyChanged;

        private ViewModel dashBoardVM;
        private ViewModel mapVM;
        private ViewModel steeringVM;

        public ViewModel(IFlightModel ifm)
            {
                this.myModel = ifm;

            }
        public void InitializeVM()
        {
            ViewModel d = new DashboardViewModel(this.myModel);
            this.dashBoardVM = d;
            ViewModel m = new MapViewModel(this.myModel);
            this.mapVM = m;
            ViewModel s = new SteeringViewModel(this.myModel);
            this.steeringVM = s;
        }
        public ViewModel DashBoardVM
        {
            get
            {
                return this.dashBoardVM;
            }
        }
        public ViewModel MapVM
        {
            get
            {
                return this.mapVM;
            }
        }
        public ViewModel SteeringVM
        {
            get
            {
                return this.steeringVM;

            }
        }
            public void NotifyPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }

            }
        }
}
