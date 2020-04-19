using System;
using System.Windows;


namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IFlightModel myFilght;

        public MainWindow(IFlightModel ifm)
        {
            InitializeComponent();
            this.myFilght = ifm;
            DataContext = (Application.Current as App).MainViewModel;
            errLab.DataContext = (Application.Current as App).MainViewModel.ErrorVM;
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            myFilght.Disconnect();
            App.Current.Shutdown();
        }

        [Obsolete]
        private void ReconnectBtnClick(object sender, RoutedEventArgs e)
        {
            myFilght.Disconnect();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        private void DisconnectBtnClick(object sender, RoutedEventArgs e)
        {
            errLab.Visibility = Visibility.Visible;
            errLab.Content = "Server is not available";
            myFilght.Disconnect();
        }
    }
}
