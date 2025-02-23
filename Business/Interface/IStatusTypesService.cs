using Data.Entities;

namespace Business.Services
{
    public interface IStatusTypesService
    {
        StatusTypesEntity CreateStatusType(StatusTypesEntity statusType);
        IEnumerable<StatusTypesEntity> GetAllStatusTypes();
        StatusTypesEntity GetStatusTypeById(int id);
        StatusTypesEntity UpdateStatusType(StatusTypesEntity statusTypeEntity);
        bool DeleteStatusType(int id);
    }
}