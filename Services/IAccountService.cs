﻿using EBankAppSample.Models;

namespace EBankAppSample.Services
{
    public interface IAccountService
    {
        public List<Account> GetAll();
        public Account GetById(int id);
        public int Add(Account account);
        public Account Update(Account account);
        public void Delete(Account account);


    }
}