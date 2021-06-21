using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XayahFiances.Common;
using XayahFinances.Common.Ofx.Data;
using XayahFinances.Domain.Entities;
using XayahFinances.Domain.Interfaces.Services;
using XayahFinances.Web.Models;

namespace XayahFinances.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBankAccountService _bankAccountService;
        private readonly ITransactionService _transactionService;

        public HomeController(ILogger<HomeController> logger, IBankAccountService bankService, ITransactionService transactionService)
        {
            _logger = logger;
            _bankAccountService = bankService;
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
         public async Task<IActionResult> UploadOfx()
        {
            if (Request.Form.Files.Count != 1)
                return BadRequest();

            var ofxFile = Request.Form.Files.First();
            
            using (var ms = new MemoryStream())
            {
                await ofxFile.CopyToAsync(ms);

                OfxSerializer serializer = new OfxSerializer(typeof(Ofx));

                var ofxData = (Ofx)serializer.Deserialize(new StreamReader(ofxFile.OpenReadStream()));
                var ofxAccountInfo = ofxData.BankMessage.ResponseTranscation.Response.AccountInfo;
                var ofxTransactions = ofxData.BankMessage.ResponseTranscation.Response.BankList;

                var obj = new BankAccount
                {
                    BankId = ofxAccountInfo.BankId,
                    AccountNumber = ofxAccountInfo.AccountNumber,
                    AccountType = ofxAccountInfo.AccountType,
                    Transactions = new List<Transaction>()
                };

                _bankAccountService.Create(obj);
                
                foreach (var tr in ofxTransactions.Transactions)
                {
                    Transaction t = new Transaction
                    {
                        Amount = tr.Amount,
                        BankAccountId = obj.Id,
                        Date = tr.DatePosted,
                        Description = tr.Information,
                        Type = tr.Type
                    };

                    _transactionService.Create(t);

                    obj.Transactions.Add(t);
                }
            }

            return Ok();
        }
    }
}
