using System;

public class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int AmountCompleted { get; set; }

    public ChecklistGoal(string shortName, string description, int points, int target, DateTime dueDate) : base(shortName, description, points, dueDate)
    {
        Target = target;
        AmountCompleted = 0;
    }

    public override string GetDetailsString() =>
        $"Checklist Goal: {ShortName}, {Description}, {Points} points, Target: {Target}, Completed: {AmountCompleted}, Due Date: {DueDate.ToShortDateString()}";

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
