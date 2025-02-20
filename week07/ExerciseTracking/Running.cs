public class Running : Activity
{
    private double distance;

    public double Distance 
    { 
        get => distance; 
        set => distance = value; 
    }

    public Running(DateTime date, int length, double distance)
        : base(date, length)
    {
        Distance = distance;
    }

    public override double GetDistance() => Distance;
    
    public override double GetSpeed() => (Distance / Length) * 60;
    
    public override double GetPace() => Length / Distance;
    
    public override string GetSummary() =>
        $"{Date.ToShortDateString()} Running ({Length} min) - Distance: {Distance} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
}
