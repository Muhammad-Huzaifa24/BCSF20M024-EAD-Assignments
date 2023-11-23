using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A7
{
    // *************************************** EXAMPLE  01
    // Subsystem components
    public class Amplifier
    {
        public void On()
        {
            Console.WriteLine("Amplifier is on");
        }

        public void SetVolume(int level)
        {
            Console.WriteLine($"Setting volume to {level}");
        }
    }

    public class DVDPlayer
    {
        public void Play(string movie)
        {
            Console.WriteLine($"Playing {movie}");
        }
    }

    public class Projector
    {
        public void On()
        {
            Console.WriteLine("Projector is on");
        }

        public void WideScreenMode()
        {
            Console.WriteLine("Projector is in widescreen mode");
        }
    }

    // Facade - Home Theater
    public class HomeTheaterFacade
    {
        private Amplifier amp;
        private DVDPlayer dvd;
        private Projector projector;

        public HomeTheaterFacade()
        {
            amp = new Amplifier();
            dvd = new DVDPlayer();
            projector = new Projector();
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            amp.On();
            amp.SetVolume(7);
            projector.On();
            projector.WideScreenMode();
            dvd.Play(movie);
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting down the home theater...");
            amp.SetVolume(0);
            amp.On(); // Could include further operations for shutdown
            projector.On(); // Could include further operations for shutdown
        }


    }

    // *************************************** EXAMPLE  02
    // Online Shopping Facade

    // Subsystem components
    public class InventorySystem
    {
        public bool IsAvailable(string product)
        {
            // Check inventory for product availability
            return true; // Simulating availability
        }
    }

    public class PaymentSystem
    {
        public void ProcessPayment(string product, decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} for {product}");
            // Process payment logic
        }
    }

    public class ShippingSystem
    {
        public void ShipProduct(string product)
        {
            Console.WriteLine($"Shipping {product}");
            // Shipping logic
        }
    }

    // Facade - Online Shopping
    public class OnlineShoppingFacade
    {
        private InventorySystem inventory;
        private PaymentSystem payment;
        private ShippingSystem shipping;

        public OnlineShoppingFacade()
        {
            inventory = new InventorySystem();
            payment = new PaymentSystem();
            shipping = new ShippingSystem();
        }

        public void PurchaseItem(string product, decimal amount)
        {
            if (inventory.IsAvailable(product))
            {
                payment.ProcessPayment(product, amount);
                shipping.ShipProduct(product);
                Console.WriteLine($"Purchase of {product} successful!");
            }
            else
            {
                Console.WriteLine($"{product} is out of stock.");
            }
        }
    }
}
