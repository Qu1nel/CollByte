using System;

class Program
{
    public static void Main(string[] argv)
    {
        GetNumbers(out Int32 a, out Int32 b);  // Вводим два числа с приглашением к вводу

        Int32 res_a = a;  // Заранее ложим в результирующие переменные исходные числа (4-ое условие)
        Int32 res_b = b;

        if (a < 0 && b < 0) {  // 1-ое улосвие: оба числа отрицательные
            ToAbs(ref a, ref b, ref res_a, ref res_b);  // Кладём в res_X переменные абсолютные значения а и b
        }
        else if (a < 0 || b < 0) {  // 2-ое улосвие: одно из них отрицательные
            IncBoth5(ref a, ref b, ref res_a, ref res_b);  // Прибавляем 5 к res_X результирующим переменным
        }
        else if ((a >= 0 && b >= 0) && (NotIn5to20(a) || NotIn5to20(b))) {  // 3-ое улосвие: оба числа неотрицательные и одно из них не в [5; 20]
            IncBoth10(ref a, ref b, ref res_a, ref res_b);  // Прибавляем 10 к res_X результирующим переменным
        }

        PrintResult(a, b, res_a, res_b);  // Выводим результат
    }

    public static void ToAbs(ref Int32 a, ref Int32 b, ref Int32 res_a, ref Int32 res_b)
    {
        res_a = Math.Abs(a);
        res_b = Math.Abs(b);
    }

    public static void IncBoth5(ref Int32 a, ref Int32 b, ref Int32 res_a, ref Int32 res_b)
    {
        res_a = a + 10;
        res_b = b + 10;
    }

    public static void IncBoth10(ref Int32 a, ref Int32 b, ref Int32 res_a, ref Int32 res_b)
    {
        IncBoth5(ref a, ref b, ref res_a, ref res_b);
        IncBoth5(ref a, ref b, ref res_a, ref res_b);
    }

    public static void GetNumbers(out Int32 a, out Int32 b)
    {
        // Ввод первого числа
        Console.Write("Введите первое число: ");
        a = Convert.ToInt32(Console.ReadLine());

        // Ввод второго числа
        Console.Write("Введите второе число: ");
        b = Convert.ToInt32(Console.ReadLine());
    }

    public static void PrintResult(Int32 a, Int32 b, Int32 res_a, Int32 res_b)
    {
        Console.WriteLine($"После обработки чисел {a} и {b}");
        Console.WriteLine($"получен результат: {res_a}, {res_b}");
    }

    public static bool NotIn5to20(Int32 n)
    {
        return n < 5 || n > 20;
    }
}
