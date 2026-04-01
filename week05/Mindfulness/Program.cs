//Exceeding Requirements: Keep a log of how many times activities were performed.

using System;

class Program
{
    static int breathingCount = 0;
    static int reflectingCount = 0;
    static int listingCount = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Mindfulness Program ---");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.SetDuration();
                    breathing.Run();
                    breathingCount++;
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.SetDuration();
                    reflecting.Run();
                    reflectingCount++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.SetDuration();
                    listing.Run();
                    listingCount++;
                    break;

                case "4":
                    running = false;
                    Console.WriteLine("\nThanks for using Mindfulness Program!");
                    Console.WriteLine($"Breathing done: {breathingCount} times");
                    Console.WriteLine($"Reflecting done: {reflectingCount} times");
                    Console.WriteLine($"Listing done: {listingCount} times");
                    break;
                
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;

            }
        }
    }
}