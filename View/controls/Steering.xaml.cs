using System.Windows;
using System.Windows.Controls;


namespace FlightSimulator.View.controls
{
    /// <summary>
    /// Interaction logic for Steering.xaml
    /// </summary>
    public partial class Steering : UserControl
    {
        public Steering()
        {
            InitializeComponent();
            DataContext = (Application.Current as App).MainViewModel.SteeringVM;

        }

    }
}
