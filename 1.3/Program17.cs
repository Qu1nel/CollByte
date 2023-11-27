using System;

class Program
{
    public static void Main(string[] argv)
    {
        GetInfoAboutFigure(out Figure figure);  // Ввод названия и координат фигуры на доске
        GetPointToJump(out Point point_to_jmp);  // Получение информации о точке, куда должна* сходить фигура
        CanMoveTo(point_to_jmp, figure, out bool can_jump);  // Определение может ли фигура сходить на данную точку
        PrintResult(can_jump);  // Вывод результата
    }

    static void GetInfoAboutFigure(out Figure figure)  // Метод ввода информации о фигуре с валидацией данных
    {
        figure = new();

        // Ввод названия фигуры
        Console.Write("Введите символ обозначающий фигуру (Ф – ферзь, Ц – король, Л – ладья, С – слон, К – конь): ");  // Приглашение к вводу фигуры
        string input = Console.ReadLine() ?? "";  // Если ничего не ввели, значение по умолчанию - пустая строка

        if (new List<string> { "Ф", "Ц", "Л", "С", "К" }.All(s => s != input)) {  // Если введённое значение не в этом списке - выход
            Console.WriteLine("Не корректное значение! Допустимый ввод для фигуры: Ф, Ц, Л, С, К.");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }

        figure.Name = input;


        // Ввод x координаты фигуры
        Console.Write("Введите координату фигуры по x (от 1 до 8): ");  // Приглашение к вводу первой координаты фигуры
        input = Console.ReadLine() ?? "0";  // Если ничего не было введено, значение по умолчанию - 0

        if (!Int32.TryParse(input, out int number)) {  // Попытка перевести строку в число
            Console.WriteLine("Не корректное тип! Ввод для координаты должен быть целочисленным.");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }
        else if (number < 1 || number > 8) {
            Console.WriteLine("Не корректное значение! Ввод для координаты должен быть в интервале [1; 8]");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }

        figure.X = number;


        // Ввод y координаты фигуры
        Console.Write("Введите координату фигуры по y (от 1 до 8): ");  // Приглашение к вводу второй координаты фигуры
        input = Console.ReadLine() ?? "0";  // Если ничего не было введено, значение по умолчанию - 0

        if (!Int32.TryParse(input, out number)) {  // Попытка перевести строку в число
            Console.WriteLine("Не корректное тип! Ввод для координаты должен быть целочисленным.");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }
        else if (number < 1 || number > 8) {
            Console.WriteLine("Не корректное значение! Ввод для координаты должен быть в интервале [1; 8]");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }

        figure.Y = number;
    }

    static void GetPointToJump(out Point point)  // Метод ввода информации о конечной точки на доске с валидацией данных
    {
        point = new();

        // Ввод x координаты конечной точки
        Console.Write("Введите координату конечной точки по x (от 1 до 8): ");
        string input = Console.ReadLine() ?? "0";  // Если ничего не было введено, значение по умолчанию - 0

        if (!Int32.TryParse(input, out int number)) {  // Попытка перевести строку в число
            Console.WriteLine("Не корректное тип! Ввод для координаты должен быть целочисленным.");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }
        else if (number < 1 || number > 8) {
            Console.WriteLine("Не корректное значение! Ввод для координаты должен быть в интервале [1; 8]");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }

        point.X = number;


        // Ввод y координаты конечной точки
        Console.Write("Введите координату конечной точки по y (от 1 до 8): ");
        input = Console.ReadLine() ?? "0";  // Если ничего не было введено, значение по умолчанию - 0

        if (!Int32.TryParse(input, out number)) {  // Попытка перевести строку в число
            Console.WriteLine("Не корректное тип! Ввод для координаты должен быть целочисленным.");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }
        else if (number < 1 || number > 8) {
            Console.WriteLine("Не корректное значение! Ввод для координаты должен быть в интервале [1; 8]");  // Вывод предупреждения в случае неудачи
            Environment.Exit(1);  // Выход из программы с кодом возврата не 0
        }

        point.Y = number;
    }

    static void CanMoveTo(Point to, Figure figure, out bool result)
    {
        string name = (figure.Name ?? "").ToUpper();  // Сохраняем имя в верхнем регистре (чтобы сравнивать) в локальную переменную

        if (name == "Ф") {  // Ферзь
            result = Queen(to, figure);
        }
        else if (name == "Ц") {  // Король
            result = King(to, figure);
        }
        else if (name == "Л") {  // Ладья
            result = Rook(to, figure);
        }
        else if (name == "С") {  // Слон
            result = Bishop(to, figure);
        }
        else if (name == "К")  // Конь
        {
            result = Knight(to, figure);
        }
        else {
            throw new Exception("не возможно..");
        }
    }

    static bool Knight(Point to, Figure figure)
    {
        /* 
         * Т.к. конь ходит буквой Г, то при верном ходе одна ось изменяется на 1, вторая на 2.
         * Если вычислить данные абсолютные величины (возвести в квадрат разность) и сложить их,
         * то получиться 4 + 1, т.е. 5
         */
        return (Math.Pow((figure.X - to.X), 2) + Math.Pow(figure.Y - to.Y, 2)) == 5;
    }

    static bool Bishop(Point to, Figure figure)
    {
        /*
         * Слон ходит по диагонали, соответственно его оси изменяются одновременно. Если найти разность осей
         * и взять абсолютную величину, то если они равны - фигура сможет сделать ход.
         */
        return Math.Abs(figure.X - to.X) == Math.Abs(figure.Y - to.Y);
    }

    static bool Rook(Point to, Figure figure)
    {
        /*
         * Ладья ходит вдоль своих осей, т.е. начальная координата должна совпадать с конечной (одна из них).
         */
        return figure.X == to.X || figure.Y == to.Y;
    }

    static bool King(Point to, Figure figure)
    {
        /*
         * Когда ходит король, его оси изменяются только на 1. Соответственно нужно найти абсолютную величину
         * этих изменений: одна ось остается той же - 0, вторая 1; их сумма = 1 всегда.
         */
        return Math.Abs(figure.X - to.X) + Math.Abs(figure.Y - to.Y) == 1;
    }

    static bool Queen(Point to, Figure figure)
    {
        /*
         * Ферзь это сочетание двух фигур - слона и ладьи. Условие, по которому вычисляется валидность хода это
         * составное условие двух фигур: слона и ладьи.
         */
        return Bishop(to, figure) || Rook(to, figure);
    }

    static void PrintResult(bool can)
    {
        if (can) {
            Console.WriteLine("Может");
        }
        else {
            Console.WriteLine("Не может");
        }
    }
}

class Point  // Класс точки на поле 8х8
{
    /*
     * X - Координата x
     * Y - Координата y
     */
    public Int32 X
    {
        get; set;
    }
    public Int32 Y
    {
        get; set;
    }
}

class Figure : Point // Класс фигуры
{
    /*
     * Name - имя фигуры
     * X - Координата x
     * Y - Координата y
     */
    public String? Name
    {
        get; set;
    }
}
