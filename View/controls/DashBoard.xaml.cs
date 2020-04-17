using System.Windows;
using System.Windows.Controls;


namespace FlightSimulator.View.controls
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>

    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
            DataContext = (Application.Current as App).MainViewModel.DashBoardVM;
        }
    }
}
