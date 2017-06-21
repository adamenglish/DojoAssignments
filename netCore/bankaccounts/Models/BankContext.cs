using Microsoft.EntityFrameworkCore;
 
namespace bankaccounts.Models
{
    public class BankContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Action> Actions {get; set;}
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }
    }
}
