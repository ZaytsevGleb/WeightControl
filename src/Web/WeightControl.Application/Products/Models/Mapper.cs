using AutoMapper;
using WeightControl.Domain.Entities;

namespace WeightControl.Application.Products.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}