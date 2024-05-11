using APhoto.Data;
using APhoto.Infrastructure;

namespace APhoto.Common.Repositories
{
    public class HolidayRepository(APhotosContext dbContext) : AbstractRepository<Holiday>(dbContext), IHolidayRepository
    {
        public bool IsEntityOverlapping(Holiday entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), "Parameter can not be null.");
            }

            return _context.Set<Holiday>().Any(holiday =>
            // entity interval covers the holiday interval    
            (entity.StartDate <= holiday.StartDate
                    && entity.EndDate >= holiday.EndDate)
            // entity startdate is inside holiday interval & entity enddate is inside holiday interval
            || ((entity.StartDate > holiday.StartDate && entity.StartDate <= holiday.EndDate)
                    && (entity.EndDate <= holiday.EndDate))
            // entity startdate is inside holiday interval & entity enddate is after holiday enddate
            || ((entity.StartDate > holiday.StartDate && entity.StartDate <= holiday.EndDate)
                    && entity.EndDate > holiday.EndDate)
            // entity startdate is before holiday startdate & entity enddate is inside holiday interval
            || ((entity.StartDate <= holiday.StartDate)
                    && (entity.EndDate < holiday.EndDate && entity.EndDate > holiday.StartDate)));
        }
    }
}
