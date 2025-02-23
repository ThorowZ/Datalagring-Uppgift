using Data.Entities;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepositories : IProjectRepositories
{
    public Task<ProjectEntity> CreateAsync(ProjectEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectEntity> DeleteAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProjectEntity> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectEntity> UpdateAsync(ProjectEntity updatedEntity)
    {
        throw new NotImplementedException();
    }
}
