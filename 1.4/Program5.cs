using System;


class Program
{
    public static void Main(string[] argv)
    {
        GetNumber(out Decimal x);  // Получение числа с приглашение к вводу
        CalcResult(x, out Decimal result);  // Вычисление значение по формуле (результат в reuslt переменной)
        PrintResult(result);  // Вывод результата в терминал
    }

    public static void GetNumber(out Decimal x)
    {
        Console.Write("Введите x: ");
        string input = Console.ReadLine() ?? "0";  // Если ничего не ввели - значение по умолчанию 0

        if (!Decimal.TryParse(input, out x)) {  // Пытаемся привести строку к числу
            Console.WriteLine("Не корректный тип! Дотустимый тип ввода для числа - целочисленный.");  // Предупреждение в случае, если строка не число
            Environment.Exit(1);  // Выход с кодом возврата 1
        }
    }

    public static void CalcResult(Decimal x, out Decimal result)
    {
        result = 0.0m;

        Decimal sign = 1m;  // заводим переменну-флаг для изменения знака слагаемого

        for (int i = 1; i <= 13; i += 2) {  // По формуле показатель степени и знаминатель нечетные числа от 1 до 13 (шаг 2)
            result += sign * (Power(x, i) / Factorial(i));
            sign *= -1m;  // При каждом новом слагаемом - изменяется знак, путём умножения его на -1
        }
    }

    public static void PrintResult(Decimal result)
    {
        Console.WriteLine($"Значение, вычисленное по формуле: {result}");
    }

    private static Decimal Factorial(Decimal x)  // Метод вычисления факториала от x (x - натуральное число)
    {
        Decimal result = 1;  // Ложим 1, т.к. при 0 - всё занулиться при умножениее (вычислении факториала)

        for (int i = 2; i <= x; ++i) { // Сам цикл вычисления факториала
            result *= i;
        }

        return result;  // Возвращение результирующего факториала
    }

    private static Decimal Power(Decimal x, Int32 power)  // Метод возведения в степень (быстрое возведение в степень) O[log2(N)] по времени
    {
        Decimal result = 1m;
        Decimal mult = x;

        while (power != 0) {  // Представляем степень как двоичное число и там, где разряды равны 1 - умножение числа в квадрат
            if (power % 2 != 0) {  // Оканчивается ли число на 1 в двоичной СС (по опредлению, если делить число по модулю равной основанию СС - остаток будет входит в интервал (множества) всех цифр этой СС
                result *= mult;  // Накопление результата
            }
            mult *= mult;  // Квадрат числа
            power /= 2;  // Убираем последнюю цифру показателя степени в двоичном представлении
        }

        return result;
    }
}
