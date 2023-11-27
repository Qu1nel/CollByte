using System;

class Program
{
    public static void Main(string[] argv)
    {
        GetNumbers(out Int32 a, out Int32 b);  // Вводим два числа с приглашением к вводу

        Int32 res_a = a;  // Заранее ложим в результирующие переменные исходные числа (4-ое условие)
        Int32 res_b = b;

        if (NumberLessZero(a) && NumberLessZero(b)) {  // 1-ое улосвие: оба числа отрицательные
            ToAbs(ref res_a, ref res_b);  // Кладём в res_X переменные абсолютные значения а и b
        }
        else if (NumberLessZero(a) || NumberLessZero(b)) {  // 2-ое улосвие: одно из них отрицательные
            IncBoth5(ref res_a, ref res_b);  // Прибавляем 5 к res_X результирующим переменным
        }
        else if ((!NumberLessZero(a) && !NumberLessZero(b)) && (NotIn5to20(a) || NotIn5to20(b))) {  // 3-ое улосвие: оба числа неотрицательные и одно из них не в [5; 20]
            IncBoth10(ref res_a, ref res_b);  // Прибавляем 10 к res_X результирующим переменным
        }

        PrintResult(a, b, res_a, res_b);  // Выводим результат
    }

    public static void GetNumbers(out Int32 a, out Int32 b)  // Метод ввода двух целых чисел, иначе выход из программы
    {
        // Ввод первого числа
        Console.Write("Введите первое целое число: ");  // Приглашение к вводу первого числа
        string input = Console.ReadLine() ?? "0";  // Если ничего не было введено, значение по умолчанию - 0

        if (!Int32.TryParse(input, out a)) {  // Попытка перевести строку в число
            Console.WriteLine("Не корректный тип! Ввод для первого числа должен быть целочисленным.");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }


        // Ввод второго числа
        Console.Write("Введите первое целое число: ");  // Приглашение к вводу второго числа
        input = Console.ReadLine() ?? "0";  // Если ничего не было введено, значение по умолчанию - 0

        if (!Int32.TryParse(input, out b)) {  // Попытка перевести строку в число
            Console.WriteLine("Не корректный тип! Ввод для второго числа должен быть целочисленным.");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }
    }

    public static void ToAbs(ref Int32 res_a, ref Int32 res_b)  // Заменяет значения двух переменных на их абсолютные велечины
    {
        res_a = Math.Abs(res_a);
        res_b = Math.Abs(res_b);
    }

    public static void IncBoth5(ref Int32 res_a, ref Int32 res_b)  // Искрементирует две переменные на 5
    {
        res_a += 5;
        res_b += 5;
    }

    public static void IncBoth10(ref Int32 res_a, ref Int32 res_b)  // Искрементирует две переменные на 10
    {
        res_a += 10;
        res_b += 10;
    }

    public static void PrintResult(Int32 a, Int32 b, Int32 res_a, Int32 res_b)  // Метод вывода резульата по условию
    {
        Console.WriteLine($"После обработки чисел {a} и {b}");
        Console.WriteLine($"получен результат: {res_a}, {res_b}");
    }

    private static bool NotIn5to20(Int32 n)  // Метод-предикат: проверяет не пренадлежность n интервалу [5; 20]
    {
        return n < 5 || n > 20;
    }

    private static bool NumberLessZero(Int32 n)  // Метод-предикат: проверяет является ли число отрицательным (инверсия позволяет проверить является ли число неотрицательным)
    {
        return n < 0;
    }
}
