using BlueModas.Domain.Core.Interfaces;
using BlueModas.Domain.Core.Notifications;
using BlueModas.Domain.Interfaces.Data;
using BlueModas.Domain.Interfaces.Repositories;
using BlueModas.Domain.Models;

using MediatR;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlueModas.Domain.Commands
{
  public class OrderCommandHandler : CommandHandler, IRequestHandler<CreateOrderCommand>
  {
    private readonly IMediatorHandler _bus;
    private readonly DomainNotificationHandler _notifications;
    private readonly IOrderRepository _orderRepository;

    public OrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
    {
      _orderRepository = orderRepository;
      _bus = bus;
      _notifications = (DomainNotificationHandler)notifications;
    }

    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
      Order order;
      if (!request.IsValid()) NotifyValidationErrors(request);
      else
      {
        var number = await GenerateOrderNumber();
        order = CreateOrder(request.Name, request.Email, request.Phone, number, request.OrderProducts);

        await Commit();

        await _bus.RaiseEvent(new DomainNotification("EntityId", order.Id.ToString()));
      }

      return Unit.Value;
    }

    private async Task<int> GenerateOrderNumber()
    {
      var ordersDayCount = await _orderRepository.GetCountOrdersOfDay();
      var now = DateTime.Now;
      return Int32.Parse(now.ToString("yyMMdd") + ordersDayCount.ToString("D4"));
    }

    private Order CreateOrder(string name, string email, string phone, int number, IEnumerable<OrderProduct> products)
    {
      var order = new Order(name, email, phone, number, products);

      _orderRepository.Add(order);

      return order;
    }
  }
}
