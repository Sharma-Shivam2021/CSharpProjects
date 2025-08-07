
namespace StructsApp;

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }


    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Display()
    {
        Console.WriteLine($"Point: ({X},{Y})");
    }

}

public class PointClass
{
    public PointClass(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public void Display()
    {
        Console.WriteLine($"Point: ({X},{Y})");
    }
}