using MediatR;
using System;

namespace BlueModas.Domain.Core.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event() => Timestamp = DateTime.Now;
    }
}
