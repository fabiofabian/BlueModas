using AutoMapper;
using BlueModas.Application.ViewModels;
using BlueModas.Domain.Interfaces.Repositories;
using BlueModas.Domain.Models;
using BlueModas.Infra.Data.Configuration;
using BlueModas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModas.Infra.Data.Repositories
{
  public class ProductRepository : Repository<Product>, IProductRepository
  {
    protected BlueModasContext _context;
    protected IMapper _mapper;

    public ProductRepository(BlueModasContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }
    
    public async Task<Product> GetById(Guid id)
    {
      return await _context.Set<Product>().FirstAsync(x => x.Id == id);
    }

    public IEnumerable<Product> GetProducts()
    {
      return _context.Set<Product>();
    }
  }
}
