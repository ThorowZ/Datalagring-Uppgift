
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    internal class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; } = null!;
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}