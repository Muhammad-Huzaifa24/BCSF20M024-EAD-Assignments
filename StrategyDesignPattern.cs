using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    // ****************************************  Example 01 *******************************************

    // Strategy interface
    interface ISortStrategy
    {
        void Sort(int[] array);
    }

    // Concrete strategies
    class BubbleSort : ISortStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Sorting using Bubble Sort");
            // Actual Bubble Sort algorithm implementation
            // ...
        }
    }

    class QuickSort : ISortStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Sorting using Quick Sort");
            // Actual Quick Sort algorithm implementation
            // ...
        }
    }

    // Context class
    class Sorter
    {
        private ISortStrategy sortStrategy;

        public void SetSortStrategy(ISortStrategy strategy)
        {
            sortStrategy = strategy;
        }

        public void Sort(int[] array)
        {
            sortStrategy.Sort(array);
        }
    }

    // ****************************************  Example 02 *******************************************

    // Strategy interface
    interface IPaymentMethod
    {
        void ProcessPayment(double amount);
    }

    // Concrete strategies
    class CreditCardPayment : IPaymentMethod
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount}");
            // Actual credit card payment processing logic
            // ...
        }
    }

    class PayPalPayment : IPaymentMethod
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount}");
            // Actual PayPal payment processing logic
            // ...
        }
    }

    // Context class
    class PaymentProcessor
    {
        private IPaymentMethod paymentMethod;

        public void SetPaymentMethod(IPaymentMethod method)
        {
            paymentMethod = method;
        }

        public void MakePayment(double amount)
        {
            paymentMethod.ProcessPayment(amount);
        }
    }
}
