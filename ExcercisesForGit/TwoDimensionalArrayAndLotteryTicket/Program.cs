using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoDimensionalArrayAndLotteryTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int rows = rowsAndCols[0];
                int cols = rowsAndCols[1];

                int[,] array = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();

                    for (int j = 0; j < cols; j++)
                    {
                        array[i, j] = row[j];
                    }
                }

                //PrintArray(array);

                int mainDiagonalSum = 0, secondDiagonalSum = 0,
                    aboveMainDiagonalSum = 0, belowMainDiagonalSum = 0;
                
                // I way
                for (int i = 0; i < rows; i++)
                {
                    mainDiagonalSum = mainDiagonalSum + array[i, i];
                }

                // II way:
                //for (int i = 0; i < rows; i++)
                //{
                //    for (int j = 0; j < cols; j++)
                //    {
                //        if (i == j)
                //        {
                //            mainDiagonalSum = mainDiagonalSum + array[i, j];
                //        }
                //    }
                //}

                for (int i = 0; i < rows; i++)
                {
                    secondDiagonalSum = secondDiagonalSum + array[i, cols - 1 - i];
                }

                if (mainDiagonalSum == secondDiagonalSum)
                {
                    for (int i = 0; i < rows - 1; i++)
                    {
                        for (int j = i + 1; j < cols; j++)
                        {
                            aboveMainDiagonalSum = aboveMainDiagonalSum + array[i, j];
                        }
                    }

                    if (aboveMainDiagonalSum % 2 == 0)
                    {
                        for (int i = 1; i < rows; i++)
                        {
                            for (int j = 0; j < i; j++)
                            {
                                belowMainDiagonalSum = belowMainDiagonalSum + array[i, j];
                            }
                        }

                        if (belowMainDiagonalSum % 2 != 0)
                        {
                            decimal income = CalculatePrize(array);

                            Console.WriteLine("YES");
                            Console.WriteLine("The amount of money won is: {0:f2}", Math.Round(income, 2));
                        }
                        else
                        {
                            Console.WriteLine("NO");
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static decimal CalculatePrize(int[,] array)
        {
            int mainDiagonalSum = 0, belowMainDiagonalSum = 0;

            for (int i = 1; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    belowMainDiagonalSum = belowMainDiagonalSum + array[i, j];
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, i] % 2 == 0)
                {
                    mainDiagonalSum = mainDiagonalSum + array[i, i];
                }
            }

            int outsideRowsSum = 0, outsideColsSum = 0;

            for (int i = 0; i <= array.GetLength(0); i++)
            {
                if (i == 0 || i == array.GetLength(0) - 1)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] % 2 == 0)
                        {
                            outsideRowsSum = outsideRowsSum + array[i, j];
                        }
                    }
                }
            }

            for (int j = 0; j <= array.GetLength(1); j++)
            {
                if (j == 0 || j == array.GetLength(1) - 1)
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        if (array[i, j] % 2 != 0)
                        {
                            outsideColsSum = outsideColsSum + array[i, j];
                        }
                    }
                }
            }

            decimal average = (mainDiagonalSum + belowMainDiagonalSum + outsideRowsSum + outsideColsSum) / 4.00m;

            return average;
        }

    }
}
