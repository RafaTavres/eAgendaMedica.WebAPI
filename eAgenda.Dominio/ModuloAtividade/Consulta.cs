using eAgendaMedica.Dominio.ModuloMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaMedica.Dominio.ModuloAtividade
{
    public class Consulta : ITipoAtividade
    {
        public string Assunto { get; set; }
        public Medico Medico { get; set; }

        public TimeSpan TempoDeDescanso { get; set; }

        public Consulta(string a,Medico m)
        {
            Assunto = a;
            Medico = m;
            TempoDeDescanso = new TimeSpan(2000);
              
        }
    }
}
