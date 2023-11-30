using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ******************** Template Design Pattern ********************

            /*
            // Example 01
            WoodenHouseBuilder woodenHouse = new WoodenHouseBuilder();
            woodenHouse.BuildHouse();

            Console.WriteLine("-------------------------");

            BrickHouseBuilder brickHouse = new BrickHouseBuilder();
            brickHouse.BuildHouse();

            // Example 02

            PastaRecipe pastaRecipe = new PastaRecipe();
            pastaRecipe.Cook();

            Console.WriteLine("-------------------------");

            CakeRecipe cakeRecipe = new CakeRecipe();
            cakeRecipe.Cook();

            */

            // ******************** Mediator Design Pattern ********************

            /*
             
            // Example 01
            ChatRoom chatRoom = new ChatRoom();

            User user1 = new User("Alice", chatRoom);
            User user2 = new User("Bob", chatRoom);
            User user3 = new User("Charlie", chatRoom);

            chatRoom.RegisterUser(user1);
            chatRoom.RegisterUser(user2);
            chatRoom.RegisterUser(user3);

            user1.SendMessage("Hello, everyone!");
            user2.SendMessage("Hey there!");
            user3.SendMessage("Hi!");

            // Example 02

            AirTrafficControl atc = new AirTrafficControl();

            Flight flight1 = new Flight("ABC123", atc);
            Flight flight2 = new Flight("XYZ789", atc);
            Flight flight3 = new Flight("DEF456", atc);

            atc.RegisterFlight(flight1);
            atc.RegisterFlight(flight2);
            atc.RegisterFlight(flight3);

            flight1.SendMessage("Requesting landing clearance");
            flight2.SendMessage("Confirming altitude change");
            flight3.SendMessage("Reporting turbulence ahead");
            */

            // ************* Chain of Responsibility Design Pattern ************

            /*
             
            // Example 01

            ATM atm = new ATM();
            atm.Withdraw(125);
            Console.WriteLine("-------------------------");
            atm.Withdraw(80);

            // Example 02

            Employee employee = new Employee();
            employee.RequestLeave(1);
            Console.WriteLine("-------------------------");
            employee.RequestLeave(3);
            Console.WriteLine("-------------------------");
            employee.RequestLeave(6);

            */

            // ******************** Observer Design Pattern ********************

            /*
            // Example 01

            Stock stock = new Stock("ABC", 100.0);

            Investor investor1 = new Investor("Alice");
            Investor investor2 = new Investor("Bob");

            stock.Attach(investor1);
            stock.Attach(investor2);

            stock.PriceChange(105.0);
            stock.PriceChange(98.0);

            // Example 02

            WeatherStation weatherStation = new WeatherStation();
            Display display = new Display();

            weatherStation.AddObserver(display);

            weatherStation.Temperature = 25.5;
            weatherStation.Temperature = 30.0;

            weatherStation.RemoveObserver(display);

            weatherStation.Temperature = 27.8;

            */

            // ******************** Strategy Design Pattern ********************

            /*
             
            // Example 01

            int[] data = { 7, 2, 5, 1, 9 };

            Sorter sorter = new Sorter();

            sorter.SetSortStrategy(new BubbleSort());
            sorter.Sort(data);

            Console.WriteLine("-------------------------");

            sorter.SetSortStrategy(new QuickSort());
            sorter.Sort(data);

            Console.WriteLine("\n\t\t***********\n");

            // Example 02

            PaymentProcessor processor = new PaymentProcessor();

            processor.SetPaymentMethod(new CreditCardPayment());
            processor.MakePayment(100.0);

            Console.WriteLine("-------------------------");

            processor.SetPaymentMethod(new PayPalPayment());
            processor.MakePayment(50.0);

            */

            // ******************** Command Design Pattern *********************

            /*
            // Example 01

            Light light = new Light();
            ICommand lightOn = new LightOnCommand(light);
            ICommand lightOff = new LightOffCommand(light);

            RemoteControl remote = new RemoteControl();

            remote.SetCommand(lightOn);
            remote.PressButton();

            remote.SetCommand(lightOff);
            remote.PressButton();

            // Example 02

            Clipboard clipboard = new Clipboard();
            IEditorCommand copy = new CopyCommand(clipboard);
            IEditorCommand paste = new PasteCommand(clipboard);

            TextEditor editor = new TextEditor();

            editor.SetCommand(copy);
            editor.ExecuteCommand();

            editor.SetCommand(paste);
            editor.ExecuteCommand();
            */

            // ******************** State Design Pattern *********************

            /*
            // Example 01

            TrafficLight trafficLight = new TrafficLight();

            trafficLight.ChangeLight(); // Red -> Green
            trafficLight.ChangeLight(); // Green -> Yellow
            trafficLight.ChangeLight(); // Yellow -> Red

            // Example 02

            TextEditor editor = new TextEditor();

            editor.Type("Hello World"); // Default case
            editor.SetState(new UpperCaseState());
            editor.Type("This should be in uppercase"); // Uppercase
            editor.SetState(new LowerCaseState());
            editor.Type("THIS SHOULD BE IN LOWERCASE"); // Lowercase
            */

            // ******************** Visitor Design Pattern *******************

            /*
            // Example 01

            List<IEmployee> employees = new List<IEmployee>
            {
            new FullTimeEmployee("Alice", 5000),
            new PartTimeEmployee("Bob", 15, 120)
            };

            SalaryCalculator calculator = new SalaryCalculator();

            foreach (var employee in employees)
            {
                employee.Accept(calculator);
            }

            // Example 02

            List<IProduct> products = new List<IProduct>
            {
            new Book("The Catcher in the Rye", 20),
            new Fruit("Apple", 2, 3.5),
            new Fruit("Banana", 1.5, 2.5)
            };

            ShoppingCartVisitor cartVisitor = new ShoppingCartVisitor();

            foreach (var product in products)
            {
                product.Accept(cartVisitor);
            }
            */

            // ****************** Interpreter Design Pattern *****************

            /*
            // Example 01

            // Context with variables and their values
            var context = new Dictionary<string, int>
            {
            { "x", 5 },
            { "y", 10 }
            };

            // Expression tree: x + y
            IExpression expression = new AdditionExpression(
                new NumberExpression("x"),
                new NumberExpression("y")
            );

            // Interpret the expression with the context
            int result = expression.Interpret(context);
            Console.WriteLine($"Result: {result}");


            // Example 02

            // Context with variables and their boolean values
            var context2 = new Dictionary<string, bool>
            {
            { "x", true },
            { "y", false }
            };

            // Expression tree: x AND y
            IBooleanExpression expression2 = new AndExpression(
                new VariableExpression("x"),
                new VariableExpression("y")
            );

            // Interpret the expression with the context
            bool result2 = expression2.Interpret(context2);
            Console.WriteLine($"Result: {result2}");
            */

            // ****************** Iterator Design Pattern ********************

            /*
            // Example 01

            CustomList<int> list = new CustomList<int>();
            list.AddItem(1);
            list.AddItem(2);
            list.AddItem(3);

            IIterator<int> iterator = list.GetIterator();

            while (iterator.HasNext())
            {
                int item = iterator.Next();
                Console.WriteLine(item);
            }
            Console.WriteLine("\n***********\n");
            // Example 02

            int[] numbers = { 1, 2, 3, 4, 5 };

            IEnumerator<int> iterator2 = new ArrayIterator<int>(numbers);

            while (iterator2.MoveNext())
            {
                int number = iterator2.Current;
                Console.WriteLine(number);

            }
            */

            // ****************** Memento Design Pattern *********************

            /*
            // Example 01

            MementoTextEditor editor = new MementoTextEditor();
            History history = new History();

            editor.Text = "Hello, World!";
            history.Memento = editor.Save();

            editor.Text = "Updated text";

            // Restore previous state
            editor.Restore(history.Memento);

            // Example 02

            Game game = new Game();
            GameHistory gameHistory = new GameHistory();

            game.Play(); // Play the game

            gameHistory.Memento = game.Save(); // Save the game state

            game.Play(); // Play more

            // Restore previous game state
            game.Restore(gameHistory.Memento);

            */



        }
    }
}
