using System;

class Program
{
    public static void Main(string[] argv)
    {

        double edge = GetEdge("Введите длину ребра куба: ");
        double V = Math.Pow(edge, 3);
        double S = edge * edge * 6;

        Console.WriteLine($"У куба с длиной ребра = {edge}\nобъем = {V}, общая поверхность граней = {S}");
    }

    public static double GetEdge(string prompt)
    {
        Console.Write(prompt);
        return Convert.ToDouble(Console.ReadLine());
    }
}
