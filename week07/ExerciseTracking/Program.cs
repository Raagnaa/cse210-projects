using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 02, 14), 45, 5),
            new Cycling(new DateTime(2025, 02, 15), 60, 15),
            new Swimming(new DateTime(2025, 02, 16), 30, 15)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
