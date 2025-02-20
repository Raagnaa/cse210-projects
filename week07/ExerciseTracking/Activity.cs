using System;

public abstract class Activity
{
    private DateTime date;
    private int length;

    public DateTime Date 
    { 
        get => date;
        set => date = value;
    }
    
    public int Length 
    { 
        get => length;
        set => length = value;
    }

    public Activity(DateTime date, int length)
    {
        Date = date;
        Length = length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract string GetSummary();
}
