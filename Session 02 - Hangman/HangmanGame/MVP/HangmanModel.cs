namespace MVP
{
    public class HangmanModel
    {
        public string HiddenWord { get; set; }
        public int RemainingAttempts { get; set; }
        public string FailedGuesses { get; set; }
        public bool IsGameOver { get; set; }
        public string EndGameMessage { get; set; }
    }
}