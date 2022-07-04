using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sentence = Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .ToArray();
            Dictionary<char, int> lettersOcurncies = new Dictionary<char, int>();
            for(int i = 0; i < sentence.Length; i++)
            {
                string currentWord = sentence[i];
                foreach(char letter in currentWord)
                {
                    if (!lettersOcurncies.ContainsKey(letter))
                    {
                        lettersOcurncies[letter]=0;
                    }
                    lettersOcurncies[letter] += 1;
                }
            }
            foreach(var item in lettersOcurncies)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
            
        }
    }
}
