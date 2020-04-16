using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.ViewModels
{
    class DashBoardViewModel: BaseNotify
    {
        private MainModel model;
        public DashBoardViewModel()
        {
            this.model = new MainModel();
            this.model.PropertyChanged += Model_PropertyChanged;
        }

        public double Degree
        {
            get { 
                return Math.Round(model.Degree, 2); }
            set {
                NotifyPropertyChanged("Degree");
            }
        }
        public double VerticalSpeed
        {
            get { return Math.Round(model.VerticalSpeed, 2); }
        }
        public double GroundSpeed
        {
            get { return Math.Round(model.GroundSpeed, 2); }
        }
        public double GpsAltitude
        {
            get { return Math.Round(model.GpsAltitude, 2); }
        }
        public double RollDegree
        {
            get { return Math.Round(model.RollDegree, 2); }
        }
        public double PitchDegree
        {
            get { return Math.Round(model.PitchDegree, 2); }
        }
        public double AltimeterAltitude
        {
            get { return Math.Round(model.GroundSpeed, 2); }
        }
        public void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IMainWindowModel m = sender as IMainWindowModel;
            if (m != null && m == model)
            {
                if (e.PropertyName.Equals("Degree"))
                {
                    Degree = model.Degree;
                }
             
            }
        }
    }
}
