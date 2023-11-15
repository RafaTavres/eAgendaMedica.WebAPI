using eAgendaMedica.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeradorTestes.Infra.Orm
{
    public class eAgendaMedicaDbContextFactory : IDesignTimeDbContextFactory<eAgendaMedicaDbContext>
    {
        public eAgendaMedicaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            builder.UseSqlServer(@"Data Source=(LOCALDB)\MSSQLLOCALDB;Initial Catalog=eAgendaMedicaOrm;Integrated Security=True");

            return new eAgendaMedicaDbContext(builder.Options);
        }
    }
}
