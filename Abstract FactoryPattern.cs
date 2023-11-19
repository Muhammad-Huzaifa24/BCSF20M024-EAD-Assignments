using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A6
{

    // ----------------------------------------- ( EXAMPLE 01 ) ------------------------- 

    // interface product
    public interface IBike
    {
        void GetDetails();
    }

    // concrete product
    public class RegularBike : IBike
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching RegularBike Details..");
        }
    }
    // concrete product
    public class SportsBike : IBike
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching SportsBike Details..");
        }
    }

    // interface product
    public interface ICar
    {
        void GetDetails();
    }

    // concrete product
    public class RegularCar : ICar
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching RegularCar Details..");
        }
    }

    // concrete product
    public class SportsCar : ICar
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching SportsCar Details..");
        }
    }

    // Abstract Factory
    // Interface Factory
    // Factory of Factories
    public interface IVehicleFactory
    {
        //Abstract Product Bike
        IBike CreateBike();
        //Abstract Product Car
        ICar CreateCar();
    }

    // Same Variant (Regular) VECHICLE
    // Factories
    public class RegularVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new RegularBike();
        }
        public ICar CreateCar()
        {
            return new RegularCar();
        }
    }

    // Same Variant (Sports) VECHICLE
    // Factories
    public class SportsVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new SportsBike();
        }
        public ICar CreateCar()
        {
            return new SportsCar();
        }
    }

    // ----------------------------------------- ( EXAMPLE 02 ) ------------------------- 

    // Abstract Products/ class
    // for Chairs
    public abstract class Chair
    {
        public abstract void SitOn();
    }

    // Concrete Products/ class
    // for Chairs
    public class ModernChair : Chair
    {
        public override void SitOn()
        {
            Console.WriteLine("Sitting on a modern chair");
        }
    }

    public class VictorianChair : Chair
    {
        public override void SitOn()
        {
            Console.WriteLine("Sitting on a Victorian chair");
        }
    }

    // Abstract Products/class
    // for Tables
    public abstract class Table
    {
        public abstract void PutOn();
    }

    // Concrete Products/class
    // for Tables
    public class ModernTable : Table
    {
        public override void PutOn()
        {
            Console.WriteLine("Putting something on a modern table");
        }
    }

    public class VictorianTable : Table
    {
        public override void PutOn()
        {
            Console.WriteLine("Putting something on a Victorian table");
        }
    }

    // Abstract Factory
    public abstract class FurnitureFactory
    {
        public abstract Chair CreateChair();
        public abstract Table CreateTable();
    }

    // Concrete Factories (separate same variant)
    // for Modern Furniture
    // and Victorian Furniture
    public class ModernFurnitureFactory : FurnitureFactory
    {
        public override Chair CreateChair()
        {
            return new ModernChair();
        }

        public override Table CreateTable()
        {
            return new ModernTable();
        }
    }

    public class VictorianFurnitureFactory : FurnitureFactory
    {
        public override Chair CreateChair()
        {
            return new VictorianChair();
        }

        public override Table CreateTable()
        {
            return new VictorianTable();
        }
    }


}
