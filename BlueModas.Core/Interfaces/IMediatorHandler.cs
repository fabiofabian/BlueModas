
using BlueModas.Domain.Core.Commands;
using BlueModas.Domain.Core.Events;

using System.Threading.Tasks;

namespace BlueModas.Domain.Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
