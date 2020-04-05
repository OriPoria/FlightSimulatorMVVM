using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl.WPF;
using System.ComponentModel;

<<<<<<< HEAD:View/FirstPage.xaml.cs
namespace flightSimulator.View
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {
        private MainWindow mainWindow;
        public FirstPage(MainWindow mw)
=======


namespace flightSimulator.View.controls
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl
    {

        public Map()
>>>>>>> branch2:View/controls/Map.xaml.cs
        {
            this.mainWindow = mw;
            InitializeComponent();
<<<<<<< HEAD:View/FirstPage.xaml.cs
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainWin.Content = new SimulatorPage();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
=======
            ControlTemplate template = (ControlTemplate)this.FindResource("CutomPushpinTemplate");
            pin.Template = template;



        }



>>>>>>> branch2:View/controls/Map.xaml.cs
    }
}
