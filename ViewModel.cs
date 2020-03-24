﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightSimulator
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Model myModel;
        private SimulatorObject[] VM_objects;
        public ViewModel(Model m)
        {
            this.myModel = m;
            myModel.PropertyChanged += update;
        }
        public void update(Object o, PropertyChangedEventArgs e)
        {
            

        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
