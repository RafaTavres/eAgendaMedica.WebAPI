using eAgenda.Dominio.ModuloAtividade;
using eAgendaMedica.Aplicacao.ModuloMedico;
using eAgendaMedica.Dominio;
using eAgendaMedica.Infra.Orm;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.WebApi.Config
{
    public static class InjecaoDependenciaConfigExtension
    {
        public static void ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<IContextoPersistencia, eAgendaMedicaDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            services.AddTransient<IRepositorioMedico, IRepositorioMedico>();
            services.AddTransient<ServicoMedico>();


        }
    }
}