using eAgendaMedica.Dominio;
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
                   .NotNull().NotEmpty().CRM();

            RuleFor(x => x.Nome).NotNull().NotEmpty();
        }
    }
}
