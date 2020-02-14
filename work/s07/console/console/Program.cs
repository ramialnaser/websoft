
using console;
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
        private AccountManger accountManger;
        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.accountManger = new AccountManger();

            
            bool showMenu = true;
            do
            {
                string num ;
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) View Account");
                Console.WriteLine("2) View Specific Acount");
                Console.WriteLine("3) Search");
                Console.WriteLine("4) Move Money");
                Console.WriteLine("5) Exit");
                Console.Write("\r\nSelect an option: ");
                num = Console.ReadLine();

                switch (num)
                {
                    case "1":
                        pr.ReadFile();
                        
                        break;
                    case "2":
                        pr.ReadSpecificAccount();
                        break;

                    case "3":
                        pr.Search();
                        break;
                    case "4":
                        pr.transfer();
                        break;
                    default:
                        showMenu = false;
                        break;
                }
            } while (showMenu);
            
        }
        private void ReadFile()
        {

            accountManger.ReadFile();

        }
        private void ReadSpecificAccount()
        {
            // List<Account> list = new List<Account>();
            Console.Write("\nAccount number > ");
            string input = Console.ReadLine();
            int number;
            Int32.TryParse(input, out number);

            accountManger.ReadSpecificAccount(number);


        }

        private void Search()
        {
            // List<Account> list = new List<Account>();
            Console.Write("\nEntre a string > ");
            string search = Console.ReadLine().Trim();
            Console.WriteLine("");

            accountManger.Search(search);


        }
        private void transfer()
        {
            Console.Write("Please specify the sender's account number: ");
            int senderNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please specify the receiver's account number: ");
            int receiverNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please specify the amount to be moved: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            accountManger.ProcessTransfer(senderNum, receiverNum, amount);
        }
    }
}
