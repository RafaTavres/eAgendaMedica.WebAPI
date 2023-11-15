using eAgendaMedica.Dominio.ModuloMedico;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAgendaMedica.Dominio.ModuloAtividade;

namespace eAgendaMedica.Infra.Orm.ModuloAtividade
{
    public class MapeadorAividade : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("TBAtividade");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.DataRealizacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.HoraInicio).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.HoraTermino).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Finalizada).HasColumnType("bit").IsRequired();
        }
    }
}
