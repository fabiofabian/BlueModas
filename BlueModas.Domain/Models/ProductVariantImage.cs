using System;

namespace BlueModas.Domain.Models
{
  public class ProductVariantImage
    {
        public Guid Id { get; set; }
        public Guid ProductVariantId { get; set; }
        public string Location { get; set; }

        //public ProductVariant ProductVariant { get; set; }

    }
}
