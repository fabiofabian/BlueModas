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
  public class ProductController : ApiBaseController
  {
    private readonly IProductService _productService;

    public ProductController(IProductService productService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
    {
      _productService = productService;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Response(_productService.GetProducts());
    }

    [HttpGet("{idProduct}")]
    public async Task<IActionResult> Get(Guid idProduct)
    { 
      try
      {
        return Response(await _productService.GetById(idProduct));
      }
      catch (Exception ex)
      {
        return HandleException(ex);
      }
      
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductViewModel productViewModel)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          NotifyModelStateErrors();
          return Response();
        }

        await _productService.Update(productViewModel);

        return Response();
      }
      catch (Exception ex)
      {
        return HandleException(ex);
      }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid idProduct)
    {
      try
      {
        await _productService.Delete(idProduct);

        return Response();
      }
      catch (Exception ex)
      {
        return HandleException(ex);
      }
    }
  }
}
