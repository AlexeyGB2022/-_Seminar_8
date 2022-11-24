Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Задайте две матрицы, так чтобы количество стобцов первой матрицы было равным количеству строк второй матрицы");
Console.ResetColor();

Console.WriteLine("Введите количество строк первой матрицы");
int rows1;
while (!int.TryParse(Console.ReadLine()!, out rows1) || rows1 <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Неверный ввод");
    Console.ResetColor();
    Console.WriteLine("Введите количество строк первой матрицы");
}

Console.WriteLine("Введите количество столбцов первой матрицы");
int columns1;
while (!int.TryParse(Console.ReadLine()!, out columns1) || columns1 <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Неверный ввод");
    Console.ResetColor();
    Console.WriteLine("Введите количество столбцов первой матрицы");
}

int[,] matrix1 = new int[rows1, columns1];

Console.WriteLine("Введите количество строк второй матрицы");
int rows2;
while (!int.TryParse(Console.ReadLine()!, out rows2) || rows2 <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Неверный ввод");
    Console.ResetColor();
    Console.WriteLine("Введите количество строк второй матрицы");
}

Console.WriteLine("Введите количество столбцов второй матрицы");
int columns2;
while (!int.TryParse(Console.ReadLine()!, out columns2) || columns2 <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Неверный ввод");
    Console.ResetColor();
    Console.WriteLine("Введите количество столбцов второй матрицы");
}

int[,] matrix2 = new int[rows2, columns2];

if (rows2 != columns1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Количество стобцов первой матрицы не равно количеству строк второй матрицы, перезапустите программу");
    Console.ResetColor();
    return;
}

var random = new Random();

void FillArray(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = random.Next(1, 6);
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

void Product(int[,] matr1, int[,] matr2)
{
    int[,] matrix3 = new int[rows1, columns2];

    int product = 0;

    for (int z = 0; z < matr1.GetLength(0); z++)
    {
        for (int i = 0; i < matr1.GetLength(0); i++)
        {
            for (int j = 0; j < matr2.GetLength(1); j++)
            {
                product = product + matr1[i, j] * matr2[j, z];
            }
            matrix3[i, z] = product;
            product = 0;
        }
    }
    Console.WriteLine();
    Console.WriteLine("Произведение двух матрица: ");
    PrintArray(matrix3);
}

Console.WriteLine();
FillArray(matrix1);
Console.WriteLine("Первая матрица: ");
PrintArray(matrix1);

Console.WriteLine();
FillArray(matrix2);
Console.WriteLine("Вторая матрица: ");
PrintArray(matrix2);

Product(matrix1, matrix2);
Console.WriteLine();

