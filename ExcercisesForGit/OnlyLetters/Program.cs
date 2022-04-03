using System;

namespace OnlyLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string word = Console.ReadLine();
                int index = -1, count = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    //if (word[i] >= '0' && word[i] <= '9')
                    if(char.IsDigit(word[i]))
                    {
                        if (count == 0)
                        {
                            index = i;
                        }

                        count++;
                    }
                    else
                    {
                        if (index != -1)
                        {
                            word = word.Remove(index, count);
                            word = word.Insert(index, word[i - count].ToString());
                            
                            count = 0;
                            index = -1;
                        }
                    }
                }

                Console.WriteLine(word);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
