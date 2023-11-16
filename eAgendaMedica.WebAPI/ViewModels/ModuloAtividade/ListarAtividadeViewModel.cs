﻿using eAgendaMedica.Dominio.ModuloAtividade;

namespace eAgendaMedica.WebAPI.ViewModels.ModuloAtividade
{
    public class ListarAtividadeViewModel
    {
        public string Assunto { get; set; }
        public DateTime DataRealizacao { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public string TempoDeDescanso { get; set; }
    }
}