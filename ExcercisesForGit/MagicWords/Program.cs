using System;
using System.Collections.Generic;

namespace MagicWords
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] words = Console.ReadLine().Split();
                string word1 = words[0], word2 = words[1];
                List<char> array1 = new List<char>(word1.Length), array2 = new List<char>(word2.Length);
                bool isMagic = true;

                string tempWord;
                if (word1.Length > word2.Length)
                {
                    tempWord = word1;
                    word1 = word2;
                    word2 = tempWord;
                }

                for (int i = 0; i < word1.Length; i++)
                {
                    if (array1.Contains(word1[i]))
                    {
                        int index = array1.IndexOf(word1[i]);
                        isMagic = array2[index] == word2[i];

                        if (!isMagic)
                        {
                            break;
                        }
                    }
                    else
                    {
                        array1.Add(word1[i]);
                        array2.Add(word2[i]);
                    }
                }

                if (isMagic)
                {
                    if (word2.Length > word1.Length)
                    {
                        for (int i = word1.Length; i < word2.Length; i++)
                        {
                            if (!array2.Contains(word2[i]))
                            {
                                isMagic = false;
                                break;
                            }
                        }       
                    }
                }
                
                Console.WriteLine(isMagic);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
