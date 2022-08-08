using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightControl.BusinessLogic.Models;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Mapping
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            this.CreateMap<Product, ProductDto>().ReverseMap();
            this.CreateMap<List<Product>, List<ProductDto>>().ReverseMap();
        }
    }
}
