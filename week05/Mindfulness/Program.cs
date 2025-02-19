/*It is not applied here but I wanted to explain it here, that's why I write here,
 I used a little help by seeing other applications that do that to be able to get inspired
  because I really need the points, and I saw that they all have phrases that help people,
   so what I did was add some motivational phrases at the end of doing the activities.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            ActivityBase activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.StartActivity();
            activity.PerformActivity();
        }
    }
}
