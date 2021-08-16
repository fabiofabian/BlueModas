﻿using System;

namespace BlueModas.Domain.Models
{
  public class OrderProduct
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        //public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
