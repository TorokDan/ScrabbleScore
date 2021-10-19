using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleScore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kérlek add meg, hogy hány szót szeretnél felvenni: ");
            int nbrOfWords = int.Parse(Console.ReadLine());
            string[,] words = new string[nbrOfWords, 2];

            for (int i = 0; i < words.GetLength(0); i++)
            {
                Console.Write($"Kérem az {i+1}. szót: ");
                words[i, 0] = Console.ReadLine();
            }
            CalculateWordsScores(words);
            Console.WriteLine("---");
            Print(words);
            
            // Ide ki lehetne iratni a ReplaceWorld metódussal, hogy a felhasználó szeretne-e cserélni a tömbben.

            Console.WriteLine("---");
            SortWordsByScore(words);
            Print(words);
        }
        static void CalculateWordsScores(string[,] words)
        {
            for (int i = 0; i < words.GetLength(0); i++)
                words[i, 1] = CalculateWordScore(words[i,0]).ToString();
        }
        static int CalculateWordScore(string s)
        {
            int score = 0;
            for (int i = 0; i < s.Length; i++)
                score += GetCharScore(s[i]);
            return score;
        }
        static int GetCharScore(char c)
        {
            if ("aeiounrtls".Contains(c)) return 1;
            if ("áéíóöőúüű".Contains(c)) return 2;
            if ("dg".Contains(c)) return 3;
            if ("bcmp".Contains(c)) return 5;
            if ("fhv".Contains(c)) return 7;
            if ("kjz".Contains(c)) return 8;
            if ("qwxy".Contains(c)) return 10;
            return 0;
        }
        static void Print(string[,] words)
        {
            Console.WriteLine("Szavak\tÉrtékük");
            for (int i = 0; i < words.GetLength(0); i++)
            {
                Console.WriteLine($"{words[i, 0]}\t{words[i, 1]}");
            }
        }
        static void ReplaceWord(string[,] words, string from, string to)
        {
            for (int i = 0; i < words.GetLength(0); i++)
                if (words[i,0] == from)
                {
                    words[i, 0] = to;
                    words[i, 1] = CalculateWordScore(to).ToString();
                }
        }
        static void SortWordsByScore(string[,] words)
        {
            for (int i = 0; i < words.GetLength(0) -1; i++)
            {
                for (int j = i+1; j < words.GetLength(0); j++)
                {
                    if (int.Parse(words[i,1]) < int.Parse(words[j,1]))
                    {
                        string tmp = words[i, 0];
                        words[i, 0] = words[j, 0];
                        words[j, 0] = tmp;

                        tmp = words[i, 1];
                        words[i, 1] = words[j, 1];
                        words[j, 1] = tmp;
                    }
                }
            }
        }
    }
}
