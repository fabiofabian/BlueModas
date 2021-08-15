using BlueModas.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace BlueModas.Infra.Data.Mappings
{
  public class ProductImageMap : IEntityTypeConfiguration<ProductImage>
  {
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Location).IsRequired();

      //builder.HasOne(x => x.ProductVariant).WithMany().HasForeignKey(x => x.ProductVariantId);

      builder.HasData(
          new ProductImage
          {
            Id = Guid.Parse("940b1a36-0fa2-40a6-b425-bd25144c82c2"),
            ProductId = Guid.Parse("2debc054-b480-470d-a1d6-07106a705c61"),
            Location = "/images/products/image1.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          },
          new ProductImage
          {
            Id = Guid.Parse("5398c5c5-4de2-4c15-8c27-4bfdf65fcd57"),
            ProductId = Guid.Parse("829df3f6-2641-421e-a0de-e9f757337bc6"),
            Location = "/images/products/image1.jpg",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
          }
      ); ;
    }
  }
}
