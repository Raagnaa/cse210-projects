using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points, DateTime dueDate) : base(shortName, description, points, dueDate) { }

    public override string GetDetailsString() =>
        $"Eternal Goal: {ShortName}, {Description}, {Points} points, Due Date: {DueDate.ToShortDateString()}";

    public override string GetStringRepresentation() => $"EternalGoal: {ShortName}";
    public override int RecordEvent() => Points;
}
