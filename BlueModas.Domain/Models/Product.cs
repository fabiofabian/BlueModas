using BlueModas.Domain.Core.Models;
using System.Collections.Generic;

namespace BlueModas.Domain.Models
{
  public class Product: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //public IEnumerable<ProductVariant> Variants { get; set; }
        public IEnumerable<ProductImage> Images { get; set; }
    }
}
