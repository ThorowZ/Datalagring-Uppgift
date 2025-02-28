using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;



public class ProjectRepositories(DataContext context) : IProjectRepositories

{
    private readonly DataContext _context = context;
    public async Task<ProjectEntity> CreateAsync(ProjectEntity entity)

    {
        if (entity == null)
            return null!;

        try
        {
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Error Creating User Entity :: {ex.Message}");
            return null!;
        }
    }
  

    public async Task<bool> DeleteAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        if (expression == null)
            return false;

        try
        {
            var existingEntity = await GetAsync(expression);
            if (existingEntity == null)
                return false;

            _context.Projects.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting project entity :: {ex.Message}");
            return false;
        }
    }

    public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<ProjectEntity> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        return await _context.Projects.FirstOrDefaultAsync(expression) ?? null!;
    }

    public async Task<ProjectEntity> UpdateAsync(ProjectEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;

        try
        {
            var existingEntity = await _context.Projects.FirstOrDefaultAsync(x => x.Id == updatedEntity.Id) ?? null!;
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return existingEntity;

            
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error Updating project entity :: {ex.Message}");
            return null!;
        }
    }
}
