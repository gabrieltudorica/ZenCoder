using System;
using System.Linq;

namespace HangmanGame
{
    public class HiddenWord
    {
        private readonly string word;
        private readonly char[] partialWord;
        private const char Placeholder = '_';

        public HiddenWord(string word)
        {
            this.word = word;
            partialWord = Enumerable.Repeat(Placeholder, word.Length).ToArray();

            RevealFirstAndLastLetters();      
        }        

        public string GetPartial()
        {
            return new string(partialWord);
        }

        public bool ContainsLetter(char letter)
        {
            return word.IndexOf(letter.ToString(), StringComparison.InvariantCultureIgnoreCase) != -1;
        }

        public bool IsFound()
        {
            return !partialWord.Contains(Placeholder);
        }

        public void RevealLetter(char letter)
        {
            if (ContainsLetter(letter))
            {
                RevealAllLettersWith(letter);
            }
        }

        public string Reveal()
        {
            return word;
        }

        private void RevealFirstAndLastLetters()
        {
            RevealLetter(word[0]);

            int lastLetterIndex = word.Length - 1;
            RevealLetter(word[lastLetterIndex]);            
        }

        private void RevealAllLettersWith(char letter)
        {
            for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
            {
                RevealLetter(letterIndex, letter);
            }
        }

        private void RevealLetter(int letterIndex, char letter)
        {
            if (AreEqual(word[letterIndex], letter))
            {
                partialWord[letterIndex] = char.ToUpper(letter);
            }
        }

        private static bool AreEqual(char letterA, char letterB)
        {
            return string.Equals(letterA.ToString(), letterB.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }
    }
}