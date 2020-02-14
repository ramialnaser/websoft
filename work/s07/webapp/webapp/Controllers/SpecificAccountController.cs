using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using webapp.Services;

namespace webapp.Controllers
{
    
    [ApiController]
    public class SpecificAccountController : ControllerBase
    {
        
        public SpecificAccountController(SpecificAccountService accountService)
        {
            AccountService = accountService;
        }

        public SpecificAccountService AccountService { get; }

        [HttpGet("api/accounts/{number}")]
        public IEnumerable<Account> Get(int number)
        {
            
            var accounts = AccountService.GetSpecAccounts();
            List<Account> aco = new List<Account>();
            foreach (var account in accounts)
            {
                if (account.Number == number)
                {

                    aco.Add(account);
                }
            }

            return aco;
            
        }

    }
}