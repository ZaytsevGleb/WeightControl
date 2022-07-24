using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightControl.Domain.Enums;

namespace WeightControl.Domain.Entities
{
    public class ProductResult
    {
        public bool Succeded { get; set; }
        public ProductError Error { get; set; }
    }
}
