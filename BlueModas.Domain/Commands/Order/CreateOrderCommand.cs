using BlueModas.Domain.Core.Commands;
using BlueModas.Domain.Models;
using BlueModas.Domain.Validations;
using System;
using System.Collections.Generic;

namespace BlueModas.Domain.Commands
{
  public class CreateOrderCommand : Command
  {
    public CreateOrderCommand() { }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public IEnumerable<OrderProduct> OrderProducts { get; set; }

    public override bool IsValid()
    {
      ValidationResult = new CreateOrderValidation().Validate(this);
      return ValidationResult.IsValid;
    }

  }
}
