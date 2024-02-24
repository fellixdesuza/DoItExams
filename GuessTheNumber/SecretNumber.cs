using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class SecretNumber
    {
        private int secretNumber;
        public int answer { set; get; }
      

        public void PlayGame()
        {
            byte gameDifficult = SecretNumber.Mode();
            Random random = new Random();


            switch (gameDifficult)
            {
                case 1:
                    secretNumber = random.Next(1, 25);
                    break;
                case 2:
                    secretNumber = random.Next(1, 50);
                    break;
                case 3:
                    secretNumber = random.Next(1, 100);
                    break;
                default:
                    throw new ArgumentException("Invalid difficulty level. Please choose 1, 2, or 3.");
            }


            Console.WriteLine("Well done!\nNow guess the number. You have 10 try.");
            while (true)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        Console.Write("Enter a number: ");
                        string input = Console.ReadLine();
                        if (!IsNumeric(input))
                        {
                            i--;
                            throw new FormatException("Input contains non-numeric characters.");
                        }
                        answer = int.Parse(input);
                        if (answer == secretNumber)
                        {
                            Console.WriteLine("Wow, Congratulations! You are Genius!\nSecret Number was: " + secretNumber);
                            return;
                        }
                        else if (answer < secretNumber)
                        {
                            Console.WriteLine("The answer is less than the imagined number.\nyou have " + (9 - i) + " try!");
                        }
                        else if (answer > secretNumber)
                        {
                            Console.WriteLine("The answer is more than the imagined number.\nyou have " + (9 - i) + " try!");
                        }
                        
                        
                    }

                    catch (FormatException e)
                    {
                        
                        Console.WriteLine("Error: " + e.Message);
                    }

                   
                }
                Console.WriteLine("Game Over.\n\nSecret Number was " + secretNumber);
               break;
            }


        }
        private static byte Mode()
        {           
            byte number = 0;
            while (true)
            {
                try
                {
                    Console.Write("Enter a number: ");
                    string input = Console.ReadLine();
                    if (!IsMode(input))
                    {
                        throw new FormatException("Invalid difficulty level. Please choose 1, 2, or 3.");
                    }
                    number = byte.Parse(input);
                    break;
                }
                catch (FormatException e)
                {
                    
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            return number;
        }
        private static bool IsMode(string input)
        {
            foreach (char c in input)
            {
                if (!(c == '1' || c == '2' || c == '3'))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
