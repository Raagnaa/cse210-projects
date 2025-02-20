public class Cycling : Activity
{
    private double speed;

    public double Speed 
    { 
        get => speed; 
        set => speed = value; 
    }

    public Cycling(DateTime date, int length, double speed)
        : base(date, length)
    {
        Speed = speed;
    }

    public override double GetDistance() => (Speed * Length) / 60;
    
    public override double GetSpeed() => Speed;
    
    public override double GetPace() => 60 / Speed;
    
    public override string GetSummary() =>
        $"{Date.ToShortDateString()} Cycling ({Length} min) - Speed: {Speed} mph, Distance: {GetDistance():F2} miles, Pace: {GetPace():F2} min per mile";
}
