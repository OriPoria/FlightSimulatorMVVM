using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace FlightSimulator.controls
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl
    {
        private Point firstPoint = new Point();

        public Joystick()
        {
            InitializeComponent();
        }


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

        public static readonly DependencyProperty ElevatorValueProperty = DependencyProperty.Register("ElevatorValue", typeof(double), typeof(Joystick));


        public double RudderValue
        {
            get { return (double)GetValue(RudderValueProperty); }
            set
            {
                SetValue(RudderValueProperty, value);
            }
        }

        public static readonly DependencyProperty RudderValueProperty = DependencyProperty.Register("RudderValue", typeof(double), typeof(Joystick));



        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X - firstPoint.X;
                double y = e.GetPosition(this).Y - firstPoint.Y;
                double d = Math.Sqrt(x * x + y * y);

                if (d < Base.Width / 2)
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
