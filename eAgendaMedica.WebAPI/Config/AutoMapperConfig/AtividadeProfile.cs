using AutoMapper;
using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.WebAPI.ViewModels.ModuloAtividade;

namespace eAgendaMedica.WebAPI.Config.AutoMapperConfig
{
    public class AtividadeProfile : Profile
    {
        public AtividadeProfile() 
        {
            CreateMap<Atividade, ListarAtividadeViewModel>();

            CreateMap<FormAtividadeViewModel,Atividade>();
        }
    }
}
