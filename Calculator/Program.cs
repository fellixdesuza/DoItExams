namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            bool exit = false;

            do
            {
                try
                {
                    double num1 = Calculator.GetNumber("Enter the first number:");
                    char op = Calculator.GetOperator("Enter the operator (+, -, *, /):");
                    double num2 = Calculator.GetNumber("Enter the second number:");

                    double result = Calculator.PerformOperation(num1, op, num2);
                    Console.WriteLine("Result: " + result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.WriteLine("Do you want to perform another calculation? (yes/no)");
                string choice = Console.ReadLine();

                if (choice.ToLower() != "yes")
                {
                    Console.WriteLine("Calculator session ended.");
                    exit = true;
                }

            } while (!exit);

        }
    }
}
