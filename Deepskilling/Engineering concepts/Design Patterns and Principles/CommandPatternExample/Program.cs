using System;

interface ICommand
{
    void Execute();
}

class Light
{
    public void On()
    {
        Console.WriteLine("Light ON");
    }
}

class LightOnCommand : ICommand
{
    private Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.On();
    }
}

class Program
{
    static void Main()
    {
        Light light = new Light();
        ICommand command = new LightOnCommand(light);

        command.Execute();
    }
}