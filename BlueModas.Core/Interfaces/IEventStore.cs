

using BlueModas.Domain.Core.Events;

namespace BlueModas.Domain.Core.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
