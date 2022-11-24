// Задача 56: Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке
// и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int[,] CreateMatrixRndInt(int rows, int columns, int SumLine, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(SumLine, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],2}");
            Console.Write(j < matrix.GetLength(1) - 1 ? " " : "");
        }
        Console.WriteLine("]");
    }

}

int[] SumMatrixLinesCount(int[,] matrix)
{
    int[] array = new int[matrix.GetLength(0)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        ;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            array[i] += matrix[i, j];
        }
    }
    return array;
}

int MinInArray(int[] array)
{
    int min = array[0];
    int minLineNumber = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] < min)
        {
            min = array[i];
            minLineNumber = i;
        }
    }
    return minLineNumber;
}

int[,] matrixRnd = CreateMatrixRndInt(4, 4, 1, 9);
PrintMatrix(matrixRnd);
Console.WriteLine();

int[] sumLines = SumMatrixLinesCount(matrixRnd);

// Нумерацию строк оставляем с 0
Console.WriteLine($"Строка с наименьшей суммой: № {MinInArray(sumLines)}");