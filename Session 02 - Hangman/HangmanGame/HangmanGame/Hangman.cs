using System.Collections.Generic;

namespace HangmanGame
{
    public class Hangman
    {
        private const int MaxAttempts = 6;
        
        private readonly HiddenWord hiddenWord;
        private readonly List<char> failedGuesses = new List<char>(); 

        public int RemainingAttempts { get; private set; }

        public Hangman(string word)
        {
            hiddenWord = new HiddenWord(word);

            RemainingAttempts = MaxAttempts;            
        }        

        public string GetPuzzle()
        {
            return hiddenWord.GetPartial();
        }

        public void AttemptGuess(char character)
        {
            if (IsGameOver() || !char.IsLetter(character))
            {
                return;
            }
            
            if (hiddenWord.ContainsLetter(character))
            {
                hiddenWord.RevealLetter(character);
                return;
            }

            PenalizePlayerFor(character);
        }

        public List<char> GetFailedGuesses()
        {
            return failedGuesses;
        }

        public bool IsGameOver()
        {
            return RemainingAttempts==0 || IsSolutionFound();
        }

        public bool IsSolutionFound()
        {
            return hiddenWord.IsFound();
        }

        public string GetSolution()
        {
            return hiddenWord.Reveal();
        }

        private void PenalizePlayerFor(char character)
        {
            if (!failedGuesses.Contains(character))
            {
                RemainingAttempts--;
                failedGuesses.Add(character);
            }
        }
    }
}