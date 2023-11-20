using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Dominio.Test.ModuloMedico
{
    [TestClass]
    public class MedicoTest
    {
        [TestMethod]
        public void Medico_Nao_Deve_Ter_Dois_Horarios_Iguais()
        {
            //arrange
            var t = new Medico();
            HoraOcupada hora = new HoraOcupada(DateTime.UtcNow, new TimeSpan(3000), new TimeSpan(4000));
            t.AdicionarHorario(hora);

            //action
            var resultado = t.VerificarHorarioLivre(hora);

            //assert
            Assert.AreEqual(false, resultado);
        }

        [TestMethod]
        public void Medico_Deve_inserir_uma_atividade()
        {
            //arrange
            var t = new Medico();
            Atividade atividade = new Atividade();
            atividade.DataRealizacao = DateTime.UtcNow;
            atividade.HoraInicio = new TimeSpan(1000);
            atividade.HoraTermino = new TimeSpan(2000);
            t.AdicionarAtividade(atividade);

            //action
            var resultado = t.Atividades.Count();

            //assert
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void Medico_calcular_suas_horas_de_trabalho()
        {
            //arrange
            var t = new Medico();
            t.AdicionarHorario(DateTime.UtcNow.AddMinutes(10), new TimeSpan(1000), new TimeSpan(2000));
            t.AdicionarHorario(DateTime.UtcNow.AddDays(3), new TimeSpan(1000), new TimeSpan(2000));
            
            //action
            var resultado = t.CalcularHorasOcupadas(DateTime.UtcNow, DateTime.UtcNow.AddDays(1));

            //assert
            Assert.AreEqual(new TimeSpan(1000), resultado);
        }
    }
}