using System;


class Program
{
    public static void Main(string[] argv)
    {
        Int32 number = GetNumber();  // Получаем число + приглашение к вводу
        Console.WriteLine(NumberInteresting(number) ? "Число интересное" : "Число не интересное");  // Вывод результата, использую тернарный оператор ветления
    }

    public static Int32 GetNumber()
    {
        Console.Write("Введите число: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    public static bool NumberInteresting(Int32 num)  // Метод предикат, который вычисляет является ли число интересным (по условию)
    {
        Int32 count_digits = Convert.ToInt32(Math.Floor(Math.Log10(Math.Abs(num)))) + 1;  // Сразу считаем количество цифр int(log10(num)) + 1

        if (count_digits != 3) {  // Если число не 3-х значное можно не продолжать, а вернуть false
            return false;
        }

        // Заводим локальные переменные для дальнейших действий (под максимальную цифру, минимальную и среднюю)
        Int32 max = 0;
        Int32 avg = num / 10 % 10;  // Чтобы получить цифру в разряде десятков, число нужно поделить на 10 и взять остаток деления на 10 (по кольцу вычетов это от 0 до 9)
        Int32 min = 9;

        while (num != 0) {  // В цикле разбираем* число на цифры путём взятия последней, пока число не будет равно 0
            Int32 digit = num % 10;  // Берём цифру с начало

            if (digit > max) {  // Если число больше максимальной - максимальная = цифра
                max = digit;
            }
            if (digit < min) {  // Если число меньше минимальной - минимальная = цифра
                min = digit;
            }
            num /= 10;  // Убираем цифру в начале
        }

        return (max - min) == avg;  // Определяем является ли число интересным (по условию)
    }
}
