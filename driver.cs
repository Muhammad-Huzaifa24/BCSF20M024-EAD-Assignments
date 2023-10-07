using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using location_class;
using vehicle_class;
namespace driver_class
{
    public class driver
    {
        private int ID;
        private string name;
        private int age;
        private string gender;
        private string address;
        private string phone_no;
        private bool availablity;
        private Location curr_location;
        private vehicle driver_vehicle;
        private List<int> rating_list;

        public driver()
        {
            driver_vehicle= new vehicle();
            curr_location= new Location();
            rating_list = new List<int>();

        }

        public string VechicleType
        {
            get
            {
                return driver_vehicle.Type;
            }
            set
            {
                driver_vehicle.Type = value;
            }
        }
        public bool Availability
        {
            get
            {
                return availablity;
            }
            set
            {
                availablity = value;
            }
        }
        public int AddRating
        {
            set { rating_list.Add(value); }
            get { return rating_list.Count; }
        }

        public double GetRating()
        {
            int sum = 0;
            foreach (var rating in rating_list)
            {
                sum += rating;
            }
            return sum / rating_list.Count;
        }
        public int Driver_id
        {
            set
            {
                ID = value;
            }
            get
            {
                return ID;
            }
        }
       public vehicle DriverVehicle
        {
            get
            {
                return driver_vehicle;
            }
            set
            {
                driver_vehicle = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return phone_no;
            }
            set
            {
                phone_no = value;
            }
        }
       public string Name
       {
            get { return name; }
            set { name = value; }
       }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
            }
        }
        public Location CurrentLocation
        {
            set
            {
                curr_location = value;
            }
            get
            {
                return curr_location;
            }
        }
        public void UpdateAvailability()
        {
            if (availablity == true)
                availablity = false;
            else
                availablity = true;
        }
        public void UpdateLocation(double latitude, double longitude)
        {
            curr_location= new Location();
            curr_location.setLocation(latitude, longitude);
              
        }
    }
}
