using APhoto.Api.Requests;
using APhoto.Data;
using AutoMapper;

namespace APhoto.Api.Mappers
{
    public class HolidayMapper : Profile
    {
        public HolidayMapper()
        {
            CreateMap<AddHolidayRequestV1, Holiday>();
        }
    }
}
