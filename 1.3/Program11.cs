using System;


class Program
{
    public static void Main(string[] argv)
    {
        GetNumber(out Int32 number);  // Получаем число с приглашение к вводу
        NumberInteresting(number, out bool interesting);  // Проверяем уникальность числа по условию, ложим результат в переменую interesting
        PrintResult(interesting);  // Вывод результата
    }

    public static void GetNumber(out Int32 n)  // Метод ввода числа с валидацией вводимого значения
    {
        Console.Write("Введите целое число: ");  // Приглашение к вводу числа
        string input = Console.ReadLine() ?? "0";  // Если ничего не ввели, значение по умолчанию - 0

        if (!Int32.TryParse(input, out n)) {  // Попытка перевести строку в число
            Console.WriteLine("Не корректное значение! Ввод для первого числа должен быть целочисленным.");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }
    }

    public static void NumberInteresting(Int32 num, out bool result)  // Метод предикат, который вычисляет является ли число интересным (по условию)
    {
        num = Math.Abs(num);  // Дальнейшие вычисления легче выполнять, когда число положительное
        Int32 count_digits = Convert.ToInt32(Math.Floor(Math.Log10(num))) + 1;  // Считаем количество цифр int(log10(num)) + 1 для дальнейших вычислений

        if (count_digits != 3) {  // Если число не 3-х значное можно не продолжать
            result = false;
            return;
        }

        // Заводим локальные переменные для дальнейших действий (под максимальную цифру, минимальную циферку)
        Byte max = 0;
        Byte min = 9;

        // Раскладываем число на 3 цифры
        Byte first_digit = (byte)(num / 100);  // Количество сотен единиц в разряде
        Byte second_digit = (byte)(num / 10 % 10);  // Количество десятков единиц в разряде
        Byte third_digit = (byte)(num % 10);  // Количество единиц в разряде

        // Находим максимальную, а затем минимальную цифру:
        if (first_digit >= second_digit && first_digit >= third_digit) {  // Первая больше чем две другие
            max = first_digit;
        }
        else if (second_digit >= first_digit && second_digit >= third_digit) {  // Вторая больше чем две другие
            max = second_digit;
        }
        else if (third_digit >= first_digit && third_digit >= second_digit) {  // Третья больше чем две другие
            max = third_digit;
        }

        // Минимальная цифра
        if (first_digit <= second_digit && first_digit <= third_digit) {  // Первая меньше чем две другие
            min = first_digit;
        }
        else if (second_digit <= first_digit && second_digit <= third_digit) {  // Вторая меньше чем две другие
            min = second_digit;
        }
        else if (third_digit <= first_digit && third_digit <= second_digit) {  // Третья больше чем две другие
            min = third_digit;
        }

        result = (max - min) == second_digit;  // Определяем является ли число интересным (по условию)
    }

    public static void PrintResult(bool flag)  // Метод вывода результата
    {
        Console.WriteLine(flag ? "Число интересное" : "Число не интересное");
    }
}
