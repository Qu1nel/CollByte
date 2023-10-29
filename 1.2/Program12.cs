using System;

class Program
{
    private static double GetDouble()
    {
        return Convert.ToDouble(Console.ReadLine());
    }

    private static void GetInfoFromUser(out double degree)
    {
        degree = GetFahrenheit("Введите градусы в фаренгейтах: ");
    }

    private static double CalculateResult(double fahrenheit)
    {
        return (fahrenheit - 32) / 1.8;
    }

    public static void Main(string[] argv)
    {
        GetInfoFromUser(out double fahrenheit);
        double celsius = CalculateResult(fahrenheit);
        OutPutResult(fahrenheit, celsius);
    }

    public static void OutPutResult(double fahrenheit, double celsius)
    {
        Console.WriteLine($"Температура в градусах по шкале Фаренгейта = {fahrenheit}");
        Console.WriteLine($"Температура в гардусах по шкале Цельсия = {celsius}");
    }

    private static double GetFahrenheit(string prompt)
    {
        Console.Write(prompt);
        return GetDouble();
    }
}
