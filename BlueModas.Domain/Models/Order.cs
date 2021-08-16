using BlueModas.Domain.Core.Models;

using System.Collections.Generic;

namespace BlueModas.Domain.Models
{
  public class Order : Entity
  {
    public int Number { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public IEnumerable<OrderProduct> OrderProducts { get; set; }

    public Order(string name, string email, string phone, int number, IEnumerable<OrderProduct> products)
    {
      Id = System.Guid.NewGuid();
      Number = number;
      Name = name;
      Email = email;
      Phone = phone;
      OrderProducts = products;
    }
    public Order()
    {
    }
  }
}
