
using FlightSimulatorApp.Model;
using FlightSimulatorApp.ViewModels;
using System.Windows;
using FlightSimulatorApp.Views;

namespace FlightSimulatorApp
{

    public partial class MainWindow : System.Windows.Window
    {
        MainViewModel mainViewModel;
        DashBoardViewModel dvm;


       /// DashBoardViewModel dvm;
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel(new MainModel());
            this.DataContext = mainViewModel;

        }

        private void Joystick_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
        //   var jo = myJoystick; 
        }

        private void myJoystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void myMap_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}




