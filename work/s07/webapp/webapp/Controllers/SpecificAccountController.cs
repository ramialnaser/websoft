using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using webapp.Services;

namespace webapp.Controllers
{
    
    [ApiController]
    public class SpecificAccountController : ControllerBase
    {
        
        public SpecificAccountController(JsonFileAccountService accountService)
        {
            AccountService = accountService;
        }

        public JsonFileAccountService AccountService { get; }

        [HttpGet("api/accounts/{number}")]
        public String Get(int number)
        {
            String ms = "{Not found}";
            var account = AccountService.GetAccountBynumber(number);
            if (account!=null)
            {
                return account.ToString();
            }
            return ms;
            
        }
       
        
    }
}