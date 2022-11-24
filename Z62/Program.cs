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
            if (i == 0) matr[i, j] = j + 1;
            if (i != 0 && i != rows - 1 && j != columns - 1 && j == 0) matr[i, j] = j + (columns * rows) - (((columns - 2) * (rows - 2))) - i + 1;
            if (j == columns - 1) matr[i, j] = i + j + 1;
            if (i == rows - 1) matr[i, j] = matr[i - 1, 0] - j - 1;
        }
    }

    int pi = 1;
    int pj = 1;

    for (int z = 0; z < matr.GetLength(0); z++)
    {
        for (int i = pi; i < matr.GetLength(0) - pi; i++)
        {
            for (int j = pj; j < matr.GetLength(1) - pj; j++)
            {
                if (i == pi) matr[i, j] = matr[pi, pj - 1] + j - pj + 1;

                if (i != pi && i != rows - 1 - pi && j != columns - 1 - pj && j == pj) matr[i, j] = matr[i, j - 1] + (4 * columns - 11)-8*(pi-1);
                if (j == columns - 1 - pj && i != pi) matr[i, j] = matr[i - 1, j] + 1;

                if (i == rows - 1 - pi && j != columns - 1 - pj && columns%2!=0) matr[i, j] = matr[i - 1, pj] - j+pj-1;

                if (i == rows - 1 - pi && j != columns - 1 - pj && columns%2==0) matr[i, j] = matr[i - 1, pj] - j+pj-1;
                if (i == rows - 1 - pi && j != columns - 1 - pj && columns%2==0 && i==rows/2 && j==columns/2-1) matr[i, j] = matr[i, j-1] + 5;
            }
        }
        pi++;
        pj++;
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

FillArray(matrix);
Console.WriteLine("Матрица: ");
PrintArray(matrix);



