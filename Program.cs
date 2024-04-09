using System;

class Circle
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public double Circumference()
    {
        return 2 * Math.PI * Radius;
    }

    public bool ContainsPoint(double x, double y)
    {
        double distance = Math.Sqrt(x * x + y * y);
        return distance <= Radius;
    }
}

class Program
{
    static Circle[] CreateCircles(int numCircles)
    {
        Circle[] circles = new Circle[numCircles];
        for (int i = 0; i < numCircles; i++)
        {
            Console.Write($"Enter radius for circle {i + 1}: ");
            double radius = double.Parse(Console.ReadLine());
            circles[i] = new Circle(radius);
        }
        return circles;
    }

    static void PrintCircleInfo(Circle circle)
    {
        Console.WriteLine($"Circle with radius {circle.Radius}");
        Console.WriteLine($"Area: {circle.Area()}");
        Console.WriteLine($"Circumference: {circle.Circumference()}");
    }

    static (double, double) GetUserPoint()
    {
        Console.Write("Enter x-coordinate of the point: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter y-coordinate of the point: ");
        double y = double.Parse(Console.ReadLine());
        return (x, y);
    }

    static void CheckPointInCircles(Circle[] circles, double x, double y)
    {
        for (int i = 0; i < circles.Length; i++)
        {
            if (circles[i].ContainsPoint(x, y))
            {
                Console.WriteLine($"Point is inside Circle {i + 1}");
            }
            else
            {
                Console.WriteLine($"Point is outside Circle {i + 1}");
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter the number of circles you want to create: ");
        int numCircles = int.Parse(Console.ReadLine());
        Circle[] circles = CreateCircles(numCircles);

        for (int i = 0; i < circles.Length; i++)
        {
            Console.WriteLine($"Information for Circle {i + 1}");
            PrintCircleInfo(circles[i]);
            Console.WriteLine();
        }

        var (x, y) = GetUserPoint();
        CheckPointInCircles(circles, x, y);
    }
}
