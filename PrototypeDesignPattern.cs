using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A6
{
    // ----------------------------------------- ( EXAMPLE 01 ) ------------------------- 

    // prototype abstract class
    public abstract class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Type { get; set; }
        public abstract Employee GetClone();
        public abstract void ShowDetails();
    }

    // ConcretePrototype class 
    public class PermanentEmployee : Employee
    {
        public int Salary { get; set; }
        public override Employee GetClone()
        {
            // MemberwiseClone Method Creates a shallow copy of the current System.Object
            // So typecast the Object Appropriate Type
            // In this case, typecast to PermanentEmployee type
            return (PermanentEmployee)this.MemberwiseClone();
        }
        public override void ShowDetails()
        {
            Console.WriteLine("Permanent Employee");
            Console.WriteLine($" Name:{this.Name}, Department: {this.Department}, Type:{this.Type}, Salary: {this.Salary}\n");
        }
    }

    public class TemporaryEmployee : Employee
    {
        public int FixedAmount { get; set; }
        public override Employee GetClone()
        {
            // MemberwiseClone Method Creates a shallow copy of the current System.Object
            // So typecast the Object Appropriate Type
            // In this case, typecast to TemporaryEmployee type
            return (TemporaryEmployee)this.MemberwiseClone();
        }
        public override void ShowDetails()
        {
            Console.WriteLine("Temporary Employee");
            Console.WriteLine($" Name:{this.Name}, Department: {this.Department}, Type:{this.Type}, FixedAmount: {this.FixedAmount}\n");
        }
    }


    // ----------------------------------------- ( EXAMPLE 02 ) ------------------------- 

    // Prototype interface
    interface IDeepCopyable
    {
        object DeepCopy();
    }

    // concretePrototype
    class Person : IDeepCopyable
    {
        public string Name { get; set; }
        public List<string> Hobbies { get; set; }

        public Person(string name, List<string> hobbies)
        {
            Name = name;
            Hobbies = hobbies;
        }

        // Method to perform deep copy
        public object DeepCopy()
        {
            // Create a new Person object with a new list containing the same hobbies
            return new Person(Name, new List<string>(Hobbies));
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.Write("Hobbies: ");
            foreach (var hobby in Hobbies)
            {
                Console.Write($"{hobby} ");
            }
            Console.WriteLine();
        }
    }
}
