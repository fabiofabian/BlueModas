using BlueModas.Domain.Core.Interfaces;
using BlueModas.Domain.Core.Notifications;
using BlueModas.Domain.Interfaces.Data;
using BlueModas.Domain.Interfaces.Repositories;

using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueModas.Domain.Commands
{
  public class ProductCommandHandler : CommandHandler, IRequestHandler<UpdateProductCommand>, IRequestHandler<RemoveProductCommand>
  {
    private readonly IMediatorHandler _bus;
    private readonly DomainNotificationHandler _notifications;
    private readonly IProductRepository _productRepository;

    public ProductCommandHandler(IProductRepository productRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
    {
      _productRepository = productRepository;
      _bus = bus;
      _notifications = (DomainNotificationHandler)notifications;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
      if (!request.IsValid()) NotifyValidationErrors(request);
      else
      {
        await UpdateProduct(request.IdProduct, request.Name, request.Description);
      }

      await Commit(_notifications.HasNotifications());     

      return Unit.Value;
    }

    public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
      if (!request.IsValid()) NotifyValidationErrors(request);
      else
      {
        await RemoveProduct(request.IdProduct);
      }

      await Commit(_notifications.HasNotifications());

      return Unit.Value;
    }

    private async Task UpdateProduct(Guid idProduct, string name, string description)
    {
      var product = await _productRepository.GetById(idProduct);

      product.Name = name;
      product.Description = description;

      _productRepository.Update(product);
    }

    private async Task RemoveProduct(Guid idProduct)
    {
      var product = await _productRepository.GetById(idProduct);

      _productRepository.Remove(product);
    }
  }
}
