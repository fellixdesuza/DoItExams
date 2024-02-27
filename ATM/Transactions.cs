using ATM.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
                Console.WriteLine("Deposit must be greater than 0.\n-----------------");
                return;
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
                
                Console.WriteLine("Your balance is 0.\n-----------------"); 
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

        public void Transfer(User user, long amount)
        {
            Transactions sender = new Transactions();
            Transactions receiver = new Transactions();
            TransactionRepository transactionSender = new TransactionRepository();
            TransactionRepository transactionReceiver = new TransactionRepository();
            UserRepository userRepository = new UserRepository();
            List<User> users = new List<User>();
            User receiverUser = new User();
            users = userRepository.ReadUserFromFile();            
            if (amount <= 0)
            {
                Console.WriteLine("Transfer must be greater than 0.\n-----------------");
                return;
            }
            else if (user.Balance == 0)
            {

                Console.WriteLine("Your balance is 0\n-----------------");
                return;
            }
            else if (amount > user.Balance)
            {

                Console.WriteLine($"Your balance is not enough.\nYour current balance is {user.Balance} GEL\n-----------------");
                return;
            }
            string tempId = "";
            long tempID = 0;
            Console.Write("Type receiver personal ID:");
            while (true)
            {
                try
                {
                    tempId = Console.ReadLine();
                    if (!User.IsNumeric(tempId))
                    {
                        throw new FormatException("Input contains non-numeric characters.\n-----------------");
                    }
                    if (tempId.Length != 11)
                    {
                        throw new FormatException("ID size is not correct.\n------------------");
                    }
                    else
                    {
                        tempID = long.Parse(tempId);
                        break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message + "\nType correct ID:");
                }
            }

            foreach (User person in users)
            {
                if (tempID == person.PersonalId)
                {
                    receiverUser = person;
                    break;
                }
                else
                {
                    receiverUser = null;
                }
            }
            if(receiverUser != null)
            {
                receiverUser.Balance += amount;
                user.Balance -= amount;
                Console.WriteLine($"You transferred {amount} GEL to {receiverUser.Name}. Your current balance is {user.Balance} GEL.\n------------------");
                sender.TransactionID = user.Id;
                sender.Actions = $"{user.Name} sent {amount} GEl to {receiverUser.Name}. Transaction date: {DateTime.Now}";
                transactionSender.AddLogToFile(sender);
                userRepository.UpdateUser(userRepository.BalanceChange(user.PersonalId, user.Balance));
                receiver.TransactionID = receiverUser.Id;
                receiver.Actions = $"{receiverUser.Name} received {amount} GEl from {user.Name}. Transaction date: {DateTime.Now}";
                transactionReceiver.AddLogToFile(receiver);
                userRepository.UpdateUser(userRepository.BalanceChange(receiverUser.PersonalId, receiverUser.Balance));              
            }
            else
            {
                Console.WriteLine("User not found!\n------------------");
            }

        }

    }
}
