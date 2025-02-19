using System;

public class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int AmountCompleted { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        Target = target;
        AmountCompleted = 0;
        Bonus = bonus;
    }

    public override string GetDetailsString() =>
        $"Checklist Goal: {ShortName}, {Description}, {Points} points, Target: {Target}, Completed: {AmountCompleted}, Bonus: {Bonus}";

    public override string GetStringRepresentation() => $"ChecklistGoal: {ShortName}";
    public override int RecordEvent()
    {
        AmountCompleted++;
        return AmountCompleted >= Target ? Points + Bonus : Points;
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        AmountCompleted = amountCompleted;
    }
}
