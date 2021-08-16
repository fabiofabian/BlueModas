using BlueModas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BlueModas.Infra.Data.Mappings
{
  public class OrderMap : IEntityTypeConfiguration<Order>
  {
    public void Configure(EntityTypeBuilder<Order> builder)
    {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Name).IsRequired();    
      builder.Property(x => x.Email).IsRequired();    
      builder.Property(x => x.Phone).IsRequired();

      builder.HasMany(x => x.OrderProducts).WithOne().HasForeignKey(x => x.OrderId);
    }
  }
}
