using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloAtividade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaMedica.Dominio.ModuloMedico
{
    public class Medico : EntidadeBase<Medico>
    {
        public Medico()
        {
        }

        public Medico(CRM d,string n,bool ea)
        {
            CRM = d;
            Nome = n;
            EmAtividade = ea;
        }

        public CRM CRM { get; set; }
        public string Nome { get; set; }
        public bool EmAtividade { get; set; }

        public override void Atualizar(Medico registro)
        {
            Id = registro.Id;
            CRM = registro.CRM;
            Nome = registro.Nome;
            EmAtividade= registro.EmAtividade;
        }
    }
}
