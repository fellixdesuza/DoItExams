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
            Console.WriteLine(message);
            double number;
            if (!double.TryParse(Console.ReadLine(), out number))
            {
                throw new FormatException("Invalid input! Please enter a valid number.");
            }
            return number;
        }

        public static char GetOperator(string message)
        {
            Console.WriteLine(message);
            char op = Console.ReadKey().KeyChar;
            if (op != '+' && op != '-' && op != '*' && op != '/')
            {
                throw new InvalidOperationException("Invalid operator!");
            }
            Console.WriteLine();
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
    }
}
