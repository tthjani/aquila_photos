using APhoto.Api.Requests;
using APhoto.Data;
using APhoto.Infrastructure;
using APhoto.Infrastructure.Utility;
using AutoMapper;

namespace APhoto.Api.Services
{
    public class HolidayService(IMapper mapper, IAbstractRepository<Holiday> holidayRepository) : IHolidayService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAbstractRepository<Holiday> _holidayRepository = holidayRepository;

        public IAsyncEnumerable<Holiday> GetHolidays(CancellationToken cancellationToken)
            => _holidayRepository.GetManyAsync(holiday => holiday.StartDate >= DateTime.UtcNow, cancellationToken);

        public async Task<IServiceResult> CreateHoliday(AddHolidayRequestV1 request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Holiday>(request);

            var result = await _holidayRepository.CreateAsync(entity, cancellationToken);

            if (result.IsFailure)
            {
                return ServiceResult.Fail(result.Reason!);
            }

            return ServiceResult.Success();
        }

        public async Task<IServiceResult> UpdateHoliday(UpdateHolidayRequestV1 request, CancellationToken cancellationToken)
        {
            var holiday = await _holidayRepository.GetOneAsync(
                holiday => holiday.HolidayId == request.HolidayId,
                cancellationToken);

            if (holiday.IsFailure)
            {
                return ServiceResult.Fail($"Holiday could not be found with the provided ID: {request.HolidayId}");
            }

            var holidayEntity = holiday.Value!;
            holidayEntity.StartDate = request.StartDate;
            holidayEntity.EndDate = request.EndDate;
            holidayEntity.Comment = request.Comment;
            holidayEntity.AllowOrders = request.AllowOrders;

            var result = await _holidayRepository.UpdateAsync(holidayEntity, cancellationToken);

            if (result.IsFailure)
            {
                return ServiceResult.Fail(result.Reason!);
            }

            return ServiceResult.Success();
        }

        public async Task<IServiceResult> DeleteHoliday(RemoveHolidayRequestV1 request, CancellationToken cancellationToken)
        {
            var holiday = await _holidayRepository.GetOneAsync(
                holiday => holiday.HolidayId == request.HolidayId,
                cancellationToken);

            if (holiday.IsFailure)
            {
                return ServiceResult.Fail($"Holiday could not be found with the provided ID: {request.HolidayId}");
            }

            var result = await _holidayRepository.DeleteAsync(holiday.Value!, cancellationToken);

            if (result.IsFailure)
            {
                return ServiceResult.Fail(result.Reason!);
            }

            return ServiceResult.Success();
        }
    }
}
