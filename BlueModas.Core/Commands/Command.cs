using BlueModas.Domain.Core.Events;
using FluentValidation.Results;
using System;

namespace BlueModas.Domain.Core.Commands
{
  public abstract class Command : Message
  {
    public Guid? UsuarioRequerenteId { get; set; }
    public DateTime Timestamp { get; set; }
    public ValidationResult ValidationResult { get; set; }

    protected Command() => Timestamp = DateTime.Now;

    public abstract bool IsValid();

  }
}
