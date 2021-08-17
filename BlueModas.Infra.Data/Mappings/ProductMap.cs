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
      builder.Property(x => x.Price).IsRequired();
      builder.Property(x => x.CreatedAt).IsRequired();
      builder.Property(x => x.UpdatedAt).IsRequired();
      builder.Property(x => x.Active).IsRequired().HasDefaultValue(true);

      builder.HasData(
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Blusa de lã",
            Price = 49.99M,
            ImagePath = "assets/images/image1.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },          
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Jaqueta de couro",
            Price = 159.99M,
            ImagePath = "assets/images/image2.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Blusa moletom",
            Price = 39.99M,
            ImagePath = "assets/images/image3.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Gorro para catioro",
            Price = 24.99M,
            ImagePath = "assets/images/image4.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Camiseta branca",
            Price = 19.99M,
            ImagePath = "assets/images/image5.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Calça jeans",
            Price = 69.99M,
            ImagePath = "assets/images/image6.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Vestido vermelho",
            Price = 49.99M,
            ImagePath = "assets/images/image7.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Camisa",
            Price = 54.99M,
            ImagePath = "assets/images/image8.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Jaqueta jeans",
            Price = 89.99M,
            ImagePath = "assets/images/image9.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Camiseta de manga longa",
            Price = 25.00M,
            ImagePath = "assets/images/image10.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Jaqueta de couro",
            Price = 190.00M,
            ImagePath = "assets/images/image11.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new Product
          {
            Id = Guid.NewGuid(),
            Name = "Vestido floral",
            Price = 59.99M,
            ImagePath = "assets/images/image12.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          }
      );
    }
  }
}
