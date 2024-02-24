using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            var result = JsonSerializer.Deserialize<List<Transactions>>(input);
            return result;
        }

   

        public void AddLogToFile(Transactions account)
        {
            string tempLogs = "";
            List<Transactions> accounts = ReadLogsFromFile();
            accounts.Add(account);
            foreach (Transactions item in accounts)
            {
                tempLogs += JsonSerializer.Serialize(item) + ",";
            }
            tempLogs = "[" + tempLogs.TrimEnd(',') + "]";
            try
            {
                File.WriteAllText(_path, tempLogs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
