namespace MVP
{
    public class HangmanViewModel
    {
        public string HiddenWord { get; set; }
        public int RemainingAttempts { get; set; }
        public string FailedGuesses { get; set; }
    }
}