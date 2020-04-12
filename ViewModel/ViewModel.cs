using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows;

namespace flightSimulator
{   
    public class ViewModel : INotifyPropertyChanged
    {
        protected IFlightModel myModel;
        public event PropertyChangedEventHandler PropertyChanged;

        private Visibility errorVisi = Visibility.Hidden;

        private readonly HashSet<string> errors = new HashSet<string>();

        private ViewModel dashBoardVM;
        private ViewModel mapVM;
        private ViewModel steeringVM;

        public ViewModel(IFlightModel ifm)
        {
            this.myModel = ifm;            
        }
        public void AddError(string s)
        {
            errors.Add(s);
            VM_error = Visibility.Visible;
        }
        public void RemoveError(string s)
        {
            errors.Remove(s);
            if (errors.Count == 0)
            {
                VM_error = Visibility.Hidden;
            }
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
            get{ return this.dashBoardVM;}
        }
        public ViewModel MapVM
        {
            get{ return this.mapVM; }
        }
        public ViewModel SteeringVM
        {
            get
            { return this.steeringVM;}
        }
         

        public Visibility VM_error
        {
            get
            {
                return this.errorVisi;
            }
            set
            {
                this.errorVisi = value;
                NotifyPropertyChanged("VM_error");
            }
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
