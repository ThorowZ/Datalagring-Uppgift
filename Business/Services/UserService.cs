using Data.Context;
using Data.Entities;
using Data.Interface;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services
{
    public class UserService(DataContext context) : IUserService
    {
        private readonly DataContext _context = context;  



        public UserEntity CreateUser(UserEntity userEntity)
        {
            _context.Users.Add(userEntity);
            _context.SaveChanges();

            return userEntity;
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            return _context.Users;
        }

        public UserEntity GetUserById(int id)
        {
            var userEntity = _context.Users.FirstOrDefault(x => x.Id == id);
            if (userEntity != null)
                return userEntity;
            else
                return null!;
            {
                
            }
        }

        public UserEntity UpdateUser(UserEntity userEntity)
        {
            _context.Users.Update(userEntity);
            _context.SaveChanges();

            return userEntity;
        }

        public bool DeleteUserById(int id)
        {
            var userEntity = _context.Users.FirstOrDefault(x => x.Id == id);
            if (userEntity != null)
            {
                _context.Remove(userEntity);
                _context.SaveChanges();

                return true;

            }
            else { return false; }
        }

    }
}