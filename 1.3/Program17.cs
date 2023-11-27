using System;


class Program
{
    public static void Main(string[] argv)
    {
        Figure figure = new();  // Объект фигура со всеми нужными полями
        GetInfoAboutFigure(ref figure);  // Ввод названия и координат фигуры на доске

        Point point_to_jmp = new();  // Создание объекта точки с информацией о конечных
        GetPointToJump(ref point_to_jmp);  // Получение информации о точке, куда должна* сходить фигура

        bool can_jump = CanMoveTo(point_to_jmp, figure);  // Определение что за фигура c дальнейшими вычислениями
        PrintResult(can_jump);  // Вывод результата
    }

    static void GetInfoAboutFigure(ref Figure figure)
    {
        // Ввод названия фигуры
        Console.Write("Введите символ обозначающий фигуру (Ф – ферзь, Ц – король, Л – ладья, С – слон, К – конь): ");
        figure.Name = Console.ReadLine() ?? "";

        // Ввод x координаты фигуры
        Console.Write("Введите координату фигуры по x (от 1 до 8): ");
        figure.X = Convert.ToInt32(Console.ReadLine());

        // Ввод y координаты фигуры
        Console.Write("Введите координату фигуры по y (от 1 до 8): ");
        figure.Y = Convert.ToInt32(Console.ReadLine());
    }

    static void GetPointToJump(ref Point point)
    {
        // Ввод x координаты конечной точки
        Console.Write("Введите координату конечной точки по x (от 1 до 8): ");
        point.X = Convert.ToInt32(Console.ReadLine());

        // Ввод y координаты конечной точки
        Console.Write("Введите координату конечной точки по y (от 1 до 8): ");
        point.Y = Convert.ToInt32(Console.ReadLine());

    }

    static bool CanMoveTo(Point to, Figure figure)
    {
        string name = (figure.Name ?? "").ToUpper();  // Сохраняем имя в верхнем регистре (чтобы сравнивать) в локальную переменную

        if (name == "Ф") {  // Ферзь
            return Queen(to, figure);
        }
        else if (name == "Ц") {  // Король
            return King(to, figure);
        }
        else if (name == "Л") {  // Ладья
            return Rook(to, figure);
        }
        else if (name == "С") {  // Слон
            return Bishop(to, figure);
        }
        else if (name == "К")  // Конь
        {
            return Knight(to, figure);
        }
        else {  // Не валидное значение для фигуры
            Console.WriteLine("Фигура не распознана.");
            return false;
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
