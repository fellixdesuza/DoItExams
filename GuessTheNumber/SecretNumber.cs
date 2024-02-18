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
        public SecretNumber(int gameDifficult)
        {
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
        }


        public void PlayGame()
        {
            Console.WriteLine("Well done!\nNow guess the number. You have 10 try.");
            try
            {

                for (int i = 0; i < 10; i++)
                {
                    answer = int.Parse(Console.ReadLine());
                    if (answer == secretNumber)
                    {
                        Console.WriteLine("Wow, Congratulations! You are Genius!\nSecret Number was: " + secretNumber);
                        return;
                    }
                    else if (answer < secretNumber)
                    {
                        Console.WriteLine("The answer is less than the imagined number\nyou have " + (9 - i) + " try!");
                    }
                    else if (answer > secretNumber)
                    {
                        Console.WriteLine("The answer is more than the imagined number\nyou have " + (9 - i) + " try!");
                    }
                }
                Console.WriteLine("Game Over.\n\nSecret Number was " + secretNumber);
            }
            catch (Exception)
            {

                throw new FormatException("Invalid input! Please enter only number.");
            }

        }
    }
}

