﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace EBankAppSample.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string AccountType { get; set; } //Savings, current, fd
        public string? AccountNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }
        public bool IsActive { get; set; }

        // 1:M relationship with Transaction
        public List<Transaction>? Transactions { get; set; }
    }
}
