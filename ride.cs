using admin_class;
using driver_class;
using location_class;
using passenger_class;
using System;

namespace ride_class
{
    public class ride
    {
        // attributes
        private Location start_location;
        private Location end_location;
        private double price;
        private passenger Passenger;
        private driver _driver;

        // constructor
        public ride()
        {
            _driver = new driver();
            start_location = new Location();
            end_location = new Location();
            Passenger = new passenger();
            price = 0.0;
        }

        // properties
        public driver AssignedDriver
        {
            get { return _driver; }
            set { _driver = value; }
        }
        public passenger AssignedPassenger
        {
            get
            {
                return Passenger;
            }
            set
            {
                Passenger = value;
            }
        }
        
        public Location StartLocation
        {
            set { start_location = value; }
            get { return start_location; }
        }
        public Location EndLocation
        {
            get { return end_location; }
            set { end_location = value; }
        }

        // Functions
        public void GiveRating()
        {
            Console.Write("Give Rating Out of 5  :");
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            _driver.AddRating = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

        }
        public void Setlocation(Location start, Location end)
        {
            start_location = start;
            end_location = end;
        }

        public void AssignPassenger(passenger passengerObject)
        {
            this.AssignedPassenger = passengerObject;
        }
        public void AsssignDriver(Admin adminObject)
        {
            // finding the minimum distance of driver
            double x1 = adminObject.listOfDrivers[0].CurrentLocation.Latitude;
            double x2 = this.start_location.Latitude;
            double y1 = adminObject.listOfDrivers[0].CurrentLocation.Longitude;
            double y2 = this.start_location.Longitude;

            double distance_min = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));

            for (int i = 1; i < adminObject.listOfDrivers.Count; i++)
            {
                if (adminObject.listOfDrivers[i].Availability)
                {
                    double a1 = adminObject.listOfDrivers[i].CurrentLocation.Latitude;
                    double a2 = this.start_location.Latitude;
                    double b1 = adminObject.listOfDrivers[i].CurrentLocation.Longitude;
                    double b2 = this.start_location.Longitude;

                    double newDistance = Math.Sqrt(Math.Pow((a2 - a1), 2) + Math.Pow((b2 - b1), 2));

                    if (distance_min < newDistance)
                    {
                        this.AssignedDriver = adminObject.listOfDrivers[i];
                        break;
                    }
                }
            }
        }

        public void rideType()
        {
            Console.Write("Enter Ride Type : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            _driver.VechicleType = Console.ReadLine();
            Console.ResetColor();
        }
        public double CalculatePrice()
        {
            double x1 = start_location.Latitude;
            double x2 = end_location.Latitude;
            double y1 = start_location.Longitude;
            double y2 = end_location.Longitude;


            const int fuel_price = 270;
            double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));

            if (_driver.VechicleType == "bike")
            {
                price = (((distance * fuel_price) / 50.0) + 0.05);
            }
            else if (_driver.VechicleType == "rikshaw")
            {
                price = (((distance * fuel_price) / 35.0) + 0.1);
            }
            else if (_driver.VechicleType == "car")
            {
                price = (((distance * fuel_price) / 15.0) + 0.2);

            }
            return price;
        }
    }
}



