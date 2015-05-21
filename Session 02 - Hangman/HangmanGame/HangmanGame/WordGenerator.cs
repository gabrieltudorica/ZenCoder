using System;

namespace HangmanGame
{
    public class WordGenerator
    {
        readonly string[] words =  
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
            int randomWord = random.Next(0, words.Length);

            return words[randomWord];
        }
    }
}
