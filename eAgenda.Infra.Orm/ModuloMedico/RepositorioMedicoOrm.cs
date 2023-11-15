
using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.Dominio;
using eAgendaMedica.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAgendaMedica.Dominio.ModuloMedico;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.Infra.Orm.ModuloMedico
{
    public class RepositorioMedicoOrm : RepositorioBase<Medico>, IRepositorioMedico
    {
        public RepositorioMedicoOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public override Medico SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.HorasOcupadas)
                .SingleOrDefault(x => x.Id == id);
        }
    }
}
