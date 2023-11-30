using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    // ****************************************  Example 01 *******************************************
    // Subject interface
    interface IStock
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    // Concrete subject
    class Stock : IStock
    {
        private readonly List<IObserver> observers = new List<IObserver>();
        private string symbol;
        private double price;

        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }

        public void PriceChange(double newPrice)
        {
            price = newPrice;
            Notify();
        }

        public string Symbol { get => symbol; }
        public double Price { get => price; }
    }

    // Observer interface
    interface IObserver
    {
        void Update(Stock stock);
    }

    // Concrete observer
    class Investor : IObserver
    {
        private string name;

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(Stock stock)
        {
            Console.WriteLine($"Notified {name} of {stock.Symbol}'s price change to {stock.Price}");
        }
    }
}

// ****************************************  Example 02 *******************************************

// Subject interface
interface IWeatherSubject
{
    void AddObserver(IWeatherObserver observer);
    void RemoveObserver(IWeatherObserver observer);
    void NotifyObservers();
}

// Concrete subject
class WeatherStation : IWeatherSubject
{
    private double temperature;
    private readonly List<IWeatherObserver> observers = new List<IWeatherObserver>();

    public double Temperature
    {
        get { return temperature; }
        set
        {
            temperature = value;
            NotifyObservers();
        }
    }

    public void AddObserver(IWeatherObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IWeatherObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(Temperature);
        }
    }
}

// Observer interface
interface IWeatherObserver
{
    void Update(double temperature);
}

// Concrete observer
class Display : IWeatherObserver
{
    public void Update(double temperature)
    {
        Console.WriteLine($"Temperature updated: {temperature}");
    }
}