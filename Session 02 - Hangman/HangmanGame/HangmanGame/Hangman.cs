namespace HangmanGame
{
    public class Hangman
    {
        private const int MaxAttempts = 6;
        private readonly string word;
        private readonly char[] partialWord;

        public int RemainingAttempts { get; private set; }

        public Hangman(string word)
        {
            this.word = word.ToUpper();
            partialWord = new char[word.Length];
            InitializePartialWord();

            RemainingAttempts = MaxAttempts;            
        }        

        public string GetPartialWord()
        {
            return new string(partialWord);
        }

        private void InitializePartialWord()
        {            
            InsertUnderscores();   
            RevealInitialLetters();
        }

        private void InsertUnderscores()
        {
            for (int i = 0; i < partialWord.Length; i++)
            {
                partialWord[i] = '_';
            }
        }

        private void RevealInitialLetters()
        {
            RevealFirstAndLastLetters();
            RevealDuplicatedLetters();
        }

        private void RevealFirstAndLastLetters()
        {
            partialWord[0] = word[0];

            int lastLetterIndex = GetLastLetterIndex() ;            
            partialWord[lastLetterIndex] = word[lastLetterIndex];
        }

        private int GetLastLetterIndex()
        {
            return word.Length - 1;
        }

        private void RevealDuplicatedLetters()
        {            
            for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
            {                
                RevealFirstLetterDuplicates(letterIndex);
                RevealLastLetterDuplicates(letterIndex);                
            }
        }

        private void RevealFirstLetterDuplicates(int letterIndex)
        {
            if (word[0] == word[letterIndex])
            {
                partialWord[letterIndex] = word[0];
            }
        }

        private void RevealLastLetterDuplicates(int letterIndex)
        {
            int lastLetterIndex = GetLastLetterIndex();

            if (word[lastLetterIndex] == word[letterIndex])
            {
                partialWord[letterIndex] = word[lastLetterIndex];
            }
        }
    }
}
