
using Data.Entites;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; } = null!;

        public DbSet<ProjectEntity> Projects { get; set; } = null!;





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\C-Projects\\LOCALDB\\LOCALDB\\Data\\database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
            //optionsBuilder.EnableServiceProviderCaching();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntity>()
        .HasKey(p => new { p.Id, p.UserId });

            modelBuilder.Entity<ProjectEntity>()
                .HasOne(p => p.User)
                .WithMany(u => u.Project)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}