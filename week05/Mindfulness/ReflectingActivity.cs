using System;
using System.Collections.Generic;

class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        SetName("Reflecting");
        SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you did something really difficult."
        };
        _questions = new List<string>
        {
            "How can you keep this experience in mind in the future?",
            "What could you learn from this experience?",
            "What made this time different than other times?",
            "How did you get started",
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you feel when it was complete?", 
            "What did you learn about yourself?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        Console.WriteLine("Prompt: " + _prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("Think carefully about this experience...");
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Question: " + _questions[rand.Next(_questions.Count)]);
            Pause(3);
        }
        DisplayEndingMessage();
    }
}