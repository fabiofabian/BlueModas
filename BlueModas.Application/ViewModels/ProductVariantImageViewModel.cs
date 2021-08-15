using System;
using System.Collections.Generic;

namespace BlueModas.Application.ViewModels
{
  public class ProductVariantImageViewModel
  {
    public Guid Id { get; set; }
    public Guid ProductVariantId { get; set; }
    public string Location { get; set; }
  }
}
