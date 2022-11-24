// Задача 60. ...Сформируйте трёхмерный массив
// из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно
// выводить массив, добавляя индексы каждого элемента.
// Например, задан массив размером 2 x 2 x 2.
// Результат:
// 66(0,0,0) 27(0,0,1) 25(0,1,0) 90(0,1,1)
// 34(1,0,0) 26(1,0,1) 41(1,1,0) 55(1,1,1)

int[,,] Create3D(int rows, int columns, int depth, int[] arrayRnd)
{
    int[,,] cube = new int[rows, columns, depth];
    int count = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {

            for (int k = 0; k < depth; k++)
            {
                cube[i, j, k] = arrayRnd[count++];
            }
        }
    }
    return cube;
}

void Print3DByLines(int[,,] cube)
{
    for (int i = 0; i < cube.GetLength(0); i++)
    {
        for (int j = 0; j < cube.GetLength(1); j++)
        {
            for (int k = 0; k < cube.GetLength(2); k++)
            {
                Console.Write($"{cube[i, j, k],3}");
                Console.Write($"({i},{j},{k})");
                // Console.Write(j < cube.GetLength(1) - 1 ? " " : "");
            }
        }
        Console.WriteLine();
    }
}

int[] CreateRndArray2Digits(int num)
{
    int[] array = new int[num];
    for (int i = 0; i < num; i++)
    {
        array[i] = i + 10;
    }
    int[] arrayRnd = new int[num];
    Random rnd = new Random();
    for (int i = 0; i < num; i++)
    {
        int randomIndex = rnd.Next(0, num);
        while (array[randomIndex] == 0)
        {
            randomIndex++;
            if (randomIndex > num - 1) randomIndex = 0;
        }
        arrayRnd[i] = array[randomIndex];
        array[randomIndex] = 0;
    }
    return arrayRnd;
}

int rows3D = 3;
int columns3D = 3;
int depth3D = 3;
int matrix3DLength = rows3D * columns3D * depth3D;

int[] arrRnd2Digits = CreateRndArray2Digits(matrix3DLength);

int[,,] matrix3D = Create3D(rows3D, columns3D, depth3D, arrRnd2Digits);
Print3DByLines(matrix3D);