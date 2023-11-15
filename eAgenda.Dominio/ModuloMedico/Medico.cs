using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloAtividade;
using Microsoft.Win32;
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
            Atividades = new List<Atividade>();
        }

        public Medico(string c,string n, bool ea)
        {
            CRM = c;
            Nome = n;
            EmAtividade = ea;
            HorasOcupadas = new List<HoraOcupada>();
            Atividades = new List<Atividade>();
        }

        public string CRM { get; set; }
        public string Nome { get; set; }
        public bool EmAtividade { get; set; }
        public List<HoraOcupada> HorasOcupadas { get; set; }
        public List<Atividade> Atividades { get; set; }

        public override void Atualizar(Medico registro)
        {
            Id = registro.Id;
            CRM = registro.CRM;
            Nome = registro.Nome;
            EmAtividade= registro.EmAtividade;
            HorasOcupadas = registro.HorasOcupadas;
            Atividades = registro.Atividades;
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
                  HorasOcupadas == medico.HorasOcupadas &&
                  Atividades == medico.Atividades;

        }
        public override string? ToString()
        {
            return "CRM: " + CRM + " - Medico:  " + Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CRM, Nome, EmAtividade,HorasOcupadas,Atividades);
        }

        public void AdicionarHorario(DateTime diaDaAtiviadade,TimeSpan horarioInicio,TimeSpan horarioFinal)
        {
            HoraOcupada horas = new HoraOcupada(diaDaAtiviadade,horarioInicio,horarioFinal);
            if(VerificarHorarioLivre(horas) == true)
                HorasOcupadas.Add(horas);
        }

        public void AdicionarHorario(HoraOcupada horas)
        {
            if (VerificarHorarioLivre(horas) == true)
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
