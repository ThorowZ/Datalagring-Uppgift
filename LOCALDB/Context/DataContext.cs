
using Data.Entites;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //public DataContext() { }
        public DbSet<UserEntity> Users { get; set; } = null!;

        public DbSet<ProjectEntity> Projects { get; set; } = null!;

        public DbSet<StatusTypesEntity> StatusTypes { get; set; } = null!;

        //public Dbset<CustomerEntity> Customer { get; set; } = null!;





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured && string.IsNullOrEmpty(optionsBuilder.Options.ContextType.Name))
            //{
            //   optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\C-Projects\\LOCALDB\\LOCALDB\\Data\\MSSQLLocalDB.mdf;Integrated Security=True");
            //}

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntity>()
        .HasKey(p => p.Id);

            modelBuilder.Entity<ProjectEntity>()
                .HasOne(p => p.User)
                .WithMany(u => u.Project)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectEntity>()
              .HasOne(p => p.Status)
              .WithMany(s => s.Projects)
              .HasForeignKey(p => p.StatusId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}