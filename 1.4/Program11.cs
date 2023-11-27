using System;


class Program
{
    public static void Main(string[] argv)
    {
        GetN(out Int32 N);  // Вводим N
        CalcResult(N, out Int32 result);  // Обрабатываем число по условию
        PrintResult(N, result);  // Выводим результат по условию
    }

    public static void GetN(out Int32 N)
    {
        Console.Write("Введите число N: ");  // Выводим приглашение к вводу
        string input = Console.ReadLine() ?? "0";  // Если ничего не ввели - значение по умолчанию 0

        if (!Int32.TryParse(input, out N)) {  // Пытаемся привести строку к числу
            Console.WriteLine("Не корректный тип! Дотустимый тип ввода для числа - целочисленный.");  // Предупреждение в случае, если строка не число
            Environment.Exit(1);  // Выход с кодом возврата 1
        }
    }

    public static void CalcResult(Int32 number, out Int32 result)
    {
        result = 0;  // Переменная в которой будет собираться результирующее число

        int sign = (number > 0) ? 1 : -1;  // Сохраняем знак числа, чтобы корректно собрать новое
        number = Math.Abs(number);  // Далее работаем с положительным значением - так легче

        int count_digits = (int)Math.Floor(Math.Log10(Math.Abs(number))) + 1;  // Берём количество для дальнейших вычислений
        if (count_digits == 1) {  // Когда число = цифра, то никаких преобраований не нужно
            result = number;
            return;
        }

        int last_digit = number % 10;  // Бёрем последнюю цифру числа (чтобы её умножит на 10 в степени (количество цифр числа)-1 и получить первую
        int first_digit = number / (int)Math.Pow(10, count_digits - 1);  // Берём первую цифру числа, путём деления на десять в степени индекса последнего разряда числа -1

        Int32 center_part = number / 10 % (int)Math.Pow(10, count_digits - 2);  // Убираем последнюю цифру исходногоо числаи делим на 10 в степени количество цифр-2, т.к. мы стираем 2 цифры


        result = sign * ((center_part * 10 + first_digit) + (last_digit * (int)Math.Pow(10, count_digits - 1)));  // Результат преобразований первого числа
    }

    public static void PrintResult(Int32 number, Int32 result)
    {
        Console.WriteLine($"{number} => {result}");
    }
}
