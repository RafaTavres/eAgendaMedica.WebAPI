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
    }
}