using BlueModas.Domain.Interfaces.Data;
using BlueModas.Domain.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModas.Domain.Interfaces.Repositories
{
  public interface IProductRepository : IRepository<Product>
  {
    IEnumerable<Product> GetProducts();
    Task<Product> GetById(Guid id);
  }
}
