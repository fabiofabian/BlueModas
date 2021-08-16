using System;
using System.Collections.Generic;

namespace BlueModas.Application.ViewModels
{
  public class ProductImageViewModel
  {
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Location { get; set; }
  }
}
