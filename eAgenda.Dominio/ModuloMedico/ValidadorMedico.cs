using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.Dominio.ModuloMedico;
using FluentValidation;
using FluentValidation.Validators;

namespace eAgenda.Dominio.ModuloAtividade
{

    public class ValidadorMedico : AbstractValidator<Medico>
    {
        public ValidadorMedico()
        {
            RuleFor(x => x.CRM)
                   .NotNull().NotEmpty();


            RuleFor(x => x.EmAtividade)
                   .NotNull().NotEmpty();


            RuleFor(x => x.Nome).NotNull().NotEmpty();
        }
    }
}
