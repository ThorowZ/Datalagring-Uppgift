using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Interface
{
    public interface IUserRepositories
    {
        Task<bool> DeleteAsync(Expression<Func<UserEntity, bool>> expression);

        public Task<UserEntity> GetById(Expression<Func<UserEntity, bool>> expression);

        Task<IEnumerable<UserEntity>> GetAllAsync();

        public Task<UserEntity> UpdateAsync(Expression<Func<UserEntity, bool>> expression);

        //public async Task<UserEntity> CreateAsync(UserEntity userEntity)
        //{
        //    if (userEntity == null)
        //        return null!;

        //    try
        //    {
        //        //await _context.User.AddAsync(userEntity);
        //        //await _context.SaveChangeAsync();
        //        //return userEntity;
        //    }

        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Error Creating User Entity :: {ex.Message}");
        //        return null!;
        //    }
        //}


    }

}

