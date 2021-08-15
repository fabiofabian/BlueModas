using AutoMapper;
using BlueModas.Application.Interfaces;
using BlueModas.Application.ViewModels;
using BlueModas.Domain.Commands;
using BlueModas.Domain.Core.Interfaces;
using BlueModas.Domain.Core.Notifications;
using BlueModas.Domain.Interfaces.Repositories;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Application.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _ProductRepository;
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _bus;
    private readonly DomainNotificationHandler _notifications;

    public ProductService(IProductRepository ProductRepository, IMapper mapper, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
    {
      _ProductRepository = ProductRepository;
      _mapper = mapper;
      _notifications = (DomainNotificationHandler)notifications;
      _bus = bus;
    }

    public async Task Delete(Guid idProduct)
    {
      var command = _mapper.Map<RemoveProductCommand>(idProduct);
      await _bus.SendCommand(command);
    }

    public async Task<ProductViewModel> GetById(Guid idProduct)
    {
      var product = await _ProductRepository.GetById(idProduct);
      return _mapper.Map<ProductViewModel>(product);      
    }

    public IEnumerable<ProductViewModel> GetProducts()
    {
      return _mapper.ProjectTo<ProductViewModel>(_ProductRepository.GetProducts().AsQueryable());
    }

    public async Task Update(ProductViewModel model)
    {
      var command = _mapper.Map<UpdateProductCommand>(model);
      await _bus.SendCommand(command);
    }

  }
}
