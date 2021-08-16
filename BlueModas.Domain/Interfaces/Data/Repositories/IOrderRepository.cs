using BlueModas.Domain.Interfaces.Data;
using BlueModas.Domain.Models;
using System;
using System.Threading.Tasks;

namespace BlueModas.Domain.Interfaces.Repositories
{
  public interface IOrderRepository : IRepository<Order>
  {
    Task<Order> GetById(Guid id);
    Task<int> GetCountOrdersOfDay();
  }
}
