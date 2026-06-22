using System;

interface IPaymentStrategy
{
    void Pay(int amount);
}

class CreditCardPayment : IPaymentStrategy
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Paid ₹{amount} using Credit Card");
    }
}

class PaymentContext
{
    private IPaymentStrategy strategy;

    public PaymentContext(IPaymentStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void Execute(int amount)
    {
        strategy.Pay(amount);
    }
}

class Program
{
    static void Main()
    {
        PaymentContext payment = new PaymentContext(new CreditCardPayment());
        payment.Execute(1000);
    }
}
