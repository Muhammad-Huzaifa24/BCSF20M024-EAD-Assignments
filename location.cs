using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace location_class
{
    public class Location
    {
        private double latitude;
        private double longitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public void setLocation(double latitude, double longitude)
        {
            this.latitude = latitude;   
            this.longitude = longitude;
        }
    }
}
