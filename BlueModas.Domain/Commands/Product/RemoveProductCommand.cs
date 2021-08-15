using BlueModas.Domain.Core.Commands;
using BlueModas.Domain.Validations;
using System;

namespace BlueModas.Domain.Commands
{
  public class RemoveProductCommand : Command
  {
    public RemoveProductCommand() { }

    public Guid IdProduct { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public override bool IsValid()
    {
      ValidationResult = new RemoveProductValidation().Validate(this);
      return ValidationResult.IsValid;
    }

  }
}
