using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        SetName("Breathing");
        SetDescription("This activity will help you relax by walking you through breathing in and out slowly.");
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in slowly...");
            ShowCountDown(3);
            Console.WriteLine("Now breathe out gently...");
            ShowCountDown(3);
        }
        DisplayEndingMessage();
    }
}