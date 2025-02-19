using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points) { }

    public override string GetDetailsString() => $"Eternal Goal: {ShortName}, {Description}, {Points} points";
    public override string GetStringRepresentation() => $"EternalGoal: {ShortName}";
    public override int RecordEvent() => Points;
}
