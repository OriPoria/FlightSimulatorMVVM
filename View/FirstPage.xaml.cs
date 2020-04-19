using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Configuration;
using System.Windows.Media;


namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Window
    {
        private MainWindow myMain;
        private IFlightModel myFlight;

        [Obsolete]
        public FirstPage()
        {
            InitializeComponent();
            ip_textbox.Text = ConfigurationSettings.AppSettings["ip"];
            port_text_box.Text = ConfigurationSettings.AppSettings["port"];
        }
        public void SetFlight(IFlightModel ifm)
        {
            this.myFlight = ifm;
        }
        public void SetMain(MainWindow mw)
        {
            this.myMain = mw;
        }



        private void ButtonClick(object sender, RoutedEventArgs e)
        {

            int port = Int32.Parse(this.port_text_box.Text);
            try
            {
                myFlight.Connect(this.ip_textbox.Text, port);
            }
            catch (Exception) 
            {
                Label l = new Label
                {
                    Content = "Connection failure",
                    FontSize = 20,
                    Foreground = Brushes.Red,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetRow(l, 2);
                Grid.SetColumnSpan(l, 2);

                myGrid.Children.Add(l);
                return;
            }


            Thread t = new Thread(new ThreadStart(myFlight.Start));
            t.Start();

            this.Hide();
            myMain.Show();
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            this.Close();
            App.Current.Shutdown();
        }
    }
}
