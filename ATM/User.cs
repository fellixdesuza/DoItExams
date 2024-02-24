using ATM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long PersonalId { get; set; }

        public int Password { get; set; }
        public  long Balance { get; set; }
        public User() { }
        

        public static User UserRegister(User user)
        {
            bool login = false;
            UserRepository userRepository = new ();
            List<User> users = userRepository.ReadUserFromFile();
            User authorisedUser = new User();
            if (users.Count == 0)
                user.Id = 0;
            else
            {
                user.Id = users.Max(x => x.Id) + 1;
            }
           Console.Write("Enter Your First Name: ");
            string firstName = null;
            while (true)
            {
                try
                {
                    firstName = Console.ReadLine();
                    if (!IsLetters(firstName))
                    {
                      throw new FormatException("Input contains non-letter characters.");
                    }
                    firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message + "\nType correct name:");
                }
            }
           Console.Write("Enter Your Last Name: ");
            string lastName = null;
            while (true)
            {
                try
                {
                    lastName = Console.ReadLine();
                    if (!IsLetters(lastName))
                    {
                        throw new FormatException("Input contains non-letter characters.");
                    }
                    lastName = char.ToUpper(lastName[0]) + lastName.Substring(1);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message + "\nType correct lastname:");
                }
            }

            user.Name = $"{firstName} {lastName}";
           Console.Write("Enter Your ID number: ");
           string tempId = "";
           long tempID = 0;
            while (true)
            {
                try
                {
                    tempId = Console.ReadLine();
                    if (!IsNumeric(tempId))
                    {
                        throw new FormatException("Input contains non-numeric characters.");
                    }
                    if (tempId.Length != 11)
                    {
                        Console.WriteLine("ID size is not correct.\n------------------");
                        authorisedUser = null;
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
           
            if (users.Count != 0)
            {
                foreach (var person in users)
                    if (person.PersonalId == tempID)
                    {
                        Console.WriteLine("Entered ID is already registered.\n------------------");
                        authorisedUser = null;
                        break;
                    }
                    else
                    {                       
                        user.PersonalId = tempID;
                        authorisedUser = user;
                    } 
            }
            else
            {
                user.PersonalId = tempID;
                authorisedUser = user;
            }
            if (authorisedUser != null)
            {
                Random random = new Random();
                user.Password = random.Next(1000, 9999);
                Console.WriteLine($"Your PIN is - ({user.Password})\nDo not forget it!\n------------------");
                user.Balance = 0; 
            }

            if (authorisedUser != null)
            {
                userRepository.AddUserToFile(user); 
            }
            
            return authorisedUser;
        }

        public static User UserLogin(User user)
        {
            bool login = false;
            UserRepository userRepository = new();
            List<User> users = userRepository.ReadUserFromFile();
            User authorisedUser = null;    
            if (users.Count == 0)
            {
                Console.WriteLine("There are not registered users. Please register to use ATM.\n------------------");
               
            }
            Console.Write("Type you personal ID: ");
            string tempId = "";
            long tempID = 0;
            while (true)
            {
                try
                {
                    tempId = Console.ReadLine();
                    if (!IsNumeric(tempId))
                    {
                        throw new FormatException("Input contains non-numeric characters.");
                    }
                    if (tempId.Length != 11)
                    {
                        Console.WriteLine("ID size is not correct.\n------------------");                       
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
            Console.WriteLine("\n");

            foreach (var person in users)
            {
                if (person.PersonalId == tempID)
                {
                    Console.Write("Type your password:");
                    int tempPass = 0;
                    while (true)
                    {
                        try
                        {
                            string stringPass = Console.ReadLine();
                            if (!IsNumeric(stringPass))
                            {
                                throw new FormatException("Input contains non-numeric characters.");
                            }

                            if (stringPass.Length != 4)
                            {
                                throw new FormatException("Password length must be four");
                            }
                           
                                tempPass = int.Parse(stringPass);
                                break;
                            
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Error: " + e.Message + "\nType correct password:");
                        }
                    }
                    
                    if (tempPass == person.Password)
                    {
                        Console.WriteLine("\n------------------");

                        authorisedUser = person;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Password is incorrect.\n------------------");
                        authorisedUser = null;
                        return authorisedUser;
                    }
                }
            }
            if(authorisedUser == null) 
                {
                    Console.WriteLine("You are not registered.\n------------------");                  
                }
            return authorisedUser;
        }

        private static bool IsLetters(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }              
            }
            return true;
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
    }
}
