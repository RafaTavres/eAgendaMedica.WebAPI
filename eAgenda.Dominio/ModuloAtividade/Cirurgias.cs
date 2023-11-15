using eAgendaMedica.Dominio.ModuloMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaMedica.Dominio.ModuloAtividade
{
    public class Cirurgias : ITipoAtividade
    {
        public string Assunto { get; set; }
        public List<Medico> Medicos { get; set; }
        public TimeSpan TempoDeDescanso { get; set; }

        public Cirurgias(string a, List<Medico> m)
        {
            Assunto = a;
            Medicos = m;
            TempoDeDescanso = new TimeSpan(40000);

        }
    }
}
