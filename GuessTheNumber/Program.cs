
namespace GuessTheNumber

{
    internal class Program
    {
        static void Main(string[] args)
        {
            
               Console.WriteLine(" _____                       _____            _       ");
               Console.WriteLine("|  __ \\                     / ____|          | |      ");
               Console.WriteLine("| |__) |___  ___ ___  _ __| (___   ___  _ __| |_ ___ ");
               Console.WriteLine("|  _  // _ \\/ __/ _ \\| '__|\\___ \\ / _ \\| '__| __/ __|");
               Console.WriteLine("| | \\ \\  __/ (_| (_) | |   ____) | (_) | |  | |_\\__ \\");
               Console.WriteLine("|_|  \\_\\___|\\___\\___/|_|  |_____/ \\___/|_|   \\__|___/");
               Console.WriteLine("                                                       ");
               Console.WriteLine("Welcome to \"Guess the Number!\"\n\n");
               Console.WriteLine("Choose the game mode: \n" + "1 - Easy(from 1 to 25)\n" + "2 - Medium(from 1 to 50)\n" + "3 - Hard(from 1 to 100)\n");
                
            int mode = int.Parse(Console.ReadLine());

            SecretNumber game = new SecretNumber(mode);

            game.PlayGame();
              
           
           
            
        }
    }   
}
