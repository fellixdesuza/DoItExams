using System.Reflection.Metadata;

namespace ATM
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To ATM\n\n");
            bool atm = true;
            while (atm)
            {
                bool login = false;

                int choise = 0;
                User user = new User();
                Transactions transactions = new Transactions();
                User authorisedUser = new User();
                Console.WriteLine("To use ATM you have to Register or Login.\nTo Login Press - 1\nTo Register Press - 2\nTo Finish Work Press - 3\n-------------------------\n");
                while (true)
                {
                    try
                    {
                        choise = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter valid answer.");
                    } 
                }

                switch (choise)
                {
                    case 1:
                        authorisedUser = User.UserLogin(user);
                        if (authorisedUser != null)
                        {
                         login = true;
                        }
                        break;
                    case 2:
                        authorisedUser = User.UserRegister(user);
                        if (authorisedUser != null)
                        {
                            login = true;
                        }
                        break;
                    case 3:
                        atm = false;
                        break;
                    default:
                        Console.WriteLine("Unknow Option! Try again!");
                        break;


                }

                while (login)
                {
                    Console.WriteLine("Available Options:\nShow Balance - 1\nDeposit - 2\nWithdraw - 3\nTransfer - 4\nTransactions History - 5\nLog Out - 6\n-------------------------\n");
                    int action = 0; 
                    while (true)
                    {
                        try
                        {
                            action = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter valid answer.");
                        }
                    }
                    switch (action)
                    {
                        case 1:
                            transactions.ShowBalance(authorisedUser);
                            break;
                        case 2:
                            Console.Write("Type deposit amount: ");
                            int depositAmount = 0;
                            while (true)
                            {
                                try
                                {
                                    depositAmount = int.Parse(Console.ReadLine());
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please enter valid answer.");
                                }
                            }
                            transactions.Deposit(authorisedUser, depositAmount);
                            break;
                        case 3:
                            Console.Write("Type withdraw amount: ");
                            int withdrawAmount = 0;
                            while (true)
                            {
                                try
                                {
                                    withdrawAmount = int.Parse(Console.ReadLine());
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please enter valid answer.");
                                }
                            }
                            transactions.Withdraw(authorisedUser, withdrawAmount);
                            break;
                        case 4:
                            Console.Write("Type transfer amount: ");
                            long transferAmount = 0;
                            while (true)
                            {
                                try
                                {
                                    transferAmount = long.Parse(Console.ReadLine());
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please enter valid answer.");
                                }
                            }

                            transactions.Transfer(authorisedUser, transferAmount);
                            break;
                        case 5:
                            transactions.TransactionHistory(authorisedUser);
                            break;
                        case 6:
                            Console.WriteLine("You are logged out!\n-------------------------\n");
                            login = false;
                            break;
                        default:
                            Console.WriteLine("Unknow Option! Try again!\n-------------------------\n");
                            break;

                    }
                } 
            }
        }
    }
}
