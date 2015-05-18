using System;
using System.Collections.Generic;

namespace HangmanGame
{
    public class WordGenerator
    {
        readonly List<string> words = new List<string>
        {
            "hangman",
            "iQuest",
            "excellence",
            "commitment",
            "honesty",
            "respect",
            "courage",
            "teamwork"
        };

        public string GetRandom()
        {
            var random = new Random();
            int randomWord = random.Next(0, words.Count);

            return words[randomWord];
        }
    }
}
