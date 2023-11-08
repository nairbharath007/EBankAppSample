using EBankAppSample.Models;
using Microsoft.EntityFrameworkCore;

namespace EBankAppSample.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Query> Query { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    }
}
