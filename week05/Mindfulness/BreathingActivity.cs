using System;

public class BreathingActivity : ActivityBase
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing";
    }


    public override void PerformActivity()
    {
        for (int i = 0; i < Duration; i += 6)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(3);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(3);
        }
        EndActivity();
    }
}