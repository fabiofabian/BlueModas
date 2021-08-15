using BlueModas.Domain.Core.Models;

using System;
using System.Collections.Generic;

namespace BlueModas.Domain.Models
{
  public class ProductVariant : Entity
  {
    public Guid ProductId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    //public Product Product { get; set; }
    public IEnumerable<ProductVariantImage> Images { get; set; }
  }
}
