using System.Collections.Generic;
using HangmanGame;

namespace HangmanGameTests.HangmanTests
{
    public class HangmanTestsHelper
    {
        private readonly Hangman hangman;

        public HangmanTestsHelper()
        {
            hangman = new Hangman("hangman");
        }

        public Hangman GetInstance()
        {           
            return hangman;
        }

        public int GetMaximumAttempts()
        {
            return 6;
        }

        public void AttemptGuessesWith(IEnumerable<char> letters)
        {
            foreach (char letter in letters)
            {
                hangman.AttemptGuess(letter);
            }
        }

        public void AttemptMultipleGuessesWithSingleLetter(char letter, int numberOfAttempts)
        {
            for (int i = 0; i < numberOfAttempts; i++)
            {
                hangman.AttemptGuess(letter);
            }
        }
    }
}
