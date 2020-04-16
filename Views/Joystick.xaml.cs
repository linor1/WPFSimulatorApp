using FlightSimulatorApp.Model.EventArgs;
using FlightSimulatorApp.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl
    {


        public static readonly DependencyProperty RudderProperty =
        DependencyProperty.Register("Rudder", typeof(double), typeof(Joystick), null);

        // <summary>Current Elevator</summary>
        public static readonly DependencyProperty ElevatorProperty =
            DependencyProperty.Register("Elevator", typeof(double), typeof(Joystick),null);

        /// <summary>How often should be raised StickMove event in degrees</summary>
        public static readonly DependencyProperty RudderStepProperty =
            DependencyProperty.Register("RudderStep", typeof(double), typeof(Joystick), new PropertyMetadata(1.0));

        /// <summary>How often should be raised StickMove event in Elevator units</summary>
        public static readonly DependencyProperty ElevatorStepProperty =
            DependencyProperty.Register("ElevatorStep", typeof(double), typeof(Joystick), new PropertyMetadata(1.0));


        private double canvasWidth, canvasHeight;
        private readonly Storyboard centerKnob;
        private double _prevAileron, _prevElevator;
        private JoystickViewModel vm;

        public Joystick()
        {
            InitializeComponent();

            //work also without this lines:
            Knob.MouseLeftButtonDown += Knob_MouseLeftButtonDown;

            Knob.MouseLeftButtonUp += Knob_MouseLeftButtonUp;

            Knob.MouseMove += Knob_MouseMove;

            centerKnob = Knob.Resources["CenterKnob"] as Storyboard;
            vm = new JoystickViewModel();
            this.DataContext = vm;
            // UpdateKnobPosition();
        }

        public delegate void EmptyJoystickEventHandler(Joystick sender);
        public delegate void OnScreenJoystickEventHandler(Joystick sender, VirtualJoystickEventArgs args);

        public event EmptyJoystickEventHandler Released;
        public event EmptyJoystickEventHandler Captured;
        public event OnScreenJoystickEventHandler Moved;
     
        public double Rudder
        {
            get { return Convert.ToDouble(GetValue(RudderProperty)); }
            set { SetValue(RudderProperty, value); }
        }

        /// <summary>current Elevator (or "power"), from 0 to 100</summary>
        public double Elevator
        {
            get { return Convert.ToDouble(GetValue(ElevatorProperty)); }
            set { SetValue(ElevatorProperty, value); }
        }

        /// <summary>How often should be raised StickMove event in degrees</summary>
        public double RudderStep
        {
            get { return Convert.ToDouble(GetValue(RudderStepProperty)); }
            set
            {
                if (value < 1) value = 1; else if (value > 90) value = 90;
                SetValue(RudderStepProperty, Math.Round(value));
            }
        }

        /// <summary>How often should be raised StickMove event in Elevator units</summary>
        public double ElevatorStep
        {
            get { return Convert.ToDouble(GetValue(ElevatorStepProperty)); }
            set
            {
                if (value < 1) value = 1; else if (value > 50) value = 50;
                SetValue(ElevatorStepProperty, value);
            }
        }
     
        double x, y;
        Point _startPos;
        bool mousePressed = false;
        private void CenterKnob_Completed(Object sender, EventArgs e) {
            //
            Rudder = Elevator = _prevAileron = _prevElevator = 0;
            vm.Rudder = 0;
            vm.Elevator = 0;
            Released?.Invoke(this);
        }

       private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void Knob_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPos = e.GetPosition(Base);
            x = _startPos.X;
            y = _startPos.Y;
            canvasWidth = Base.ActualWidth - KnobBase.ActualWidth;
            canvasHeight = Base.ActualHeight - KnobBase.ActualHeight;
            Captured?.Invoke(this);
            Knob.CaptureMouse();
            centerKnob.Stop();

        }

        private void Knob_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Knob.ReleaseMouseCapture();
            centerKnob.Begin();
        }
        private double normalize( double value) {
            return ((Math.Abs(value)-170)/170);
        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
 

            if (!Knob.IsMouseCaptured) return;
                Point newPos = e.GetPosition(Base);
                //Point normalized = new Point(normalize(newPos.X), normalize(newPos.Y));
                //   this.canvasWidth = Base.ActualWidth - KnobBase.ActualWidth;
                //  this.canvasHeight = Base.ActualHeight - KnobBase.ActualHeight;
      
                Point deltaPos = new Point(newPos.X - _startPos.X, newPos.Y - _startPos.Y);

                double distance = length(newPos.X, newPos.Y, _startPos.X, _startPos.Y);
                if (distance >= canvasWidth / 2 || distance >= canvasHeight / 2)
                    return;
              Rudder = (deltaPos.X);
              Elevator = -(deltaPos.Y);
            //  Rudder = normalize(deltaPos.X);
            //  Elevator = normalize(deltaPos.Y);

                 vm.Rudder = Rudder;
                vm.Elevator = Elevator;
                knobPosition.X = (deltaPos.X);
                knobPosition.Y = (deltaPos.Y);
            
                 if (Moved == null ||
                     (!(Math.Abs(_prevAileron - Rudder) > RudderStep) && !(Math.Abs(_prevElevator - Elevator) > ElevatorStep)))
                      return;

                  Moved?.Invoke(this, new VirtualJoystickEventArgs { Rudder = deltaPos.X / 100, Elevator = deltaPos.Y / 100 });
                  _prevAileron = Rudder;
                  _prevElevator = Elevator;

            
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private double length(double x, double y, double initialX, double initialY)
        {
            return Math.Sqrt((initialX - x) * (initialX - x) + (initialY - y) * (initialY - y));
        }

       
        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }



        /* bool buttonWasClick = false;

bool _leftMousePressed;
private void Ellipse_MouseUp(object sender, MouseButtonEventArgs e)
{
    _leftMousePressed = false;
    Point p = e.GetPosition(this);
    double x = p.X;
    double y = p.Y;
    if (x <= -1)
    {
        x = -1;
    }
    if (x >= 1)
    {
        x = 1;
    }
    if (y <= -1)
    {
        y = -1;
    }
    if (y >= 1)
    {
        y = 1;
    }
    Console.WriteLine("value of x:{0}" ,x);
    Console.WriteLine("value of y:{0}", y);

}

private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
{
    if (buttonWasClick == true)
    {
        _leftMousePressed = true;
    }

}
Vector m_vtJoystickPos = new Vector();
private void Ellipse_MouseMove(object sender, MouseEventArgs e)
{
    double fJoystickRadius = Knob.Height * 0.5;
    Vector vtJoystickPos = e.GetPosition(Knob) -
    new Point(fJoystickRadius, fJoystickRadius);
    //Normalize coords
    Vector m_vtJoystickPos = new Vector();

    //Limit R [0; 1]
    if (vtJoystickPos.Length > 1.0)
        vtJoystickPos.Normalize();
    Console.WriteLine("x:{0}",vtJoystickPos.X);
    Console.WriteLine("y:{0}",vtJoystickPos.Y);

    //XMousePos.Text = vtJoystickPos.X.ToString();
    //YMousePos.Text = vtJoystickPos.Y.ToString();

    //Polar coord system
    double fTheta = Math.Atan2(vtJoystickPos.Y, vtJoystickPos.X);

    //Console.WriteLine(vtJoystickPos.Length);
   // Console.WriteLine(fTheta);
    //XPolPos.Text = fTheta.ToString(); //Angle
    //YPolPos.Text = vtJoystickPos.Length.ToString(); //Radius

    if (e.LeftButton == MouseButtonState.Pressed)
    {
        m_vtJoystickPos = vtJoystickPos;
        UpdateKnobPosition();
    }
    if (_leftMousePressed == true)
    {

    }
}




private void Ellipse_button_Click(object sender, RoutedEventArgs e)
{
    buttonWasClick = true;
}*/
        Vector m_vtJoystickPos = new Vector();
       /* private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            double fJoystickRadius = .Height * 0.5;

            //Make coords related to the center
            Vector vtJoystickPos = e.GetPosition(Joystick) -
                new Point(fJoystickRadius, fJoystickRadius);

            //Normalize coords
            vtJoystickPos /= fJoystickRadius;

            //Limit R [0; 1]
            if (vtJoystickPos.Length > 1.0)
                vtJoystickPos.Normalize();

            XMousePos.Text = vtJoystickPos.X.ToString();
            YMousePos.Text = vtJoystickPos.Y.ToString();

            //Polar coord system
            double fTheta = Math.Atan2(vtJoystickPos.Y, vtJoystickPos.X);
            XPolPos.Text = fTheta.ToString(); //Angle
            YPolPos.Text = vtJoystickPos.Length.ToString(); //Radius

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                m_vtJoystickPos = vtJoystickPos;
                UpdateKnobPosition();
            }
        }*/
        //void UpdateKnobPosition()
        //{
        //    double fJoystickRadius = Base.Height * 0.5;
        //    double fKnobRadius = Knob.Width * 0.5 - Knob.Width*0.5;
        //    Canvas.SetLeft(Knob, Canvas.GetLeft(Base) +
        //        m_vtJoystickPos.X * fJoystickRadius + fJoystickRadius - fKnobRadius);
        //   /* Canvas.SetTop(Knob, Canvas.GetTop(Base) +
        //        m_vtJoystickPos.Y * fJoystickRadius + fJoystickRadius - fKnobRadius);*/
        //}
    }
}
