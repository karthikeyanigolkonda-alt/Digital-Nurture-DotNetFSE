using System;

interface INotifier
{
    void Send();
}

class EmailNotifier : INotifier
{
    public void Send()
    {
        Console.WriteLine("Email Notification Sent");
    }
}

abstract class NotifierDecorator : INotifier
{
    protected INotifier notifier;

    public NotifierDecorator(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public virtual void Send()
    {
        notifier.Send();
    }
}

class SMSNotifierDecorator : NotifierDecorator
{
    public SMSNotifierDecorator(INotifier notifier) : base(notifier) { }

    public override void Send()
    {
        base.Send();
        Console.WriteLine("SMS Notification Sent");
    }
}

class Program
{
    static void Main()
    {
        INotifier notifier = new SMSNotifierDecorator(new EmailNotifier());
        notifier.Send();
    }
}