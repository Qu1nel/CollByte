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
        Console.Write("Введите натуральное число N: ");  // Выводим приглашение к вводу
        string input = Console.ReadLine() ?? "0";  // Если ничего не ввели - значение по умолчанию 0

        if (!Int32.TryParse(input, out n)) {  // Пытаемся привести строку к числу
            Console.WriteLine("Не корректный тип! Дотустимый тип ввода для числа - целочисленный.");  // Предупреждение в случае, если строка не число
            Environment.Exit(1);  // Выход с кодом возврата 1
        }
    }

    public static void CalcResult(Int32 n, out Int32 result)
    {
        result = 0;  // ложим начальное значение суммы ряда

        for (int i = 0; i <= n; ++i) {
            result += NumberIsOdd(i) ? i : -i;  // Каждое нечетное число - положительное, а четное - отрицательное
        }
    }

    public static void PrintResult(Int32 n, Int32 result)
    {
        Console.WriteLine($"Исходное значение N: {n}");
        Console.WriteLine($"Сумма ряда знакачередующегося ряда: {result}");
    }

    private static bool NumberIsOdd(Int32 number)
    {
        return number % 2 != 0;  // У чётных чисел отстаток от деления на 2 должен равняться 0, у нечётных - 1
    }
}
