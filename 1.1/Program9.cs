using System;

class Program
{
    public static void Main(string[] argv)
    {
        Int32 A = Convert.ToInt32(Console.ReadLine());
        Int32 B = Convert.ToInt32(Console.ReadLine());
        Int32 C = Convert.ToInt32(Console.ReadLine());

        Int32 length_AC = Math.Abs(C - A);
        Int32 length_BC = Math.Abs(B - C);

        Int32 result = length_AC * length_BC;

        Console.WriteLine(result);
    }
}
