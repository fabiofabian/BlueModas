using BlueModas.Domain.Commands;
using BlueModas.Domain.Core.Validations;
using FluentValidation;

namespace BlueModas.Domain.Validations
{
  public class CreateOrderValidation : CommandValidation<CreateOrderCommand>
  {
    public CreateOrderValidation()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage("É necessário inserir um nome válido");
      RuleFor(x => x.Email).NotEmpty().WithMessage("É necessário inserir um email válido");
      RuleFor(x => x.Phone).NotEmpty().WithMessage("É necessário inserir um telefone válido");
    }
  }
}
