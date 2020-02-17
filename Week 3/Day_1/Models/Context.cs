using Microsoft.EntityFrameworkCore;

namespace Day_1.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options): base(options){}

        public DbSet<User> Users {get;set;}
        public DbSet<Post> Posts {get;set;}
        public DbSet<Vote> Votes {get;set;}
    }
}