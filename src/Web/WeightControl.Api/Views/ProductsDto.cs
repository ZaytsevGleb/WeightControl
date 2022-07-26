using System;

namespace WeightControl.Api.Views
{
    public class ProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Type { get; set; }
        public int Unit { get; set; }
    }
}
