using BlueModas.Domain.Core.Models;

using System;
using System.Collections.Generic;

namespace BlueModas.Domain.Models
{
  public class ProductImage : Entity
  {
    public Guid ProductId { get; set; }
    public string Location { get; set; }
  }
}
