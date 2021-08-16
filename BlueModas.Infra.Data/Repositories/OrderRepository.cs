using AutoMapper;
using BlueModas.Application.ViewModels;
using BlueModas.Domain.Interfaces.Repositories;
using BlueModas.Domain.Models;
using BlueModas.Infra.Data.Configuration;
using BlueModas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Infra.Data.Repositories
{
  public class OrderRepository : Repository<Order>, IOrderRepository
  {
    protected BlueModasContext _context;
    protected IMapper _mapper;

    public OrderRepository(BlueModasContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<Order> GetById(Guid id)
    {
      return await _context.Set<Order>()
        .Include(x => x.OrderProducts)
        .ThenInclude(x => x.Product)
        .FirstAsync(x => x.Id == id);
    }

    public async Task<int> GetCountOrdersOfDay()
    {
      var initialDate = DateTime.Today;
      var finalDate = DateTime.Today.AddDays(1).AddSeconds(-1);
      return await _context.Set<Order>().Where(x => x.CreatedAt >= initialDate && x.CreatedAt <= finalDate).CountAsync();
    }
  }
}
