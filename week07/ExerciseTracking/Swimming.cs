public class Swimming : Activity
{
    private int laps;

    public int Laps 
    { 
        get => laps; 
        set => laps = value; 
    }

    public Swimming(DateTime date, int length, int laps)
        : base(date, length)
    {
        Laps = laps;
    }

    public override double GetDistance() => Laps * 50 / 1000.0 * 0.62;
    
    public override double GetSpeed() => (GetDistance() / Length) * 60;
    
    public override double GetPace() => Length / GetDistance();
    
    public override string GetSummary() =>
        $"{Date.ToShortDateString()} Swimming ({Length} min) - Laps: {Laps}, Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
}
