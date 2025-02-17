
using Data.Entites;

namespace Data.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C-Projects\LOCALDB\LOCALDB\Data\database.mdf;Integrated Security=True;Connect Timeout=30";

        public void CreateUserTableIfNotExists()
        {

        }

        public bool Create()
        {

        }

        public IEnumerable<ProductEntity> GetAll()
        {

        }


    }
}

