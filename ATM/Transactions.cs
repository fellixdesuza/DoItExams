using ATM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATM
{
    public class Transactions
    {
        public long TransactionID {  get; set; }
        public string Actions{ get; set; }

       
        public void Deposit(User user, long amount)
        {
            Transactions transaction = new Transactions();
            TransactionRepository transactionRepository = new TransactionRepository();
            UserRepository userRepository = new UserRepository();
            if (amount <= 0)
            {
                throw new Exception("Deposit must be greater than 0");
            }

            user.Balance += amount;
            Console.WriteLine($"You deposited {amount} GEL to you balance. your current balance is {user.Balance} GEL.\n------------------");
            transaction.TransactionID = user.Id;
            transaction.Actions = $"{user.Name} deposited {amount} GEL. Transaction date: {DateTime.Now}";
            transactionRepository.AddLogToFile(transaction);
            userRepository.UpdateUser(userRepository.BalanceChange(user.PersonalId, user.Balance));
        }

        public void Withdraw(User user, long amount)
        {
            Transactions transaction = new Transactions();
            TransactionRepository transactionRepository = new TransactionRepository();
            UserRepository userRepository = new UserRepository();
            if (user.Balance == 0)
            {
                
                Console.WriteLine("Your balance is 0\n-----------------"); 
                return;
            }
            else if (amount > user.Balance)
            {
                
                Console.WriteLine($"Your balance is not enough.\nYour current balance is {user.Balance} GEL\n-----------------");
                return;
            }
            user.Balance -= amount;
            Console.WriteLine($"You withdrawn {amount} GEL from your balance. your current balance is {user.Balance} GEL.\n------------------");
            transaction.TransactionID = user.Id;
            transaction.Actions = $"{user.Name} withdrawn {amount} GEl. Transaction date: {DateTime.Now}";
            transactionRepository.AddLogToFile(transaction);
            userRepository.UpdateUser(userRepository.BalanceChange(user.PersonalId, user.Balance));

        }

        public void ShowBalance(User user)
        {
            Console.WriteLine($"{user.Name}'s current balance is {user.Balance} GEL.\n------------------");
           
        }

        public void TransactionHistory(User user)
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            List<Transactions> transactions = transactionRepository.ReadLogsFromFile();
            foreach (Transactions transaction in transactions)
            {
                if(transaction.TransactionID == user.Id)
                {
                    Console.WriteLine($"{transaction.Actions}\n------------------");
                }
                else if(transaction.TransactionID == null)
                {
                    Console.WriteLine("You do not have any transactions made yet.\n------------------");
                }

            }
            
        }

    }
}
