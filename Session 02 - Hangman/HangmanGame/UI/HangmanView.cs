using System.Drawing;
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
            hanging.Image = Image.FromFile("images\\" + viewModel.RemainingAttempts + ".png");
            
            if (viewModel.IsGameOver)
            {
                EndGame(viewModel.EndGameMessage);
            }
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
            hanging.Image = Image.FromFile("images/6.png");
        }

        private void EndGame(string message)
        {
            DialogResult dialogResult = MessageBox.Show(
                                            message + " Would you like to start a new game?", 
                                            "Game Over",
                                            MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.Yes)
            {
                NewGame();
            }            
        }

        private void HangmanUI_KeyDown(object sender, KeyEventArgs e)
        {
            presenter.AttemptGuess((char) e.KeyCode);
        }

        private void StartNewGame_Click(object sender, System.EventArgs e)
        {
            NewGame();
        }
    }
}
