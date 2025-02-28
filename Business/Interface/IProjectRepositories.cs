
using Data.Entities;
using System.Linq.Expressions;

namespace Data.Repositories;

    public interface IProjectRepositories
    {
    Task<ProjectEntity> CreateAsync(ProjectEntity entity);

    Task<IEnumerable<ProjectEntity>> GetAllAsync();

    Task<ProjectEntity> GetAsync(Expression<Func<ProjectEntity, bool>> expression);

    Task<ProjectEntity> UpdateAsync(ProjectEntity updatedEntity);

    Task<bool> DeleteAsync(Expression<Func<ProjectEntity, bool>> expression);

}

