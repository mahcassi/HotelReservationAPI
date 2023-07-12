using Entity.Entity;
using Entity.Validations.Documentos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Validations
{
    public class RoomValidation : AbstractValidator<Room>
    {
        public RoomValidation()
        {
            RuleFor(f => f.Price)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.Size)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

             RuleFor(f => f.Availability)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        }
    }
}
