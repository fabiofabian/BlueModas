using BlueModas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BlueModas.Infra.Data.Mappings
{
  public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
  {
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
      builder.HasKey(x => new { x.OrderId, x.ProductId});
      builder.Property(x => x.Quantity).IsRequired();    

      //builder.HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderId);
      builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);      
    }
  }
}
