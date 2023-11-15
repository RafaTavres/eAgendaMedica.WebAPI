using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloAtividade;
using System;
using System.Collections.Generic;

namespace eAgendaMedica.Dominio.ModuloAtividade
{
    public class Atividade : EntidadeBase<Atividade>
    {
        public Atividade()
        {
        }

        public Atividade(DateTime d, DateTime hi, DateTime ht, bool f,ITipoAtividade t)
        {
            DataRealizacao = d;
            HoraInicio = hi;
            HoraTermino = ht;
            Finalizada = f;
            TipoAtividade = t;
        }

        public DateTime DataRealizacao { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraTermino { get; set; }
        public bool Finalizada { get; set; }

        public ITipoAtividade TipoAtividade { get; set; }

        public override void Atualizar(Atividade registro)
        {
            Id = registro.Id;
            DataRealizacao = registro.DataRealizacao;
            HoraInicio = registro.HoraInicio;
            HoraTermino = registro.HoraTermino;
            Finalizada = registro.Finalizada;
            TipoAtividade = registro.TipoAtividade;
        }

        public Atividade Clonar()
        {
            return MemberwiseClone() as Atividade;
        }

        public override bool Equals(object? obj)
        {
            return obj is Atividade atividade &&
                  Id == atividade.Id &&
                  DataRealizacao == atividade.DataRealizacao &&
                  HoraInicio == atividade.HoraInicio &&
                  HoraTermino == atividade.HoraTermino &&
                  Finalizada == atividade.Finalizada &&
                  TipoAtividade == atividade.TipoAtividade;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, DataRealizacao, HoraInicio, HoraTermino, Finalizada, TipoAtividade);
        }

        public override string? ToString()
        {
            return " - " + TipoAtividade.Assunto + " - Data:  "+ DataRealizacao.ToString("d");
        }
    }
}
