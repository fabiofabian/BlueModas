using System;
using System.Collections.Generic;

namespace BlueModas.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public IEnumerable<ProductVariantViewModel> Variants { get; set; }
    }
}
