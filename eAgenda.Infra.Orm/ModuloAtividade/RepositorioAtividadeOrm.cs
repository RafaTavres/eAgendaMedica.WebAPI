using eAgenda.Dominio.ModuloAtividade;
using eAgendaMedica.Dominio;
using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaMedica.Infra.Orm.ModuloAtividade
{
    public class RepositorioAtividadeOrm : RepositorioBase<Atividade>, IRepositorioAtividade
    {
        public RepositorioAtividadeOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        
    }
}
