using System;

public sealed class Logger
{
    private static Logger instance;

    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }

    public static Logger GetInstance()
    {
        if (instance == null)
        {
            instance = new Logger();
        }
        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine("Log: " + message);
    }
}

class Program
{
    static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("First log message");
        logger2.Log("Second log message");

        if (logger1 == logger2)
        {
            Console.WriteLine("Both objects are same. Singleton works.");
        }
    }
}
