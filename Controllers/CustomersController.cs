using EBankAppSample.DTOs;
using EBankAppSample.Models;
using EBankAppSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBankAppSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            var customers = _customerService.GetAll();
            if (customers.Count == 0)
                return BadRequest("Nobody here.");
            else
            {
                foreach (var customer in customers)
                {
                    customerDtos.Add(ConvertToDto(customer));
                }
            }
            return Ok(customerDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customerService.GetById(id);

            if (customer != null)
            {
                var customerDto = ConvertToDto(customer);
                return Ok(customerDto);
            }

            return NotFound("No such customer exists.");
        }
        [HttpPost("")]
        public IActionResult Add(CustomerDto customerDto)
        {
            var customer = ConvertToModel(customerDto);
            int newCustomerId = _customerService.Add(customer);
            if (newCustomerId != null)
                return Ok(newCustomerId);
            return BadRequest("Some issue while Adding customer.");
        }

        [HttpPut("")]
        public IActionResult Update(CustomerDto customerDto)
        {
            var customer = _customerService.GetById(customerDto.CustomerId);
            if (customer != null)
            {
                var updatedCustomer = ConvertToModel(customerDto);
                var modifiedCustomer = _customerService.Update(updatedCustomer);
                return Ok(modifiedCustomer);
            }
            return BadRequest("Some issue while updating Customer id: ");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer != null)
            {
                _customerService.Delete(customer);
                return Ok(id);
            }
            return BadRequest("No user found to delete.");
        }



        private Customer ConvertToModel(CustomerDto customerDto)
        {
            return new Customer()
            {
                CustomerId = customerDto.CustomerId,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                DOB = customerDto.DOB,
                Email = customerDto.Email,
                IsActive = customerDto.IsActive,
            };
        }


        private CustomerDto ConvertToDto(Customer customer)
        {
            var customerDto = new CustomerDto()
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DOB = customer.DOB,
                Email = customer.Email,
                IsActive = customer.IsActive,
                TotalAccounts = customer.Accounts != null ? customer.Accounts.Count() : 0,
                TotalDocs = customer.Documents != null ? customer.Documents.Count() : 0,
                TotalQuerys = customer.Queries != null ? customer.Queries.Count() : 0

            };
            customerDto.CustomerAccounts = customer.Accounts
                .Where(account => account.IsActive)
                .Select(account => account.AccountId)
                .ToList();

            return customerDto;
        }
    }
}
