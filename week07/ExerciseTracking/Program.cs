using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Apr 2026", 30, 4.8));
        activities.Add(new Cycling("04 Apr 2026", 40, 20));
        activities.Add(new Swimming("05 Apr 2026", 50, 30));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}