using Microsoft.EntityFrameworkCore;
using MyMvcReactApp.Core.UserData.Objects;

namespace MyMvcReactApp.Core.UserData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
