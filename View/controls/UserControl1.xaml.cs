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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace flightSimulator.controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void centerKnob_Completed(object sender, EventArgs e) { }
        private Point firstPoint = new Point();


        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { firstPoint = e.GetPosition(this); }
        }




        public double ElevatorValue
        {
            get { return (double)GetValue(ElevatorValueProperty); }
            set
            {
                SetValue(ElevatorValueProperty, value);
            }
        }

        public static readonly DependencyProperty ElevatorValueProperty = DependencyProperty.Register("ElevatorValue", typeof(double), typeof(UserControl1));


        public double RudderValue
        {
            get { return (double)GetValue(RudderValueProperty); }
            set
            {
                SetValue(RudderValueProperty, value);
            }
        }

        public static readonly DependencyProperty RudderValueProperty = DependencyProperty.Register("RudderValue", typeof(double), typeof(UserControl1));






        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X - firstPoint.X;
                double y = e.GetPosition(this).Y - firstPoint.Y;
                double d = Math.Sqrt(x * x + y * y);
                if (d < Math.Abs(Base.Width / Knob.Width) / 2)
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                }

                RudderValue = x / (Math.Abs(Base.Width - KnobBase.Width) * 2);
                ElevatorValue = y / (Math.Abs(Base.Width - KnobBase.Width) * 2);

            }

        }

        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
        }






    }
}
