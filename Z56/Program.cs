Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Задайте прямоугольную матрицу");
Console.ResetColor();
Console.WriteLine("Введите количество строк");
int rows;
while (!int.TryParse(Console.ReadLine()!, out rows) || rows <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Неверный ввод");
    Console.ResetColor();
    Console.WriteLine("Введите количество строк");
}

Console.WriteLine("Введите количество столбцов");
int columns;
while (!int.TryParse(Console.ReadLine()!, out columns) || columns <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Неверный ввод");
    Console.ResetColor();
    Console.WriteLine("Введите количество столбцов");
}

if (rows == columns)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Матрица не прямоугольная, перезапустите программу");
    Console.ResetColor();
    return;
}

int[,] matrix = new int[rows, columns];
var random = new Random();

void FillArray(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = random.Next(1, 101);
        }
    }
}

void PrintArray(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.ForegroundColor = (ConsoleColor)random.Next(12, 16);
            if (matr[i, j] == 100) Console.Write($"{matr[i, j]}     ");
            else if (matr[i, j] == -100) Console.Write($"{matr[i, j]}    ");

            else if (matr[i, j] < 100 && matr[i, j] >= 10) Console.Write($"{matr[i, j]}      ");

            else if (matr[i, j] > -100 && matr[i, j] <= -10) Console.Write($"{matr[i, j]}     ");

            else if (matr[i, j] > 0 && matr[i, j] <= 10) Console.Write($"{matr[i, j]}       ");

            else if (matr[i, j] >= -10 && matr[i, j] < 0) Console.Write($"{matr[i, j]}      ");

            else Console.Write($"{matr[i, j]}       ");

            Console.ResetColor();
        }
        Console.WriteLine();
    }
}

void Sorted(int[,] matr)
{
    int[,] matrix2 = new int[rows, 1];

    int sum = 0;

    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            sum = sum + matr[i, j];
            matrix2[i, 0] = sum;
        }
        sum = 0;
    }

    Console.WriteLine();
    Console.WriteLine("Матрица из суммы строк: ");
    PrintArray(matrix2);

    int min = matrix2[0, 0];
    int indexMin = 0;

    for (int j = 0; j < matrix2.GetLength(0); j++)
    {
        if (matrix2[j, 0] < min)
        {
            min = matrix2[j, 0];
            indexMin = j;
        }
    }

    Console.WriteLine();
    Console.WriteLine($"Cтрока с наименьшей суммой элементов: {indexMin+1} строка");
}

Console.WriteLine();
FillArray(matrix);
Console.WriteLine("Матрица: ");
PrintArray(matrix);
Sorted(matrix);
Console.WriteLine();
