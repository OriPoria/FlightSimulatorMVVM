using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightSimulator
{
    public class View
    {
        private ViewModel myViewModel;
        public View(ViewModel vm)
        {
            this.myViewModel = vm;
            myViewModel.PropertyChanged += updateMyView;
        } 
        public void updateMyView(Object o, PropertyChangedEventArgs p)
        {
            //change something on the screen after you get changes in the viewModel
        }
    }
}
