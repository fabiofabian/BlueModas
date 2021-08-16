using AutoMapper;
using BlueModas.Application.ViewModels;
using BlueModas.Domain.Commands;
using BlueModas.Domain.Models;

namespace BlueModas.Application.AutoMapper
{
  public class ViewModelToDomainMappingProfile : Profile
  {
    public ViewModelToDomainMappingProfile()
    {
      // Entities
      CreateMap<ProductViewModel, Product>();
      CreateMap<ProductImageViewModel, ProductImage>();
      CreateMap<OrderViewModel, Order>();
      CreateMap<OrderProductViewModel, OrderProduct>();
      //CreateMap<ProductVariant, ProductVariantViewModel>();
      //CreateMap<ProductVariantImage, ProductVariantImageViewModel>();


      // Commands
      CreateMap<OrderViewModel, CreateOrderCommand>();
      CreateMap<ProductViewModel, UpdateProductCommand>();
      CreateMap<ProductViewModel, RemoveProductCommand>();

    }
  }
}
