﻿while (true)
{
	int task = ReadInt("номер задания");

	switch (task)
	{
		case 54: Task54(); break;
		case 56: Task56(); break;
		case 58: Task58(); break;
	}
}


void Task54() // Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
{
    int[,] array = CreateTwoDimensionIntArray(ReadInt("первое измерение"), ReadInt("второе измерение"));
	Console.WriteLine(TwoDimensionIntArrayToString(array));
    Console.WriteLine(LineSortDescending(array));
}

void Task56() // Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
{
	int[,] array = CreateTwoDimensionIntArray(3, 7);
	Console.WriteLine(TwoDimensionIntArrayToString(array));
	int firstLineNumber = 0;
	int secondLineNumber = 1;
	int ThirdLineNumber = 2;
	ComparisonSum((SumLineElements(firstLineNumber, array)), (SumLineElements(secondLineNumber, array)), (SumLineElements(ThirdLineNumber, array)));

}

void Task58() // Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
{
	int[,] firstMatrix = CreateTwoDimensionIntArray(ReadInt("количество строк первой матрицы"), ReadInt("количество столбцов первой матрицы"));
	int[,] secondMatrix = CreateTwoDimensionIntArray(ReadInt("количество строк второй матрицы"), ReadInt("количество столбцов второй матрицы"));
	if (firstMatrix.GetLength(1) == secondMatrix.GetLength(0))
	{	
		Console.WriteLine(TwoDimensionIntArrayToString(firstMatrix));
		Console.WriteLine(TwoDimensionIntArrayToString(secondMatrix));
		MultipleMatrices(firstMatrix, secondMatrix);
	}
	else 
	Console.WriteLine("Матрицы не согласованы, умножение невозможно. Попробуйте ввести матрицы так, чтобы количеcтво столбцов первой матрицы было равно количеству строк второй матрицы");	
}

int ReadInt(string argument)
{
	int number;
	Console.Write($"Введите {argument}: ");

	while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
	{
		Console.WriteLine("Ошибка ввода, пожалуйста, введите неотрицательное число");
    }

    return number;
}

int[,] CreateTwoDimensionIntArray(int firstLength, int secondLength)
{
	int[,] result = new int[firstLength, secondLength];
	Random rnd = new Random();

	for (int i = 0; i < result.GetLength(0); i++)
	{
		for (int j = 0; j < result.GetLength(1); j++)
		{
			result[i, j] = rnd.Next(0, 10);
		}
	}

	return result;
}

string TwoDimensionIntArrayToString(int[,] array)
{
	string result = string.Empty;

	for (int i = 0; i < array.GetLength(0); i++)
	{
		for (int j = 0; j < array.GetLength(1); j++)
		{
			result += $"{array[i, j]} ";
		}

		result += Environment.NewLine;
    }

	return result;
}

string LineSortDescending(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            int helper;

			for (int n = 0; n < array.GetLength(1); n++)
            {
                for (int j = n + 1; j < array.GetLength(1); j++)
                {
                    if (array[i,n] < array[i,j])
                    {
                        helper = array[i,n];
                        array[i,n] = array[i,j];
                        array[i,j] = helper;
                    }
                }
		    }
		}

		return TwoDimensionIntArrayToString(array);
    }

int SumLineElements(int i, int[,] array)
{
	int sum = 0;

	for (int j = 0; j < array.GetLength(1); j++)
	{
		sum = sum + array[i,j];
	}

	Console.WriteLine($"Сумма строки {i} равняется {sum}");

	return (sum);
}

void ComparisonSum(int a, int b, int c)
{
	if (a < b && a < c)
	Console.WriteLine($"Строка с наименьшей суммой элементов - первая");
	else
	{
		if (b < c && b < a)
		Console.WriteLine($"Строка с наименьшей суммой элементов - вторая");
		else
		Console.WriteLine($"Строка с наименьшей суммой элементов - третья");
	}
}

void MultipleMatrices(int[,] firstMatrix, int[,] secondMatrix)
{
	for (int i = 0; i < firstMatrix.GetLength(0); i++)
	{
		for (int n = 0; n < secondMatrix.GetLength(1); n++)
		{
			int j = 0;
			int m = 0;
			int product = 0;
			while (j < firstMatrix.GetLength(1) && m < secondMatrix.GetLength(0))
			{
				product = product + firstMatrix[i,j] * secondMatrix[m,n];
				j = j + 1;
				m = m + 1;
			}
			Console.Write($"{product} ");
		}
		Console.WriteLine();
	}
}