using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Searching
{
    class Program
    {
        static string[] words;
        static Random rnd = new Random();
        static Stopwatch swLinear = new Stopwatch();
        static Stopwatch swBinary = new Stopwatch();

        static void Main(string[] args)
        {
            words = System.IO.File.ReadAllLines(@"C:\Work\Training\Searching\words.txt");

            Array.Sort(words, (a, b) => String.Compare(a, b, true));

            swLinear.Start();
            for (int i = 0; i < 10000; i++)
            {
                LinearSearch(FindRandomWord());
            }
            swLinear.Stop();

            Console.WriteLine("Time for Linear: {0} ", swLinear.Elapsed);
            //Console.ReadLine();
            //Console.WriteLine(words[384670]);

            swBinary.Start();
            for (int i = 0; i < 10000; i++)
            {
                //bool found = BinarySearch("stinkberries", 0, words.Length - 1);
                bool found = BinarySearch(FindRandomWord(), 0, words.Length - 1);
            }
            swBinary.Stop();

            Console.WriteLine("Time for Binary: {0} ", swBinary.Elapsed);
            Console.ReadLine();

        }

        static string FindRandomWord()
        {
            return words[rnd.Next(1, words.Length)];
        }

        static void LinearSearch(string wordToFind)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == wordToFind)
                {
                    return;
                }
            }
        }

        static bool BinarySearch(string wordToFind, int min, int max)
        {
            bool found = false;

            while (!found && min < max)
            {
                int mid = (min + max) / 2;
                if (wordToFind == words[mid])
                {
                    found = true;
                }
                else if (string.Compare(wordToFind, words[mid], true) < 0)
                {
                    return BinarySearch(wordToFind, min, mid - 1);
                }
                else
                {
                    return BinarySearch(wordToFind, mid + 1, max);
                }
            }
            return true;
        }
    }
}
