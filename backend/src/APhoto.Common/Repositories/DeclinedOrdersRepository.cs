using APhoto.Data;
using APhoto.Infrastructure;

namespace APhoto.Common.Repositories;

public class DeclinedOrdersRepository : AbstractRepository<DeclinedOrder>
{
    public DeclinedOrdersRepository(APhotosContext context)
        : base(context)
    {
    }
}