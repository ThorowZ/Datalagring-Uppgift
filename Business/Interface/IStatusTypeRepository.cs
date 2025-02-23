

using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interface
{
    public interface IStatusTypeRepository
    {
        Task<bool> DeleteAsync(Expression<Func<StatusTypesEntity, bool>> expression);

        public Task<StatusTypesEntity> GetById(Expression<Func<StatusTypesEntity, bool>> expression);

        Task<IEnumerable<StatusTypesEntity>> GetAllAsync();

        public Task<StatusTypesEntity> UpdateAsync(Expression<Func<StatusTypesEntity, bool>> expression);
    }
}