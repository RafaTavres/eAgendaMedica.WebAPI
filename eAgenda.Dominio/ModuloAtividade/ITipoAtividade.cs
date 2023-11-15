using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaMedica.Dominio.ModuloAtividade
{
    public interface ITipoAtividade
    {
        public string Assunto { get; set; }
        public TimeSpan TempoDeDescanso { get; set; }
    }
}
