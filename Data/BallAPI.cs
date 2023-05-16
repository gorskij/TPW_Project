﻿namespace Data;

public abstract class BallAPI
{
    public static BallAPI CreateBall(double x, double y, double radius)
    {
        return new Ball(x, y, radius);
    }
    public abstract void Move();
    public abstract double X { get; set; }
    public abstract double Y { get; set; }
    public abstract double VelX { get; set; }
    public abstract double VelY { get; set; }
    public abstract double Mass { get; }
    public abstract double Radius { get; }
    public abstract double Diameter { get; }
}

internal class Ball: BallAPI
{
    private double _x;
    private double _y;
    private double _velY = 0;
    private double _velX = 0;
    private double _mass;
    private double _radius;
    private double _diameter;
    private readonly Random _random = new();
   
    public Ball(double x, double y, double radius)
    {
        while(_velX == 0)
        {
            _velX = _random.Next(-2, 2);
        }
        while(_velY == 0)
        { 
            _velY = _random.Next(-2, 2);
        }
        _x = x;
        _y = y;
        _radius = radius;
        _mass = radius;
        _diameter = radius * 2;
    }

    public override void Move()
    {
        _x += _velX;
        _y += _velY;
    }

    public override double VelX 
    {
        get => _velX;
        set => _velX = value;
    }

    public override double VelY
    {
        get => _velY;
        set => _velY = value;
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
    
    public override double Radius { get => _radius; }
    public override double Diameter { get => _diameter; }
    public override double Mass { get => _mass; }
}