
namespace GuessTheNumber

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######         ### #######");
            Console.WriteLine("#     #  ####   #     #   ");
            Console.WriteLine("#     # #    #  #     #   ");
            Console.WriteLine("#     # #    #  #     #   ");
            Console.WriteLine("#     # #    #  #     #   ");
            Console.WriteLine("#     # #    #  #     #   ");
            Console.WriteLine("######   ####  ###    #   ");
            Console.WriteLine("Welcome to \"Guess the Number!\"\n\n");
               Console.WriteLine("Choose the game mode: \n" + "1 - Easy(from 1 to 25)\n" + "2 - Medium(from 1 to 50)\n" + "3 - Hard(from 1 to 100)\n");
            

            SecretNumber game = new ();

            game.PlayGame();



        }
    }   
}
