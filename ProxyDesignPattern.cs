using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A7
{
    // *************************************** EXAMPLE  01
    // Virtual Proxy

    // Subject Interface
    public interface Image
    {
        void Display();
    }

    // Real Subject - Loads the image (heavy operation)
    public class RealImage : Image
    {
        private string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            LoadImageFromDisk();
        }

        private void LoadImageFromDisk()
        {
            Console.WriteLine("Loading " + fileName);
        }

        public void Display()
        {
            Console.WriteLine("Displaying " + fileName);
        }
    }

    // Proxy - Controls access to RealImage (loads only when required)
    public class ProxyImage : Image
    {
        private RealImage realImage;
        private string fileName;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.Display();
        }
    }

    // *************************************** EXAMPLE  02
    // Protection proxy

    // Subject Interface
    public interface IBankAccount
    {
        void WithdrawMoney(int amount);
    }

    // Real Subject - Represents a bank account
    public class BankAccount : IBankAccount
    {
        public void WithdrawMoney(int amount)
        {
            Console.WriteLine($"Withdrawing ${amount} from the bank account");
        }
    }

    // Proxy - Controls access to BankAccount based on user role
    public class BankAccountProxy : IBankAccount
    {
        private BankAccount bankAccount = new BankAccount();
        private string userRole;

        public BankAccountProxy(string userRole)
        {
            this.userRole = userRole;
        }

        public void WithdrawMoney(int amount)
        {
            if (userRole == "admin")
            {
                bankAccount.WithdrawMoney(amount);
            }
            else
            {
                Console.WriteLine("Access denied. Insufficient privileges.");
            }
        }
    }

}
