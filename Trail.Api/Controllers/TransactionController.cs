using Microsoft.AspNetCore.Mvc;
using Trail.Api.DbModels;
using Trail.Api.Models.DTOs;
using Trail.Api.Models.ViewModels;
using Trail.Api.Services;

namespace Trail.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class TransactionController : ControllerBase
    {

        private readonly ILogger<TransactionController> _logger;
        private readonly IService _service;

        public TransactionController(ILogger<TransactionController> logger, IService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost(Name ="deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionDTO transactionDTO)
        {
            Transaction record = new Transaction()
            {
                Amount= transactionDTO.Amount,
                AccountNumber= transactionDTO.AccountNumber,
                Currency= transactionDTO.Currency,
                Type=0,
                Date=DateTime.Now
            };

            var result = await _service.Deposit(record);

            if (result != null)
            {
                await _service.AddTransaction(record);

                return Ok(new ResponseViewModel { AccountNumber= result.AccountNumber,Successful=true,Balance= result.Balance,Message="Successfully Deposited." });
            }
            else
            {
                return Ok(new ResponseViewModel { AccountNumber = transactionDTO.AccountNumber, Successful = false, Message = "Unable to Deposit." });
            }
        }

        [HttpPost(Name = "withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] TransactionDTO transactionDTO)
        {
            Transaction record = new Transaction()
            {
                Amount = transactionDTO.Amount,
                AccountNumber = transactionDTO.AccountNumber,
                Currency = transactionDTO.Currency,
                Type = 1,
                Date = DateTime.Now
            };

            var result= await _service.Withdraw(record);

            if (result != null)
            {
                await _service.AddTransaction(record);

                return Ok(new ResponseViewModel { AccountNumber = result.AccountNumber, Successful = true, Balance = result.Balance, Message = "Successfully Widthdraw Amount." });
            }
            else
            {
                return Ok(new ResponseViewModel { AccountNumber = transactionDTO.AccountNumber, Successful = false, Message = "Unable to Widthdraw Amount" });
            }
        }

        [HttpGet("{accountBalance}")]
        public async Task<IActionResult> Balance(int accountBalance)
        {
            var result = await _service.Balance(accountBalance);

            if (result != null)
            {
                return Ok(new ResponseViewModel { AccountNumber = result.AccountNumber, Successful = true, Balance = result.Balance, Message = "Successfully retreved Account Balance." });
            }
            else
            {
                return Ok(new ResponseViewModel { AccountNumber = accountBalance, Successful = false, Message = "Unable to retrive Account Balance." });
            }
        }
    }
}