using BlueModas.Domain.Commands;
using BlueModas.Domain.Core.Validations;
using FluentValidation;

namespace BlueModas.Domain.Validations
{
  public class UpdateProductValidation : CommandValidation<UpdateProductCommand>
  {
    public UpdateProductValidation()
    {
      RuleFor(x => x.IdProduct).NotEmpty().WithMessage("É necessário selecionar um produto válido");
      RuleFor(x => x.Name).NotEmpty().WithMessage("É necessário inserir um nome de produto válido");
      RuleFor(x => x.Description).NotEmpty().WithMessage("É necessário inserir uma descrição de produto válido");
    }
  }
}
