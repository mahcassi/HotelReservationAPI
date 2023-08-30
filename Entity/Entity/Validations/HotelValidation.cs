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
    public class HotelValidation : AbstractValidator<Hotel>
    {
        public HotelValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            //RuleFor(f => f.CNPJ.Length).Equal(CnpjValidacao.TamanhoCnpj)
            //        .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            //RuleFor(f => CnpjValidacao.Validar(f.CNPJ)).Equal(true)
            //    .WithMessage("O documento fornecido é inválido.");
        }
    }
}
