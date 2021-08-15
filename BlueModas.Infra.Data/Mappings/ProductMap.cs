using BlueModas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BlueModas.Infra.Data.Mappings
{
  public class ProductMap : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Name).IsRequired();
      builder.Property(x => x.Description).IsRequired();
      builder.Property(x => x.CreatedAt).IsRequired();
      builder.Property(x => x.UpdatedAt).IsRequired();

      //builder.HasMany(x => x.Variants).WithOne().HasForeignKey(x => x.ProductId);
      builder.HasMany(x => x.Images).WithOne().HasForeignKey(x => x.ProductId);

      builder.HasData(
          new Product
          {
            Id = Guid.Parse("2debc054-b480-470d-a1d6-07106a705c61"),
            Name = "Camiseta Branca",
            Description = "Camiseta de algodão macio",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.Parse("829df3f6-2641-421e-a0de-e9f757337bc6"),
            Name = "Blusa Azul",
            Description = "Blusa de algodão macio",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          }
      );
    }
  }
}
