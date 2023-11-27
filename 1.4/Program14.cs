using System;


class Program
{
    public static void Main(string[] argv)
    {
        GetNumber(out Int32 N);
        CalcResult(N, out Int32 result);
        PrintResult(N, result);
    }

    public static void GetNumber(out Int32 n)
    {
        Console.Write("Введите натуральное число N: ");
        n = Convert.ToInt32(Console.ReadLine());
    }

    public static void CalcResult(Int32 n, out Int32 result)
    {
        result = 0;

        for (int i = 0; i <= n; ++i) {
            result += NumberIsOdd(i) ? i : -i;
        }
    }

    public static void PrintResult(Int32 n, Int32 result)
    {
        Console.WriteLine($"Исходное значение N: {n}");
        Console.WriteLine($"Сумма ряда знакачередующегося ряда: {result}");
    }

    private static bool NumberIsOdd(Int32 number)
    {
        return number % 2 != 0;
    }
}
