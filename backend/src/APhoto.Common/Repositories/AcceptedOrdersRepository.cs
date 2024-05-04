using APhoto.Data;
using APhoto.Infrastructure;

namespace APhoto.Common.Repositories;

public class AcceptedOrdersRepository : AbstractRepository<AcceptedOrder>
{
    public AcceptedOrdersRepository(APhotosContext context)
        : base(context)
    {
    }
}