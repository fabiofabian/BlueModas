using BlueModas.Application.Interfaces;
using BlueModas.Application.ViewModels;
using BlueModas.Domain.Core.Interfaces;
using BlueModas.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlueModas.Presentation.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OrderController : ApiBaseController
  {
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
    {
      _orderService = orderService;
    }

    [HttpGet]   
    public async Task<IActionResult> Get(Guid id)
    { 
      try
      {
        return Response(await _orderService.GetById(id));
      }
      catch (Exception ex)
      {
        return HandleException(ex);
      }      
    }

    [HttpPost]
    public async Task<IActionResult> Post(OrderViewModel orderViewModel)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          NotifyModelStateErrors();
          return Response();
        }

        await _orderService.Create(orderViewModel);

        return Response();
      }
      catch (Exception ex)
      {
        return HandleException(ex);
      }
    }
    
  }
}
