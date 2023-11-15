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
            HorasOcupadas = new List<HoraOcupada>();
        }

        public Medico(string c,string n, bool ea)
        {
            CRM = c;
            Nome = n;
            EmAtividade = ea;
            HorasOcupadas = new List<HoraOcupada>();
        }

        public string CRM { get; set; }
        public string Nome { get; set; }
        public bool EmAtividade { get; set; }
        private List<HoraOcupada> HorasOcupadas { get; set; }

        public override void Atualizar(Medico registro)
        {
            Id = registro.Id;
            CRM = registro.CRM;
            Nome = registro.Nome;
            EmAtividade= registro.EmAtividade;
            HorasOcupadas = registro.HorasOcupadas;
        }

        public Medico Clonar()
        {
            return MemberwiseClone() as Medico;
        }

        public override bool Equals(object? obj)
        {
            return obj is Medico medico &&
                  Id == medico.Id &&
                  CRM == medico.CRM &&
                  Nome == medico.Nome &&
                  EmAtividade == medico.EmAtividade &&
                  HorasOcupadas == HorasOcupadas;

        }
        public override string? ToString()
        {
            return "CRM: " + CRM + " - Medico:  " + Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CRM, Nome, EmAtividade);
        }

        public void AdicionarHorario(DateTime diaDaAtiviadade,TimeSpan horarioInicio,TimeSpan horarioFinal)
        {
            HoraOcupada horas = new HoraOcupada(diaDaAtiviadade,horarioInicio,horarioFinal);
            HorasOcupadas.Add(horas);
        }

        public void AdicionarHorario(HoraOcupada horas)
        {
            HorasOcupadas.Add(horas);
        }

        public bool VerificarHorarioLivre(HoraOcupada horario)
        {
            foreach (var h in HorasOcupadas)
            {
                if (h.Equals(horario))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
