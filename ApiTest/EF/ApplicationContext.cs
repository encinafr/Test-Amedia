using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
