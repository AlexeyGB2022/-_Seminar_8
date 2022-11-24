Console.WriteLine("Введите количество страниц");
int page;
while (!int.TryParse(Console.ReadLine()!, out page) || page <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Неверный ввод");
    Console.ResetColor();
    Console.WriteLine("Введите количество страниц");
}

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

int[,,] matrix = new int[page, rows, columns];
var random = new Random();

void FillArray(int[,,] matr)
{
    int[] arr = new int[page * rows * columns];

    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            for (int k = 0; k < matr.GetLength(2);)
            {
                int temp = random.Next(10, 100);

                int z;
                for (z = 0; z < page * rows * columns; z++)
                {
                    if (temp == arr[z]) break;
                }
                if (z == page * rows * columns)
                {
                    arr[k] = temp;
                    matrix[i, j, k] = temp;
                    k++;
                }
            }
        }
    }
}

void PrintArray(int[,,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            for (int k = 0; k < matr.GetLength(2); k++)
            {
                Console.ForegroundColor = (ConsoleColor)random.Next(12, 16);
                if (matr[i, j, k] == 100) Console.Write($"{matr[i, j, k]}({i},{j},{k})     ");
                else if (matr[i, j, k] == -100) Console.Write($"{matr[i, j, k]}({i},{j},{k})    ");

                else if (matr[i, j, k] < 100 && matr[i, j, k] >= 10) Console.Write($"{matr[i, j, k]}({i},{j},{k})      ");

                else if (matr[i, j, k] > -100 && matr[i, j, k] <= -10) Console.Write($"{matr[i, j, k]}({i},{j},{k})     ");

                else if (matr[i, j, k] > 0 && matr[i, j, k] <= 10) Console.Write($"{matr[i, j, k]}({i},{j},{k})       ");

                else if (matr[i, j, k] >= -10 && matr[i, j, k] < 0) Console.Write($"{matr[i, j, k]}({i},{j},{k})      ");

                else Console.Write($"{matr[i, j, k]}({i},{j},{k})       ");

                Console.ResetColor();
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

Console.WriteLine();
FillArray(matrix);
Console.WriteLine("Матрица: ");
PrintArray(matrix);

Console.WriteLine("Проверка индексации, показан элемент с индексами (1,0,1): " + matrix[1,0,1]);


