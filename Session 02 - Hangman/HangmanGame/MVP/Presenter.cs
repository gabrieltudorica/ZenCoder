using HangmanGame;

namespace MVP
{
    public class Presenter
    {
        private readonly IView view;
        private Hangman hangman;

        public Presenter(IView view)
        {
            this.view = view;
        }

        public void NewGame()
        {
            var wordGenerator = new WordGenerator();            
            hangman = new Hangman(wordGenerator.GetRandom());
            
            UpdateView();
        }

        public void AttemptGuess(char character)
        {
            hangman.AttemptGuess(character);
            UpdateView();
        }

        private void UpdateView()
        {
            HangmanModel model = GetModel();
            view.Update(model);
        }

        private HangmanModel GetModel()
        {
            return new HangmanModel
            {
                HiddenWord = FormatPuzzle(),
                FailedGuesses = FormatFailedGuesses(),
                RemainingAttempts = hangman.RemainingAttempts,
                IsGameOver = hangman.IsGameOver(),
                EndGameMessage = GetEndGameMessage()
            };
        }

        private string FormatPuzzle()
        {
            string puzzle = string.Empty;

            foreach (char letter in hangman.GetPuzzle())
            {
                puzzle += letter + " ";
            }

            return puzzle;
        }

        private string FormatFailedGuesses()
        {
            string failedGuesses = string.Empty;

            foreach (char failedGuess in hangman.GetFailedGuesses())
            {
                failedGuesses += failedGuess + ", ";
            }

            return failedGuesses;
        }

        private string GetEndGameMessage()
        {
            if (hangman.IsSolutionFound())
            {
                return "Congratulations! You found the solution!";               
            }

            return string.Format("Looks like you didn't manage to guess the word... Too bad! " +
                                 "The word you were looking for was {0}!",
                                  hangman.GetSolution().ToUpper());
        }
    }
}
