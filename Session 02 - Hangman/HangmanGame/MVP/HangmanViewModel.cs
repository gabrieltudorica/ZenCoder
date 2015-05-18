using System.Collections.Generic;

namespace MVP
{
    public class HangmanViewModel
    {
        public string HiddenWord { get; set; }
        public int RemainingAttempts { get; set; }
        public List<char> FailedGuesses { get; set; }
    }
}
