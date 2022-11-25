// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

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

int[,] SquareMatrixSpirallFilling(int dimension)
{
    int[,] matrix = new int[dimension, dimension];
    int count = 1;
    int cellsNumber = dimension * dimension;
    int[] rowInrements = { 0, 1, 0, -1 };
    int[] columnInrements = { 1, 0, -1, 0 };
    int incrementPositions = 0;
    int row = 0;
    int column = -1;
    for (int i = 0; i < dimension; i++)
    {
        row += rowInrements[incrementPositions];
        column += columnInrements[incrementPositions];
        matrix[row, column] = count++;
    }
    dimension--;
    incrementPositions++;
    while (count < cellsNumber)
    {
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < dimension; i++)
            {
                row += rowInrements[incrementPositions];
                column += columnInrements[incrementPositions];
                matrix[row, column] = count++;
            }
            if (incrementPositions == 3) incrementPositions = 0;
            else incrementPositions++;
        }
        dimension--;
    }
    return matrix;
}

int matrixDimention = 4;
int[,] spiralMatrix = SquareMatrixSpirallFilling(matrixDimention);
PrintMatrix(spiralMatrix);
