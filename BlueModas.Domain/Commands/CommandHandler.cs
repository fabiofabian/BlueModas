﻿using BlueModas.Domain.Core.Commands;
using BlueModas.Domain.Core.Interfaces;
using BlueModas.Domain.Core.Notifications;
using BlueModas.Domain.Interfaces.Data;
using MediatR;
using System.Threading.Tasks;

namespace BlueModas.Domain.Commands
{
  public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public async Task<bool> Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (await _uow.Commit()) return true;

            await _bus.RaiseEvent(new DomainNotification("Commit", "Problemas ao gravar os dados"));

            return false;
        }

        public async Task<bool> Commit(bool ignoreNotification = false)
        {
            if ((!ignoreNotification && _notifications.HasNotifications())) return false;
            if (await _uow.Commit()) return true;

            await _bus.RaiseEvent(new DomainNotification("Commit", "Problemas ao gravar os dados"));

            return false;
        }
    }
}