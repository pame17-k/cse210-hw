using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }
        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Display Player Info");
                Console.WriteLine("2. List Goal Names");
                Console.WriteLine("3. List Goal Details");
                Console.WriteLine("4. Create New Goal");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Save Goals");
                Console.WriteLine("7. Load Goals");
                Console.WriteLine("8. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                 switch (choice)
                {
                    case "1": DisplayPlayerInfo(); break;
                    case "2": ListGoalNames(); break;
                    case "3": ListGoalDetails(); break;
                    case "4": CreateGoal(); break;
                    case "5": RecordEvent(); break;
                    case "6": SaveGoals(); break;
                    case "7": LoadGoals(); break;
                    case "8": running = false; break;
                    default: Console.WriteLine("Invalid choice, try again."); break;
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Your current score is: {_score}");
        }

        public void ListGoalNames()
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
            }
        }

        public void ListGoalDetails()
        {
            foreach (Goal goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("Select the type of goal:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            string choice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());

            if (choice == "1")
            {
                _goals.Add(new SimpleGoal(name, description, points));
            }
            else if (choice == "2")
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (choice == "3")
            {
                Console.Write("Enter target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            }
        }

        public void RecordEvent()
        {
            ListGoalNames();
            Console.Write("Which goal did you accomplish? ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < _goals.Count)
            {
                int pointsEarned = _goals[index].RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        public void SaveGoals()
        {
             Console.Write("Enter filename to save goals: ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }

        public void LoadGoals()
        {
            Console.Write("Enter filename to load goals: ");
            string filename = Console.ReadLine();

            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(":");
                string type = parts[0];
                string[] data = parts[1].Split(",");

                if (type == "SimpleGoal")
                {
                    string name = data[0];
                    string description = data[1];
                    int points = int.Parse(data[2]);
                    bool isComplete = bool.Parse(data[3]);
                    SimpleGoal sg = new SimpleGoal(name, description, points);
                    if (isComplete) sg.RecordEvent();
                    _goals.Add(sg);
                }
                else if (type == "EternalGoal")
                {
                    string name = data[0];
                    string description = data[1];
                    int points = int.Parse(data[2]);
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    string name = data[0];
                    string description = data[1];
                    int points = int.Parse(data[2]);
                    int target = int.Parse(data[3]);
                    int bonus = int.Parse(data[4]);
                    int amountCompleted = int.Parse(data[5]);

                    ChecklistGoal cg = new ChecklistGoal(name, description, points, target, bonus);

                    // Ajustar el progreso ya guardado
                    for (int j = 0; j < amountCompleted; j++)
                    {
                        cg.RecordEvent();
                    }

                    _goals.Add(cg);
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
    }
}