using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A6
{
    // ----------------------------------------- ( EXAMPLE 01 ) ------------------------- 
    // factory class or creator class 
    // creating and return the instance of class
    // based on some paramter to a function


    // Abstract class / super interface / product interface
    public interface ICreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }

    // subclasses / concrete class / product class
    // implements interface ICreditCard
    public class SadaPay : ICreditCard
    {
        public string GetCardType()
        {
            return "SadaPay";
        }
        public int GetCreditLimit()
        {
            return 15000;
        }
        public int GetAnnualCharge()
        {
            return 500;
        }
        
    }

    public class NayaPay : ICreditCard
    {
        public string GetCardType()
        {
            return "NayaPay";
        }
        public int GetCreditLimit()
        {
            return 25000;
        }
        public int GetAnnualCharge()
        {
            return 1500;
        }
    }

    public class PakPay : ICreditCard
    {
        public string GetCardType()
        {
            return "PakPay";
        }
        public int GetCreditLimit()
        {
            return 35000;
        }
        public int GetAnnualCharge()
        {
            return 2000;
        }
    }

    // Factory or Creator class that
    // creating and returning the required instance of
    // product class or concrete class (type ICreditCard)
    // based on client needs
    public class CreditCardFactory
    {
        public static ICreditCard GetCreditCard(string cardType)
        {
            ICreditCard cardDetails = null;
            if (cardType == "SadaPay")
            {
                cardDetails = new SadaPay();
            }
            else if (cardType == "NayaPay")
            {
                cardDetails = new NayaPay();
            }
            else if (cardType == "PakPay")
            {
                cardDetails = new PakPay();
            }
            return cardDetails;
        }
    }

    // ----------------------------------------- ( EXAMPLE 02 ) ------------------------- 
    // Each concrete class has its own
    // factory class that return the instance of
    // current class

    // Product interface
    // super class
    // abstract class
    // base class
    public interface IShape
    {
        void Draw();
    }

    // Concrete Products
    // derived class
    // implements classes
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Circle");
        }
    }

    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Square");
        }
    }

    // Creator interface
    // return the instance of type IShape
    public interface IShapeFactory
    {
        IShape CreateShape();
    }

    // Concrete Creators class
    // factory / creator class 
    // for Circle (concrete class)
    public class CircleFactory : IShapeFactory
    {
        public IShape CreateShape()
        {
            return new Circle();
        }
    }

    // Concrete Creators
    // factory / creator class 
    // for Sqaure (concrete class)
    public class SquareFactory : IShapeFactory
    {
        public IShape CreateShape()
        {
            return new Square();
        }
    }

}
