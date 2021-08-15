using BlueModas.Domain.Commands;
using BlueModas.Domain.Core.Validations;
using FluentValidation;

namespace BlueModas.Domain.Validations
{
  public class RemoveProductValidation : CommandValidation<RemoveProductCommand>
  {
    public RemoveProductValidation()
    {
      RuleFor(x => x.IdProduct).NotEmpty().WithMessage("É necessário selecionar um produto válido");
    }
  }
}
