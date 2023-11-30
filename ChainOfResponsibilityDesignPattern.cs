using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    // ****************************************  Example 01 *******************************************
    // Handler interface
    interface IWithdrawalHandler
    {
        void SetNextHandler(IWithdrawalHandler handler);
        void HandleRequest(int amount);
    }

    // Concrete handler
    class FiftyHandler : IWithdrawalHandler
    {
        private IWithdrawalHandler nextHandler;

        public void SetNextHandler(IWithdrawalHandler handler)
        {
            nextHandler = handler;
        }

        public void HandleRequest(int amount)
        {
            if (amount >= 50)
            {
                int num = amount / 50;
                int remainder = amount % 50;
                Console.WriteLine($"Dispensing {num} x $50 notes");
                if (remainder > 0 && nextHandler != null)
                {
                    nextHandler.HandleRequest(remainder);
                }
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleRequest(amount);
            }
        }
    }

    class TwentyHandler : IWithdrawalHandler
    {
        private IWithdrawalHandler nextHandler;

        public void SetNextHandler(IWithdrawalHandler handler)
        {
            nextHandler = handler;
        }

        public void HandleRequest(int amount)
        {
            if (amount >= 20)
            {
                int num = amount / 20;
                int remainder = amount % 20;
                Console.WriteLine($"Dispensing {num} x $20 notes");
                if (remainder > 0 && nextHandler != null)
                {
                    nextHandler.HandleRequest(remainder);
                }
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleRequest(amount);
            }
        }
    }

    // Client code
    class ATM
    {
        private readonly IWithdrawalHandler withdrawalHandler;

        public ATM()
        {
            FiftyHandler fiftyHandler = new FiftyHandler();
            TwentyHandler twentyHandler = new TwentyHandler();

            fiftyHandler.SetNextHandler(twentyHandler);

            withdrawalHandler = fiftyHandler;
        }

        public void Withdraw(int amount)
        {
            Console.WriteLine($"Requesting withdrawal of ${amount}");
            withdrawalHandler.HandleRequest(amount);
        }
    }
}

// ****************************************  Example 02 *******************************************

// Handler interface
interface ILeaveHandler
{
    void SetNextHandler(ILeaveHandler handler);
    void HandleRequest(int days);
}

// Concrete handler
class Supervisor : ILeaveHandler
{
    private ILeaveHandler nextHandler;

    public void SetNextHandler(ILeaveHandler handler)
    {
        nextHandler = handler;
    }

    public void HandleRequest(int days)
    {
        if (days <= 2)
        {
            Console.WriteLine($"Leave approved by Supervisor for {days} days.");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(days);
        }
        else
        {
            Console.WriteLine("Leave request denied.");
        }
    }
}

class Manager : ILeaveHandler
{
    private ILeaveHandler nextHandler;

    public void SetNextHandler(ILeaveHandler handler)
    {
        nextHandler = handler;
    }

    public void HandleRequest(int days)
    {
        if (days <= 5)
        {
            Console.WriteLine($"Leave approved by Manager for {days} days.");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(days);
        }
        else
        {
            Console.WriteLine("Leave request denied.");
        }
    }
}

// Client code
class Employee
{
    private readonly ILeaveHandler leaveHandler;

    public Employee()
    {
        Supervisor supervisor = new Supervisor();
        Manager manager = new Manager();

        supervisor.SetNextHandler(manager);

        leaveHandler = supervisor;
    }

    public void RequestLeave(int days)
    {
        Console.WriteLine($"Requesting leave for {days} days.");
        leaveHandler.HandleRequest(days);
    }
}