using System;
using System.Collections.Generic;

interface IObserver
{
    void Update(string message);
}

class MobileApp : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine("Mobile App: " + message);
    }
}

class StockMarket
{
    private List<IObserver> observers = new();

    public void Register(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}

class Program
{
    static void Main()
    {
        StockMarket market = new StockMarket();
        market.Register(new MobileApp());

        market.Notify("Stock Price Increased!");
    }
}