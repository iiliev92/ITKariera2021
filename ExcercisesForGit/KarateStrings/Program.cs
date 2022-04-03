using System;

namespace KarateStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string karate = Console.ReadLine();
                int sum = 0, firstIndex = -1, lastIndex = -1;

                for (int i = 0; i < karate.Length; i++)
                {
                    if (karate[i] == '>')
                    {
                        if (sum == 0)
                        {
                            firstIndex = i + 1;
                        }

                        sum = sum + int.Parse(karate[i + 1].ToString());
                        i++;
                    }
                    else if(sum != 0)
                    {
                        lastIndex = i;

                        if (firstIndex + 1 == lastIndex)
                        {
                            karate = karate.Remove(firstIndex, sum);
                            i = firstIndex - 1;
                        }
                        else
                        {
                            int count = 0;
                            while (firstIndex + 1 != lastIndex)
                            {
                                karate = karate.Remove(firstIndex, 1);
                                firstIndex++;
                                lastIndex--;
                                count++;
                            }

                            sum = sum - count;

                            if (sum > 0)
                            {
                                karate = karate.Remove(firstIndex, sum);
                            }
                        }

                        sum = 0;
                    }
                }

                Console.WriteLine(karate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
