using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A7
{
    // *************************************** EXAMPLE  01
    // Coffee Ordering System

    // Component - Coffee
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    // Concrete Component - Basic Coffee
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple coffee";
        }

        public double GetCost()
        {
            return 1.0;
        }
    }

    // Decorator - Abstract class for condiments
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee decoratedCoffee;

        protected CoffeeDecorator(ICoffee coffee)
        {
            decoratedCoffee = coffee;
        }

        public virtual string GetDescription()
        {
            return decoratedCoffee.GetDescription();
        }

        public virtual double GetCost()
        {
            return decoratedCoffee.GetCost();
        }
    }

    // Concrete Decorator - Milk
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, with milk";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.5;
        }
    }

    // Concrete Decorator - Caramel
    public class CaramelDecorator : CoffeeDecorator
    {
        public CaramelDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, with caramel";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.7;
        }
    }

    // *************************************** EXAMPLE  02
    // Pizza Ordering System


    // Component - Pizza
    public interface IPizza
    {
        string GetDescription();
        double GetCost();
    }

    // Concrete Component - Basic Pizza
    public class SimplePizza : IPizza
    {
        public string GetDescription()
        {
            return "Simple pizza";
        }

        public double GetCost()
        {
            return 5.0;
        }
    }

    // Decorator - Abstract class for toppings
    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza decoratedPizza;

        protected PizzaDecorator(IPizza pizza)
        {
            decoratedPizza = pizza;
        }

        public virtual string GetDescription()
        {
            return decoratedPizza.GetDescription();
        }

        public virtual double GetCost()
        {
            return decoratedPizza.GetCost();
        }
    }

    // Concrete Decorator - Cheese
    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, with extra cheese";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1.0;
        }
    }

    // Concrete Decorator - Pepperoni
    public class PepperoniDecorator : PizzaDecorator
    {
        public PepperoniDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, with pepperoni";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1.5;
        }
    }
}
