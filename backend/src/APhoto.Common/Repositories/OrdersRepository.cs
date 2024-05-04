using APhoto.Data;
using APhoto.Infrastructure;

namespace APhoto.Common.Repositories;

public class OrdersRepository : AbstractRepository<Order>
{
    public OrdersRepository(APhotosContext context)
        : base(context)
    {
    }
}