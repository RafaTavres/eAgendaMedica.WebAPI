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
    }
}