using System;
using System.Collections.Generic;

public class ListingActivity : ActivityBase
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void PerformActivity()
    {
        var random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine(prompt);
        PauseWithAnimation(5);
        Console.WriteLine("Start listing items...");

        int itemCount = 0;
        var end = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < end)
        {
            Console.WriteLine("Enter an item:");
            Console.ReadLine();
            itemCount++;
        }

        Console.WriteLine($"You listed {itemCount} items.");
        EndActivity();
    }
}
