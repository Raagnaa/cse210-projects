using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string shortName, string description, int points, DateTime dueDate) : base(shortName, description, points, dueDate) { }

    public override string GetDetailsString() =>
        $"Simple Goal: {ShortName}, {Description}, {Points} points, Due Date: {DueDate.ToShortDateString()}";

    public override string GetStringRepresentation() => $"SimpleGoal: {ShortName}";
    public override int RecordEvent() => Points;
}
