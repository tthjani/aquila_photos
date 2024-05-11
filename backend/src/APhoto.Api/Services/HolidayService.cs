using APhoto.Api.Requests;
using APhoto.Common.Repositories;
using APhoto.Data;
using APhoto.Infrastructure.Utility;
using AutoMapper;

namespace APhoto.Api.Services
{
    public class HolidayService(IMapper mapper, IHolidayRepository holidayRepository) : IHolidayService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IHolidayRepository _holidayRepository = holidayRepository;

        public IAsyncEnumerable<Holiday> GetHolidays(CancellationToken cancellationToken)
            => _holidayRepository.GetAllAsync(cancellationToken);

        public async Task<IServiceResult> CreateHoliday(AddHolidayRequestV1 request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Holiday>(request);

            if (_holidayRepository.IsEntityOverlapping(entity))
            {
                return ServiceResult.Fail("The given holiday has an overlap with an already existing holiday.");
            }

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

            if (_holidayRepository.IsEntityOverlapping(holidayEntity))
            {
                return ServiceResult.Fail("The given holiday has an overlap with an already existing holiday.");
            }

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
