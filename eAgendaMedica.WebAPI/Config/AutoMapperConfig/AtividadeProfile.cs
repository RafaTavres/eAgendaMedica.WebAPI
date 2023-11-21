using AutoMapper;
using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.WebAPI.ViewModels.ModuloAtividade;
using eAgendaMedica.WebAPI.ViewModels.ModuloMedico;

namespace eAgendaMedica.WebAPI.Config.AutoMapperConfig
{
    public class AtividadeProfile : Profile
    {
        public AtividadeProfile() 
        {
            CreateMap<Atividade, ListarAtividadeViewModel>();

            CreateMap<Atividade, VisualizarAtividadeViewModel>();

            CreateMap<FormAtividadeViewModel, Atividade>();

            CreateMap<InserirAtividadeViewModel, Atividade>()
                .ForMember(destino => destino.Medicos, opt => opt.Ignore())
                .AfterMap<InserirAtividadeMappingAction>();

        }
    }

    public class InserirAtividadeMappingAction : IMappingAction<InserirAtividadeViewModel, Atividade>
    {
        private readonly IRepositorioMedico repositorioMedico;
        public InserirAtividadeMappingAction(IRepositorioMedico repositorioMedico)
        {
            this.repositorioMedico = repositorioMedico;
        }
        public void Process(InserirAtividadeViewModel source, Atividade destination, ResolutionContext context)
        {
            var Medicos = repositorioMedico.SelecionarMuitos(source.IdsMedicos);

            foreach (var m in Medicos)
            {
                destination.AdicionarMedico(m);
            }
        }
    }
}
