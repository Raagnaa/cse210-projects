using System;

public class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int AmountCompleted { get; set; }

    public ChecklistGoal(string shortName, string description, int points, int target)
        : base(shortName, description, points)
    {
        Target = target;
        AmountCompleted = 0;
    }

    public override string GetDetailsString() =>
        $"Checklist Goal: {ShortName}, {Description}, {Points} points, Target: {Target}, Completed: {AmountCompleted}";

    public override string GetStringRepresentation() => $"ChecklistGoal: {ShortName}";
    public override int RecordEvent()
    {
        AmountCompleted++;
        return Points;
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        AmountCompleted = amountCompleted;
    }
}
