using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using System.Diagnostics;
using System.Xml.Linq;


// required libraries

using driver_class;
using passenger_class;
using admin_class;
using location_class;
using vehicle_class;
using ride_class;
using System.Net;
using System.Xml.Serialization;

namespace my_ride_application
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            Admin adminObject = new Admin();
            passenger _passenger = new passenger();
            driver Driver = new driver();
            ride rideObject = new ride();
            vehicle newVechicle = new vehicle();
            Location start_location = new Location();
            Location end_location = new Location();

            int option;
            while (true)
            {
                do
                {
                    Console.WriteLine("\t\t\t---------------------------------------------------------------------------");
                    Console.WriteLine("\t\t\t                            Welcome to MYRIDE");
                    Console.WriteLine("\t\t\t---------------------------------------------------------------------------");
                    Console.WriteLine("Main Menu :");
                    Console.WriteLine("\n\n1. Book Ride\n2. Enter as Driver\n3. Enter as Admin\n4. Exit From MyRIDE");
                    Console.Write("\nPress 1 to 4 to select an option : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    option = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    if (option < 1 || option > 4)
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("\nOops!! wrong input! Try Again");
                        Console.ResetColor();
                    }
                    else break;
                } while (option < 1 || option > 4);

                switch (option)
                {
                    // Book a Ride
                    case 1:
                        {
                            // passenger details

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\n\nBook a Ride");
                            Console.ResetColor();

                            Console.Write("\nEnter Name : ");

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            _passenger.Name = Console.ReadLine();
                            Console.ResetColor();

                            Console.Write("Enter PhoneNo : ");

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            _passenger.PhoneNo = Console.ReadLine();
                            Console.ResetColor();

                            rideObject.AssignPassenger(_passenger);

                            // location details

                            Console.Write("Enter Start location: ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            double start_latitude, start_longitude;

                            string[] start_values = Console.ReadLine().Split(',');
                            Console.ResetColor();
                            if (start_values.Length == 2)
                            {
                                start_latitude = double.Parse(start_values[0]);
                                start_longitude = double.Parse(start_values[1]);
                            }
                            else
                                break;

                            double end_latitude, end_longitude;
                            Console.Write("Enter End location: ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;                          
                            string[] end_values = Console.ReadLine().Split(',');
                            Console.ResetColor();
                            if (end_values.Length == 2)
                            {
                                end_latitude = double.Parse(end_values[0]);
                                end_longitude = double.Parse(end_values[1]);
                            }
                            else break;

                            // ride details
                            rideObject.rideType();

                            Console.WriteLine("\n\n----------------Thank You----------------\n");
                            Console.Write("Enter (Y/y) if You want to book the ride or other to cancel: ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            char choice = char.Parse(Console.ReadLine());
                            Console.ResetColor();

                            if (choice == 'Y' || choice == 'y')
                            {
                                // start location
                                start_location.setLocation(start_latitude, start_longitude);
                                // end location
                                end_location.setLocation(end_latitude, end_longitude);
                                // ride 
                                rideObject.Setlocation(start_location, end_location);

                                Console.Write("\nPrice of Ride : " + rideObject.CalculatePrice());
                                Console.WriteLine("\nHappy Travel!");
                                // give rating
                                rideObject.GiveRating();
                            }
                            else
                                Environment.Exit(0);
                            break;
                        }
                    // Enter as Driver
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\n\nDriver\n");
                            Console.ResetColor();
                            
                            Console.Write("Enter ID: ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Driver.Driver_id = Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();

                            Console.Write("Enter Name : ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Driver.Name = Console.ReadLine();
                            Console.ResetColor();

                            bool isFound = false;

                            for (int i = 0; i < adminObject.listOfDrivers.Count; i++)
                            {
                                if (Driver.Driver_id == adminObject.listOfDrivers[i].Driver_id)
                                {
                                    Console.Write("Hello ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine(adminObject.listOfDrivers[i].Name);
                                    Console.ResetColor();

                                    isFound = true;
                                    Driver.Availability = true;
                                    break;
                                }
                            }
                            if (isFound == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n********** Oops!!Driver Not Found : \n\n");
                                Console.ResetColor();
                                break;
                            }
                            else
                            {

                                Console.Write("\nEnter Your Current Location: ");

                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                string[] start_values = Console.ReadLine().Split(',');
                                double first = double.Parse(start_values[0]);
                                double second = double.Parse(start_values[1]);
                                Driver.CurrentLocation.setLocation(first, second);
                                Console.ResetColor();

                                Console.WriteLine("Current Location Of Driver : " + Driver.CurrentLocation.Latitude + "," + Driver.CurrentLocation.Longitude);
                                Console.WriteLine("1. Change Availability\n2. Change Location\n3. Exit as Driver");
                                Console.ForegroundColor= ConsoleColor.DarkGreen;
                                int driver_option = Convert.ToInt32(Console.ReadLine());
                                Console.ResetColor();
                                switch (driver_option)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("********** Changing Availability Status...");
                                            Driver.UpdateAvailability();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("********** Updatating Current Location...");
                                            Driver.UpdateLocation(first, second);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("********** Exiting as Driver...");
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                        // Enter as ADMIN
                    case 3:
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\n\nADMIN");
                            Console.ResetColor();

                            Console.WriteLine("\nChoose ADMIN Option : ");
                            Console.WriteLine("\n1.Add Driver\n2.Remove Driver\n3.Update Driver\n4.Search Driver\n5.Exit as Admin");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            int option_admin = Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();
                            switch (option_admin)
                            {
                                case 1:

                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n********** Adding Driver **********\n");
                                        Console.ResetColor();
                                        adminObject.AddDriver();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n********** Driver Added Successflly **********");
                                        Console.ResetColor();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n********** Removing a Driver **********\n");
                                        Console.ResetColor();
                                        adminObject.RemoveDriver();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n********** Driver Remove Successflly **********");
                                        Console.ResetColor();
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n********** Updating Driver **********\n");
                                        Console.ResetColor();
                                        adminObject.UpdatDriver();
                                        break;
                                    }
                                case 4:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n********** Searching Driver **********\n");
                                        Console.ResetColor();
                                        adminObject.SearchDriver();
                                        break;
                                    }
                                case 5:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("Exiting as Admin...");
                                        Console.ResetColor();
                                        break;
                                    }
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.ForegroundColor= ConsoleColor.DarkGray;
                            Console.WriteLine("\n...Exiting From Main Menu...\n\n\n\n\n");
                            Console.ResetColor();
                            return;
                        }
                }

            }
        }
    }
}
