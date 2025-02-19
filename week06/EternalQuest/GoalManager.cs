using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class GoalManager
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
        while (true)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("\n1. List Goal Names");
            Console.WriteLine("2. List Goal Details");
            Console.WriteLine("3. Create Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListGoalNames();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    return;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score}");
    }

    private void ListGoalNames()
    {
        Console.Clear();
        DisplayPlayerInfo();
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStringRepresentation());
        }
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }

    private void ListGoalDetails()
    {
        Console.Clear();
        DisplayPlayerInfo();
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }

    private void CreateGoal()
    {
        Console.Clear();
        DisplayPlayerInfo();
        Console.Write("Enter the type of goal (Simple, Eternal, Checklist): ");
        string type = Console.ReadLine();
        Console.Write("Enter the short name of the goal: ");
        string shortName = Console.ReadLine();
        Console.Write("Enter the description of the goal: ");
        string description = Console.ReadLine();
        Console.Write("Enter the points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        if (type.Equals("Simple", StringComparison.OrdinalIgnoreCase))
        {
            _goals.Add(new SimpleGoal(shortName, description, points));
        }
        else if (type.Equals("Eternal", StringComparison.OrdinalIgnoreCase))
        {
            _goals.Add(new EternalGoal(shortName, description, points));
        }
        else if (type.Equals("Checklist", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Enter the target count for the checklist goal: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter the bonus points for the checklist goal: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(shortName, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    private void RecordEvent()
    {
        Console.Clear();
        DisplayPlayerInfo();
        Console.Write("Enter the short name of the goal you want to record: ");
        string shortName = Console.ReadLine();

        foreach (var goal in _goals)
        {
            if (goal.ShortName.Equals(shortName, StringComparison.OrdinalIgnoreCase))
            {
                _score += goal.RecordEvent();
                break;
            }
        }
    }

    private void SaveGoals()
    {
        using (FileStream fs = new FileStream("goals.json", FileMode.Create))
        {
            var data = new
            {
                goals = _goals,
                score = _score
            };
            JsonSerializer.Serialize(fs, data, new JsonSerializerOptions { WriteIndented = true });
        }
        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        if (File.Exists("goals.json"))
        {
            using (FileStream fs = new FileStream("goals.json", FileMode.Open))
            {
                var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(fs);
                if (data != null)
                {
                    _goals.Clear();
                    if (data.TryGetValue("goals", out JsonElement goalsElem))
                    {
                        foreach (JsonElement goalElem in goalsElem.EnumerateArray())
                        {
                            string type = "SimpleGoal"; // Default type

                            if (goalElem.TryGetProperty("Type", out var typeProperty))
                            {
                                type = typeProperty.GetString();
                            }

                            string shortName = goalElem.GetProperty("ShortName").GetString();
                            string description = goalElem.GetProperty("Description").GetString();
                            int points = goalElem.GetProperty("Points").GetInt32();

                            if (type.Equals(nameof(SimpleGoal), StringComparison.OrdinalIgnoreCase))
                            {
                                _goals.Add(new SimpleGoal(shortName, description, points));
                            }
                            else if (type.Equals(nameof(EternalGoal), StringComparison.OrdinalIgnoreCase))
                            {
                                _goals.Add(new EternalGoal(shortName, description, points));
                            }
                            else if (type.Equals(nameof(ChecklistGoal), StringComparison.OrdinalIgnoreCase))
                            {
                                if (goalElem.TryGetProperty("Target", out var targetProperty) &&
                                    goalElem.TryGetProperty("AmountCompleted", out var amountCompletedProperty) &&
                                    goalElem.TryGetProperty("Bonus", out var bonusProperty))
                                {
                                    int target = targetProperty.GetInt32();
                                    int amountCompleted = amountCompletedProperty.GetInt32();
                                    int bonus = bonusProperty.GetInt32();
                                    ChecklistGoal checklistGoal = new ChecklistGoal(shortName, description, points, target, bonus);
                                    checklistGoal.SetAmountCompleted(amountCompleted);
                                    _goals.Add(checklistGoal);
                                }
                                else
                                {
                                    Console.WriteLine("ChecklistGoal properties missing.");
                                }
                            }
                        }
                    }

                    if (data.TryGetValue("score", out JsonElement scoreElem) && scoreElem.TryGetInt32(out int loadedScore))
                    {
                        _score = loadedScore;
                    }

                    Console.WriteLine("Goals loaded successfully.");
                }
            }
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}
