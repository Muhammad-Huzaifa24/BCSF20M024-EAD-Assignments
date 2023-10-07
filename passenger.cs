using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using location_class;
using ride_class;
using driver_class;
using vehicle_class;

namespace passenger_class
{
    public class passenger
    {
        private string name;
        private string phone_no;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string PhoneNo
        {
            get { return phone_no; }
            set { phone_no = value; }
        }
       
    }
            
}
