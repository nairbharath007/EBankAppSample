using EBankAppSample.DTOs;
using EBankAppSample.Models;
using EBankAppSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBankAppSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            List<TransactionDto> transactionDtos = new List<TransactionDto>();
            var transactions = _transactionService.GetAll();

            foreach (var transaction in transactions)
            {
                transactionDtos.Add(ConvertToDto(transaction));
            }

            return Ok(transactionDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var transaction = _transactionService.GetById(id);

            if (transaction != null)
            {
                var transactionDto = ConvertToDto(transaction);
                return Ok(transactionDto);
            }

            return NotFound("No such transaction exists.");
        }

        [HttpPost("")]
        public IActionResult Add(TransactionDto transactionDto)
        {
            var transaction = ConvertToModel(transactionDto);
            int newTransactionId = _transactionService.Add(transaction);

            if (newTransactionId != 0)
            {
                return Ok(newTransactionId);
            }

            return BadRequest("Some issue while adding transaction.");
        }

        private Transaction ConvertToModel(TransactionDto transactionDto)
        {
            return new Transaction
            {
                AccountId = transactionDto.AccountId,
                TransactionType = transactionDto.TransactionType,
                Amount = transactionDto.Amount,
                TransactionDate = DateTime.Now
            };
        }

        private TransactionDto ConvertToDto(Transaction transaction)
        {
            return new TransactionDto
            {
                TransactionId = transaction.TransactionId,
                AccountId = transaction.AccountId,
                TransactionType = transaction.TransactionType,
                Amount = transaction.Amount,
                TransactionDate = transaction.TransactionDate
            };
        }

    }
}
