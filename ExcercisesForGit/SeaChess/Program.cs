using System;

namespace SeaChess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                char[,] array = new char[3, 3];

                for (int i = 0; i < 3; i++)
                {
                    string[] row = Console.ReadLine().Split();

                    for (int j = 0; j < 3; j++)
                    {
                        array[i, j] = row[j][0];
                    }
                }

                char playerWon = char.MinValue;
                bool isWon = true;

                for (int i = 0; i < 2; i++)
                {
                    if (array[i, i] != array[i + 1, i + 1])
                    {
                        isWon = false;
                        break;
                    }
                }

                if (isWon)
                {
                    Console.WriteLine("The winner is: {0}", array[0, 0]);
                    return;
                }

                isWon = true;

                for (int i = 0; i < 2; i++)
                {
                    if (array[i, 2 - i] != array[i + 1, 2 - i - 1])
                    {
                        isWon = false;
                        break;
                    }
                }

                if (isWon)
                {
                    Console.WriteLine("The winner is: {0}", array[0, 2]);
                    return;
                }

                int counter = 1;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (array[i, j] != array[i, j + 1])
                        {
                            isWon = false;
                            break;
                        }
                        else
                        {
                            counter++;

                            if (counter == 3)
                            {
                                isWon = true;
                                playerWon = array[i, j];
                                break;
                            } 
                        }
                    }

                    if (isWon)
                    {
                        break;
                    }

                    counter = 1;
                }

                if (isWon)
                {
                    Console.WriteLine("The winner is: {0}", playerWon);
                    return;
                }

                counter = 1;

                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (array[i, j] != array[i + 1, j])
                        {
                            isWon = false;
                            break;
                        }
                        else
                        {
                            counter++;

                            if (counter == 3)
                            {
                                isWon = true;
                                playerWon = array[i, j];
                                break;
                            }
                        }
                    }

                    if (isWon)
                    {
                        break;
                    }

                    counter = 1;
                }

                if (isWon)
                {
                    Console.WriteLine("The winner is: {0}", playerWon);
                    return;
                }

                Console.WriteLine("There is no winner");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
