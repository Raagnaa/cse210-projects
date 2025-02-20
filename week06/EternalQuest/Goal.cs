using System;

public abstract class Goal
{
    public string ShortName { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public DateTime DueDate { get; set; }

    protected Goal(string shortName, string description, int points)
    {
        ShortName = shortName;
        Description = description;
        Points = points;
    }

    protected Goal(string shortName, string description, int points, DateTime dueDate)
    {
        ShortName = shortName;
        Description = description;
        Points = points;
        DueDate = dueDate;
    }

    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
    public abstract int RecordEvent();
}
