using APhoto.Api.Requests;
using APhoto.Data;
using APhoto.Infrastructure.Utility;

namespace APhoto.Api.Services
{
    public interface IHolidayService
    {
        IAsyncEnumerable<Holiday> GetHolidays(CancellationToken cancellationToken);

        Task<IServiceResult> CreateHoliday(AddHolidayRequestV1 request, CancellationToken cancellationToken);

        Task<IServiceResult> UpdateHoliday(UpdateHolidayRequestV1 request, CancellationToken cancellationToken);

        Task<IServiceResult> DeleteHoliday(RemoveHolidayRequestV1 request, CancellationToken cancellationToken);
    }
}
