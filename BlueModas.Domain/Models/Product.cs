using BlueModas.Domain.Core.Models;

namespace BlueModas.Domain.Models
{
  public class Product : Entity
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }

    public string ImagePath { get; set; }
    //public IEnumerable<ProductImage> Images { get; set; }
  }
}
