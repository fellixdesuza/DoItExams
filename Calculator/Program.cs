namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            bool exit = false;

            do
            {
                try
                {
                    double num1 = calculator.GetNumber("Enter the first number:");
                    char op = calculator.GetOperator("Enter the operator (+, -, *, /):");
                    double num2 = calculator.GetNumber("Enter the second number:");

                    double result = calculator.PerformOperation(num1, op, num2);
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
