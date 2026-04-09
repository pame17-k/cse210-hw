//This program can be enriched with gamification elements
// to motivate the user while achieving their goals:

// - Level system: the player levels up each time they
// reach a certain accumulated score (e.g., every 1000 points).

// - Badges or achievements: award "badges" for completing specific goals, such as:
// * "Consistency": log an EternalGoal for 7 consecutive days.
// * "Goal achieved": complete 5 SimpleGoals.
// * "Checklist Master": finish 3 Checklist-type goals.

using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}
