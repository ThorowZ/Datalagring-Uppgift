namespace Data.Interface;

using Data.Entites;
using Data.Entities;
using Data.Repositories;

    internal class IProductRepositories
    {
    bool Create(ProductEntity productEntity);
    IEnumerable<ProductEntity> GetAll();

}

