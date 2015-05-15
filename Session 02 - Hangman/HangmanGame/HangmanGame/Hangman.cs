using System.Collections.Generic;

namespace HangmanGame
{
    public class Hangman
    {
        private const int MaxAttempts = 6;
        
        private readonly WordSolution solution;
        private readonly List<char> invalidChosenLetters = new List<char>(); 

        public int RemainingAttempts { get; private set; }

        public Hangman(WordSolution solution)
        {
            this.solution = solution;

            RemainingAttempts = MaxAttempts;            
        }        

        public string GetPartialWord()
        {
            return solution.GetPartial();
        }

        public void AttemptGuess(char letter)
        {
            if (!solution.IsLetterValid(letter))
            {
                RemainingAttempts--;
                invalidChosenLetters.Add(letter);
                return;
            }

            solution.AddToPartialSolution(letter);
        }

        public List<char> GetInvalidChosenLetters()
        {
            return invalidChosenLetters;
        }
    }
}
