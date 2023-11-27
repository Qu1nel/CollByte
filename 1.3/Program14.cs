using System;


class Program
{
    public static void Main(string[] argv)
    {
        float weight = GetWeightFighter();  // Вводим вещественное число с приглашением к вводу
		
        if (weight > 0 && weight < 250) {  // Проверяем разумность веса
            string result = $"Вес {weight}, весовая категория: ";  // Заранее определяем результирующщу строку, иначе - лишний код

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
            else {
                result += "средний вес.";
            }

            Console.WriteLine(result);  // Вывод результата
        }
        else {
            Console.WriteLine("Не валидный вес");
        }
    }

    public static float GetWeightFighter()
    {
        Console.Write("Введите вес боксёра: ");
        return Convert.ToSingle(Console.ReadLine());
    }
}
