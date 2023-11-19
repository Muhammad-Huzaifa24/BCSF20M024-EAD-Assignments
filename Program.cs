using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BCSF20M024_EAD_A6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //---------------------------(Singleton Pattern)---------------------------------
            // ************* (Example 1) 

            /*

            // this statement initiate instance of Singleton
            Singleton s = Singleton.GetInstance();

            // this statement can not becoz the instance already created
            Singleton s1 = Singleton.GetInstance();

            */



            // ************* (Example 2) 

            // only one thread of the following will
            // instantiate the instance and set the value of prop (Id) ,
            // other will get blocked and
            // will not create other instance 

            /*
             
            Thread t1 = new Thread( ()=> {
                ThreadSafeSingleton.GetInstance(1);
            });
            Thread t2 = new Thread(() => {
                ThreadSafeSingleton.GetInstance(2);
            });
            Thread t3 = new Thread(() => {
                ThreadSafeSingleton.GetInstance(3);
            });

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            */



            //---------------------------(Factory Pattern)---------------------------------

            // ************* (Example 1) 

            /*
            ICreditCard cardDetails = CreditCardFactory.GetCreditCard("PakPay");

            if (cardDetails != null)
            {
                Console.WriteLine("CardType : " + cardDetails.GetCardType());
                Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
                Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.ReadLine();
            */


            // ************* (Example 2) 

            /*
            IShapeFactory circleFactory = new CircleFactory();
            IShape circle = circleFactory.CreateShape();
            circle.Draw(); // circle

            IShapeFactory squareFactory = new SquareFactory();
            IShape square = squareFactory.CreateShape();
            square.Draw(); // Square
            */

            //---------------------------(Abstract Factory Pattern)---------------------------------

            // ************* (Example 1) 


            // using interfaces for
            // each concrete factory class

            /*

            IVehicleFactory regularVehicleFactory = new RegularVehicleFactory();
            IBike regularBike = regularVehicleFactory.CreateBike();
            regularBike.GetDetails(); // Regular bike

            IVehicleFactory sportsVehicleFactory = new SportsVehicleFactory();
            ICar sportsCar = sportsVehicleFactory.CreateCar();
            sportsCar.GetDetails(); // Sports car

            */

            // ************* (Example 2) 


            // using abstract classes for
            // each concrete factory class

            /*
            FurnitureFactory moderFurnitureFactory = new ModernFurnitureFactory();
            Chair modernChair = moderFurnitureFactory.CreateChair();
            modernChair.SitOn(); // modern chair furniture

            FurnitureFactory vectorianFurnitureFactory = new VictorianFurnitureFactory();
            Table vectorianTable = vectorianFurnitureFactory.CreateTable();
            vectorianTable.PutOn(); // victorian chair furniture 
            */


            //---------------------------(Builder Design Pattern)---------------------------------

            // ************* (Example 1)

            // using builder and director classes

            /*
             
            // Creating a PDF report
            IReportBuilder pdfBuilder = new PDFReportBuilder();
            ReportDirector pdfDirector = new ReportDirector(pdfBuilder);

            // Constructing PDF report
            pdfDirector.Construct();
            PDFReport pdfReport = (PDFReport)pdfBuilder.GetReport();

            // Displaying PDF report details
            Console.WriteLine("PDF Report Details:");
            Console.WriteLine($"Header: {pdfReport.Header}");
            Console.WriteLine($"Body:   {pdfReport.Body}");
            Console.WriteLine($"Title:  {pdfReport.Title}");
            Console.WriteLine($"Data:   {pdfReport.Data}");

            */


            // ************* (Example 2) 

            // using fluent builder 

            /*
            var pdfReport = new FluentReportBuilder()
                .ForPDFReport()
                .SetHeader("PDF Header")
                .SetBody("PDF Body")
                .SetTitle("PDF Title")
                .SetData("PDF Data");
               
            pdfReport.DisplayPDFReport();
            */


            //---------------------------(Prototype Design Pattern)---------------------------------

            // ************* (Example 1)

            // cloning object 
            // shallow copy

            /*
             
            // Creating an Instance of
            // Permanent Employee Class
            Employee emp1 = new PermanentEmployee()
            {
                Name = "Anurag",
                Department = "IT",
                Type = "Permanent",
                Salary = 100000
            };

            //Creating a Clone of the above
            //Permanent Employee
            Employee emp2 = emp1.GetClone();

            // Changing the Name and Department Property Value of emp2 instance, 
            // will not change the Name and Department Property Value of the emp1 instance
            emp2.Name = "Pranaya";
            emp2.Department = "HR";
            emp1.ShowDetails(); // show details of emp1
            emp2.ShowDetails(); // show details of emp2

            // Creating an Instance of
            // Temporary Employee Class
            Employee emp3 = new TemporaryEmployee()
            {
                Name = "Preety",
                Department = "HR",
                Type = "Temporary",
                FixedAmount = 200000
            };

            //Creating a Clone of the above
            //Temporary Employee
            Employee emp4 = emp3.GetClone();

            // Changing the Name and Department Property Value of emp4 instance, 
            // will not change the Name and Department Property Value of the emp3 instance
            emp4.Name = "Priyanka";
            emp4.Department = "Sales";
            emp3.ShowDetails();
            emp4.ShowDetails();

            */


            // ************* (Example 2) 

            // cloning object 
            // deep copy

            /*
             
            // Create an original person
            var originalPerson = new Person("Alice", new List<string> { "Reading", "Hiking" });

            // Perform deep copy to create a new person
            var clonedPerson = (Person)originalPerson.DeepCopy();

            // Modify the cloned person's hobbies
            clonedPerson.Hobbies.Add("Painting");

            // Print details of both original and cloned persons
            Console.WriteLine("- - - - - Original Person:");
            originalPerson.PrintDetails();

            Console.WriteLine("\n- - - - - Cloned Person:");
            clonedPerson.PrintDetails();

            */
        }

    }
}
