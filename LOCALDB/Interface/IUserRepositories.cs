using Data.Entities;

namespace Data.Interface
{
    public interface IUserRepositories
    {
        bool Create(UserEntity userEntity);
        IEnumerable<UserEntity> GetAll();
    }
}
