using eAgendaMedica.Dominio.ModuloMedico;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.Infra.Orm.Test.ModuloMedico
{
    [TestClass]
    public class RepositorioMedicoOrmTest
    {
        private readonly eAgendaMedicaDbContext db;

        public RepositorioMedicoOrmTest()
        {
            var builder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            builder.UseSqlServer(@"Data Source=(LOCALDB)\MSSQLLOCALDB;Initial Catalog=eAgendaMedicaOrmTest;Integrated Security=True");

            db = new eAgendaMedicaDbContext(builder.Options);

            db.Set<Medico>().RemoveRange(db.Set<Medico>());

            db.SaveChanges();
        }

        [TestMethod]
        public void Deve_inserir_tarefa()
        {
          
        }
    }
}