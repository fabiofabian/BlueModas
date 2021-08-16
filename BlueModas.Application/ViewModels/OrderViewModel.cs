using System;
using System.Collections.Generic;

namespace BlueModas.Application.ViewModels
{
  public class OrderViewModel
  {
    public Guid? Id { get; set; }
    public int Number { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public IEnumerable<OrderProductViewModel> OrderProducts { get; set; }
  }
}
