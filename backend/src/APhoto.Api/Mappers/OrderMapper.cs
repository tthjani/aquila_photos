using APhoto.Api.Requests;
using APhoto.Data;
using AutoMapper;

namespace APhoto.Api.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<AddOrderRequestV1, Order>();
        }
    }
}
