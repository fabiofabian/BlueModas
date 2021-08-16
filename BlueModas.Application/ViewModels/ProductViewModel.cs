using System;
using System.Collections.Generic;

namespace BlueModas.Application.ViewModels
{
  public class ProductViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string ImagePath { get; set; }
    //public IEnumerable<ProductImageViewModel> Images { get; set; }
  }
}
