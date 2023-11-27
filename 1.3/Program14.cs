using System;


class Program
{
    public static void Main(string[] argv)
    {
        GetWeightFighter(out float weight);  // Вводим вещественное число с приглашением к вводу

        if (weight > 0 && weight < 250) {  // Проверяем разумность веса
            CalcResult(weight, out string result);
            Console.WriteLine(result);  // Вывод результата
        }
        else {
            Console.WriteLine("Не валидный вес");
        }
    }

    public static void GetWeightFighter(out float n)
    {
        Console.Write("Введите вес боксёра в кг: ");  // Приглашение к вводу числа
        string input = Console.ReadLine() ?? "0.0";  // Если ничего не ввели, значение по умолчанию - 0

        if (!Single.TryParse(input, out n)) {  // Попытка перевести строку в число
            Console.WriteLine("Не корректноый тип! Ввод для первого числа должен быть вещественным.");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }
    }

    public static void CalcResult(float weight, out string result)
    {
        result = $"Вес {weight}, весовая категория: ";  // Заранее определяем результирующщу строку, иначе - лишний код

        // Условия вычисления весовой категории
        if (weight < 60) {
            result += "лёгкий вес.";
        }
        else if (weight < 64) {
            result += "первый полусредний вес.";

        }
        else if (weight < 69) {
            result += "полусредний вес.";
        }
        else {  // В условии задачи не было ничего сказано про исключительный вариант..
            result += "средний вес.";
        }
    }
}
