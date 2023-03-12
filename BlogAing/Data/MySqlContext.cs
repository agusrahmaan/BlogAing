using BlogAing.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAing.Data
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
