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
    for (int z = 0; z < matr.GetLength(0); z++)
    {
        for (int i = 0; i < matr.GetLength(0); i++)
        {
            for (int j = 0; j < matr.GetLength(1) - 1; j++)
            {
                if (matr[i, j] < matr[i, j + 1])
                {
                    int temp = matr[i, j + 1];
                    matr[i, j + 1] = matr[i, j];
                    matr[i, j] = temp;
                }
            }
        }
    }

    Console.WriteLine();
    Console.WriteLine("Отсортированная матрица: ");
    PrintArray(matr);
}

Console.WriteLine();
FillArray(matrix);
Console.WriteLine("Матрица: ");
PrintArray(matrix);
Sorted(matrix);
Console.WriteLine();

