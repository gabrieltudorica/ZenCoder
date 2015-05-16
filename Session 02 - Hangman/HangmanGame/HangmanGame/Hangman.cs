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

        public string GetPartialWord()
        {
            return word.GetPartial();
        }

        public void AttemptGuess(char letter)
        {
            if (word.IsLetterValid(letter))
            {
                word.AddLetterToSolution(letter);
                return;
            }

            if (!invalidChosenLetters.Contains(letter))
            {
                RemainingAttempts--;
                invalidChosenLetters.Add(letter);
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
