namespace HangmanGame
{
    public class Hangman
    {
        private const int MaxAttempts = 6;
        private readonly WordSolution solution;
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
            }
        }
    }
}
