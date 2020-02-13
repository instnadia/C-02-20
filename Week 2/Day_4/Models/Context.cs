using Microsoft.EntityFrameworkCore;

namespace Day_4.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options): base(options){}

        public DbSet<User> Users {get;set;}
    }
}