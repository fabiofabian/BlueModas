using BlueModas.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace BlueModas.Infra.Data.Mappings
{
  public class ProductVariantMap : IEntityTypeConfiguration<ProductVariant>
  {
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Description).IsRequired();
      builder.Property(x => x.Price).IsRequired();
      builder.Property(x => x.Quantity).IsRequired();
      builder.Property(x => x.CreatedAt).IsRequired();
      builder.Property(x => x.UpdatedAt).IsRequired();
      
      //builder.HasMany(x => x.Images).WithOne().HasForeignKey(x => x.ProductVariantId);

      builder.HasData(
          new ProductVariant
          {
            Id = Guid.Parse("7f7204b0-2a23-4c62-9ea1-6b4fe603f29d"),
            ProductId = Guid.Parse("2debc054-b480-470d-a1d6-07106a705c61"),
            Description = "Azul",
            Price = 24.99M,
            Quantity = 15,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new ProductVariant
          {
            Id = Guid.Parse("42c79dc8-34eb-4f4d-9872-7e3b712b7e4d"),
            ProductId = Guid.Parse("829df3f6-2641-421e-a0de-e9f757337bc6"),
            Description = "Azul",
            Price = 59.99M,
            Quantity = 15,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          }
      );
    }
  }
}
