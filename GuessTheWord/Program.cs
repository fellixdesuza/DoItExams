namespace GuessTheWord
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
            Console.WriteLine("\n\n");

            SecretWord gamer = new SecretWord();
            gamer.PlayGame();
        }
    }
}
