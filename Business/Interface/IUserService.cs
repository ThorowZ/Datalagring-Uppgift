using Data.Entities;

namespace Data.Interface
{
    public interface IUserService
    {
        UserEntity CreateUser(UserEntity userEntity);
        IEnumerable<UserEntity> GetUsers();
        UserEntity GetUserById(int id);
        UserEntity UpdateUser(UserEntity userEntity);
        bool DeleteUserById(int id);
    }
}
