using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.Dominio.ModuloMedico;
using System;
using System.Collections.Generic;

namespace eAgendaMedica.Dominio.ModuloAtividade
{
    public class Atividade : EntidadeBase<Atividade>
    {
        public Atividade()
        {
            Medicos = new List<Medico>();
            AtribuirAtividade();
        }

        public Atividade(DateTime d, TimeSpan hi, TimeSpan ht, bool f,TipoAtividade t,string a)
        {
            DataRealizacao = d;
            HoraInicio = hi;
            HoraTermino = ht;
            Finalizada = f;
            TipoAtividade = t;
            Assunto = a;
            Medicos = new List<Medico>();
            TempoDeDescanso = t.TempoDeDescanso;
            AtribuirAtividade();
        }

        public string Assunto { get; set; }
        public DateTime DataRealizacao { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public bool Finalizada { get; set; }
        public List<Medico> Medicos { get; set; }  
        private TipoAtividade TipoAtividade { get; set; }
        public TipoAtividadeEnum TipoAtividadeEnum { get; set; }
        public TimeSpan TempoDeDescanso { get; set; }

        public override void Atualizar(Atividade registro)
        {
            Id = registro.Id;
            DataRealizacao = registro.DataRealizacao;
            HoraInicio = registro.HoraInicio;
            HoraTermino = registro.HoraTermino;
            Finalizada = registro.Finalizada;
            TipoAtividadeEnum = registro.TipoAtividadeEnum;
            Assunto = registro.Assunto;
            Medicos = registro.Medicos;
        }

        public void AdicionarMedico(Medico medico)
        {
            Medicos.Add(medico);
        }

        public Atividade Clonar()
        {
            return MemberwiseClone() as Atividade;
        }

        public void AtribuirAtividade()
        {
            if(TipoAtividadeEnum == TipoAtividadeEnum.Cirurgia)
                TipoAtividade = new Cirurgias();
            else
                TipoAtividade = new Consulta();
        }


        public override bool Equals(object? obj)
        {
            return obj is Atividade atividade &&
                  Id == atividade.Id &&
                  DataRealizacao == atividade.DataRealizacao &&
                  HoraInicio == atividade.HoraInicio &&
                  HoraTermino == atividade.HoraTermino &&
                  Finalizada == atividade.Finalizada &&
                  TipoAtividadeEnum == atividade.TipoAtividadeEnum &&
                  Assunto == atividade.Assunto &&
                  Medicos == atividade.Medicos;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, DataRealizacao, HoraInicio, HoraTermino, Finalizada, TipoAtividadeEnum, Assunto,Medicos);
        }

        public override string? ToString()
        {
            return " - " + Assunto + " - Data:  "+ DataRealizacao.ToString("d");
        }
    }
}
