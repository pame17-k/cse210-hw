using System;

class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public void SetName(string name) { _name = name; }
    public void SetDescription(string description) { _description = description; }
    public void SetDuration()
    {
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
    }

    public int GetDuration() { return _duration; }
    public string GetName() { return _name;}
    public string GetDescription() { return _description; }

    public void DisplayStartingMessage()
    {
        Console.WriteLine("\nStarting" + _name + "Activity...");
        Console.WriteLine(_description);
        Console.WriteLine("Prepare to begin... Take a deep breath and focus.");
        Pause(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine("You have completed" + _name + "Activity for" + _duration + "seconds.");
        Console.WriteLine("Take a moment to reflect on how you feel now.");
        Pause(3);
    }

    public void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for(int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i + "....");
            System.Threading.Thread.Sleep(1000);
        }
    }
}