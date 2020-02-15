using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using webapp.Models;
using webapp.Services;

namespace webapp.Pages
{
    public class MoveModel : PageModel
    {
        private readonly ILogger<MoveModel> _logger;
        public JsonFileAccountService AccountService;

        public Account Accounts { get; private set; }

        public MoveModel(
            ILogger<MoveModel> logger,
            JsonFileAccountService accountService
        )
        {
            _logger = logger;
            AccountService = accountService;
        }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public int amount { get; set; }
        public void OnPost()
        {

            int senderId = Int32.Parse(Request.Form["senderId"]);
            int receiverId = Int32.Parse(Request.Form["receiverId"]);
            int amount     = Int32.Parse(Request.Form["amount"]);
            
            Accounts = AccountService.moveMoney(senderId, receiverId, amount);
        }
    }
}
