using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheWord
{
    public class SecretWord
    {
        private readonly List<string> words = new List<string>
        {
            "apple", "banana", "orange", "grape", "kiwi",
            "strawberry", "pineapple", "blueberry", "peach", "watermelon"
        };

        public void PlayGame()
        {
            Random random = new Random();

            String secretWord = words[random.Next(words.Count)];
            int attempts = 6;
            int guessedLetterSize = secretWord.Length;
            string guessedLetters = "";
            Console.WriteLine("Welcome to Guess the Word Game!");
            Console.WriteLine("You have 6 attempts to guess the word letter by letter or whole word.");
            Console.WriteLine("The word has " + secretWord.Length + " letters.");
            bool saver = true;
            string comparer = null;
            string comp = null;
            while (attempts > 0)
            {
                Console.WriteLine("\nAttempts left: " + attempts);

                Console.Write("Enter a letter or whole word: ");
                string guessWord = null;


                string input = Console.ReadLine();
                try
                {
                    guessWord = GetLettersOnly(input);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                char guessChar = Char.ToLower(guessWord[0]);
               // Console.WriteLine('\n');
                string tempWord = null;
                if (guessWord == secretWord)
                {
                    Console.WriteLine("\nWow, Congratulations! You are Genius!\nSecret Word was: " + secretWord);
                    return;
                }
                foreach (char c in secretWord)
                {
                    if (c == guessChar)
                    {                       
                        tempWord += guessChar;
                    }
                    else
                    {                        
                        tempWord += "*";
                    }
                }
                if (saver)
                {
                    comparer = tempWord;
                }
                comp = StringsUnion(comparer, tempWord);
                comparer = comp;
                saver = false;


                Console.WriteLine("\n" + comp + "\n");
                attempts--;
                
                if (comp == secretWord)
                {
                    Console.WriteLine("\nWow, Congratulations! You are Genius!\nSecret Word was: " + secretWord);
                    return;
                }
              

            }

            if (comp != secretWord)
            {
                Console.WriteLine("\nSorry, you ran out of attempts. The word was: " + secretWord + "\nGame Over.");
            }
        }
        private static string StringsUnion(string a, string b)
        {

            string union = "";

            for (int i = 0; i < b.Length; i++)
            {

                if (a[i] == '*' && b[i] != '*')
                {
                    union += b[i];
                }
                else if (a[i] != '*' && b[i] == '*')
                {
                    union += a[i];
                }
                else if (a[i] == b[i])
                {
                    union += a[i];
                }
                else
                {
                    union += '*';
                }
            }

            return union;
        }
        static string GetLettersOnly(string input)
        {
            string result = "";
            input = input.ToLower();
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result += c;
                }
                else
                {
                    throw new ArgumentException("Input must contain only letters.");
                }
            }

            return result;
        }
        
    }
}
