using BlueModas.Application.ViewModels;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModas.Application.Interfaces
{
  public interface IProductService
  {
    IEnumerable<ProductViewModel> GetProducts();
    Task Update(ProductViewModel product);
    Task<ProductViewModel> GetById(Guid idProduct);
    Task Delete(Guid idProduct);
  }
}
