using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

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
            var result = JsonConvert.DeserializeObject<List<User>>(input);
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
            List<User> users = ReadUserFromFile();
            foreach(var person in users)
            {
                if (person.PersonalId == user.PersonalId)
                {
                    person.Balance = user.Balance;                   
                }
            }
            var jsonData = JsonConvert.SerializeObject(users,Newtonsoft.Json.Formatting.Indented);
            try
            {
                File.WriteAllText(_path, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void AddUserToFile(User user)
        {
            List<User> users = ReadUserFromFile();
            users.Add(user);
            var jsonData = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            try
            {
                File.WriteAllText(_path, jsonData);
                Console.WriteLine("User has been successfully saved.\n------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        
    }
}
