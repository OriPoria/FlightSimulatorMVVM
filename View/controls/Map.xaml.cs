using System.Windows;
using System.Windows.Controls;


namespace FlightSimulator.View.controls
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl
    {
        public Map()
        {
            InitializeComponent();
            DataContext = (Application.Current as App).MainViewModel.MapVM;
            
            ControlTemplate template = (ControlTemplate)this.FindResource("CutomPushpinTemplate");
            pin.Template = template;
            
        }



    }
}
