using System;
using System.Text;

namespace StringBuilderExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputData = Console.ReadLine();
                StringBuilder sb = new StringBuilder(inputData);

                string[] commandAndArgs = Console.ReadLine().Split();

                switch (commandAndArgs[0])
                {
                    case "Append": sb = sb.Append(commandAndArgs[1]); break;
                    case "Remove": sb = sb.Remove(int.Parse(commandAndArgs[1]), int.Parse(commandAndArgs[2])); break;
                    case "Insert": sb = sb.Insert(int.Parse(commandAndArgs[1]), commandAndArgs[2]); break;
                    case "Replace": sb = sb.Replace(commandAndArgs[1], commandAndArgs[2]); break;
                    default: Console.WriteLine("Unsupported command! [Append/Remove/Insert/Replace]"); break;
                }

                Console.WriteLine(sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
