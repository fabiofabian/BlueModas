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
  public class OrderService : IOrderService
  {
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _bus;
    private readonly DomainNotificationHandler _notifications;

    public OrderService(IOrderRepository orderRepository, IMapper mapper, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
    {
      _orderRepository = orderRepository;
      _mapper = mapper;
      _notifications = (DomainNotificationHandler)notifications;
      _bus = bus;
    }     

    public async Task Create(OrderViewModel model)
    {
      var command = _mapper.Map<CreateOrderCommand>(model);
      await _bus.SendCommand(command);
    }

    public async Task<OrderViewModel> GetById(Guid idOrder)
    {
      var order = await _orderRepository.GetById(idOrder);
      return _mapper.Map<OrderViewModel>(order);
    }
  }
}
