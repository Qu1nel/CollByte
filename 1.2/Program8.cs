using System;

class Program
{
    const double H = 10;
    private static double GetDouble()
    {
        return Convert.ToDouble(Console.ReadLine());
    }

    private static void GetInfoFromUser(out double weight, out double distance_left, out double distance_right)
    {
        weight = GetWeight("Введите вес груза в килограммах: ");
        distance_left = GetDistance("Введите расстояние от опоры до левого конца рычага: ");
        distance_right = GetDistance("Введите расстояние от опоры до правого конца рычага: ");
    }

    private static double CalculateResult(double weight, double left, double right)
    {
        return weight * left / right * H;
    }

    public static void Main(string[] argv)
    {
        double weight, distance_left, distance_right;
        GetInfoFromUser(out weight, out distance_left, out distance_right);
        double result = CalculateResult(weight, distance_left, distance_right);
        OutPutResult(weight, distance_left, distance_right, result);
    }

    public static void OutPutResult(double weight, double distance_left, double distance_right, double result)
    {
        Console.WriteLine($"Чтобы уравновесить груз весом {weight} кг, расположенный");
        Console.WriteLine($"на рычаге первого рода с характеристиками: {distance_left}, {distance_right}.");
        Console.WriteLine($"надо приложить силу {result} кг.");
    }

    private static double GetWeight(string prompt)
    {
        Console.Write(prompt);
        return GetDouble();
    }

    private static double GetDistance(string prompt)
    {
        Console.Write(prompt);
        return GetDouble();
    }
}
