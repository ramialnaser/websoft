
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using test;

namespace console
{
    public class AccountManger
    {
        public void ReadFile()
        {

            var accounts = ReadAccounts();
            var table = new ConsoleTable("Number", "Balance", "Label", "Owner");


            foreach (var account in accounts)
            {
                table.AddRow(account.Number, account.Balance, account.Label, account.Owner);
            }

            table.Write();

        }
        public void ReadSpecificAccount(int number)
        {
            // List<Account> list = new List<Account>();


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
        public void Search(String search)
        {
            // List<Account> list = new List<Account>();


            var accounts = ReadAccounts();



            var table = new ConsoleTable("Number", "Balance", "Label", "Owner");
            foreach (var account in accounts)
            {


                if (account.Label.ToString().Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    table.AddRow(account.Number, account.Balance, account.Label, account.Owner);
                }



            }

            table.Write();

        }
        public void ProcessTransfer(int senderNum, int receiverNum, int amount)
        {
            var accounts = ReadAccounts();
            if (checkId(senderNum) && checkId(receiverNum) && (senderNum != receiverNum))
            {
                foreach (var account in accounts)
                {
                    if (account.Number == senderNum)
                    {
                        account.Balance = account.Balance - amount;
                        Console.WriteLine("The new balance after moving: " + account.Balance
                            );

                    }
                    if (account.Number == receiverNum)
                    {
                        account.Balance = account.Balance + amount;
                        Console.WriteLine("The new balance after adding: " + account.Balance
                            );
                    }
                }
                SaveAccounts(accounts);
            }

         }
        public bool checkId(int number)
        {
            bool check = false;
            var accounts = ReadAccounts();
            foreach (var account in accounts)
            {
                check = true;
            }
            return check;
        }
        static void SaveAccounts(IEnumerable<Account> accounts)
        {
           String file = "C:\\Users\\ramin\\Desktop\\websoft\\work\\s07\\data\\account.json";

             using (var outputStream = File.OpenWrite(file))
             {
                 JsonSerializer.Serialize<IEnumerable<Account>>(
                    new Utf8JsonWriter(
                        outputStream,
                        new JsonWriterOptions
                        {
                             SkipValidation = true,
                            Indented = true
                        }
                        ),
                        accounts
                    );
                }
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
