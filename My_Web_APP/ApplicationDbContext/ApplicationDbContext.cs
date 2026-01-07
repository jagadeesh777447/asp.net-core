using Microsoft.EntityFrameworkCore;
using My_Web_APP.Models;



namespace My_Web_APP.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
