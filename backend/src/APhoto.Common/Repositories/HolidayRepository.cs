using APhoto.Data;
using APhoto.Infrastructure;

namespace APhoto.Common.Repositories
{
    public class HolidayRepository(APhotosContext dbContext) : AbstractRepository<Holiday>(dbContext)
    {
    }
}
