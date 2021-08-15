using System;
using BlueModas.Domain.Core.Models;
using BlueModas.Domain.Interfaces.Data;
using BlueModas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BlueModas.Infra.Data.Configuration
{
  public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly BlueModasContext _dbcontext;
        protected readonly DbSet<T> DbSet;

        public Repository(BlueModasContext dbcontext)
        {
            _dbcontext = dbcontext;
            DbSet = _dbcontext.Set<T>();
        }

        public void Add(T obj)
        {
            obj.CreatedAt = DateTime.Now;
            DbSet.Add(obj);
        }

        public void Update(T obj)
        {
            obj.UpdatedAt = DateTime.Now;
            DbSet.Update(obj);
        }

        public void Remove(T obj)
        {
            DbSet.Remove(obj);
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
