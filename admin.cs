using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using System.Diagnostics;
using System.Xml.Linq;

using driver_class;
using vehicle_class;

namespace admin_class
{
    public class Admin
    {
        public List<driver> listOfDrivers;

        public Admin()
        {
            listOfDrivers = new List<driver>();
        }

        public void AddDriver()
        {
            driver _driver = new driver();


            Console.Write("Enter Driver ID : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            _driver.Driver_id = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            Console.Write("Enter Name : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            _driver.Name = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Enter Age : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            _driver.Age = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            Console.Write("Enter Gender : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            _driver.Gender = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Enter Address : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            _driver.Address = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Enter vehicle Type : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            _driver.DriverVehicle.Type = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Enter vehicle Model : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            _driver.DriverVehicle.Model = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Enter vehicle Liscense Plate : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            _driver.DriverVehicle.Liscense_plate = Console.ReadLine();
            Console.ResetColor();

            listOfDrivers.Add(_driver);
        }
        public void UpdatDriver()
        {            
            Console.Write("Enter Driver ID to Update Driver: ");
            Console.ForegroundColor  = ConsoleColor.DarkGreen;
            
            int id = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            for (int i = 0; i < listOfDrivers.Count; i++)
            {
                if (id == listOfDrivers[i].Driver_id)
                {
                    Console.WriteLine("-----------------Driver with ID " + listOfDrivers[i].Driver_id + " Exist--------------------");

                    Console.Write("Enter Name : ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    listOfDrivers[i].Name = Console.ReadLine();
                    Console.ResetColor();


                    Console.Write("Enter Age : ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    string age = Console.ReadLine();
                    Console.ResetColor();

                    if (age.Length != 0)
                        listOfDrivers[i].Age = Convert.ToInt32(age);

                    Console.Write("Enter Gender : ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    listOfDrivers[i].Gender = Console.ReadLine();
                    Console.ResetColor();

                    Console.Write("Enter Address : ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    listOfDrivers[i].Address = Console.ReadLine();
                    Console.ResetColor();


                    Console.Write("Enter vehicle Type : ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    listOfDrivers[i].DriverVehicle.Type = Console.ReadLine();
                    Console.ResetColor();


                    Console.Write("Enter vehicle Model : ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    listOfDrivers[i].DriverVehicle.Model = Console.ReadLine();
                    Console.ResetColor();


                    Console.Write("Enter vehicle Liscense Plate : ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    listOfDrivers[i].DriverVehicle.Liscense_plate = Console.ReadLine();
                    Console.ResetColor();


                    Console.WriteLine("********** Driver Updated Successflly.");


                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("********** Driver Not Found!");
                    Console.ResetColor();
                }
            }
        }
        public void RemoveDriver()
        {
            Console.WriteLine("Enter Driver ID to Remove Driver: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int id = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            for (int i = 0; i < listOfDrivers.Count; i++)
            {
                if (id == listOfDrivers[i].Driver_id)
                {
                    listOfDrivers.Remove(listOfDrivers[i]);
                }
            }
        }


        // helper function used in SearchDriver() to show Data
        private void ShowData(int[] arr, int size)
        {
            // if the list of drivers is empty or passing array size is 0
            if (size == 0 || listOfDrivers.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOops!!No Data Found");
                Console.ResetColor();
                return;

            }
            Console.WriteLine("\n\n\n---------------------------------------------------------------------------------------------------");
            Console.WriteLine("Name\t\tAge\t\tGender\t\tV_type\t\tV_Model\t\tV_Liscense\n");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOops!!No Data Found");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{listOfDrivers[arr[i]].Name}\t\t{listOfDrivers[arr[i]].Age}\t\t{listOfDrivers[arr[i]].Gender}\t\t{listOfDrivers[arr[i]].DriverVehicle.Type}\t\t{listOfDrivers[arr[i]].DriverVehicle.Model}\t\t{listOfDrivers[arr[i]].DriverVehicle.Liscense_plate}");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------\n");
                }
            }
        }
        
        public void SearchDriver()
        {
            Console.Write("HOW MANY DRIVERS YOU WANT TO SEARCH: ");
            int searchCount = Convert.ToInt32(Console.ReadLine());

            int[] SearchArray = new int[searchCount];
            for (int i = 0; i < searchCount; i++)
            {
                SearchArray[i] = -1;
            }

            // counts when the input field is not empty
            int count_out = 0;
            for (int i = 0; i < searchCount; i++)
            {
                Console.Write("Enter Driver ID: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string id = Console.ReadLine();
                Console.ResetColor();
                if (id.Length != 0)
                    count_out++;
                else
                    id = "0";

                // agar kuch diya ha count_out ++
                Console.Write("Enter Name: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string name = Console.ReadLine();
                Console.ResetColor();
                if (name.Length != 0)
                    count_out++;
                else
                    name = " ";

                Console.Write("Enter Age: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string age = Console.ReadLine();
                Console.ResetColor();
                if (age.Length != 0)
                    count_out++;
                else
                    age = "0";

                Console.Write("Enter Gender: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string gender = Console.ReadLine();
                Console.ResetColor();
                if (gender.Length != 0)
                    count_out++;
                else
                    gender = " ";

                Console.Write("Enter Address: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string address = Console.ReadLine();
                Console.ResetColor();
                if (address.Length != 0)
                    count_out++;
                else
                    address = " ";

                Console.Write("Enter vehicle Type: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string v_type = Console.ReadLine();
                Console.ResetColor();
                if (v_type.Length != 0)
                    count_out++;
                else
                    v_type = " ";

                Console.Write("Enter vehicle Model: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string v_model = Console.ReadLine();
                Console.ResetColor();
                if (v_model.Length != 0)
                    count_out++;
                else
                    v_model = " ";

                Console.Write("Enter Liscense Plate Number: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string plate = Console.ReadLine();
                Console.ResetColor();
                if (plate.Length != 0)
                    count_out++;
                else
                    plate = " ";

                for (int j = 0; j < listOfDrivers.Count; j++)
                {


                    if (int.Parse(id) == listOfDrivers[j].Driver_id)
                    {
                        SearchArray[i] = j;
                        break;
                    }
                    else if (int.Parse(age) == listOfDrivers[j].Age)
                    {
                        SearchArray[i] = j;
                        break;

                    }
                    else if (name == listOfDrivers[j].Name)
                    {
                        SearchArray[i] = j;
                        break;

                    }
                    else if (gender == listOfDrivers[j].Gender)
                    {
                        SearchArray[i] = j;
                        break;

                    }
                    else if (address == listOfDrivers[j].Address)
                    {
                        SearchArray[i] = j;
                        break;

                    }
                    else if (v_type == listOfDrivers[j].DriverVehicle.Type)
                    {
                        SearchArray[i] = j;
                        break;

                    }
                    else if (v_model == listOfDrivers[j].DriverVehicle.Model)
                    {
                        SearchArray[i] = j;
                        break;

                    }
                    else if (plate == listOfDrivers[j].DriverVehicle.Liscense_plate)
                    {
                        SearchArray[i] = j;
                        break;
                    }
                }
            }
            ShowData(SearchArray, searchCount);

        }
    }
}
