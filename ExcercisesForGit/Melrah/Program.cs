using System;

namespace Melrah
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string word = Console.ReadLine();
                string pattern = Console.ReadLine();

                do
                {
                    int firstIndex = word.IndexOf(pattern);
                    int lastIndex = word.LastIndexOf(pattern);

                    if (firstIndex != -1 && lastIndex != firstIndex)
                    {
                        word = word.Remove(lastIndex, pattern.Length);
                        word = word.Remove(firstIndex, pattern.Length);

                        Console.WriteLine("Shake it.");

                        pattern = pattern.Remove(pattern.Length / 2, 1);
                    }
                    else
                    {
                        Console.WriteLine("No shake.");
                        Console.WriteLine(word);
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
