using System.Windows.Forms;
using MVP;

namespace UI
{
    public partial class HangmanView : Form, IView
    {
        private readonly Presenter presenter;

        public HangmanView()
        {
            InitializeComponent();

            presenter = new Presenter(this);
            NewGame();
        }

        public void Update(HangmanViewModel viewModel)
        {
            hiddenWord.Text = viewModel.HiddenWord;
            remainingAttemptsCount.Text = viewModel.RemainingAttempts.ToString();
            failedGuessesList.Text = viewModel.FailedGuesses;
        }

        private void NewGame()
        {
            SetUp();
            presenter.NewGame();
        }

        private void SetUp()
        {
            hiddenWord.Text = string.Empty;
            remainingAttemptsCount.Text = string.Empty;
            failedGuessesList.Text = string.Empty;
        }

        private void HangmanUI_KeyDown(object sender, KeyEventArgs e)
        {
            presenter.AttemptGuess((char) e.KeyCode);
        }
    }
}
