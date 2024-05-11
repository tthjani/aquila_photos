using APhoto.Api.Requests;
using APhoto.Data;
using APhoto.Infrastructure.Utility;
using AutoMapper;

namespace APhoto.Api.Mappers
{
    public class HolidayMapper : Profile
    {
        public HolidayMapper()
        {
            CreateMap<AddHolidayRequestV1, Holiday>()
                .ForMember(m => m.StartDate, opt => opt.MapFrom(o => o.StartDate.ClearTime()))
                .ForMember(m => m.EndDate, opt => opt.MapFrom(o => o.EndDate.ClearTime()));
        }
    }
}
