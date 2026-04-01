using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;

    public ListingActivity()
    {
        SetName("Listing");
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can.");
        _prompts = new List<string>
        {
            "What are personal strengths of yours?",
            "Who are some of your personal heroes?",
            "Who are people that you have helped this week?",
            "Who are people that you appreciate?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        Console.WriteLine("Prompt: " + _prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("You have a few seconds to think before you start listing...");
        ShowCountDown(3);

        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            responses.Add(item);
        }

        _count = responses.Count;
        Console.WriteLine("You listed " + _count + "items. Great job.");
        DisplayEndingMessage();
    }
}