using System;

namespace WeightControl.Application.Products.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Type { get; set; }
        public int Unit { get; set; }
    }
}
