using System;
using System.Threading.Tasks;
public abstract class ActivityBase
{
    public string Name { get ; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {Name}: {Description}");
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        PauseWithAnimation(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"You completed: {Name} for {Duration} seconds");
        PauseWithAnimation(3);
        Console.WriteLine("Here's a motivational sentence for you:");
        Console.WriteLine(MotivationalSentences.GetRandomSentence());
        PauseWithAnimation(3);
    }

    public abstract void PerformActivity();

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}