using AutoMapper;
using BlueModas.Application.ViewModels;
using BlueModas.Domain.Models;

namespace BlueModas.Application.AutoMapper
{
  public class DomainToViewModelMappingProfile : Profile
  {
    public DomainToViewModelMappingProfile()
    {
      CreateMap<Product, ProductViewModel>();
      CreateMap<Order, OrderViewModel>();
      CreateMap<OrderProduct, OrderProductViewModel>();
    }
  }
}
