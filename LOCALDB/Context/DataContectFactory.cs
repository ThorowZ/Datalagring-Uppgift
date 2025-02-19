using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

    internal class DataContectFactory
    {

    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C-Projects\LOCALDB\LOCALDB\Data\database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

            return new DataContext(optionsBuilder.Options);
        }
    }
}

