using AutoMapper;
using WeightControl.BusinessLogic.Models;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}