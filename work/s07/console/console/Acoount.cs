using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
namespace test
{
    public class Account
    {


        public int Number { get; set; }
        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }


        public override string ToString()
        {

            return JsonSerializer.Serialize<Account>(this);
        }
    }
}