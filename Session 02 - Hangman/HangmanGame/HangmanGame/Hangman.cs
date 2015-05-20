using System.Collections.Generic;

namespace HangmanGame
{
    public class Hangman
    {
        private const int MaxAttempts = 6;
        
        private readonly HiddenWord word;
        private readonly List<char> failedGuesses = new List<char>(); 

        public int RemainingAttempts { get; private set; }

        public Hangman(HiddenWord word)
        {
            this.word = word;

            RemainingAttempts = MaxAttempts;            
        }        

        public string GetPuzzle()
        {
            return word.GetPartialSolution();
        }

        public void AttemptGuess(char character)
        {
            if (IsGameOver())
            {
                return;
            }

            if (!char.IsLetter(character))
            {
                return;
            }

            if (word.SolutionContainsLetter(character))
            {
                word.AddLetterToSolution(character);
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
            return word.IsSolved();
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