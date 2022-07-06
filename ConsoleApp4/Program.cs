
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    class Program
    {
        static string regexCleanSpaces(string words)
        {
            return Regex.Replace(words, @"\s{1,}", " ");
        }

        static string CleanWords(string words)
        {
            StringBuilder CheckedWords = new StringBuilder();
            for (int letter = 0; letter < words.Length; letter++)
            {
                if (!char.IsPunctuation(words[letter]))
                    CheckedWords.Append(words[letter]);
            }
            return regexCleanSpaces(CheckedWords.ToString().Trim());
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter your words: ");
                string Words = Console.ReadLine();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string CleanedWords = CleanWords(Words.Trim());
                stopwatch.Stop();
                Console.WriteLine($"Time elapses is {stopwatch.Elapsed.Milliseconds} Milliseconds");
                Console.WriteLine($"Cleaned Words: {CleanedWords}");
                int WordsCount = 0;
                for (int cL = 0; cL < CleanedWords.Length; cL++)
                {
                    if (cL != 0 && char.IsWhiteSpace(CleanedWords[cL - 1]))
                    {
                        WordsCount++;
                    }
                }
                Console.WriteLine($"Words count: {WordsCount + 1 }");

            }

        }


    }
}
