using System;


class Program
{
    public static void Main(string[] argv)
    {
        GetNumber(out Int32 N);
        CalcResult(N, out bool NumberInSerial);
        PrintResult(N, NumberInSerial);
    }

    public static void GetNumber(out Int32 n)
    {
        Console.Write("Введите натуральное число N: ");
        n = Convert.ToInt32(Console.ReadLine());
    }

    public static void CalcResult(Int32 n, out bool In)
    {
        Int64 f1 = 0, f2 = 1, f = 1;

        while (f1 < n) {
            f1 = f2;
            f2 = f;
            f = f1 + f2;
        }

        In = n == f1;
    }

    public static void PrintResult(Int32 n, bool belongs)
    {
        Console.WriteLine($"Исходное значение N: {n}");
        Console.WriteLine("Принадлежит ли N ряду числам Фибоначчи: {0}ПРИНАДЛЕЖИТ", belongs ? "" : "НЕ ");
    }
}
