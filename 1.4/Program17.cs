using System;


class Program
{
    public static void Main(string[] argv)
    {
        GetNumber(out Int32 N);  // Ввод натурального числа N 
        CalcResult(N, out bool NumberInSerial);  // Вычисление чисел фиббоначи и проверка по условию задачи
        PrintResult(N, NumberInSerial);  // Вывод результата
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

    public static void CalcResult(Int32 n, out bool In)  // Метод вычисления чисел фибоначчи пока вычисляемое число не привысит данное
    {
        Int64 f1 = 0, f2 = 1, f = 1;  // Заводим переменные для вычисления чисел f1 и f2

        while (f1 < n) {  // Пока вычисляемое число не привысит данное - вычисляем следующее
            f1 = f2;
            f2 = f;
            f = f1 + f2;
        }

        In = n == f1;  // Кладём в результирующую переменную результат: является ли число элементом ряда фибоначчи
    }

    public static void PrintResult(Int32 n, bool belongs)
    {
        Console.WriteLine($"Исходное значение N: {n}");
        Console.WriteLine("Принадлежит ли N ряду числам Фибоначчи: {0}ПРИНАДЛЕЖИТ", belongs ? "" : "НЕ ");
    }
}
