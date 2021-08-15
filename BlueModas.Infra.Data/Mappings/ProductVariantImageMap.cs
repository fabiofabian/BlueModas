using BlueModas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BlueModas.Infra.Data.Mappings
{
    public class ProductVariantImageMap : IEntityTypeConfiguration<ProductVariantImage>
    {
        public void Configure(EntityTypeBuilder<ProductVariantImage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductVariantId).IsRequired();
            builder.Property(x => x.Location).IsRequired();

            builder.HasData(
                new ProductVariantImage
                {
                    Id = Guid.Parse("940b1a36-0fa2-40a6-b425-bd25144c82c2"),
                    ProductVariantId = Guid.Parse("7f7204b0-2a23-4c62-9ea1-6b4fe603f29d"),
                    Location = "/images/products/image1.jpg"
                },
                new ProductVariantImage
                {
                    Id = Guid.Parse("5398c5c5-4de2-4c15-8c27-4bfdf65fcd57"),
                    ProductVariantId = Guid.Parse("42c79dc8-34eb-4f4d-9872-7e3b712b7e4d"),
                    Location = "/images/products/image1.jpg"
                }
            );
        }
    }
}
