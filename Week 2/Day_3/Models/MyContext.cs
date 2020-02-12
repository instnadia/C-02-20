using Microsoft.EntityFrameworkCore;
namespace Day_3.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<Trail> Trails {get;set;}
    }
}