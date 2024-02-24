using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ATM.Repository
{
    public  class TransactionRepository
    {
        private readonly string _path = "..\\..\\..\\Repository\\Log.JSON";

        public List<Transactions> _transactions = new List<Transactions>();


        public List<Transactions> ReadLogsFromFile()
        {

            try
            {
                _transactions = Parse(File.ReadAllText(_path));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please make sure the file exists.\n------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return _transactions;
        }


        private static List<Transactions> Parse(string input)
        {
            var result = JsonConvert.DeserializeObject<List<Transactions>>(input);
            return result;
        }

   

        public void AddLogToFile(Transactions account)
        {
            string file = "..\\..\\..\\Repository\\Log.JSON";
            List<Transactions> accounts = new List<Transactions>();
            if (File.Exists(file))
            {
                accounts = ReadLogsFromFile();
            }
            accounts.Add(account);
            string jsonData = JsonConvert.SerializeObject(accounts, Newtonsoft.Json.Formatting.Indented);
            try
            {
                File.WriteAllText(_path, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
