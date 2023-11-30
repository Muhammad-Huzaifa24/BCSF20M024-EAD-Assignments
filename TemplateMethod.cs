using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    // ****************************************  Example 01 *******************************************
    // Abstract class defining the template method
    abstract class HouseBuilder
    {
        public void BuildHouse()
        {
            LayFoundation();
            BuildFrame();
            AddWalls();
            AddRoof();
        }

        protected abstract void LayFoundation();
        protected abstract void BuildFrame();
        protected abstract void AddWalls();
        protected abstract void AddRoof();
    }

    // Concrete subclass implementing specific steps
    class WoodenHouseBuilder : HouseBuilder
    {
        protected override void LayFoundation()
        {
            Console.WriteLine("Laying wooden foundation");
        }

        protected override void BuildFrame()
        {
            Console.WriteLine("Building wooden frame");
        }

        protected override void AddWalls()
        {
            Console.WriteLine("Adding wooden walls");
        }

        protected override void AddRoof()
        {
            Console.WriteLine("Adding wooden roof");
        }
    }

    // Concrete subclass implementing specific steps
    class BrickHouseBuilder : HouseBuilder
    {
        protected override void LayFoundation()
        {
            Console.WriteLine("Laying brick foundation");
        }

        protected override void BuildFrame()
        {
            Console.WriteLine("Building brick frame");
        }

        protected override void AddWalls()
        {
            Console.WriteLine("Adding brick walls");
        }

        protected override void AddRoof()
        {
            Console.WriteLine("Adding brick roof");
        }
    }
}


// ****************************************  Example 02 *******************************************

// Abstract class defining the template method
abstract class Recipe
{
    public void Cook()
    {
        PrepareIngredients();
        CookDish();
        ServeDish();
    }

    protected abstract void PrepareIngredients();
    protected abstract void CookDish();

    protected virtual void ServeDish()
    {
        Console.WriteLine("Serve the dish");
    }
}

// Concrete subclass implementing specific steps
class PastaRecipe : Recipe
{
    protected override void PrepareIngredients()
    {
        Console.WriteLine("Gather pasta, sauce, and spices");
    }

    protected override void CookDish()
    {
        Console.WriteLine("Boil pasta and mix with sauce");
    }
}

// Concrete subclass implementing specific steps
class CakeRecipe : Recipe
{
    protected override void PrepareIngredients()
    {
        Console.WriteLine("Gather flour, sugar, eggs, and baking powder");
    }

    protected override void CookDish()
    {
        Console.WriteLine("Mix ingredients and bake the cake");
    }
}

