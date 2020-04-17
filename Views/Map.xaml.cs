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
using Microsoft.Research.DynamicDataDisplay.DataSources;
using FlightSimulatorApp.ViewModels;
using FlightSimulatorApp.Model;
using System.ComponentModel;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl
    {
        private MapVM vm;
        // ObservableDataSource<Point> planeLocations = null;

        public Map()
        {
            InitializeComponent();


        vm = new MapVM();
            this.DataContext = vm;


        }

        public static object DataContaxt { get; internal set; }


        //private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
        //    {
        //        var vm = sender as MapVM;

        //    }
        //}


    }
}
