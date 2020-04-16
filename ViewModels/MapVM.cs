using FlightSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.ViewModels
{
    class MapVM
    {
        private MainModel model;
        public MapVM()
        {
            this.model = new MainModel();
          //  this.Longitude = 32.002644;
           // this.Latitude = 34.8887;
          //  this.model.PropertyChanged += Model_PropertyChanged;
        }

        //private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName.Equals("Latitude"))
        //    {
        //        Latitude = model.Latitude;
        //    }
        //    if (e.PropertyName.Equals("Longitude"))
        //    {
        //        Longitude = model.Longitude;
        //    }
        //}
      //  private double longitude = 32.002644;
        public double Longitude
        {
            get { return model.Longitude; }
            //set {
            //    longitude = value;
            //    OnPropertyChanged("Longitude");
            //    OnPropertyChanged("Location");
            //}
        }
      //  private double latitude = 34.8887;
        public double Latitude
        {
            get { return model.Latitude; }
            //set { OnPropertyChanged("Latitude");
            //    OnPropertyChanged("Location");
            //}
        }
       // private string location = "32.002644,34.8887";
        public string Location
        {
            get {
                return model.Location; }
         //   set { OnPropertyChanged("Location"); }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged(string propName)
        //{
        //    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        //    //if (this.PropertyChanged != null)
        //    //{
        //    //    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        //    //}
        //}
        //public void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    IMainWindowModel m = sender as IMainWindowModel;
        //    if (m != null && m == model)
        //    {
        //        if (e.PropertyName.Equals("Latitude"))
        //        {
        //            Latitude = model.Latitude;
        //        }
        //        if (e.PropertyName.Equals("Longitude"))
        //        {
        //            Longitude = model.Longitude;
        //        }
        //        if (e.PropertyName.Equals("Latitude") ||
        //         e.PropertyName.Equals("Longitude"))
        //        {
        //            Location = model.Longitude + "," + model.Latitude;
        //            Console.WriteLine(Location);
        //        }
        //    }
        //}

    }
}
