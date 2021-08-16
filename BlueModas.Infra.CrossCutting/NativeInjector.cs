using BlueModas.Application.Interfaces;
using BlueModas.Application.Services;
using BlueModas.Domain.Commands;
using BlueModas.Domain.Core.Interfaces;
using BlueModas.Domain.Core.Notifications;
using BlueModas.Domain.Interfaces.Data;
using BlueModas.Domain.Interfaces.Repositories;
using BlueModas.Infra.CrossCutting.Bus;
using BlueModas.Infra.Data.Configuration;
using BlueModas.Infra.Data.Context;
using BlueModas.Infra.Data.EventSourcing;
using BlueModas.Infra.Data.Repositories;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace BlueModas.Infra.CrossCutting.IoC
{
  public class NativeInjector
  {
    public static void RegisterAppServices(IServiceCollection services)
    {
      //services.AddSingleton<IHttpContextAcessor, HttpContextAcessor>();

      services.AddDbContext<BlueModasContext>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      // Domain Bus (Mediator)
      services.AddScoped<IMediatorHandler, InMemoryBus>();

      // Infra - Data EventSourcing
      services.AddScoped<IEventStore, EventStore>();

      // Domain - Events
      services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

      // Domain - Commands

      services.AddScoped<IRequestHandler<UpdateProductCommand, Unit>, ProductCommandHandler>();
      services.AddScoped<IRequestHandler<RemoveProductCommand, Unit>, ProductCommandHandler>();
      services.AddScoped<IRequestHandler<CreateOrderCommand, Unit>, OrderCommandHandler>();

      //Services
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<IOrderService, OrderService>();

      //Repos
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<IOrderRepository, OrderRepository>();
    }
  }
}
