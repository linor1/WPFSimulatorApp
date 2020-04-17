using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.ViewModels
{
    class DashBoardViewModel: INotifyPropertyChanged
    {
        private MainModel model;
        public DashBoardViewModel(MainModel model)
        {
            this.model = model;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                OnPropertyChanged(e.PropertyName);
            };
        }

        //public double Degree
        //{
        //    get {
        //        Console.WriteLine("Degree:" + Math.Round(model.Degree, 4));
        //        return Math.Round(model.Degree, 4);
        //    }
        //    set
        //    {
        //        model.Degree = value;
        //        OnPropertyChanged("Degree");
        //    }
        //}
        //public double VerticalSpeed
        //{
        //    get { return Math.Round(model.VerticalSpeed, 4); }
        //    set
        //    {
        //        model.VerticalSpeed = value;
        //        OnPropertyChanged("VerticalSpeed");
        //    }
        //}
        //public double GroundSpeed
        //{
        //    get { return Math.Round(model.GroundSpeed, 2); }
        //}
        //public double GpsAltitude
        //{
        //    get { return Math.Round(model.GpsAltitude, 2); }
        //}
        //public double RollDegree
        //{
        //    get { return Math.Round(model.RollDegree, 2); }
        //}
        //public double PitchDegree
        //{
        //    get { return Math.Round(model.PitchDegree, 2); }
        //}
        //public double AltimeterAltitude
        //{
        //    get { return Math.Round(model.AltimeterAltitude, 2); }
        //}


        //public void NotifyPropertyChanged(string prop) { 


        //}
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        public void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IMainWindowModel m = sender as IMainWindowModel;
            if (m != null && m == model)
            {
                if (e.PropertyName.Equals("Degree"))
                {
                   // Degree = model.Degree;
                }
             
            }
        }
    }
}
