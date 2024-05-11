using APhoto.Data;
using APhoto.Infrastructure;

namespace APhoto.Common.Repositories
{
    public interface IHolidayRepository : IAbstractRepository<Holiday>
    {
        bool IsEntityOverlapping(Holiday entity);

        bool IsDateInAnActiveHoliday(DateTime date, bool checkIfOrderCreationIsAllowed = true);
    }
}
