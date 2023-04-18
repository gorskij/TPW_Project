namespace Data;

public abstract class BallAPI
{
    public static BallAPI CreateBall(double x, double y, double radius)
    {
        return new Ball(x, y, radius);
    }

    public abstract double X { get; set; }
    public abstract double Y { get; set; }
    public abstract double Radius { get; }
    public abstract double Diameter { get; }
}

internal class Ball: BallAPI
{
    private double _x;
    private double _y;

    public Ball(double x, double y, double radius)
    {
        _x = x;
        _y = y;
        Radius = radius;
        Diameter = radius * 2;
    }

    public override double X
    {
        get => _x;
        set => _x = value;
    }
    
    public override double Y
    {
        get => _y;
        set => _y = value;
    }
    
    public override double Radius { get; }
    public override double Diameter { get; }
}