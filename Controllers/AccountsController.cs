using EBankAppSample.DTOs;
using EBankAppSample.Models;
using EBankAppSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBankAppSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            List<AccountDto> accountDtos = new List<AccountDto>();
            var accounts = _accountService.GetAll();
            if (accounts.Count == null)
            {
                return BadRequest("No accounts are added yet.");
            }
            else
            {
                foreach (var account in accounts)
                {
                    accountDtos.Add(ConvertToDto(account));
                }
            }
            return Ok(accountDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var account = _accountService.GetById(id);
            if(account != null)
            {
                var accountDto = ConvertToDto(account);
                return Ok(accountDto);
            }
            return NotFound("No such user exists.");
        }

        [HttpPost("")]
        public IActionResult Add(AccountDto accountDto) 
        {
            var account = ConvertToModel(accountDto);
            int newAccountId = _accountService.Add(account);
            if(newAccountId != null) 
            {
                return Ok(newAccountId);
            }
            return BadRequest("Some issue while adding Account.");
        }

        [HttpPut("")]
        public IActionResult Update(AccountDto accountDto) 
        {
            var account = _accountService.GetById(accountDto.AccountId);
            if(account != null)
            {
                var updatedAccount = ConvertToModel(accountDto,false);
                var modifiedAccount = _accountService.Update(updatedAccount);
                return Ok(modifiedAccount);

            }
            return BadRequest("Some issue while updating Account");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var account = _accountService.GetById(id);
            if (account != null)
            {
                _accountService.Delete(account);
                return Ok(id);
            }
            return BadRequest("No user found to delete.");
        }

        private Account ConvertToModel(AccountDto accountDto, bool includeOpeningDate = true)
        {
            var account = new Account
            {
                AccountId = accountDto.AccountId,
                AccountType = accountDto.AccountType,
                AccountNumber = accountDto.AccountNumber,
                InterestRate = accountDto.InterestRate,
                IsActive = accountDto.IsActive,
                CustomerId = accountDto.CustomerId,
            };
            if(includeOpeningDate)
            {
                account.OpeningDate = accountDto.OpeningDate;
            }
            return account;
        }

        private AccountDto ConvertToDto(Account account)
        {
            return new AccountDto
            {
                AccountId = account.AccountId,
                AccountType = account.AccountType,
                AccountNumber = account.AccountNumber,
                OpeningDate = account.OpeningDate,
                InterestRate = account.InterestRate,
                IsActive = account.IsActive,
                CustomerId = account.CustomerId,
            };
        }
    }
}
