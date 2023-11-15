using eAgendaMedica.Dominio.ModuloMedico;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CRMGeneratorTest()
        {
            var e = CRM.NewCRM("PB");

            var er = e;

            var err = er;

            Assert.AreEqual(2,e.);
        }
    }
}