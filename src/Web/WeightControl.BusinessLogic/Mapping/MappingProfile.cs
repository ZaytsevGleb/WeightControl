using AutoMapper;
using WeightControl.BusinessLogic.Models;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                this.CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
