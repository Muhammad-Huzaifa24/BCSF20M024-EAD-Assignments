using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{

    // ****************************************  Example 01 *******************************************
    // Element interface
    interface IEmployee
    {
        void Accept(IVisitor visitor);
    }

    // Concrete elements
    class FullTimeEmployee : IEmployee
    {
        public string Name { get; set; }
        public double MonthlySalary { get; set; }

        public FullTimeEmployee(string name, double monthlySalary)
        {
            Name = name;
            MonthlySalary = monthlySalary;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class PartTimeEmployee : IEmployee
    {
        public string Name { get; set; }
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public PartTimeEmployee(string name, double hourlyRate, int hoursWorked)
        {
            Name = name;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Visitor interface
    interface IVisitor
    {
        void Visit(FullTimeEmployee employee);
        void Visit(PartTimeEmployee employee);
    }

    // Concrete visitor
    class SalaryCalculator : IVisitor
    {
        public void Visit(FullTimeEmployee employee)
        {
            double annualSalary = employee.MonthlySalary * 12;
            Console.WriteLine($"Full-time employee: {employee.Name}, Annual Salary: {annualSalary}");
        }

        public void Visit(PartTimeEmployee employee)
        {
            double annualSalary = employee.HourlyRate * employee.HoursWorked * 12;
            Console.WriteLine($"Part-time employee: {employee.Name}, Annual Salary: {annualSalary}");
        }
    }
}

// ****************************************  Example 02 *******************************************

// Element interface
interface IProduct
{
    void Accept(IShoppingCartVisitor visitor);
}

// Concrete elements
class Book : IProduct
{
    public string Title { get; set; }
    public double Price { get; set; }

    public Book(string title, double price)
    {
        Title = title;
        Price = price;
    }

    public void Accept(IShoppingCartVisitor visitor)
    {
        visitor.Visit(this);
    }
}

class Fruit : IProduct
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double PricePerKg { get; set; }

    public Fruit(string name, double weight, double pricePerKg)
    {
        Name = name;
        Weight = weight;
        PricePerKg = pricePerKg;
    }

    public void Accept(IShoppingCartVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Visitor interface
interface IShoppingCartVisitor
{
    void Visit(Book book);
    void Visit(Fruit fruit);
}

// Concrete visitor
class ShoppingCartVisitor : IShoppingCartVisitor
{
    public void Visit(Book book)
    {
        Console.WriteLine($"Book Title: {book.Title}, Price: {book.Price}");
    }

    public void Visit(Fruit fruit)
    {
        double totalPrice = fruit.Weight * fruit.PricePerKg;
        Console.WriteLine($"Fruit: {fruit.Name}, Total Price: {totalPrice}");
    }
}