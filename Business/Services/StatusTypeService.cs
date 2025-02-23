using Data.Context;
using Data.Entities;
using Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class StatusTypesService(DataContext context) : IStatusTypesService
    {
        private readonly DataContext _context = context;


        public StatusTypesEntity CreateStatusType(StatusTypesEntity statusType)
        {
            var statusTypeEntity = GetStatusTypeByName(statusType.StatusName);
            if (statusTypeEntity == null)
            {
                statusTypeEntity!.StatusName = statusType.StatusName;
                _context.StatusTypes.Add(statusTypeEntity);
                _context.SaveChanges();
            }

            return statusTypeEntity;
        }

        public IEnumerable<StatusTypesEntity> GetAllStatusTypes()
        {
            return _context.StatusTypes.ToList();
        }

        public StatusTypesEntity GetStatusTypeById(int id)
        {
            return _context.StatusTypes.FirstOrDefault(x => x.Id == id) ?? null!;
        }

        public StatusTypesEntity GetStatusTypeByName(string statusName)
        {
            var statusTypeEntity = _context.StatusTypes.FirstOrDefault(x => x.StatusName == statusName);
            return statusTypeEntity = null!;
        }

        public StatusTypesEntity UpdateStatusType(StatusTypesEntity statusTypeEntity)
        {
            _context.StatusTypes.Update(statusTypeEntity);
            _context.SaveChanges();
            return statusTypeEntity;
        }

        public bool DeleteStatusType(int id)
        {
            var statusType = _context.StatusTypes.Find(id);
            if (statusType != null)
            {
                _context.StatusTypes.Remove(statusType);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
