global using ChatApplication_backend.Models;
global using Microsoft.EntityFrameworkCore;

namespace ChatApplication_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Chat> Chats => Set<Chat>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List<int>>().HasNoKey();
        }
    }
}
