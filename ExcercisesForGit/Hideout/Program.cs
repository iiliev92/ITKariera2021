using System;
using System.Linq;

namespace Hideout
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string map = Console.ReadLine();

                do
                {
                    string[] symbolAndCounter = Console.ReadLine().Split();

                    char symbol = symbolAndCounter[0][0];
                    int counter = int.Parse(symbolAndCounter[1]);
                    int occurences = 0;
                    int index = -1;

                    for (int i = 0; i < map.Length; i++)
                    {
                        if (map[i] == symbol)
                        {
                            occurences++;

                            if (occurences == counter)
                            {
                                index = i;
                                break;
                            }
                        }
                    }

                    if (occurences == counter)
                    {
                        int counter2 = 1; // Broim i map[index] !
                        int index2 = -1;

                        for (int j = index - 1; j >= 0; j--)
                        {
                            if (map[j] == symbol)
                            {
                                counter2++;
                            }
                            else
                            {
                                index2 = j + 1;
                                break;
                            }
                        }

                        for (int j = index + 1; j < map.Length; j++)
                        {
                            if (map[j] == symbol)
                            {
                                counter2++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        Console.WriteLine("Hideout found at index {0} and it is with size {1}!",
                            index2, counter2);

                        break;
                    }


                } while (true);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
