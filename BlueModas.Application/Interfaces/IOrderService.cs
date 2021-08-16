using BlueModas.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace BlueModas.Application.Interfaces
{
  public interface IOrderService
  {
    Task<OrderViewModel> GetById(Guid idOrder);
    Task Create(OrderViewModel order);
  }
}
