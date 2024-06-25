using BackendTest.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.API.Data.Repositories
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
