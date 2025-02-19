using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points) { }

    public override string GetDetailsString() => $"Simple Goal: {ShortName}, {Description}, {Points} points";
    public override string GetStringRepresentation() => $"SimpleGoal: {ShortName}";
    public override int RecordEvent() => Points;
}
