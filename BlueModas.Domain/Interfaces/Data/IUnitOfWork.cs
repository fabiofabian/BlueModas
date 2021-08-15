using System;
using System.Threading.Tasks;

namespace BlueModas.Domain.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
