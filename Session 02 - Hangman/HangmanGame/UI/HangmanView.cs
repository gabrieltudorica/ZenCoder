using System.Drawing;
using System.Windows.Forms;
using MVP;

namespace UI
{
    public partial class HangmanView : Form, IView
    {
        private readonly Presenter presenter;
        private const string ImagesFolder = "images\\";

        public HangmanView()
        {
            InitializeComponent();

            presenter = new Presenter(this);
            NewGame();
        }

        public void Update(HangmanModel model)
        {
            hiddenWord.Text = model.HiddenWord;
            remainingAttemptsCount.Text = model.RemainingAttempts.ToString();
            failedGuessesList.Text = model.FailedGuesses;
            hanging.Image = Image.FromFile(ImagesFolder + model.RemainingAttempts + ".png");
            
            if (model.IsGameOver)
            {
                EndGame(model.EndGameMessage);
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
            hanging.Image = Image.FromFile(ImagesFolder + "6.png");
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

        private void howToPlayToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(
                "Try to guess the missing letters to solve the puzzle. The letters are entered from the keyboard",
                "How to play", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
    }
}
