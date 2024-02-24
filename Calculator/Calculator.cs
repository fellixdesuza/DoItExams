using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public static double GetNumber(string message)          
        {
            double number=0;
            Console.WriteLine(message);
            while (true)
            {
                try
                {                 
                    string input = Console.ReadLine();
                    if (!IsNumeric(input))
                    {
                        throw new FormatException("Input contains non-numeric characters.");
                    }
                    number = double.Parse(input);
                    break;                   
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }              
            }
            return number;
        }

        public static char GetOperator(string message)
        {
            char op;
            Console.WriteLine(message);
            while (true)
            {
                try
                {
                     string input = Console.ReadLine();
                    if (!IsOperation(input))
                    {
                        throw new FormatException("Input contains non-operation characters.");
                    }
                    op = char.Parse(input);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            return op;
        }

        public static double PerformOperation(double num1, char op, double num2)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException("Division by zero!");
                    }
                    return num1 / num2;
                default:
                    throw new InvalidOperationException("Invalid operator!");
            }
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
        private static bool IsOperation(string input)
        {
            foreach(char c in input)
            { if (!(c == '+' || c == '-' || c == '*' || c == '/'))
                { 
                    return false; 
                }
            }
            return true;
        }
    }
}
