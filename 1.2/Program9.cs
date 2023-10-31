using System;

class Program
{
    private static double GetDouble()
    {
        return Convert.ToDouble(Console.ReadLine());
    }

    private static void GetInfoFromUser(out string name, out double speed, out double acceleration)
    {
        name = GetName("Введите имя планеты: ");
        speed = GetSpeedFor("Введите скороть для панеты '{0}': ", name);
        acceleration = GetAcceleration("Введите ускорение для панеты '{0}': ", name);
    }

    private static double CalculateResult(double speed1, double speed2, double acceleration1, double acceleration2, double distant)
    {
        double a, b, c;
        a = (acceleration1 + acceleration2) / 2;
        b = speed1 + speed2;
        c = -distant;
        double D = Math.Sqrt((b * b) - 4 * a * c);
        return ((-b) + D) / (2 * a);
    }

    public static void Main(string[] argv)
    {
        string planetName1, planetName2;
        double speedPlanet1, accelerationPlanet1, speedPlanet2, accelerationPlanet2;

        GetInfoFromUser(out planetName1, out speedPlanet1, out accelerationPlanet1);
        GetInfoFromUser(out planetName2, out speedPlanet2, out accelerationPlanet2);

        double distant = GetDistantFromUser();
        double result = CalculateResult(speedPlanet1, speedPlanet2, accelerationPlanet1, accelerationPlanet2, distant);

        OutPutResult(planetName1, speedPlanet1, accelerationPlanet1, planetName2, speedPlanet2, accelerationPlanet2, result);
    }

    public static void OutPutResult(string name1, double speed1, double acceleration1, string name2, double speed2, double acceleration2, double res)
    {
        Console.WriteLine("Планеты с характеристиками:");
        Console.WriteLine($"1 - {name1}, {speed1}, {acceleration1}");
        Console.WriteLine($"1 - {name2}, {speed2}, {acceleration2}");
        Console.WriteLine($"встретятся через - {res} сек");
    }

    private static double GetDistantFromUser()
    {
        Console.WriteLine("Введите расстояние между планетами: ");
        return GetDouble();
    }

    private static string GetName(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    private static double GetSpeedFor(string prompt, string name)
    {
        Console.Write(prompt, name);
        return GetDouble();
    }

    private static double GetAcceleration(string prompt, string name)
    {
        Console.Write(prompt, name);
        return GetDouble();
    }
}
