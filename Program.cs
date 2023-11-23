using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ******************** (Adapter Design pattern) *******************************


            /*
             
            // class adapter
            IMediaPlayer mediaPlayer = new MediaAdapter();
            mediaPlayer.Play("mp3", "song.mp3"); // Outputs: Playing MP3: song.mp3
            mediaPlayer.Play("mp4", "video.mp4"); // Outputs: Invalid media type. Only MP3 is supported.
            
            // object adapter
            var paymentProcessor = new PaymentProcessor();
            var paymentProvider = new PaymentProviderAdapter(paymentProcessor);

            paymentProvider.MakePayment("C# design pattern course", 100.0m);

            */


            // ******************** (Composite Design pattern) *****************************

            /*
             
            // Example 01
            // File System Structure
            var root = new Directory("Root");
            var subDir1 = new Directory("SubDir1");
            var subDir2 = new Directory("SubDir2");

            var file1 = new File("File1.txt");
            var file2 = new File("File2.txt");

            root.AddComponent(subDir1);
            root.AddComponent(subDir2);
            root.AddComponent(file1);

            subDir1.AddComponent(file2);

            root.Print();

            // Example 02
            // Organization Structure

            var headDepartment = new Department("Head Office");
            var hrDepartment = new Department("HR Department");
            var financeDepartment = new Department("Finance Department");

            var employee1 = new Employee("John Doe");
            var employee2 = new Employee("Alice Smith");
            var employee3 = new Employee("Bob Johnson");

            hrDepartment.AddComponent(employee1);
            hrDepartment.AddComponent(employee2);
            financeDepartment.AddComponent(employee3);

            headDepartment.AddComponent(hrDepartment);
            headDepartment.AddComponent(financeDepartment);

            headDepartment.Display();

            */


            // ********************   (Proxy Design pattern) *******************************


            /*

            // EXAMPLE 01
            // Virtual Proxy

                Image image = new ProxyImage("example.jpg");

                // Image is loaded only when displayed
                image.Display();
                // This time, the image is already loaded and will display directly
                image.Display();

                // EXAMPLE 02
                // Protection Proxy

                IBankAccount userAccount = new BankAccountProxy("user");
                IBankAccount adminAccount = new BankAccountProxy("admin");

                // User tries to withdraw money
                userAccount.WithdrawMoney(100); // Outputs: Access denied. Insufficient privileges.

                // Admin withdraws money
                adminAccount.WithdrawMoney(100); // Outputs: Withdrawing $100 from the bank account
            */

            // ******************** (Flyweight Design pattern) *****************************

            /*
             
            // EXAMPLE 01
            // Text Formatting

            FontFactory factory = new FontFactory();

            // Shared fonts are reused
            IFont font1 = factory.GetFont("Arial");
            font1.SetFont("Arial", 12);
            font1.Print("Hello");

            IFont font2 = factory.GetFont("Times New Roman");
            font2.SetFont("Times New Roman", 14);
            font2.Print("World");

            IFont font3 = factory.GetFont("Arial");
            font3.SetFont("Arial", 12);
            font3.Print("Flyweight");


            // EXAMPLE 02
            // Gaming - Tree Models

            ITreeModel tree1 = TreeModelFactory.GetTreeModel();
            tree1.Render(10, 20);

            ITreeModel tree2 = TreeModelFactory.GetTreeModel();
            tree2.Render(30, 40);

            // Both trees share the same intrinsic state

            */

            // ********************  (Facade Design pattern) *******************************

            /*
             
            // Home Theater System
            // EXAMPLE 01


            HomeTheaterFacade homeTheater = new HomeTheaterFacade();

            homeTheater.WatchMovie("Inception");
            // Watching the movie...

            homeTheater.EndMovie();
            // Shutting down the home theater...


            // Online shopping facade
            // EXAMPLE 02

            OnlineShoppingFacade shoppingFacade = new OnlineShoppingFacade();

            shoppingFacade.PurchaseItem("Laptop", 1200.0m);
            // Processes payment, ships the product, and confirms the purchase.

            shoppingFacade.PurchaseItem("Smartphone", 899.0m);
            // Product is out of stock.
            */


            // ********************  (Bridge Design pattern) *******************************

            /*
            // EXAMPLE 01
            // Shape Rendering with different Colors

            IColor redColor = new RedColor();
            IColor blueColor = new BlueColor();

            Shape redCircle = new Circle(5, redColor);
            Shape blueRectangle = new Rectangle(3, 4, blueColor);

            Console.WriteLine(redCircle.Draw());
            Console.WriteLine(blueRectangle.Draw());


            // EXAMPLE 02
            // Remote Control Devices

            RemoteControl tvRemote = new TVRemote(new TV());
            RemoteControl radioRemote = new RadioRemote(new Radio());

            tvRemote.TurnOn();
            tvRemote.SetChannel(5);
            tvRemote.TurnOff();

            radioRemote.TurnOn();
            radioRemote.SetChannel(103.5);
            radioRemote.TurnOff();

            */

            // ******************** (Decorator design pattern) *****************************

            /*
             
            // EXAMPLE 01
            // Coffee Ordering System

            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine(coffee.GetDescription() + " - Cost: $" + coffee.GetCost());

            coffee = new MilkDecorator(coffee);
            Console.WriteLine(coffee.GetDescription() + " - Cost: $" + coffee.GetCost());

            coffee = new CaramelDecorator(coffee);
            Console.WriteLine(coffee.GetDescription() + " - Cost: $" + coffee.GetCost());

            // EXAMPLE 02
            // Pizza Ordering System

            IPizza pizza = new SimplePizza();
            Console.WriteLine(pizza.GetDescription() + " - Cost: $" + pizza.GetCost());

            pizza = new CheeseDecorator(pizza);
            Console.WriteLine(pizza.GetDescription() + " - Cost: $" + pizza.GetCost());

            pizza = new PepperoniDecorator(pizza);
            Console.WriteLine(pizza.GetDescription() + " - Cost: $" + pizza.GetCost());

            */



        }



    }


}

