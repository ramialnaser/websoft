using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using webapp.Models;

namespace webapp.Services
{
    public class JsonFileAccountService
    {
        public JsonFileAccountService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "C:\\Users\\ramin\\Desktop\\websoft" +
                "\\work\\s07\\data\\account.json"); }
        }

        public IEnumerable<Account> GetAccounts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Account[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        public Account GetAccountBynumber(int number)
        {
            var accounts = GetAccounts();
            
            
            foreach (var account in accounts)
            {
                if (account.Number == number)
                {

                   // aco.Add(accounts.ToString);
                    return account;
                }

            }
            return null;
        }
        public Account moveMoney(int senderId,int receiverId,int amount)
        {
            var accounts = GetAccounts();
            if (checkId(senderId) && checkId(receiverId) && (senderId != receiverId))
            {
                foreach (var account in accounts)
                {
                    if (account.Number == senderId)
                    {
                        account.Balance -= amount;
                        

                    }
                    if (account.Number == receiverId)
                    {
                        account.Balance += amount;
                        
                    }
                }
                SaveAccounts(accounts);
            }
            return null;

        }
        public bool checkId(int number)
        {
            bool check = false;
            var accounts = GetAccounts();
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
    }
}
