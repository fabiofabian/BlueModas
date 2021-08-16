using BlueModas.Domain.Core.Interfaces;
using BlueModas.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueModas.Presentation
{
  public abstract class ApiBaseController : ControllerBase
  {

    private readonly DomainNotificationHandler _notifications;
    private readonly IMediatorHandler _mediator;

    protected ApiBaseController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator)
    {
      _notifications = (DomainNotificationHandler)notifications;
      _mediator = mediator;
    }

    protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

    protected bool HasIdNotification()
    {
      return (_notifications.HasEntityNotifications());
    }

    protected bool IsValidOperation()
    {
      return (!_notifications.HasNotifications());
    }

    protected new IActionResult Response(object result = null)
    {
      if (IsValidOperation())
      {
        if (HasIdNotification())
        {
          return Ok(new
          {
            success = true,
            data = new { Id = _notifications.GetNotifications().FirstOrDefault(x => x.Key == "EntityId").Value }
          });
        } else
        {
          return Ok(new
          {
            success = true,
            data = result
          });
        }
      }

      return Ok(new
      {
        success = false,
        errors = _notifications.GetNotifications().Select(n => n.Value)
      });
    }

    protected void NotifyModelStateErrors()
    {
      var erros = ModelState.Values.SelectMany(v => v.Errors);
      foreach (var erro in erros)
      {
        var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
        NotifyError(string.Empty, erroMsg);
      }
    }

    protected void NotifyError(string code, string message)
    {
      _mediator.RaiseEvent(new DomainNotification(code, message));
    }

    protected void AddIdentityErrors(IdentityResult result)
    {
      foreach (var error in result.Errors)
      {
        NotifyError(result.ToString(), error.Description);
      }
    }

    //protected IActionResult HandleException(Exception ex)
    //{
    //    ex.Message.Split(';').ToList().ForEach(error =>
    //    {
    //        NotifyError("500", error);
    //    });

    //    return Error();
    //}

    private IActionResult Error()
    {
      return BadRequest(new
      {
        success = false,
        errors = _notifications.GetNotifications().Select(n => n.Value)
      });
    }

    protected IActionResult HandleException(Exception ex)
    {
      string actionName = this.ControllerContext.ActionDescriptor.ActionName;
      string controllerName = this.ControllerContext.ActionDescriptor.ControllerName;

      //ex.Message.Split(';').ToList().ForEach(error =>
      //{
      //  Log.Error(ex, "v1/{controllername:l}/{actionName:l} - {message:l}"
      //      , controllerName
      //      , actionName
      //      , ex.Message
      //      , ex.TargetSite
      //      , ex.StackTrace);
      //  NotifyError("500", error);
      //});

      return Error();
    }
  }
}
