using System;

class Program
{
    public static void Main(string[] argv)
    {
        Double degrees = Convert.ToDouble(Console.ReadLine());
        Double radians = degrees * Math.PI / 180;
        Console.WriteLine(radians);
    }
}
