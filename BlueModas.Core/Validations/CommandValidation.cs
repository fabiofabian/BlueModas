using BlueModas.Domain.Core.Commands;
using FluentValidation;

namespace BlueModas.Domain.Core.Validations
{
  public class CommandValidation<Command> : AbstractValidator<Command>
  {
  }
}
