using System;
using System.Collections.Generic;

namespace BlueModas.Application.ViewModels
{
  public class OrderProductViewModel
  {
    public Guid? OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public ProductViewModel Product { get; set; }
  }
}
