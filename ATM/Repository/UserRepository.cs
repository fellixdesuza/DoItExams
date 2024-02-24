using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace ATM.Repository
{
    public class UserRepository
    {
        private readonly string _path = "..\\..\\..\\Repository\\User.JSON";

        public List<User> _users = new List<User>();


        public List<User> ReadUserFromFile()
        {

            try
            {
                _users = Parse(File.ReadAllText(_path));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please make sure the file exists.\n------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return _users;
        }

        private static List<User> Parse(string input)
        {
            var result = JsonSerializer.Deserialize<List<User>>(input);
            return result;
        }

        public User BalanceChange(long personalID, long balance)
        {
            List<User> users = ReadUserFromFile();
            var result = users.FirstOrDefault(x => x.PersonalId == personalID);
            if (result == null)
            {
                throw new NullReferenceException("Data not found");
            }
            result.Balance = balance;
            return result;
        }

        public void UpdateUser(User user)
        {
            string tempUsers = "";
            List<User> users = ReadUserFromFile();
            foreach(User person in users)
            {
                if (person.PersonalId == user.PersonalId)
                {
                    person.Balance = user.Balance;
                    
                }
            }
            foreach (User item in users)
            {
                tempUsers += JsonSerializer.Serialize(item) + ",";
            }

            tempUsers = "[" + tempUsers.TrimEnd(',') + "]";
            try
            {
                File.WriteAllText(_path, tempUsers);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void AddUserToFile(User user)
        {
            string tempUsers = "";
            List<User> users = ReadUserFromFile();
            users.Add(user);
            foreach (User item in users)
            {
                tempUsers += JsonSerializer.Serialize(item) + ",";
            }
            
            tempUsers = "[" + tempUsers.TrimEnd(',') + "]";
            try
            {
                File.WriteAllText(_path, tempUsers);
                Console.WriteLine("User has been successfully saved.\n------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
