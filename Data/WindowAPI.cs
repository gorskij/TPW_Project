namespace Data;

public abstract class WindowAPI
{
    public static WindowAPI CreateWindow(int width, int height)
    {
        return new Window(width, height);
    }
    
    public abstract int Width { get; }
    public abstract int Height { get; }
}

internal class Window: WindowAPI
{
    public Window(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public override int Width { get; }
    public override int Height { get; }
}