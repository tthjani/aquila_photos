using APhoto.Data;
using APhoto.Infrastructure;

namespace APhoto.Common.Repositories;

public class FinishedOrdersRepository : AbstractRepository<FinishedOrder>
{
    public FinishedOrdersRepository(APhotosContext context)
        : base(context)
    {
    }
}