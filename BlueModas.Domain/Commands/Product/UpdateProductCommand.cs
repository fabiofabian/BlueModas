using BlueModas.Domain.Core.Commands;
using BlueModas.Domain.Validations;
using System;

namespace BlueModas.Domain.Commands
{
  public class UpdateProductCommand : Command
  {
    public UpdateProductCommand() { }

    public Guid IdProduct { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override bool IsValid()
    {
      ValidationResult = new UpdateProductValidation().Validate(this);
      return ValidationResult.IsValid;
    }

  }
}
