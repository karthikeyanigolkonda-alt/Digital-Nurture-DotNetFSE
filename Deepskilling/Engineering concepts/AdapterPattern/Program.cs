using System;

interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

class PayPalGateway
{
    public void MakePayment(double amount)
    {
        Console.WriteLine($"Paid ₹{amount} using PayPal");
    }
}

class PayPalAdapter : IPaymentProcessor
{
    private PayPalGateway gateway = new PayPalGateway();

    public void ProcessPayment(double amount)
    {
        gateway.MakePayment(amount);
    }
}

class Program
{
    static void Main()
    {
        IPaymentProcessor processor = new PayPalAdapter();
        processor.ProcessPayment(5000);
    }
}
