namespace Data.Interface;

using Data.Context;
using Data.Entites;
using Data.Entities;
using Data.Repositories;
using System.Linq.Expressions;

    public interface IProjectRepositories
    {


    public Task<UserEntity> CreateAsync(ProjectEntity entity);


    public Task<IEnumerable<UserEntity>> GetAllAsync();

    Task<UserEntity> UpdateAsync(Expression<Func<ProjectEntity, bool>> expression);


    public Task<UserEntity> UpdateAsync(ProjectEntity updateEntity);

    public Task<bool> DeleteAsync(Expression<Func<ProjectEntity, bool>> expression);
}

