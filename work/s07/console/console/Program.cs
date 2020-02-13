
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace test
{
    class Program
    {
        
        static void Main(string[] args)
        {

            bool showMenu = true;
            do
            {
                string num ;
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) View Account");
                Console.WriteLine("2) View Specific Acount");
                Console.WriteLine("3) Exit");
                Console.Write("\r\nSelect an option: ");
                num = Console.ReadLine();

                switch (num)
                {
                    case "1":
                        ReadFile();
                        
                        break;
                    case "2":
                        ReadSpecificAccount();
                        break;

                                            
                    default:
                        showMenu = false;
                        break;
                }
            } while (showMenu);
            
        }
        private static void ReadFile()
        {

            var accounts = ReadAccounts();
            var table = new ConsoleTable("Number", "Balance", "Label", "Owner");


            foreach (var account in accounts)
            {
                table.AddRow(account.Number, account.Balance, account.Label, account.Owner);
            }

            table.Write();

        }
        private static void ReadSpecificAccount()
        {
            // List<Account> list = new List<Account>();
            Console.Write("\nAccount number > ");
            string input = Console.ReadLine();
            int number;
            Int32.TryParse(input, out number);
            
            var accounts = ReadAccounts();
            


            var table = new ConsoleTable("Number", "Balance", "Label", "Owner");
            foreach (var account in accounts)
            {

                if (account.Number == number)
                {
                    
                    table.AddRow(account.Number, account.Balance, account.Label, account.Owner);
                }
                
            }

            table.Write();
            
        }
        static IEnumerable<Account> ReadAccounts()
        {
            String file = "C:\\Users\\ramin\\Desktop\\websoft\\work\\s07\\data\\account.json";

            using (StreamReader r = new StreamReader(file))
            {
                string data = r.ReadToEnd();
                

                var json = JsonSerializer.Deserialize<Account[]>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

                return json;
            }
        }

        
       
    }
}
