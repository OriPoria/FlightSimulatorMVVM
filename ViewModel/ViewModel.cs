using System.ComponentModel;


namespace FlightSimulator
{   
    public class ViewModel : INotifyPropertyChanged
    {
        protected IFlightModel myModel;
        public event PropertyChangedEventHandler PropertyChanged;

        private ViewModel dashBoardVM;
        private ViewModel mapVM;
        private ViewModel steeringVM;
        private ViewModel errorVM;

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
            ViewModel e = new ErrorViewModel(this.myModel);
            this.errorVM = e;
        }
        
        public ViewModel DashBoardVM
        {
            get { return this.dashBoardVM; }
        }
        public ViewModel MapVM
        {
            get { return this.mapVM; }
        }
        public ViewModel SteeringVM
        {
            get { return this.steeringVM; }
        }
        public ViewModel ErrorVM
        {
            get { return this.errorVM; }
        }


        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
}
