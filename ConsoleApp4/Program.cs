
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello World!");
    //        KashafaContext kashafaContext = new KashafaContext();
    //        var members = kashafaContext.TbMembers.
    //            Include(x => x.TbAttendences).ToList();

    //        foreach (var member in members)
    //        {
    //            if (member.TbAttendences.Where(x => x.MeetingId == 1).FirstOrDefault() == null)
    //            {
    //                Console.WriteLine(member.MemberName + " is abcense");
    //            }
    //        }

    //        Console.ReadLine();
    //    }
    //}

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
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine($"Cleaned Words: {CleanedWords}");
                Console.ForegroundColor = ConsoleColor.White;

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


        /// <summary>
        /// Hashing the UNique hwid
        /// </summary>
        /// <returns></returns>
        static string GetMd5Sum()
        {
            string randomString = Guid.NewGuid().ToString();
            System.Text.Encoder enc = System.Text.Encoding.Unicode.GetEncoder();
            byte[] unicodeText = new byte[randomString.Length * 2];
            enc.GetBytes(randomString.ToCharArray(), 0, randomString.Length, unicodeText, 0, true);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }
            return sb.ToString();
        }


    }
}
