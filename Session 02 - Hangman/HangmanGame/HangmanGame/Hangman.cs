using System.Collections.Generic;

namespace HangmanGame
{
    public class Hangman
    {
        private const int MaxAttempts = 6;
        
        private readonly HiddenWord word;
        private readonly List<char> invalidChosenLetters = new List<char>(); 

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
            if (!char.IsLetter(character))
            {
                return;
            }

            if (word.SolutionContainsLetter(character))
            {
                word.AddLetterToSolution(character);
                return;
            }

            if (!invalidChosenLetters.Contains(character))
            {
                RemainingAttempts--;
                invalidChosenLetters.Add(character);
            }
        }

        public List<char> GetInvalidChosenLetters()
        {
            return invalidChosenLetters;
        }

        public bool IsGameOver()
        {
            return RemainingAttempts==0 || word.IsSolved();
        }
    }
}
