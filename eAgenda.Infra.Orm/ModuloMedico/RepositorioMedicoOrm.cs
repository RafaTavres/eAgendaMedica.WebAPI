using eAgenda.Dominio.ModuloAtividade;
using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.Dominio;
using eAgendaMedica.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Infra.Orm.ModuloMedico
{
    public class RepositorioMedicoOrm : RepositorioBase<Medico>, IRepositorioMedico
    {
        public RepositorioMedicoOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }


    }
}
